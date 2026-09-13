# 🍽️ FOOD X — Food Delivery Based Restaurant Management System

**CSC 2210 — Object Oriented Programming 2**
American International University-Bangladesh (AIUB)

A Windows Forms desktop application that connects customers with restaurants through one platform. Built with C#, ADO.NET and raw SQL against SQL Server.

---

## Team

| Name | Student ID | Module |
|---|---|---|
| Rafsan Azad | 25-60783-1 | Core System & Super Admin |
| MD. Habibullah Tuhin | 23-50617-1 | Restaurant Admin & Food |
| Sabbir Hasan Tanim | 23-50423-1 | Customer Module |
| Shah MD. Zunaed | 24-57769-2 | Order & Payment Module |

---

## Technology

| Layer | Technology |
|---|---|
| UI | Windows Forms (.NET Framework 4.7.2) |
| Language | C# |
| Data access | ADO.NET (`System.Data.SqlClient`) — raw parameterised SQL |
| Database | Microsoft SQL Server |
| IDE | Visual Studio 2022 |

No Entity Framework. No ASP.NET. No MVC framework. No third-party NuGet packages.

---

## Setup

### 1. Create the database

1. Open **SQL Server Management Studio**.
2. Open `FoodDeliverySystem/Database/RestaurantDB.sql`.
3. Press **F5**. This creates the `RestaurantDB` database, all 9 tables, the constraints, the indexes and the sample data.

### 2. Point the app at your server

Open `FoodDeliverySystem/App.config` and change **only** the `Data Source` value to your own SQL Server name (the one in the SSMS *Connect* dialog):

```xml
<add name="RestaurantDB"
     connectionString="Data Source=YOUR-SERVER-NAME;Initial Catalog=RestaurantDB;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

Common values: `ASUS`, `DESKTOP-1234\SQLEXPRESS`, `(localdb)\MSSQLLocalDB`.

### 3. Run

Open `FoodDeliverySystem.sln` in Visual Studio and press **F5**.

If the connection string is wrong, the login screen says so immediately instead of crashing later.

---

## Test accounts

| Role | Email | Password |
|---|---|---|
| Super Admin | `super@foodx.com` | `Super123` |
| Restaurant Admin | `rafsan@foodx.com` | `Admin123` |
| Restaurant Admin | `tuhin@foodx.com` | `Admin123` |
| Employee | `sabbir@foodx.com` | `Emp12345` |
| Customer | `ayesha@gmail.com` | `Cust1234` |

---

## Roles

### Super Admin
Manages restaurant admins and all users · manages food categories · views platform reports (sales per restaurant, best sellers, daily sales, payments) · monitors and deletes orders.

### Restaurant Admin
Manages the restaurant profile · full CRUD on the restaurant's food · manages stock with low-stock alerts · hires and manages employees · manages the restaurant's orders · views the restaurant's reports.

### Employee
Views the orders for the restaurant they work at · opens the kitchen ticket · updates order status · records cash received. No CRUD powers.

### Customer
Registers and logs in · browses food · searches · filters by category, price range and availability · adds to cart · checks out · receives a printable invoice · views order history · cancels an order before it is cooked.

---

## Architecture

```
     Form (View)            ← buttons, grids, validation
        │
        ▼
   Controller               ← business rules, permission checks
        │
        ▼
      Model                 ← the SQL lives here
        │
        ▼
  SqlDbDataAccess           ← the only class that opens a connection
        │
        ▼
   SQL Server
```

Every feature follows the same path:

```
Button Click → Event Handler → Controller Method → SQL Query
            → Database Operation → Return Data → Update UI
```

### Folders

```
FoodDeliverySystem/
├── Program.cs              entry point                  [PROTECTED]
├── App.config              connection string            [PROTECTED]
├── Database/
│   ├── SqlDbDataAccess.cs  connection class             [PROTECTED]
│   └── RestaurantDB.sql    schema + sample data         [PROTECTED]
├── Common/     Session.cs, Validator.cs, UiTheme.cs
├── Model/      9 entity classes + 9 data-access classes
├── Controller/ 10 controllers
├── View/       18 forms
└── Docs/       report, plan, guides, screenshots
```

---

## Database

Nine tables in 3NF.

```
Users ──┬──< Restaurants ──┬──< Employees
        │                  │
        │                  └──< Foods >── Categories
        │                         │
        ├──< Cart >───────────────┤
        │                         │
        └──< Orders ──┬──< OrderDetails >──┘
                      │
                      └──< Payments
```

| Table | Purpose |
|---|---|
| `Users` | Everyone in the system; `Role` decides which dashboard opens |
| `Restaurants` | One per Restaurant Admin |
| `Employees` | Job record; login lives in `Users` |
| `Categories` | Shared list controlled by the Super Admin |
| `Foods` | Menu items, owned by a restaurant and a category |
| `Cart` | Pre-checkout holding area |
| `Orders` | Order header |
| `OrderDetails` | One row per item in an order |
| `Payments` | Method, status and date, separate from the order |

**Order status workflow:** `Pending → Accepted → Preparing → Completed`, with `Cancelled` reachable from any of the first three.

---

## Documentation

| Document | Contents |
|---|---|
| [`Docs/MODIFICATION_PLAN.md`](Docs/MODIFICATION_PLAN.md) | Analysis of the original project, every change and why |
| [`Docs/VIVA_GUIDE.md`](Docs/VIVA_GUIDE.md) | Expected questions with answers, per module |
| [`Docs/GITHUB_GUIDE.md`](Docs/GITHUB_GUIDE.md) | Branches, commits, pull requests, merge conflicts |
| [`Docs/TEAM_GUIDE.md`](Docs/TEAM_GUIDE.md) | Who owns which files |
| [`Docs/TESTING_CHECKLIST.md`](Docs/TESTING_CHECKLIST.md) | Every case to test before the demo |
| `Docs/Restaurant_Management_System_Report.pdf` | The project report |

---

## Demo video

`<paste the link here>`

---

## Screenshots

Screenshots live in `Docs/Screenshots/`.
