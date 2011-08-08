using System;
using System.Text;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class InTests
    {
        [Test]
        public void When_a_string_is_in_a_list_return_true()
        {
            const string word = "word";

            word.In("word", "another word").ShouldBeTrue();
        }

        [Test]
        public void When_a_string_is_not_in_a_list_return_false()
        {
            const string word = "word";

            word.In("different word", "another word").ShouldBeFalse();
        }

        [Test]
        public void When_an_object_is_in_a_list_return_true()
        {
            var list = new List();

            list.In(list, new StringBuilder()).ShouldBeTrue();
        }

        [Test]
        public void When_an_object_is_not_in_a_list_return_false()
        {
            var list = new List();

            list.In(new StringBuilder(), new object[] { "stuff" }).ShouldBeFalse();
        }

        [Test]
        public void When_a_type_is_in_a_list_return_true()
        {
            var myType = typeof (string);

            myType.In(typeof (string), typeof (int)).ShouldBeTrue();
        }

        [Test]
        public void When_a_type_is_not_in_a_list_return_false()
        {
            var myType = typeof (string);

            myType.In(typeof (int), typeof (bool)).ShouldBeFalse();
        }
    }
}
