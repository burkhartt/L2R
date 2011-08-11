namespace System
{
    public static class Map
    {
        /// <summary>
        /// Maps the properties of an object to a new object of a different type.
        /// </summary>
        /// <typeparam name="T">The new objects type</typeparam>
        /// <param name="inObject">The object to map from</param>
        /// <returns>A new object of type T with properties filled from the inObject</returns>
        public static T MapAs<T>(this object inObject)
        {
			var outObject = Activator.CreateInstance<T>();
			var inProperties = inObject.GetType().GetProperties();
			var outProperties = outObject.GetType().GetProperties();
			foreach (var outProperty in outProperties)
			{
				foreach (var inProperty in inProperties)
				{
					if (inProperty.Name != outProperty.Name || inProperty.PropertyType != outProperty.PropertyType)
						continue;
					var value = inProperty.GetValue(inObject, null);
					outProperty.SetValue(outObject, value, null);
				}
			}
			return outObject;
        }
    }
}