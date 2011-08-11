using System;
using NUnit.Framework;
using Should;

namespace L2RTests
{
	[TestFixture]
	public class MapTests
	{
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
		public void Property_with_matching_name_but_different_type_is_not_mapped()
		{
			var classOne = new ClassOne { WrongTypeProperty = 666 };
			var classTwo = classOne.MapAs<ClassTwo>();
			classTwo.WrongTypeProperty.ShouldEqual(0);
		}


		private class ClassOne
		{
			public string NamedProperty { get; set; }

			public string StringProperty { get; set; }
			public int IntProperty { get; set; }
			public bool BoolProperty { get; set; }
			public DateTime DateTimeProperty { get; set; }

			public int WrongTypeProperty { get; set; }
		}

		private class ClassTwo
		{
			public string NamedProperty { get; set; }

			public string StringProperty { get; set; }
			public int IntProperty { get; set; }
			public bool BoolProperty { get; set; }
			public DateTime DateTimeProperty { get; set; }

			public long WrongTypeProperty { get; set; }
		}
	}
}