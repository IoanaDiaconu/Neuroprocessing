using System.Collections.Generic;
using System.Linq;

namespace NaiveBayesClassifier.Training
{
    public class TrainingTuple
    {
        public readonly BagOfAttributes Bag;

        public readonly Topic[] Topics;

        public TrainingTuple(BagOfAttributes bag, IEnumerable<Topic> topics)
        {
            Bag = bag;
            Topics = topics.ToArray();
        }

        public TrainingTuple(Document document, params Topic[] topics)
            : this(document.ToBag(), topics)
        {
        }

        public bool HasTopic(Topic topic)
        {
            return Topics.Contains(topic);
        }
    }
}
