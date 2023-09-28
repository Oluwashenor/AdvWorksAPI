using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/HelloAll", () => "Hello Every one").WithTags("Simple");
app.MapGet("/api/HelloWorld", () => Results.Ok("Hello World")).WithTags("Simple");
app.MapGet("/api/HelloPerson", (string name) => Results.Ok($"Hello {name}")).WithTags("Simple");


app.MapGet("/api/product/{id:int}", (int id) =>
{
    var product = new ProductRepository().Get(id);
    if(product == null)
    {
        return Results.NotFound($"Product with Product Id {id} not found");
    }
    return Results.Ok(product);
}).WithTags("Products").Produces(200).Produces(404).Produces<Product>();

app.MapGet("/api/product", () =>
{
    List<Product> products = new ProductRepository().Get();
    if (products == null || products.Count == 0)
        return Results.NotFound("No Products found");
    return Results.Ok();
}).WithTags("Products").Produces(200).Produces(404).Produces<List<Product>>();

app.MapGet("/api/customer/{id:int}", (int id) =>
{
    var customer = new CustomerRepository().Get(id);
    if (customer == null)
    {
        return Results.NotFound($"Customer with Id {id} not found");
    }
    return Results.Ok(customer);
}).WithTags("Customers").Produces(200).Produces(404).Produces<Customer>();

app.MapGet("/api/customer", () =>
{
    List<Customer> customers = new CustomerRepository().Get();
    if (customers == null || customers.Count == 0)
        return Results.NotFound("No Customers found");
    return Results.Ok();
}).WithTags("Customers").Produces(200).Produces(404).Produces<List<Customer>>();


app.Run();