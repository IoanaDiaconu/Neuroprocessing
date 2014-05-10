using System;
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
            var bag = StanfordExample.TestDocument.ToBag();

            double delta = Math.Pow(10, -10.0);

            double p1 = 3 / 4.0 * Math.Pow(3 / 7.0, 3) * 1 / 14.0 * 1 / 14.0;
            double p2 = 1 / 4.0 * Math.Pow(2 / 9.0, 3) * 2 / 9.0 * 2 / 9.0;

            double logp1 = Math.Log(p1);
            double logp2 = Math.Log(p2);

            Assert.AreEqual(p1, model.ComputeScore(StanfordExample.C, bag), delta);
            Assert.AreEqual(p2, model.ComputeScore(StanfordExample.J, bag), delta);

            Assert.AreEqual(logp1, model.ComputeLogScore(StanfordExample.C, bag), delta);
            Assert.AreEqual(logp2, model.ComputeLogScore(StanfordExample.J, bag), delta);
        }
    }
}
