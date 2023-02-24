using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddMagicOnion();

#region Swagger
builder.Services.AddControllersWithViews();
#endregion

var app = builder.Build();

#region Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapMagicOnionHttpGateway("_", app.Services.GetService<MagicOnion.Server.MagicOnionServiceDefinition>().MethodHandlers, GrpcChannel.ForAddress("http://localhost:5000"));
    endpoints.MapMagicOnionSwagger("swagger", app.Services.GetService<MagicOnion.Server.MagicOnionServiceDefinition>().MethodHandlers, "/_/");
    
    endpoints.MapMagicOnionService();
});
#endregion
app.Run();