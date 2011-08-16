using System;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class StringHelpersTests
    {
        [Test]
        public void When_I_have_an_empty_string_then_return_true_when_testing_if_it_is_null_or_empty()
        {
            "".IsNullOrEmpty().ShouldBeTrue();
        }

        [Test]
        public void When_I_have_a_null_string_then_return_true_when_testing_if_it_is_null_or_empty()
        {
            string a = null;
            a.IsNullOrEmpty().ShouldBeTrue();
        }

        [Test]
        public void When_I_have_a_non_empty_and_non_null_string_then_return_false_when_testing_if_it_is_null_or_empty()
        {
            var a = "stuff";
            a.IsNullOrEmpty().ShouldBeFalse();
        }
    }
}
