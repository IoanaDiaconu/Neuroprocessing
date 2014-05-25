namespace NaiveBayesClassifier.Evaluation
{
    public class ConfusionMatrix
    {
        private readonly Topic _topic;

        public ConfusionMatrix(Topic topic)
        {
            _topic = topic;
        }

        public int tp;

        public int fp;

        public int fn;

        public int tn;

        public float Precision
        {
            get { return (float) tp / (tp + fp); }
        }

        public float Recall
        {
            get { return (float) tp / (tp + fn); }
        }

        public float Accuracy
        {
            get { return (float) (tp + tn) / (tp + tn + fp + fn); }
        }

        public float NegtivePredictionValue
        {
            get { return (float) (tn) / (tn + fp); }
        }

        public override string ToString()
        {
            return string.Format("{0} \t Acc {1:0.00} \t Rec {2:0.00} \t Prec {3:0.00}", _topic,
                Accuracy, Recall, Precision);
        }
    }
}
