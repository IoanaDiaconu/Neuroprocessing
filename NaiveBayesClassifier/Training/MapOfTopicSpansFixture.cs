using NaiveBayesClassifier.Data;
using NUnit.Framework;

namespace NaiveBayesClassifier.Training
{
    [TestFixture]
    public class MapOfTopicSpansFixture
    {
        [Test]
        [TestCase(5, "Chinese", "c")]
        [TestCase(0, "Tokyo", "c")]
        [TestCase(0, "Japan", "c")]
        [TestCase(1, "Chinese", "j")]
        public void IsAttributeFrequencyWithinClassCorrect(int expected, string attributeValue,
            string topicValue)
        {
            var set = StanfordExample.TrainingSet;
            var attribute = new Attribute(attributeValue);
            var topic = new Topic(topicValue);
            var map = new MapOfTopicSpans(set);
            Assert.AreEqual(expected, map.FindTopicSpan(topic).GetFrequencyOfAttribute(attribute));
        }
    }
}
