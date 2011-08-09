namespace System
{
    public class Switch
    {
        private readonly object @object;

        public Switch(object obj)
        {
            @object = obj;
        }

        public Switch Case(object @objectToCompare, Action action)
        {
            if (@object == @objectToCompare)
                action();

            return this;
        }

        public Switch Case(bool boolCase, Action action)
        {
            if (boolCase)
                action();

            return this;
        }

        public void Default(Action action)
        {
            action();
        }
    }
}
