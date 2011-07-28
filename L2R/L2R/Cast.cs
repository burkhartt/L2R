namespace System
{
    public static class Cast
    {
        public static T CastAs<T>(this object @object)
        {
            return (T)@object;
        }
    }
}