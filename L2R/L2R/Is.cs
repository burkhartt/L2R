namespace System
{
    public static class Is
    {
        public static bool IsA<T>(this object @object)
        {
            try
            {
                @object.CastAs<T>();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsA<T>(this object @object, T type)
        {
            return @object.IsA<T>();
        }

        public static bool IsAn<T>(this object @object)
        {
            return @object.IsA<T>();
        }

        public static bool IsAn<T>(this object @object, T type)
        {
            return @object.IsAn<T>();
        }

        public static bool IsNull(this object @object)
        {
            return @object == null;
        }

        public static bool IsNotNull(this object @object)
        {
            return @object != null;
        }
    }
}
