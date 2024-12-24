using AuctionService.Consumers;
using AuctionService.Data;
using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Provide Automapper as a service. And specify the location of the assemblies containing the profile classes.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Connection for RabbitMq
builder.Services.AddMassTransit(x =>
{
    /*
     * Configures an Entity Framework Outbox pattern for the specified AuctionDbContext.
     * The outbox is useful for managing distributed transactions in a reliable and transactional manner.
     * 1. x Represents a service collection or configuration instance typically used for dependency injection (e.g., IServiceCollection).
     * 2. AddEntityFrameworkOutbox<TContext>
     *  2.1. Adds an Entity Framework Outbox for handling messages inside the AuctionDbContext.
     *  2.2. The type parameter <AuctionDbContext> specifies the DbContext that will use the outbox pattern.
     *  3.2. Lambda o => { ... }: This is a configuration delegate where additional properties and behaviors of the outbox can be customized.
     * 3. Configuration within the Delegate:
     *  3.1. .QueryDelay
     *      3.1.1. Specifies a delay for the outbox query in order to handle operations such as polling for unprocessed messages.
     *      3.1.2. Set to 10 seconds in this case (TimeSpan.FromSeconds(10)), meaning queries for unprocessed outbox messages will occur every 10 seconds.
     * Use Case
     * 1. The Outbox Pattern ensures atomicity and durability of messages when integrating with different systems
     *  through events or messages (e.g., in an event-driven system or microservices architecture).
     * 2. Using Entity Framework as the outbox storage, it allows applications using AuctionDbContext to safely
     *  store and forward messages while adhering to database transactions, avoiding inconsistencies.
     */
    x.AddEntityFrameworkOutbox<AuctionDbContext>(o =>
    {
        o.QueryDelay = TimeSpan.FromSeconds(10);

        o.UsePostgres();
        o.UseBusOutbox();
    });
    
    x.AddConsumersFromNamespaceContaining<AuctionCreatedFaultConsumer>();
    
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("auction", false));
    
    x.UsingRabbitMq((context, cfg) =>
    {
        
        cfg.ConfigureEndpoints(context);
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
