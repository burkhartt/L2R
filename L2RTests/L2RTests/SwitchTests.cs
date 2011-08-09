using System;
using NUnit.Framework;

namespace L2RTests
{
    [TestFixture]
    public class SwitchTests
    {
        [Test]
        public void When_I_pass_a_string_of_letters_abc_then_I_assert_true()
        {
            var letters = "abc";

            new Switch(letters)
                .Case("abc", () => Assert.True(true))
                .Case("def", () => Assert.True(false));
        }

        [Test]
        public void When_I_pass_a_string_of_letters_def_then_I_assert_true_in_a_non_first_case_statement()
        {
            var letters = "def";

            new Switch(letters)
                .Case("abc", () => Assert.True(false))
                .Case("def", () => Assert.True(true));
        }

        [Test]
        public void When_I_pass_a_string_that_does_not_exist_in_the_switch_statement_then_assert_true()
        {
            var letters = "ghi";

            new Switch(letters)
                .Case("abc", () => Assert.True(false))
                .Case("def", () => Assert.True(false));

            Assert.True(true);
        }

        [Test]
        public void When_I_pass_a_string_that_does_not_exist_in_the_switch_statement_then_go_to_the_default_case_and_assert_true()
        {
            var letters = "abc";

            new Switch(letters)
                .Case("def", () => Assert.True(false))
                .Case("ghi", () => Assert.True(false))
                .Default(() => Assert.True(true));
        }

        [Test]
        public void When_I_pass_a_true_boolean_expression_then_assert_true()
        {
            var letters = 6;

            new Switch(letters)
                .Case(letters > 3, () => Assert.True(true))
                .Case(letters <= 3, () => Assert.True(false));
        }
    }
}
