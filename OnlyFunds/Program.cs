global using FastEndpoints;
using FastEndpoints.ClientGen;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnlyFunds.Services;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<IChannelsService, ChannelsService>();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(s =>
{
    s.DocumentName = "api"; 
});

var app = builder.Build();
app.UseDefaultExceptionHandler();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

#region HotTips
// Dependency graph
#endregion

#region Packages Missing
// Exception Handling
// Health and Ready endpoints
// Resilience
// Graceful Termination
// KeyVault (or similar) integration / onprem
// FeatureFlag
// Cache for azure and onprem (BFF)
#endregion

#region Generators
app.MapCSharpClientEndpoint("/generatecclient", "api", s =>
{
    s.ClassName = "ApiClient";
    s.CSharpGeneratorSettings.Namespace = "My Namespace";
});

app.MapTypeScriptClientEndpoint("/generatetsclient", "api", s =>
{
    s.ClassName = "ApiClient";
    s.TypeScriptGeneratorSettings.Namespace = "My Namespace";
});
#endregion


app.Run();