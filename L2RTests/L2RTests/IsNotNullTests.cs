using System;
using NUnit.Framework;
using BooleanAssertionExtensions = Should.BooleanAssertionExtensions;

namespace L2RTests
{
    [TestFixture]
    public class IsNotNullTests
    {
        [Test]
        public void Returns_true_when_null_is_not_null()
        {
            object nullVar = null;
            BooleanAssertionExtensions.ShouldBeFalse(nullVar.IsNotNull());
        }

        [Test]
        public void Returns_false_when_not_null_is_not_null()
        {
            var notNullVar = new object();
            BooleanAssertionExtensions.ShouldBeTrue(notNullVar.IsNotNull());
        }
    }
}