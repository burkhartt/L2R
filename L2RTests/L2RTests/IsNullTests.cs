using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class IsNullTests
    {
        [Test]
        public void Returns_true_when_null_is_null()
        {
            object nullVar = null;
            nullVar.IsNull().ShouldBeTrue();
        }

        [Test]
        public void Returns_false_when_non_null_object_is_null()
        {
            var nonNullVar = new object();
            nonNullVar.IsNull().ShouldBeFalse();
        }
    }
}
