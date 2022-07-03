DependecyInjection.LoadAssemblies();

var builder = Host.CreateApplicationBuilder();

//Configure Database

//Register Services
builder.Services.RegisterTypes<IInitializer>();
builder.Services.RegisterTypes<IConfigFile>();
builder.Services.RegisterTypes<IServer>();

var app = builder.Build();

var initializers = app.Services.GetServices<IInitializer>().ToList();
var servers = app.Services.GetServices<IServer>().ToList();
var configFiles = app.Services.GetServices<IConfigFile>().ToList();

initializers.ForEach(i => i.Initialize());
servers.ForEach(i => i.Start());

await app.RunAsync();

servers.ForEach(s => s.Stop());