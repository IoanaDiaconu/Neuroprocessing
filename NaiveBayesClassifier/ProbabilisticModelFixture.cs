using NaiveBayesClassifier.Data;
using NUnit.Framework;

namespace NaiveBayesClassifier
{
    [TestFixture]
    public class ProbabilisticModelFixture
    {
        [Test]
        public void CanGetPriorProbabilityCorrectly()
        {
            var set = StanfordExample.TrainingSet;
            var model = new ProbabilisticModel(set);
            Assert.AreEqual(3 / 4.0d, model.ComputePriorProbability(StanfordExample.C));
            Assert.AreEqual(1 / 4.0d, model.ComputePriorProbability(StanfordExample.J));
        }

        [Test]
        [TestCase(3 / 7.0d, "Chinese", "c")]
        [TestCase(1 / 14.0d, "Tokyo", "c")]
        [TestCase(1 / 14.0d, "Japan", "c")]
        [TestCase(2 / 9.0d, "Chinese", "j")]
        [TestCase(2 / 9.0d, "Tokyo", "j")]
        [TestCase(2 / 9.0d, "Japan", "j")]
        public void CanComputeLikelihoodsCorrectly(double expected, string attributeValue,
            string topicValue)
        {
            var set = StanfordExample.TrainingSet;
            var model = new ProbabilisticModel(set);
            var attribute = new Attribute(attributeValue);
            var topic = new Topic(topicValue);

            Assert.AreEqual(expected, model.ComputeConditionalLikelihood(attribute, topic));
        }

        [Test]
        public void CanComputeScore()
        {
            var set = StanfordExample.TrainingSet;
            var model = new ProbabilisticModel(set);
            var testDocument = new Document(StanfordExample.Chinese, StanfordExample.Chinese,
                StanfordExample.Chinese, StanfordExample.Tokyo, StanfordExample.Japan);
            var bag = testDocument.ToBag();

            const double acceptedError = 0.00005;

            Assert.AreEqual(0.0003d, model.ComputeScore(StanfordExample.C, bag), acceptedError);
            Assert.AreEqual(0.0001d, model.ComputeScore(StanfordExample.J, bag), acceptedError);
        }
    }
}
