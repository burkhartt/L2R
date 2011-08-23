using System.Collections.Generic;
using System.Reflection;

namespace System
{
	public static class Map
	{
		/// <summary>
		/// A static cache of properties that have been gathered via the MapTo extension.
		/// </summary>
		public static readonly Dictionary<Type, IEnumerable<PropertyInfo>> Cache = new Dictionary<Type, IEnumerable<PropertyInfo>>();

		/// <summary>
		/// Maps the properties of an object to a new object of a different type.
		/// Properties are retrieved via reflection, then cached to reduce overhead.
		/// The properties cache can be cleared by calling Map.Cache.Clear().
		/// </summary>
		/// <typeparam name="T">The new objects type</typeparam>
		/// <param name="inObject">The object to map from</param>
		/// <returns>A new object of type T with properties filled from the inObject</returns>
		public static T MapAs<T>(this object inObject)
		{
			var outObject = Activator.CreateInstance<T>();
			var inProperties = GetProperties(inObject);
			var outProperties = GetProperties(outObject);
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

		private static IEnumerable<PropertyInfo> GetProperties(object o)
		{
			var key = o.GetType();
			if (Cache.ContainsKey(key) == false)
				Cache.Add(key, key.GetProperties());
			return Cache[key];
		}
	}
}