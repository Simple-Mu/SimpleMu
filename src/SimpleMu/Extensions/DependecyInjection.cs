using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SimpleMu.Extensions;

public static class DependecyInjection
{

    public static void LoadAssemblies()
    {
        var references = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "SimpleMu*.dll");
        foreach (var reference in references)
        {
            Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(reference)));
        }
        
        Assemblies = AppDomain.CurrentDomain.GetAssemblies();
    }

    private static Assembly[] Assemblies;

    public static void RegisterTypes<T>(this IServiceCollection services)
    {
        Log.Information($"Registering types for {typeof(T).Name}");
        services.Scan(scan => scan.FromAssemblies(Assemblies).AddClasses(classes => classes.AssignableTo<T>())
                                  .AsSelf().As<T>().WithSingletonLifetime());
    }
}
