using System.Linq;
using NUnit.Framework;

namespace NaiveBayesClassifier
{
    [TestFixture]
    public class DocumentFixture
    {
        [Test]
        public void CanConvertToBagOfAttributes()
        {
            var chinese = new Attribute("Chinese");
            var beijing = new Attribute("Beijing");
            var document = new Document(chinese, beijing, chinese);

            var bag = document.ToBag();
            var occurrences = bag.AttributeOccurrences;
            Assert.AreEqual(1, occurrences.Single(e => e.Attribute.Equals(beijing)).Count);
            Assert.AreEqual(2, occurrences.Single(e => e.Attribute.Equals(chinese)).Count);
        }
    }
}
