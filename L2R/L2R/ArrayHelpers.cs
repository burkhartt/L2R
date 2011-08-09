using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class ArrayHelpers
    {
        public static string Implode(this IEnumerable<string> array, string glue)
        {
            var result = array.Aggregate(string.Empty, (current, element) => current + (glue + element));

            if (result.Length > glue.Length)
                result = result.Substring(glue.Length);

            return result;
        }
    }
}
