using System.Collections.Generic;
using System.Linq;
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
			var matchedProperties = from inProperty in GetProperties(inObject)
									 from outProperty in GetProperties(outObject)
									 where inProperty.Name == outProperty.Name
			                         select new PropertyInfoSet(inProperty, outProperty);

			foreach (var match in matchedProperties)
			{
				var inValue = match.InProperty.GetValue(inObject, null);
				if (inValue == null) continue;

				var outValue = SpartConvert(inValue, match.OutProperty.PropertyType);
				if (outValue == null) continue;

				match.OutProperty.SetValue(outObject, outValue, null);
			}

			return outObject;
		}

		private static object SpartConvert(object value, Type type)
		{
			try
			{
				return Convert.ChangeType(value, type);
			}
			catch (InvalidCastException)
			{
				if (type == typeof(string))
					return value.ToString();
			}
			return null;
		}

		private static IEnumerable<PropertyInfo> GetProperties(object obj)
		{
			var key = obj.GetType();
			if (Cache.ContainsKey(key) == false)
				Cache.Add(key, key.GetProperties());
			return Cache[key];
		}

		// custom tuple for matched properties
		private class PropertyInfoSet
		{
			public PropertyInfo InProperty { get; private set; }
			public PropertyInfo OutProperty { get; private set; }

			public PropertyInfoSet(PropertyInfo inProperty, PropertyInfo outProperty)
			{
				InProperty = inProperty;
				OutProperty = outProperty;
			}
		}
	}
}