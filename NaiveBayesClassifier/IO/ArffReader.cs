using System;
using System.IO;
using System.Linq;
using NaiveBayesClassifier.Training;

namespace NaiveBayesClassifier.IO
{
    public class ArffReader
    {
        private string[] _linesOfFile;

        public Arff Read(string path)
        {
            var arff = new Arff();
            _linesOfFile = File.ReadAllLines(path);

            var samples = _linesOfFile[0].Split(' ');
            arff.SamplesCount = int.Parse(samples[1]);

            var attributes = _linesOfFile[1].Split(' ');
            arff.AttributesCount = int.Parse(attributes[1]);

            var topics = _linesOfFile[2].Split(' ');
            arff.TopicsCount = int.Parse(topics[1]);

            _linesOfFile =
                _linesOfFile.SkipWhile(DoesNotStartWithData)
                    .SkipWhile(line => line.StartsWith("@data"))
                    .SkipWhile(string.IsNullOrEmpty)
                    .ToArray();

            arff.TrainingTuples = _linesOfFile.Select(ReadTuple).ToArray();

            return arff;

        }

        public TrainingTuple ReadTuple(string line)
        {

            var parts = line.Split('#');
            var attributeOccurrences = parts[0].Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(ReadAttributeOccurrence).ToArray();
            var topics = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(ReadTopic).ToArray();
            return new TrainingTuple(new BagOfAttributes(attributeOccurrences), topics);
        }

        public AttributeOccurrence ReadAttributeOccurrence(string input)
        {
            var parts = input.Split(':');
            return new AttributeOccurrence(new Attribute(parts[0]), int.Parse(parts[1]));
        }

        public Topic ReadTopic(string input)
        {
            return new Topic(input);
        }

        private bool DoesNotStartWithData(string line)
        {
            return !line.StartsWith("@data");

        }
    }
}
