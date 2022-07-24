using System.Reflection;

namespace SimpleMu.Extensions;

public static class DependencyInjection
{
    private static Assembly[]? _assemblies;

    public static void LoadAssemblies()
    {
        var references = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "SimpleMu*.dll");
        foreach (var reference in references)
            Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(reference)));

        _assemblies = AppDomain.CurrentDomain.GetAssemblies();
    }

    public static void RegisterTypes<T>(this IServiceCollection services)
    {
        if (_assemblies == null)
        {
            throw new Exception("Assemblies not loaded");
        }

        Log.Information($"Registering types for {typeof(T).Name}");
        services.Scan(scan => scan.FromAssemblies(_assemblies).AddClasses(classes => classes.AssignableTo<T>())
                                  .AsSelf().As<T>().WithSingletonLifetime());
    }
}