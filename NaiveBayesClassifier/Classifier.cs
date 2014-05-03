namespace NaiveBayesClassifier
{
    public class Classifier
    {
        private readonly ProbabilisticModel _model;

        public Classifier(ProbabilisticModel model)
        {
            _model = model;
        }

        public Topic Classify(BagOfAttributes document)
        {
            return null;
        }
    }
}
