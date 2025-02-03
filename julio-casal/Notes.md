dotnet new sln -n GameStore
dotnet new web -n GameStore.Api
dotnet sln GameStore.sln add GameStore.Api/GameStore.Api.csproj



## Notes
---

### 1. **Finding the Application's Running Location**

To find where your application is running, go to the `launchSettings.json` file and check in the profiles section.

---

### 2. **Preventing Automatic Browser Launch**

If you don't want your application to open in the browser, go to `launchSettings.json` and set `"launchBrowser"` as `false`.

---

### 3. **DTO (Data Transfer Object)**

DTO is a design pattern used to transfer data between different layers of an application (e.g., between a controller and a service or between a client and a server). DTOs help structure and optimize data exchange, ensuring that only relevant data is transferred.

#### 🔹 **Why Use DTOs?**
1. **Encapsulation** – Prevents exposing internal domain models.
2. **Performance** – Reduces the amount of transferred data by excluding unnecessary fields.
3. **Security** – Hides sensitive data from being exposed.
4. **Decoupling** – Separates the API contract from the database or business logic.

---

### 4. **Records in C#**

Records are immutable reference types in C# that provide value-based equality instead of reference equality. They are ideal for data transfer objects (DTOs) and read-only models.

#### **Advantages:**
- ✅ **Immutable by default** – Prevents accidental modifications.
- ✅ **Value-based equality** – Two records with the same values are considered equal.
- ✅ **Concise syntax** – Less boilerplate compared to classes.
- ✅ **Built-in ToString()** – Generates a readable string automatically.
- ✅ **Supports inheritance** – Unlike structs, records can inherit properties.

#### Example:
```csharp
public record class GameDto(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);
```

---

### 5. **List<T> in .NET**

A `List<T>` in .NET is a generic collection that stores elements dynamically (resizable array). It is part of `System.Collections.Generic` and supports various operations like adding, removing, and searching elements.

#### **Advantages:**
- ✅ **Dynamic size** – Unlike arrays, lists grow/shrink as needed.
- ✅ **Strongly typed** – Ensures type safety using generics (`List<T>`).
- ✅ **Built-in methods** – Supports sorting, filtering, searching, etc.
- ✅ **Performance** – Fast access (O(1)) and optimized insertion/removal (O(n)).

#### Example:
```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
numbers.Remove(2);
Console.WriteLine(numbers.Contains(3)); // Output: True
```

---

### 6. **Extension Methods**

Extension Methods allow adding new methods to existing types without modifying their source code. They enhance existing types by adding methods, improving readability and encapsulation.

#### **Advantages:**
- ✅ **Non-intrusive** – Doesn't modify the original class.
- ✅ **Improves readability** – Used like built-in methods.
- ✅ **Encapsulation** – Keeps utility methods organized.
- ✅ **Works with interfaces** – Can extend functionality without altering implementations.

#### Example:
```csharp
public static class StringExtensions
{
    public static string ToUpperFirstLetter(this string input)
    {
        return string.IsNullOrEmpty(input) ? input : char.ToUpper(input[0]) + input.Substring(1);
    }
}

string text = "hello";
Console.WriteLine(text.ToUpperFirstLetter()); // Output: "Hello"
```

---

### 7. **Data Validation in DTOs Using Annotations**

**Data Annotations** in .NET are used to enforce validation rules on DTO properties, ensuring the data meets required standards before processing.

### Common Validation Annotations:
- **[Required]**: Ensures a property is not null or empty.
- **[StringLength]**: Limits the length of a string.
- **[Range]**: Specifies a valid range for numeric types or dates.
- **[EmailAddress]**: Validates an email format.
- **[RegularExpression]**: Ensures a string matches a regex pattern.
- **[Compare]**: Compares two properties (e.g., password confirmation).
- **[CreditCard]**: Validates a credit card number format.

### Example: DTO with Validation

```csharp
public record class GameDto
{
    [Required] public string Name { get; init; }
    [StringLength(100, MinimumLength = 3)] public string Genre { get; init; }
    [Range(0.01, 1000.00)] public decimal Price { get; init; }
    [Required] public DateOnly ReleaseDate { get; init; }
}
```


### Advantages:
- **Simple and Quick**: Easy to implement and maintain.
- **Automatic**: Validation happens automatically during model binding.
- **Custom Messages**: Customize error messages for better user feedback.

In summary, Data Annotations simplify and automate validation in .NET, ensuring data integrity in DTOs.

---
### 8. **NuGet in .NET**

**NuGet** is the package manager for .NET, allowing developers to easily share and use libraries and tools. It helps manage dependencies, versions, and updates within .NET projects.

### Key Features:
- **Package**: A bundle of compiled code (DLLs), metadata, and dependencies.
- **NuGet Repository**: A storage location for packages (e.g., nuget.org).
- **NuGet Client**: Tools like Visual Studio, `dotnet` CLI, or `nuget` CLI to interact with repositories.

### Common Commands:
- **Install a Package**: `dotnet add package <PackageName>`
- **Update a Package**: `dotnet add package <PackageName> --version <VersionNumber>`
- **Restore Packages**: `dotnet restore`
- **Publish a Package**: `nuget push <PackageFile>`

### Advantages:
- Simplifies managing libraries.
- Automates dependency management and versioning.
- Provides access to a vast library of open-source packages.

In short, NuGet is essential for managing dependencies and libraries in .NET applications.

---

### 9. ***Endpoint Filters in .NET**

**Definition:**  
An **endpoint filter** is a mechanism used to validate and manipulate route handler parameters before they are passed into the handler logic. This allows common validation or transformation logic to be applied to parameters across multiple route handlers.

### Purpose of Endpoint Filters:
- **Validate parameters**: Ensure parameters meet necessary conditions before the handler executes.
- **Transform input data**: Ensure input data is in the correct format.
- **Centralized error handling**: Handle errors in a centralized manner, improving route handler readability.
- **Enforce common logic**: Apply business rules (e.g., ensuring an `id` parameter is positive or a date is in the future) across multiple endpoints.

### How It Works:
- **Invocation**: Filters are invoked before or after the route handler executes.
- **Filter application**: Filters can be applied globally, at the route level, or to specific handlers.
- **Parameter inspection**: Filters inspect route parameters, perform validation, and can short-circuit the request if validation fails.

### Key Benefits:
- Centralizes validation and transformation logic.
- Reduces redundancy and enhances maintainability.
- Helps enforce common rules consistently across endpoints.
- Improves readability and modularity by separating validation from the core business logic.

### Example Use Case:
- Validating that an `id` parameter is positive before executing the handler.

---

### **📌 Brief Notes on Database Generation in EF Core**  

#### **1️⃣ Code-First Approach (Recommended)**
- Define **C# entity models** and `DbContext`.  
- Create a migration:  
  ```bash
  dotnet ef migrations add InitialCreate
  ```
- Apply migration to generate the database:  
  ```bash
  dotnet ef database update
  ```

#### **2️⃣ Auto-Migrate on App Startup**
- Use `dbContext.Database.Migrate()` to apply migrations automatically.  
- Add this to `Program.cs`:  
  ```csharp
  app.MigrateDb();
  ```

#### **3️⃣ Database-First Approach**
- Generate models from an existing database:  
  ```bash
  dotnet ef dbcontext scaffold "<connection_string>" Microsoft.EntityFrameworkCore.SqlServer -o Models
  ```

#### **4️⃣ Checking Applied Migrations**
```bash
dotnet ef migrations list
```

✅ **Code-First** is preferred for new projects.  
✅ **Database-First** is useful when working with an existing DB.  
✅ **Use `MigrateDb()`** for automatic updates at runtime.

---



## Packages

dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.1

### **📌 Entity Framework Core Design (`Microsoft.EntityFrameworkCore.Design`)**  

#### **🔹 Definition:**  
The `Microsoft.EntityFrameworkCore.Design` package is required for **scaffolding**, **migrations**, and **design-time EF Core commands** using the `dotnet ef` CLI.  

#### **✅ Why Use It?**  
- Enables **code generation** for migrations.  
- Required for **`dotnet ef` commands**.  
- Helps with **reverse engineering databases** into EF Core models.  

#### **🚀 Installation:**  
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.1
dotnet restore
```

#### **⚡ Common Commands:**  
1️⃣ **Create a migration:**  
   ```bash
   dotnet ef migrations add InitialCreate
   ```  
2️⃣ **Apply migrations (update database):**  
   ```bash
   dotnet ef database update
   ```  
3️⃣ **List installed packages:**  
   ```bash
   dotnet list package
   ```

#### **💡 Notes:**  
- Works with **Entity Framework Core 9+** (ensure .NET 8+ is installed).  
- Used mainly in **development**, not required at runtime.  
- Helps in **maintaining database schema** changes over time.  

---

### **🔹 Notes on Dependency Injection (DI) in .NET**

#### **1️⃣ What is Dependency Injection (DI)?**
- **Dependency Injection (DI)** is a design pattern that deals with how objects or components are given their dependencies rather than creating them internally.
- DI allows for **loose coupling** between classes and their dependencies, making the application easier to test, maintain, and scale.

#### **2️⃣ Types of DI**
- **Constructor Injection**: Dependencies are passed into the constructor of a class.
- **Property Injection**: Dependencies are set through properties after the object is created.
- **Method Injection**: Dependencies are passed into a method.

#### **3️⃣ DI Lifetimes in .NET**
In .NET, services are registered with different lifetimes:
- **Transient**: A new instance of the service is created each time it is requested.
  - Use when services are lightweight and stateless.
- **Scoped**: A new instance is created once per **request** (or per scope).
  - Ideal for services that should live within the scope of a single request, like database contexts.
- **Singleton**: A single instance is created and shared across the entire application.
  - Use when you have shared, expensive resources or services that should be reused.

#### **4️⃣ Registering Services in DI Container**
Services are registered in the DI container in the `Program.cs` or `Startup.cs` file using extension methods:
- **AddTransient**: Register transient services.
- **AddScoped**: Register scoped services.
- **AddSingleton**: Register singleton services.

**Example**:
```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddTransient<IMyService, MyService>();
            services.AddScoped<IMyScopedService, MyScopedService>();
            services.AddSingleton<IMySingletonService, MySingletonService>();
        });
```

#### **5️⃣ How DI Works in .NET**
- **When the application starts**, the DI container creates an instance of the services that have been registered.
- **When a class requires a dependency**, the container resolves the service and injects it, either via constructor injection or method/property injection.
  
**Example of Constructor Injection**:
```csharp
public class MyService
{
    private readonly IMyDependency _myDependency;

    public MyService(IMyDependency myDependency)
    {
        _myDependency = myDependency;
    }
}
```

#### **6️⃣ Benefits of DI**
- **Loose Coupling**: Classes don't need to know how their dependencies are created. They just depend on abstractions.
- **Testability**: DI makes unit testing easier by allowing mocks or stubs to be injected instead of actual implementations.
- **Separation of Concerns**: Each class focuses only on its own logic, while DI handles the responsibility of service creation.
- **Reusability and Flexibility**: The same service can be used across different parts of the application, and you can switch implementations without changing the class using the service.

#### **7️⃣ Common DI Containers in .NET**
- **Built-in .NET DI Container**: The default DI container available in ASP.NET Core, used to register and resolve dependencies.
- **Third-party DI Containers**: Libraries like **Autofac**, **Ninject**, and **StructureMap** offer more features and flexibility compared to the default container.

#### **8️⃣ DI in ASP.NET Core**
- In **ASP.NET Core**, DI is integrated into the framework and the DI container is set up in the `ConfigureServices` method of the `Startup.cs` or `Program.cs` file.
  
**Example in ASP.NET Core**:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IMyService, MyService>();
    services.AddScoped<IMyScopedService, MyScopedService>();
    services.AddSingleton<IMySingletonService, MySingletonService>();
}
```

#### **9️⃣ DI with Middleware**
In ASP.NET Core, **middleware** components can use DI to resolve services. This is particularly useful when you need access to application services like logging, configuration, or custom services within the pipeline.

**Example**:
```csharp
public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IMyService myService)
    {
        await myService.DoSomethingAsync();
        await _next(context);
    }
}
```

---

#### **🔑 Summary**
- **Dependency Injection (DI)** is a design pattern used to inject dependencies into a class rather than having the class create them itself.
- **DI Lifetimes**: Transient, Scoped, and Singleton are the primary lifetimes in .NET.
- **Benefits**: Loose coupling, better testability, separation of concerns, and flexibility.
- **DI in ASP.NET Core**: Built-in DI container to register and resolve services efficiently.

Would you like more details on **service lifetimes** or **DI in ASP.NET Core**? 🚀

---



## Tools

dotnet tool install --global dotnet-ef --version 9.0.1


### Database Commands

seeding genre data: dotnet ef migrations add SeedGenres --output-dir Data/Migrations
Build started...