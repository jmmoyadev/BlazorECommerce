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
