using System;
using NUnit.Framework;
using Should;

namespace L2RTests
{
    [TestFixture]
    public class CastTests
    {
        [Test]
        public void Returns_true_when_object_casts_to_valid_object()
        {
            var classB = new ClassB();
            classB.CastAs<ClassA>().ShouldNotBeNull();
        }

        [Test]
        public void Throws_invalid_cast_exception_when_object_casts_to_invalid_object()
        {
            var classA = new ClassA();
            Assert.Throws<InvalidCastException>(() => classA.CastAs<ClassB>());
        }

        private class ClassA
        {
            
        }

        private class ClassB : ClassA
        {
            
        }
    }
}
