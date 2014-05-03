using System.Linq;
using NaiveBayesClassifier.Data;
using NUnit.Framework;

namespace NaiveBayesClassifier.Training
{
    [TestFixture]
    public class TopicSpanFixture
    {
        [Test]
        public void CanGetCorrectFrequency()
        {
            var tuples = StanfordExample.TrainingTuples.Where(t => t.HasTopic(StanfordExample.C));
            var bags = tuples.Select(t => t.Bag);
            var aggregate = new TopicSpan(bags);

            Assert.AreEqual(5, aggregate.GetFrequencyOfAttribute(StanfordExample.Chinese));
            Assert.AreEqual(1, aggregate.GetFrequencyOfAttribute(StanfordExample.Beijing));
            Assert.AreEqual(0, aggregate.GetFrequencyOfAttribute(StanfordExample.Tokyo));
        }

        [Test]
        public void IsTotalNumberOfAttributeOccurrencesCorrect()
        {
            var first = new Document(new Attribute("x"), new Attribute("y")).ToBag();
            var second = new Document(new Attribute("y"), new Attribute("z")).ToBag();
            var third = new Document(new Attribute("x")).ToBag();

            var aggregate = new TopicSpan(new[] {first, second, third});
            Assert.AreEqual(5, aggregate.TotalNumberOfAttributeOccurrences);
        }
    }
}
