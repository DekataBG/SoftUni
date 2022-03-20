using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            var sb = new StringBuilder();

            var type = Type.GetType(className);

            var fields = type.GetFields((BindingFlags)60);

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fields.Where(f => fieldNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(Activator.CreateInstance(type))}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType("Stealer." + className);

            var fields = type.GetFields(BindingFlags.Public
                | BindingFlags.Instance | BindingFlags.Static);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var property in properties.Where(p => p.GetMethod.IsPrivate))
            {
                sb.AppendLine($"get_{property.Name} must be public!");
            }
            foreach (var property in properties.Where(p => p.SetMethod.IsPublic))
            {
                sb.AppendLine($"set_{property.Name} must be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType(className);

            var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                sb.AppendLine($"get_{property.Name} will return {property.PropertyType}");
            }
            foreach (var property in properties)
            {
                sb.AppendLine($"set_{property.Name} will set field of { property.PropertyType}");
            }

            return sb.ToString().Trim();
        }
    }
}
