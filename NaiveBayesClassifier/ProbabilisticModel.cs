using System;
using System.Linq;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier
{
    public class ProbabilisticModel
    {
        private readonly TrainingSet _trainingSet;
        private readonly MapOfTopicSpans _mapOfTopicSpans;
        
        public ProbabilisticModel(TrainingSet trainingSet)
        {
            _trainingSet = trainingSet;
            _mapOfTopicSpans = new MapOfTopicSpans(trainingSet);
        }

        public double ComputePriorProbability(Topic topic)
        {
            return _trainingSet.TopicOccurrences.First(e => e.Topic.Equals(topic)).Count /
                   (double) _trainingSet.NumberOfTuples;
        }

        public double ComputeConditionalLikelihood(Attribute attribute, Topic topic)
        {
            var span = _mapOfTopicSpans.FindTopicSpan(topic);
            var nominator = span.GetFrequencyOfAttribute(attribute) + 1;
            var denominator = span.TotalNumberOfAttributeOccurrences +
                              _trainingSet.NumberOfDistinctAttributes;

            return nominator / (double) denominator;
        }

        public double ComputeScore(Topic topic, BagOfAttributes bag)
        {
            var prior = ComputePriorProbability(topic);
            var likelihoods =
                bag.AttributeOccurrences.Select(
                    e => Math.Pow(ComputeConditionalLikelihood(e.Attribute, topic), e.Count))
                    .Aggregate((x, y) => x * y);

            return prior * likelihoods;
        }

        public double ComputeLogScore(Topic topic, BagOfAttributes bag)
        {
            return 0.0d;
        }
    }
}