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

1. `OnInitialized`
2. `OnInitializedAsync`
3. `OnParametersSet`,
4. `OnParametersSetAsync`
5. `OnAfterRender(firstRender)`, 
6. `OnAfterRenderAsync(firstRender)`





