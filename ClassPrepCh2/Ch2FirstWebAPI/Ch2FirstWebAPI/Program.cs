using Ch2FirstWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(opts => 
opts.ResolveConflictingActions(apiDesc => apiDesc.First())
); // we are telling Swagger to resolve all conflicts related to duplicate routing handlers by always taking the firs one 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

if(app.Configuration.GetValue<bool>("UseDeveloperExceptionPage")) //Retrieves that literal value from the appsettings.json file(s)
{
    app.UseDeveloperExceptionPage(); //  If TRUE, uses the DeveloperExceptionPageMiddleware
}
else 
{ 
    app.UseExceptionHandler("/error"); // if FALSE then throws exception 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/error", () => Results.Problem()); // Minimal APIs for handling error 
app.MapGet("error/test", () => { throw new Exception("TEST"); });

app.MapGet("/BoardGames", () => new[] {
    new BoardGame() {
        Id = 1,
        Name = "Axis & Allies",
        Year = 1981
    },
    new BoardGame() {
        Id = 2,
        Name = "Citadels",
        Year = 2000
    },
    new BoardGame() {
        Id = 3,
        Name = "Terraforming Mars",
        Year = 2016
    }
});

app.MapControllers();

app.Run();
