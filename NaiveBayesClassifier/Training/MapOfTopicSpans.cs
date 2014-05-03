using System.Collections.Generic;
using System.Linq;

namespace NaiveBayesClassifier.Training
{
    public class MapOfTopicSpans
    {
        private readonly TrainingSet _trainingSet;
        private readonly Dictionary<Topic, TopicSpan> _backingDictionary;

        public MapOfTopicSpans(TrainingSet trainingSet)
        {
            _trainingSet = trainingSet;
            _backingDictionary = GroupByTopic();
        }

        private Dictionary<Topic, TopicSpan> GroupByTopic()
        {
            return _trainingSet.Topics.ToDictionary(topic => topic, CreateTopicSpan);
        }

        private TopicSpan CreateTopicSpan(Topic topic)
        {
            var bagsWithTopic = _trainingSet.Tuples.Where(t => t.HasTopic(topic)).Select(t => t.Bag);
            return new TopicSpan(bagsWithTopic);
        }

        public TopicSpan FindTopicSpan(Topic topic)
        {
            return _backingDictionary[topic];
        }
    }
}
