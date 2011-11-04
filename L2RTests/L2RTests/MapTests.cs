using System;
using System.Collections.Generic;
using NUnit.Framework;
using Should;

namespace L2RTests
{
	[TestFixture]
	public class MapTests
	{
		#region Testing Data

		private class ClassOne
		{
			public string NamedProperty { get; set; }

			public string StringProperty { get; set; }
			public int IntProperty { get; set; }
			public bool BoolProperty { get; set; }
			public DateTime DateTimeProperty { get; set; }

			public int IntToStringTypeProperty { get; set; }
			public DateTime DateTimeToStringTypeProperty { get; set; }
			public Uri UriToStringTypeProperty { get; set; }
			public Object ObjectToStringProperty { get; set; }

			public EventArgs EventArgsToUriFailProperty { get; set; }
		}

		private class ClassTwo
		{
			public string NamedProperty { get; set; }

			public string StringProperty { get; set; }
			public int IntProperty { get; set; }
			public bool BoolProperty { get; set; }
			public DateTime DateTimeProperty { get; set; }

			public string IntToStringTypeProperty { get; set; }
			public string DateTimeToStringTypeProperty { get; set; }
			public string UriToStringTypeProperty { get; set; }
			public string ObjectToStringProperty { get; set; }

			public Uri EventArgsToUriFailProperty { get; set; }
		}

		private class ClassThree
		{
		}

		#endregion

		[SetUp]
		public void Init()
		{
			Map.Cache.Clear();
		}

		[Test]
		public void Returns_the_correct_type()
		{
			var classOne = new ClassOne();
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.ShouldBeType<ClassTwo>();
		}

		[Test]
		public void Named_property_is_mapped()
		{
			const string expected = "name";
			var classOne = new ClassOne { NamedProperty = expected };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.NamedProperty.ShouldEqual(expected);
		}

		[Test]
		public void String_property_is_mapped()
		{
			const string expected = "string";
			var classOne = new ClassOne { StringProperty = expected };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.StringProperty.ShouldEqual(expected);
		}

		[Test]
		public void Int_property_is_mapped()
		{
			const int expected = 7;
			var classOne = new ClassOne { IntProperty = expected };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.IntProperty.ShouldEqual(expected);
		}

		[Test]
		public void Bool_property_is_mapped()
		{
			const bool expected = true;
			var classOne = new ClassOne { BoolProperty = expected };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.BoolProperty.ShouldEqual(expected);
		}

		[Test]
		public void Date_time_property_is_mapped()
		{
			var expected = new DateTime(1979, 6, 15);
			var classOne = new ClassOne { DateTimeProperty = expected };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.DateTimeProperty.ShouldEqual(expected);
		}

		[Test]
		public void Conversion_of_int_to_string_works()
		{

			var classOne = new ClassOne { IntToStringTypeProperty = 123 };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.IntToStringTypeProperty.ShouldEqual("123");
		}

		[Test]
		public void Conversion_of_datetime_to_string_works()
		{
			var classOne = new ClassOne { DateTimeToStringTypeProperty = new DateTime(1979, 6, 15) };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.DateTimeToStringTypeProperty.ShouldEqual("6/15/1979 12:00:00 AM");
		}

		[Test]
		public void Conversion_of_uri_to_string_works()
		{
			var classOne = new ClassOne { UriToStringTypeProperty = new Uri("http://jaredmcguire.com/") };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.UriToStringTypeProperty.ShouldEqual("http://jaredmcguire.com/");
		}

		[Test]
		public void Conversion_of_unknown_object_to_string_gives_object_type_as_a_string()
		{
			var classOne = new ClassOne { ObjectToStringProperty = new Object() };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.ObjectToStringProperty.ShouldEqual("System.Object");
		}

		[Test]
		public void Types_that_cannot_convert_are_ignored()
		{
			var classOne = new ClassOne { EventArgsToUriFailProperty = new EventArgs() };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.EventArgsToUriFailProperty.ShouldBeNull();
		}

		[Test]
		public void The_cache_increases_by_two_after_the_first_mapping()
		{
			var classOne = new ClassOne();
			var classTwo = classOne.MapAs<ClassTwo>();
			Map.Cache.Count.ShouldEqual(2);
		}

		[Test]
		public void The_cache_increases_by_one_after_mapping_with_an_unknow_type()
		{
			var classOneA = new ClassOne();
			var classTwoA = classOneA.MapAs<ClassTwo>();
			Map.Cache.Count.ShouldEqual(2);

			var classOneB = new ClassOne();
			var classThree = classOneB.MapAs<ClassThree>();
			Map.Cache.Count.ShouldEqual(3);
		}

		[Test]
		public void The_cache_does_not_increases_after_mapping_with_know_types()
		{
			var classOneA = new ClassOne();
			var classTwoA = classOneA.MapAs<ClassTwo>();
			Map.Cache.Count.ShouldEqual(2);

			var classOneB = new ClassOne();
			var classTwoB = classOneB.MapAs<ClassTwo>();
			Map.Cache.Count.ShouldEqual(2);
		}
	}
}