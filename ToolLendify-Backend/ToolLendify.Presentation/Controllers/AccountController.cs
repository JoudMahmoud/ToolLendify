using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToolLendify.Application.DTOs;
using ToolLendify.Application.Services;
using ToolLendify.Domain.Entities;

namespace ToolLendify.Presentation.Controllers
{
	public class AccountController:ControllerBase
	{
		#region Member Data
		private readonly UserManager<User> _userManager;
		private readonly RoleService _roleService;
		private readonly IConfiguration _configuration;
		#endregion

		#region Constructor
		public AccountController(UserManager<User> userManager, RoleService roleService, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleService = roleService;
			_configuration = configuration;
		}
		#endregion

		#region Registration 
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterUserDto registerUser)
		{
			if(ModelState.IsValid)
			{
				var user = new User
				{
					UserName = registerUser.UserName,
					Email = registerUser.Email
				};
				IdentityResult result = await _userManager.CreateAsync(user, registerUser.Password);
				if (result.Succeeded)
				{
					await _roleService.AddUserToRoleAsync(user, "Client");
					return Ok();
				}
				else
				{
					return BadRequest(result.Errors);
				}
			}
			return BadRequest(ModelState);
		}
		#endregion

		#region Loggin
		[HttpPost("login")]
		public async Task<IActionResult> Loggin(LogginUserDto logginUser)
		{
			if (ModelState.IsValid)
			{
				//cheak by name 
				User? user = await _userManager.FindByNameAsync(logginUser.UserName);
				if (user != null)
				{
					bool found = await _userManager.CheckPasswordAsync(user, logginUser.Password);
					if (found)
					{
						var claims = new List<Claim>
						{
						new Claim(ClaimTypes.NameIdentifier, user.UserName),
						new Claim(ClaimTypes.NameIdentifier, user.Id),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
							};
						//get role
						var roles = await _userManager.GetRolesAsync(user);
						foreach (var itemRole in roles)
						{
							claims.Add(new Claim(ClaimTypes.Role, itemRole));
						}

						SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"])); 
						SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
						//create Token 
						JwtSecurityToken myToken = new JwtSecurityToken(
							issuer: _configuration["JWT:ValidIssuer"],
							audience: _configuration["JWT:ValidAudience"],
							claims: claims,
							expires: DateTime.Now.AddHours(1),
							signingCredentials: signingCred
							);

						return Ok(new
						{
							token = new JwtSecurityTokenHandler().WriteToken(myToken),
							expiration = myToken.ValidTo
						});
					}
					return Unauthorized();
				}
				return Unauthorized();
			}
			return Unauthorized();
		}


		#endregion
	}
}
