using System.Linq;
using NaiveBayesClassifier.Data;
using NUnit.Framework;

namespace NaiveBayesClassifier.Training
{
    [TestFixture]
    public class TrainingSetFixture
    {
        [Test]
        public void CanGetTopics()
        {
            var x = new TrainingTuple(new Document(new Attribute(1)), new Topic("X"));
            var y = new TrainingTuple(new Document(new Attribute(1)), new Topic("Y"));

            var set = new TrainingSet(x, y);
            var occurrences = set.TopicOccurrences;
            Assert.AreEqual(2, occurrences.Length);
            Assert.IsTrue(occurrences.All(e => e.Count == 1));
        }

        [Test]
        public void IsNumberOfDistinctAttributesCorrect()
        {
            var set = StanfordExample.TrainingSet;
            Assert.AreEqual(6, set.NumberOfDistinctAttributes);
        }

        [Test]
        public void IsNumberOfDistinctTopicsCorrect()
        {
            var set = StanfordExample.TrainingSet;
            Assert.AreEqual(2, set.NumberOfDistinctTopics);
        }
    }
}
