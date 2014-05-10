using NaiveBayesClassifier.Data;
using NUnit.Framework;

namespace NaiveBayesClassifier
{
    [TestFixture]
    public class ClassifierFixture
    {
        [Test]
        public void CanClassifyLikeInTheStanfordExample()
        {
            var set = StanfordExample.TrainingSet;
            var model = new ProbabilisticModel(set);
            var classifier = new Classifier(model);
            var document = StanfordExample.TestDocument;

            var topic = classifier.Classify(document.ToBag());
            Assert.AreEqual(StanfordExample.C, topic);
        }
    }
}
