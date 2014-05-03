using System.Linq;

namespace NaiveBayesClassifier.Training
{
    public class TrainingSet
    {
        public readonly TrainingTuple[] Tuples;

        public readonly TopicOccurrence[] TopicOccurrences;

        public readonly Topic[] Topics;

        public readonly int NumberOfDistinctTopics;

        public readonly int NumberOfDistinctAttributes;

        public readonly int NumberOfTuples;

        public TrainingSet(params TrainingTuple[] tuples)
        {
            Tuples = tuples;
            NumberOfTuples = Tuples.Length;

            TopicOccurrences = GetTopicOccurrences();
            Topics = TopicOccurrences.Select(e => e.Topic).ToArray();
            
            NumberOfDistinctTopics = TopicOccurrences.Length;
            NumberOfDistinctAttributes = GetNumberOfDistinctAttributes();
        }

        private TopicOccurrence[] GetTopicOccurrences()
        {
            return
                Tuples.SelectMany(tuple => tuple.Topics)
                    .GroupBy(topic => topic)
                    .Select(group => new TopicOccurrence(group.Key, group.Count()))
                    .ToArray();
        }

        private int GetNumberOfDistinctAttributes()
        {
            return Tuples.SelectMany(tuple => tuple.Bag.Attributes).Distinct().Count();
        }
    }
}
