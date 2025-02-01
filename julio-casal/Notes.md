dotnet new sln -n GameStore
dotnet new web -n GameStore.Api
dotnet sln GameStore.sln add GameStore.Api/GameStore.Api.csproj



1. To find where your application is running, go to the profile launchSettings.json and check in the profiles. 

2. If you don't want your application to open in browser go to launchSettings.json and set "launchBrowser" as false.

3. DTO (Data Transfer Object) is a design pattern used to transfer data between different layers of an application, such as between a controller and a service or between a client and a server. DTOs help in structuring and optimizing data exchange, ensuring that only relevant data is sent or received. 

    🔹 Why Use DTOs?
    1. Encapsulation – Prevents exposing internal domain models.
    2. Performance – Reduces the amount of transferred data by excluding unnecessary fields.
    3. Security – Hides sensitive data from being exposed.
    4. Decoupling – Separates the API contract from the database or business logic.
   
 4. Records are immutable reference types in C# that provide value-based equality instead of reference equality. They are ideal for data transfer objects (DTOs) and read-only models.

    Advantages:
    ✅ Immutable by default – Prevents accidental modifications.
    ✅ Value-based equality – Two records with the same values are considered equal.
    ✅ Concise syntax – Less boilerplate compared to classes.
    ✅ Built-in ToString() – Generates a readable string automatically.
    ✅ Supports inheritance – Unlike structs, records can inherit properties. 

5. A List<T> in .NET is a generic collection that stores elements dynamically (resizable array). It is part of System.Collections.Generic and supports various operations like adding, removing, and searching elements.

    Advantages:
    ✅ Dynamic size – Unlike arrays, lists grow/shrink as needed.
    ✅ Strongly typed – Ensures type safety using generics (List<T>).
    ✅ Built-in methods – Supports sorting, filtering, searching, etc.
    ✅ Performance – Fast access (O(1)) and optimized insertion/removal (O(n)).