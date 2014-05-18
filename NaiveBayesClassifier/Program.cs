using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NaiveBayesClassifier.IO;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var arffTest = new ArffReader().Read(@"Data\MultiClass_Testing_SVM_1309.0.arff");
            var arffTraining = new ArffReader().Read(@"Data\MultiClass_Training_SVM_1309.0.arff");

            var trainingSet = new TrainingSet(arffTraining.TrainingTuples);
            var model = new ProbabilisticModel(trainingSet);
            var classifier = new Classifier(model);


            int bune = 0;

            foreach (var tuple in arffTest.TrainingTuples)
            {
                var bagToTest = tuple.Bag;
                var guessedTopic = classifier.Classify(bagToTest);
                Console.WriteLine(guessedTopic + " ======== " + string.Join(" ", tuple.Topics.Select(x => x.ToString()).ToArray()));

                if (tuple.HasTopic(guessedTopic))
                {
                    bune++;
                }
            }

            Console.WriteLine(bune + ", " + arffTest.TrainingTuples.Length + ", " + arffTest.SamplesCount);
            Console.WriteLine(bune/(float) arffTest.TrainingTuples.Length);
            Console.ReadLine();
        }
    }
}
