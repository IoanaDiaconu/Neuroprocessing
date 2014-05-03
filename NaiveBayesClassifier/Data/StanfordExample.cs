using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier.Data
{
    public static class StanfordExample
    {
        public static readonly Attribute Chinese = new Attribute("Chinese"),
            Beijing = new Attribute("Beijing"),
            Shangai = new Attribute("Shanghai"),
            Macao = new Attribute("Macao"),
            Tokyo = new Attribute("Tokyo"),
            Japan = new Attribute("Japan");

        public static readonly Topic C = new Topic("c"), J = new Topic("j");

        public static TrainingSet TrainingSet
        {
            get { return new TrainingSet(TrainingTuples); }
        }

        public static TrainingTuple[] TrainingTuples
        {
            get
            {
                return new[]
                {
                    new TrainingTuple(new Document(Chinese, Beijing, Chinese), C),
                    new TrainingTuple(new Document(Chinese, Chinese, Shangai), C),
                    new TrainingTuple(new Document(Chinese, Macao), C),
                    new TrainingTuple(new Document(Tokyo, Japan, Chinese), J)
                };
            }
        }

        public static Document TestDocument
        {
            get { return new Document(Chinese, Chinese, Chinese, Tokyo, Japan); }
        }
    }
}
