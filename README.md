# Community Garden Management System

A comprehensive web application for managing community garden plots, members, and harvest records built with ASP.NET Core MVC.

## 📋 Project Overview

The Community Garden Management System (CGMS) is a full-featured web application that helps community gardens manage their plots, track member registrations, and monitor harvest activities. The system provides an intuitive interface for administrators and gardeners to efficiently manage all aspects of community gardening operations.

## ✨ Main Features

- **Garden Plot Management**: Complete CRUD operations for managing garden plots with details like size, soil type, water access, and rental fees
- **Member Registration**: Track gardeners with their experience levels, interests, and membership tiers
- **Harvest Tracking**: Record harvest data including crop types, quantities, quality ratings, and organic certification
- **Responsive Design**: Modern, mobile-friendly interface using Bootstrap 5
- **Data Validation**: Comprehensive server-side and client-side validation for all forms
- **Dashboard**: Quick overview of key metrics and easy navigation to main features
- **Filtering & Search**: Filter members by membership tier and plots by availability status

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core 10.0** - Web framework
- **Entity Framework Core 10.0** - ORM for database operations
- **SQL Server (LocalDB)** - Database engine
- **C# 12** - Programming language

### Frontend
- **Razor Views** - Server-side rendering
- **Bootstrap 5** - CSS framework for responsive design
- **jQuery** - JavaScript library
- **jQuery Validation** - Client-side form validation

### Architecture & Patterns
- **MVC (Model-View-Controller)** - Application architecture
- **Service Layer Pattern** - Business logic separation
- **Dependency Injection** - Built-in DI container
- **Repository Pattern** - Data access abstraction
- **SOLID Principles** - Clean code architecture

## 📊 Database Schema

### Entity Models

**GardenPlot**
- PlotIdentifier (Primary Key)
- PlotDesignation (Unique code: e.g., A001)
- SquareMeters (5-100 sq m)
- SoilType
- WaterAccessAvailable
- IsOccupied
- YearlyRentalFee
- LastMaintenanceDate
- AssignedGardenerId (Foreign Key)

**GardenMember**
- MemberId (Primary Key)
- FullLegalName
- EmailContact (Unique)
- MembershipTier (Basic/Standard/Premium)
- RegistrationDate
- YearsOfExperience
- PreferOrganicOnly
- GardeningInterests

**HarvestRecord**
- RecordId (Primary Key)
- PlotIdentifier (Foreign Key)
- MemberId (Foreign Key)
- CropName
- QuantityKilograms
- CollectionDate
- QualityScore (1-5)
- HarvestNotes
- IsOrganicCertified

## 🚀 Setup Instructions

### Prerequisites

- .NET 10.0 SDK or higher ([Download here](https://dotnet.microsoft.com/download))
- SQL Server LocalDB (included with Visual Studio) or SQL Server Express
- A code editor (Visual Studio 2022, VS Code, or JetBrains Rider)

### Installation Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/BatakanDalkalach/WebApplication1.git
   cd WebApplication1
   ```

2. **Restore NuGet packages**
   ```bash
   cd WebApplication1
   dotnet restore
   ```

3. **Update database connection string (if needed)**
   
   Open `appsettings.json` and modify the connection string if you're not using LocalDB:
   ```json
   "ConnectionStrings": {
     "GardenDbConnection": "Server=(localdb)\\mssqllocaldb;Database=CommunityGardenDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   
   Open your browser and navigate to:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

## 🔧 Environment Variables & Configuration

### Connection Strings

The application uses the following connection string configuration in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "GardenDbConnection": "Server=(localdb)\\mssqllocaldb;Database=CommunityGardenDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### For Different Environments

**LocalDB (Default)** - Already configured, no changes needed

**SQL Server Express**
```json
"GardenDbConnection": "Server=.\\SQLEXPRESS;Database=CommunityGardenDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

**SQL Server with credentials**
```json
"GardenDbConnection": "Server=your-server;Database=CommunityGardenDb;User Id=your-username;Password=your-password;MultipleActiveResultSets=true"
```

### Initial Data

The application includes seed data for testing:
- 2 Garden Members (Sarah Johnson, Michael Chen)
- 3 Garden Plots (A001, A002, B001)
- 2 Harvest Records

## 📱 Application Structure

```
WebApplication1/
├── Controllers/
│   ├── HomeController.cs          # Landing page and dashboard
│   ├── PlotsController.cs         # Garden plot CRUD operations
│   └── MembersController.cs       # Member management
├── Models/
│   ├── GardenPlot.cs             # Plot entity with validation
│   ├── GardenMember.cs           # Member entity with validation
│   ├── HarvestRecord.cs          # Harvest tracking entity
│   └── ErrorViewModel.cs         # Error handling model
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml          # Dashboard
│   │   └── Privacy.cshtml        # Privacy policy
│   ├── Plots/
│   │   ├── Index.cshtml          # Plot listing
│   │   ├── ViewDetails.cshtml    # Plot details
│   │   ├── AddNew.cshtml         # Create plot
│   │   ├── Modify.cshtml         # Edit plot
│   │   └── Remove.cshtml         # Delete confirmation
│   ├── Members/
│   │   ├── Index.cshtml          # Member directory
│   │   ├── ViewProfile.cshtml    # Member profile
│   │   └── Register.cshtml       # New member registration
│   └── Shared/
│       ├── _Layout.cshtml        # Main layout template
│       ├── _ValidationScriptsPartial.cshtml
│       └── Error.cshtml
├── DatabaseContext/
│   └── CommunityGardenDatabase.cs # EF Core DbContext
├── Services/
│   ├── PlotManagementService.cs   # Plot business logic
│   └── MemberManagementService.cs # Member business logic
├── wwwroot/                       # Static files (CSS, JS, images)
├── Program.cs                     # Application entry point
└── appsettings.json              # Configuration

```

## 🎯 Key Features Implementation

### CRUD Operations
Complete Create, Read, Update, Delete operations implemented for Garden Plots with:
- Form validation
- Confirmation dialogs
- Success/error messages
- Responsive layouts

### Validation
- **Server-side**: Data Annotations on model properties
- **Client-side**: jQuery Unobtrusive Validation
- Custom validation messages
- Visual feedback for form errors

### Dependency Injection
All services registered in `Program.cs`:
```csharp
builder.Services.AddDbContext<CommunityGardenDatabase>();
builder.Services.AddScoped<PlotManagementService>();
builder.Services.AddScoped<MemberManagementService>();
```

### Responsive Design
- Mobile-first approach
- Bootstrap grid system
- Responsive navigation
- Adaptive card layouts

## 🧪 Testing the Application

### Manual Testing Checklist

1. **Plot Management**
   - Create a new plot with valid data
   - Edit an existing plot
   - View plot details
   - Delete a plot
   - Verify validation works (try invalid plot codes)

2. **Member Management**
   - Register a new member
   - View member profile with their plots
   - Filter members by tier
   - Verify email uniqueness

3. **Navigation**
   - All menu links work correctly
   - Breadcrumbs and back buttons function
   - Responsive menu on mobile devices

## 🐛 Troubleshooting

### Database Connection Issues
- Ensure SQL Server LocalDB is installed
- Try restarting SQL Server LocalDB: `sqllocaldb stop mssqllocaldb` then `sqllocaldb start mssqllocaldb`
- Check connection string in appsettings.json

### Migration Issues
- Delete Migrations folder and recreate: `dotnet ef migrations add InitialCreate`
- Ensure database is not in use by other applications
- Check Entity Framework tools are installed: `dotnet tool install --global dotnet-ef`

### Build Errors
- Clean and rebuild: `dotnet clean` then `dotnet build`
- Restore packages: `dotnet restore`
- Check .NET SDK version: `dotnet --version`

## 📄 License

This project is created for educational purposes.

## 👥 Contributors

- Initial development: ASP.NET Core MVC project implementation

## 📞 Support

For issues or questions, please open an issue on the GitHub repository.
