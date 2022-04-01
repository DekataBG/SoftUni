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
    }
}
