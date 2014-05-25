using System.Collections.Generic;
using System.Linq;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier.Evaluation
{
    public class BunchOfConfusionMatrices
    {
        private readonly Dictionary<Topic, ConfusionMatrix> _matricesByTopic; 

        public BunchOfConfusionMatrices(IEnumerable<Topic> topics)
        {
            _matricesByTopic = topics.ToDictionary(topic => topic,
                topic => new ConfusionMatrix(topic));
        }

        public ConfusionMatrix GetMatrix(Topic topic)
        {
            return _matricesByTopic[topic];
        }

        public void UpdateGivenGuess(TrainingTuple tuple, Topic guessedTopic)
        {
            foreach (var topic in _matricesByTopic.Keys)
            {
                var matrix = GetMatrix(topic);

                if (topic.Equals(guessedTopic))
                {
                    if (tuple.HasTopic(guessedTopic))
                    {
                        matrix.tp++;
                    }
                    else
                    {
                        matrix.fp++;
                    }
                }
                else
                {
                    if (tuple.HasTopic(topic))
                    {
                        matrix.fn++;
                    }
                    else
                    {
                        matrix.tn++;
                    }
                }
            }
        }
    }
}
