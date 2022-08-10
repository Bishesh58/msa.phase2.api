using Microsoft.EntityFrameworkCore;
using msa.phase2.api.Models;
using msa.phase2.api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//register dbContext Product
builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("Products"));


//service injection
builder.Services.AddScoped <IProductService, ProductServices >();

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

    var product1 = new Product { Id = 1, Description = "100% Polyester, Machine wash, 100% cationic polyester interlock, Machine Wash & Pre Shrunk for a Great Fit, Lightweight, roomy and highly breathable with moisture wicking fabric which helps to keep moisture away, Soft Lightweight Fabric with comfortable V-neck collar and a slimmer fit, delivers a sleek, more feminine silhouette and Added Comfort",
        ImageUrl = "men_tshirt1.png", Price = 120, Title = "Opna Women's Short Sleeve Moisture"};
    var product2 = new Product { Id = 2, Description = "95%Cotton,5%Spandex, Features: Casual, Short Sleeve, Letter Print,V-Neck,Fashion Tees, The fabric is soft and has some stretch., Occasion: Casual/Office/Beach/School/Home/Street. Season: Spring,Summer,Autumn,Winter.",
         ImageUrl = "men_tshirt2.png", Price = 22, Title = "DANVOUY Womens T Shirt Casual Cotton Short" };
    var product3 = new Product { Id = 3, Description = "95% RAYON 5% SPANDEX, Made in USA or Imported, Do Not Bleach, Lightweight fabric with great stretch for comfort, Ribbed on sleeves and neckline / Double stitching on bottom hem", ImageUrl = "men_tshirt3.png", Price = 130, Title = "MBJ Women's Solid Short Sleeve Boat Neck V " };
    var product4 = new Product { Id = 4, Description = "Lightweight perfet for trip or casual wear---Long sleeve with hooded, adjustable drawstring waist design. Button and zipper front closure raincoat, fully stripes Lined and The Raincoat has 2 side pockets are a good size to hold all kinds of things, it covers the hips, and the hood is generous but doesn't overdo it.Attached Cotton Lined Hood with Adjustable Drawstrings give it a real styled look.", ImageUrl = "men_tshirt4.png", Price = 150, Title = "Rain Jacket Women Windbreaker Striped Climbing Raincoats" };
    var product5 = new Product { Id = 5, Description = "100% POLYURETHANE(shell) 100% POLYESTER(lining) 75% POLYESTER 25% COTTON (SWEATER), Faux leather material for style and comfort / 2 pockets of front, 2-For-One Hooded denim style faux leather jacket, Button detail on waist / Detail stitching at sides, HAND WASH ONLY / DO NOT BLEACH / LINE DRY / DO NOT IRON", ImageUrl = "men_tshirt5.png", Price = 110, Title = "Lock and Love Women's Removable Hooded Faux Leather Moto Biker Jacket" };

    db.Products.Add(product1);
    db.Products.Add(product2);
    db.Products.Add(product3);
    db.Products.Add(product4);
    db.Products.Add(product5);

    db.SaveChanges();

}
