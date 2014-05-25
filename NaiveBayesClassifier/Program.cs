using System;
using System.Linq;
using NaiveBayesClassifier.Evaluation;
using NaiveBayesClassifier.IO;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier
{
    class Program
    {
        static void Main()
        {
            var arffTest = new ArffReader().Read(@"Data\MultiClass_Testing_SVM_1309.0.arff");
            var arffTraining = new ArffReader().Read(@"Data\MultiClass_Training_SVM_1309.0.arff");

            var trainingSet = new TrainingSet(arffTraining.TrainingTuples);
            var model = new ProbabilisticModel(trainingSet);
            var classifier = new Classifier(model);

            var topics = trainingSet.Topics.ToList();
            var bunchOfConfusionMatrices = new BunchOfConfusionMatrices(topics);

            var goodPredictions = 0;

            foreach (var tuple in arffTest.TrainingTuples)
            {
                var bagToTest = tuple.Bag;
                var guessedTopic = classifier.Classify(bagToTest);

                if (tuple.HasTopic(guessedTopic))
                {
                    goodPredictions++;
                }

                bunchOfConfusionMatrices.UpdateGivenGuess(tuple, guessedTopic);
            }

            Console.WriteLine();
            Console.WriteLine("Good predictions: {0}",
                goodPredictions / (float) arffTest.TrainingTuples.Length);

            var count = (float)topics.Count;
            var matrices = topics.Select(bunchOfConfusionMatrices.GetMatrix).ToList();

            var dump =
                matrices.Select(matrix => matrix.ToString()).Aggregate((p1, p2) => p1 + "\n" + p2);

            Console.WriteLine(dump);
            
            var accuracy = matrices.Sum(matrix => matrix.Accuracy) / count;
            var precision = matrices.Sum(matrix => matrix.Precision) / count;
            var recall = matrices.Sum(matrix => matrix.Recall) / count;
            var negativePredictionValue = matrices.Sum(matrix => matrix.NegtivePredictionValue) /
                                          count;

            Console.WriteLine();
            Console.WriteLine("Overall acc: {0:0.00}", accuracy);
            Console.WriteLine("Overall prec: {0:0.00}", precision);
            Console.WriteLine("Overall recall: {0:0.00}", recall);
            Console.WriteLine("Negative prediction value: {0:0.00}", negativePredictionValue);
        }
    }
}
