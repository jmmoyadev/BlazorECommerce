# Blazor E-Commerce Demo
 Blazor Bootcamp - .NET 6 E-Commerce Web App (WASM and Server)

## One way data binding
```csharp
<h3>Product</h3>
<ul>
    <li>Id: @_product.Id</li>
    <li>Name: @_product.Name</li>
    <li>Is Active: @_product.IsActive</li>
</ul>

@code {
    Product _product = new()
        {
            Id = 1,
            Name = "Rose Candle",
            IsActive = true
        };
}
```

## Two ways data binding

```csharp
<h3>Product</h3>
<ul>
    <li>Id: @_product.Id</li>
    <li>Name: @_product.Name</li>
    <li>Is Active: @_product.IsActive</li>
    <li>Price: @_product.Price.ToString("C2")</li>
    <li>Price <input type="number" placeholder="0,00" min="0.00" max="100" step=".05" 
                     @bind-value="_product.Price" @bind-value:event="oninput /></li>
    <li>Price <input type="number" placeholder="0,00" min="0.00" max="100" step=".05" 
                     @bind="_product.Price" @bind:event="oninput" /></li>
</ul>

@code {
    Product _product = new()
        {
            Id = 1,
            Name = "Rose Candle",
            Price = 9.50m,
            IsActive = true
        };
}
```` 

## Components Lifecycle

1. `OnInitialized` and `OnInitializedAsync`
    - It is executed when the component is completely loaded.
2. `OnParametersSet` and `OnParametersSetAsync`
    - When a component is first initialized, and each time new or updated parameters are received from parent in the render tree.
3. `OnAfterRender(bool firstRender)` and  `OnAfterRenderAsync(bool firstRender)`
    - Called after each render of the component.
4. `ShouldRender()`
    - This method returns a Boolean value, if true, it refreshes the UI, otherwise changes are not sent to UI.
5. `StateHasChanged()`
    - This method notifise the component that its state has changed.
    

## Database

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

Running database migrations is easy. Ensure you add the following flags to your command (values assume you are executing from repository root)

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/Web`
* `--output-dir Data/Migrations`

### Add Migration
`
dotnet ef migrations add "SampleMigration" --project src\BlazorECommerceWeb_Infrastructure --startup-project src\BlazorECommerceWeb_Server --output-dir Data\Migrations
`

 ### Update database
`
dotnet ef database update "SampleMigration" --project src\BlazorECommerceWeb_Infrastructure --startup-project src\BlazorECommerceWeb_Server
`

### Remove Migration
`
dotnet ef migrations remove --project src\BlazorECommerceWeb_Infrastructure --startup-project src\BlazorECommerceWeb_Server --context ApplicationDbContex
`

Review the [Entity Framework Core tools reference - .NET Core CLI | Microsoft Docs](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) to learn more.



