using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class ImplodeTests
    {
        [Test]
        public void When_I_pass_an_array_of_strings_and_a_comma_I_should_get_a_comma_delimited_list()
        {
            var strings = new[] {"This", "Is", "My", "List"};
            strings.Implode(",").ShouldEqual("This,Is,My,List");
        }

        [Test]
        public void When_I_pass_an_s_as_the_glue_in_an_array_I_should_get_the_word_Mississippi_back()
        {
            var strings = new[] {"Mi", "", "i", "", "ippi"};
            strings.Implode("s").ShouldEqual("Mississippi");
        }

        [Test]
        public void When_I_pass_a_long_string_as_the_glue_in_an_array_then_I_should_get_a_very_long_continuous_string_of_letters()
        {
            var strings = new[] {"Rah", "Rah", "Rasputin"};
            strings.Implode("YayYay").ShouldEqual("RahYayYayRahYayYayRasputin");
        }

        [Test]
        public void When_I_pass_an_empty_array_then_I_should_get_an_empty_string()
        {
            var strings = new string[0];
            strings.Implode("Someglue").ShouldBeEmpty();
        }
    }
}
