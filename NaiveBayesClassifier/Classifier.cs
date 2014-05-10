namespace NaiveBayesClassifier
{
    public class Classifier
    {
        private readonly ProbabilisticModel _model;

        public Classifier(ProbabilisticModel model)
        {
            _model = model;
        }

        public Topic Classify(BagOfAttributes bag)
        {
            Topic argmax = null;
            double max = double.MinValue;

            foreach (var topic in _model.Topics)
            {
                double score = _model.ComputeLogScore(topic, bag);

                if (score > max)
                {
                    max = score;
                    argmax = topic;
                }    
            }

            return argmax;
        }
    }
}
