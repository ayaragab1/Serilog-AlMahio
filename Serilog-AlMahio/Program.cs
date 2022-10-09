

using Serilog.Sinks.ElmahIo;
using Serilog;
using Serilog.Events;

var log =
    new LoggerConfiguration()
        .WriteTo.ElmahIo(new ElmahIoSinkOptions("d8b11f55b0a147068dbd7c94db41a046", new Guid("6ed929d2-6394-4b81-bb6b-a610b464e905"))
        {
            MinimumLogEventLevel = LogEventLevel.Warning,
            OnMessage = msg =>
            {
            msg.Version = "1.0.0";
        }
        })
        .CreateLogger();
Log.Logger = log;

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    builder.Services.AddRazorPages();

    builder.Services.AddHealthChecks()
        .AddElmahIoPublisher(options =>
        {
            options.ApiKey = "d8b11f55b0a147068dbd7c94db41a046";
            options.LogId =
                new Guid("6ed929d2-6394-4b81-bb6b-a610b464e905");
            options.HeartbeatId = "a04b2e2c6451413f926bb365e98a72b7";
        });
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapRazorPages();
    });

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}