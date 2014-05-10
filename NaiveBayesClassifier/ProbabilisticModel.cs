using System;
using System.Linq;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier
{
    public class ProbabilisticModel
    {
        private readonly TrainingSet _trainingSet;
        private readonly MapOfTopicSpans _mapOfTopicSpans;
        public readonly Topic[] Topics;

        public ProbabilisticModel(TrainingSet trainingSet)
        {
            Topics = trainingSet.Topics;
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
            var aggregatedLikelihood = 1.0d;

            foreach (var attributeOccurrence in bag.AttributeOccurrences)
            {
                var attribute = attributeOccurrence.Attribute;
                var count = attributeOccurrence.Count;

                var likelihood = ComputeConditionalLikelihood(attribute, topic);
                var weightedLikelihood = Math.Pow(likelihood, count);

                aggregatedLikelihood *= weightedLikelihood;
            }

            return prior * aggregatedLikelihood;
        }

        public double ComputeLogScore(Topic topic, BagOfAttributes bag)
        {
            var prior = Math.Log(ComputePriorProbability(topic));
            var aggregatedLikelihood = 0.0d;

            foreach (var attributeOccurrence in bag.AttributeOccurrences)
            {
                var attribute = attributeOccurrence.Attribute;
                var count = attributeOccurrence.Count;

                var likelihood = Math.Log(ComputeConditionalLikelihood(attribute, topic));
                var weightedLikelihood = likelihood * count;

                aggregatedLikelihood += weightedLikelihood;
            }

            return prior + aggregatedLikelihood;
        }
    }
}