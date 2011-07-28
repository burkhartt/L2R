using System;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class IsATests
    {
        [Test]
        public void Returns_false_when_a_string_is_not_an_int()
        {
            "String".IsAn<int>().ShouldBeFalse();
        }

        [Test]
        public void Returns_true_when_an_int_is_an_Int32()
        {
            5.IsAn<Int32>().ShouldBeTrue();
        }

        [Test]
        public void Returns_true_when_an_int_is_an_int()
        {
            3.IsAn<int>().ShouldBeTrue();
        }

        [Test]
        public void Returns_true_when_a_string_is_a_string()
        {
            "String".IsA<string>().ShouldBeTrue();
        }
    }
}