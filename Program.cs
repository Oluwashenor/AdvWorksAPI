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


app.MapGet("/api/HelloAll", () => "Hello Every one");
app.MapGet("/api/HelloWorld", () => Results.Ok("Hello World"));
app.MapGet("/api/HelloPerson", (string name) => Results.Ok($"Hello {name}"));


app.MapGet("/api/product/{id:int}", (int id) =>
{
    var product = new ProductRepository().Get(id);
    if(product == null)
    {
        return Results.NotFound($"Product with Product Id {id} not found");
    }
    return Results.Ok(product);
});

app.MapGet("/api/product", () =>
{
    List<Product> products = new ProductRepository().Get();
    if (products == null)
        return Results.NotFound("No Products found");
    return Results.Ok();
});


app.Run();