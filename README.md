# ToolLendify

ToolLendify is a web application designed to facilitate the rental of maintenance tools. It connects users who need tools with nearby owners, allowing for easy search and rental based on location. The application ensures a seamless and secure rental experience with features like user authentication, real-time notifications, and integrated payment processing.

## Features

- **User Authentication:** Registration, Login, JWT-based sessions.
- **Tool Listing and Search:** Add, update, delete tools, and search by keyword and category.
- **Location-Based Tool Search:** Find tools based on your location using Google Maps.
- **Tool Rental Management:** Request rentals, approve/reject requests, track rental status.
- **Payment Processing:** Secure transactions through Paymob.
- **Real-Time Notifications:** Instant updates for rental requests and status changes via Firebase Cloud Messaging (FCM).

## Tech Stack

- **Frontend:** [Angular](https://angular.io/)
- **Backend:** [.NET Core (C#)](https://docs.microsoft.com/en-us/dotnet/core/)
- **Database:** [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
- **Location Services:** [Google Maps API](https://developers.google.com/maps)
- **Authentication:** [ASP.NET Core Identity with JWT](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- **Payment:** [Paymob](https://www.paymob.com/)
- **Notifications:** [Firebase Cloud Messaging (FCM)](https://firebase.google.com/docs/cloud-messaging)

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [Angular CLI](https://angular.io/cli)
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Firebase Account](https://firebase.google.com/)
- [Paymob Account](https://www.paymob.com/)

### Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/JoudMahmoud/ToolLendify.git
    cd toollendify
    ```

2. **Frontend Setup:**
    ```bash
    cd toolLendify
    npm install
    ```

3. **Backend Setup:**
    ```bash
    cd ToolLendify
    dotnet restore
    ```

4. **Database Setup:**
    - Create a new SQL Server database.
    - Update the connection string in the `appsettings.json` file in the backend project.

5. **Firebase Setup:**
    - Create a Firebase project and enable Firebase Cloud Messaging.
    - Download the `google-services.json` file and place it in the `src` directory of your Angular project.
    - Obtain the Server Key from Firebase and update the backend project with the configuration.

6. **Paymob Setup:**
    - Create a Paymob account and obtain the API keys.
    - Update the backend project with the Paymob configuration in `appsettings.json`.

### Running the Application

1. **Start the Backend:**
    ```bash
    cd backend
    dotnet run
    ```

2. **Start the Frontend:**
    ```bash
    cd frontend
    ng serve
    ```

3. **Access the Application:**
    Open your browser and navigate to `http://localhost:4200`.

## Usage

- **Register/Login:** Create a new account or log in with existing credentials.
- **List Tools:** Tool owners can list their tools for rent.
- **Search Tools:** Renters can search for tools by keyword, category, and location.
- **Request Rentals:** Renters can request to rent available tools.
- **Manage Rentals:** Tool owners can approve or reject rental requests.
- **Payments:** Securely handle payments through Paymob.
- **Notifications:** Receive real-time notifications for rental requests and updates.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes or improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please contact [yourname@example.com].

## Acknowledgements

- [Angular](https://angular.io/) for the frontend framework.
- [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) for the backend framework.
- [Google Maps API](https://developers.google.com/maps) for location services.
- [Firebase Cloud Messaging](https://firebase.google.com/docs/cloud-messaging) for real-time notifications.
- [Paymob](https://www.paymob.com/) for payment processing.
