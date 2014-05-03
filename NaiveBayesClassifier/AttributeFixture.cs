using NUnit.Framework;

namespace NaiveBayesClassifier
{
    [TestFixture]
    public class AttributeFixture
    {
        [Test]
        public void SaysEqualWhenReallyAre()
        {
            var first = new Attribute("test");
            var second = new Attribute("test");
            Assert.AreEqual(first, second);
            Assert.True(first.Equals(second));
            Assert.True(second.Equals(first));
        }

        [Test]
        public void SaysNotEqualWhenDifferentTypes()
        {
            var first = new Attribute("test");
            var second = new Attribute(12345);
            Assert.AreNotEqual(first, second);
            Assert.False(first.Equals(second));
            Assert.False(second.Equals(first));
        }
    }
}
