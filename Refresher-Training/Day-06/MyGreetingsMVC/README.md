# MyGreetingsMVC

A simple ASP.NET Core MVC application that demonstrates the Model-View-Controller (MVC) architectural pattern. The application accepts a user's name through a web form and displays a personalized greeting on a separate page.

## 🚀 Features

* Built using ASP.NET Core MVC
* Demonstrates the MVC architectural pattern
* Accepts user input through a web form
* Displays a personalized greeting
* Uses Model Binding
* Handles HTTP GET and POST requests
* Uses Razor Views and Tag Helpers

## 🛠️ Tech Stack

* ASP.NET Core MVC
* C#
* .NET
* Razor Views
* HTML5

## 📁 Project Structure

```text
MyGreetingsMVC
│
├── Controllers
│   └── HomeController.cs
│
├── Models
│   └── GreetingModel.cs
│
├── Views
│   ├── Home
│   │   ├── Index.cshtml
│   │   └── Greeting.cshtml
│   ├── Shared
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── wwwroot
│
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── MyGreetingsMVC.csproj
└── README.md
```

## 🔄 Application Workflow

1. Open the application.
2. Enter your name in the input field.
3. Click the Submit button.
4. The form sends a POST request to the controller.
5. ASP.NET Core Model Binding maps the input to `GreetingModel`.
6. The controller passes the model to the Greeting view.
7. The Greeting view displays a personalized greeting.

## 🏗️ MVC Request Flow

```text
User
   │
   ▼
Index View
   │
   ▼
HomeController
   │
   ▼
GreetingModel
   │
   ▼
Greeting View
   │
   ▼
Response
```

## 📚 Concepts Covered

* ASP.NET Core MVC
* MVC Architecture
* Controllers
* Models
* Views
* Razor Syntax
* Model Binding
* Routing
* HTTP GET & POST
* Tag Helpers
* Passing Data from Controller to View

## ▶️ Getting Started

### Clone the Repository

```bash
git clone https://github.com/<your-username>/MyGreetingsMVC.git
```

### Navigate to the Project

```bash
cd MyGreetingsMVC
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Project

```bash
dotnet build
```

### Run the Application

```bash
dotnet run
```

Open the localhost URL displayed in the terminal.

## 📸 Application Output

### Home Page

* Enter your name.
* Click Submit.

### Greeting Page

```text
Hello, Sandesh!
```

## 🔮 Future Enhancements

* Input Validation
* Bootstrap Styling
* Greeting History
* SQL Server Integration
* Dapper Integration
* Entity Framework Core
* Dependency Injection
* Logging & Exception Handling

