using System;
using Apparatus.AOT.Reflection;
using System.Linq;
using SimpleAotMapper.Attributes;

namespace SimpleAotMapper;

public static class Mapper
{
    public static TTarget Map<TSource, TTarget>(TSource source)
        where TTarget : new()
    {
        if (source == null)
            return default;

        var target = new TTarget();
        Map(source, target);
        return target;
    }

    public static void Map<TSource, TTarget>(TSource source, TTarget target)
    {
        if (source == null || target == null)
            return;

        try
        {
            // Obter as propriedades do source usando Apparatus.AOT
            var sourceProperties = AOTReflection.GetProperties<TSource>().Values;
            var targetProperties = AOTReflection.GetProperties<TTarget>().Values;

            foreach (var sourceProperty in sourceProperties)
            {

                // 1.Try find property by name and type directly
                var targetProperty = targetProperties.FirstOrDefault(p =>
                    p.Name == sourceProperty.Name &&
                    p.PropertyType == sourceProperty.PropertyType);

                // 2. If not found, verify PropertyMapName attribute
                if (sourceProperty.Attributes.OfType<PropertyMapName>().FirstOrDefault()!=null)
                {
                    var propertyMapName = sourceProperty.Attributes.OfType<PropertyMapName>().FirstOrDefault();

                    targetProperty = targetProperties.FirstOrDefault(p =>
                        p.Name == propertyMapName.Name &&
                        p.PropertyType == sourceProperty.PropertyType );

                }

                if (targetProperty != null && sourceProperty.TryGetValue(source, out var value))
                {
                    targetProperty.TrySetValue(target, value);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mapping error: {ex.Message}");
            throw; // Re-throw to maintain the original error semantics
        }
    }

   
}