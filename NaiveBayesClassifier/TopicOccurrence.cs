namespace NaiveBayesClassifier
{
    public class TopicOccurrence
    {
        public Topic Topic { get; private set; }

        public int Count { get; private set; }

        public TopicOccurrence(Topic topic, int count)
        {
            Topic = topic;
            Count = count;
        }
    }
}
