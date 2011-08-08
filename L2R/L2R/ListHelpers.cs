using System.Linq;

namespace System
{
    public static class ListHelpers
    {
        public static bool In(this object @object, params object[] objects)
        {
            return objects.Any(obj => @object == obj);
        }

        public static bool NotIn(this object @object, params object[] objects)
        {
            return !objects.Any(obj => @object == obj);
        }
    }
}