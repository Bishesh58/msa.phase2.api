using Microsoft.EntityFrameworkCore;
using msa.phase2.api.Models;
using msa.phase2.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//register dbContext Product
builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("Products"));


//service injection
//builder.Services.AddScoped <IProductService Product >();

//add fakestore api client
builder.Services.AddHttpClient("FakeStore", configureClient: client =>
{
    client.BaseAddress = new Uri("https://fakestoreapi.com");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

//helper method call to add data into db
AddProductData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//helper method to add some data into inMemory db

static void AddProductData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<ProductContext>();

    var product1 = new Product { Id = 1, Description = "Men's T-shirt", ImageUrl = "men_tshirt1.png", Price = 120, Title = "T-shirt 1" };
    var product2 = new Product { Id = 2, Description = "Men's T-shirt", ImageUrl = "men_tshirt2.png", Price = 20, Title = "T-shirt 2" };
    var product3 = new Product { Id = 3, Description = "Men's T-shirt", ImageUrl = "men_tshirt3.png", Price = 130, Title = "T-shirt 3" };
    var product4 = new Product { Id = 4, Description = "Men's T-shirt", ImageUrl = "men_tshirt4.png", Price = 150, Title = "T-shirt 4" };
    var product5 = new Product { Id = 5, Description = "Men's T-shirt", ImageUrl = "men_tshirt5.png", Price = 110, Title = "T-shirt 5" };

    db.Products.Add(product1);
    db.Products.Add(product2);
    db.Products.Add(product3);
    db.Products.Add(product4);
    db.Products.Add(product5);

    db.SaveChanges();

}
