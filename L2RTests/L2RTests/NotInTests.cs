using System;
using System.Text;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class NotInTests
    {
        [Test]
        public void When_a_string_is_in_a_list_return_false()
        {
            const string word = "word";

            word.NotIn("word", "another word").ShouldBeFalse();
        }

        [Test]
        public void When_a_string_is_not_in_a_list_return_true()
        {
            const string word = "word";

            word.NotIn("different word", "another word").ShouldBeTrue();
        }

        [Test]
        public void When_an_object_is_in_a_list_return_false()
        {
            var list = new List();

            list.NotIn(list, new StringBuilder()).ShouldBeFalse();
        }

        [Test]
        public void When_an_object_is_not_in_a_list_return_true()
        {
            var list = new List();

            list.NotIn(new StringBuilder(), new object[] { "stuff" }).ShouldBeTrue();
        }
    }
}
