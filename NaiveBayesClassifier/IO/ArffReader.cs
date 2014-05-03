using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;

namespace NaiveBayesClassifier.IO
{
    public class ArffReader
    {
        private readonly string[] _linesOfFile;

        public ArffReader(string path)
        {
            _linesOfFile = File.ReadAllLines(path);
        }

        public IEnumerable<BagOfAttributes> ReadSamples()
        {
            return null;
        }

        public BagOfAttributes ReadSample(string sampleLine)
        {
            return null;
        }

        public IDictionary<Attribute, int> ReadFrequencyOfAttributes(string leftPartOfSampleLine)
        {
            return null;
        }

        public KeyValuePair<Attribute, int> ReadAttributeAndFrequence(string attributeAndFrequency)
        {
            return new KeyValuePair<Attribute, int>(null, 0);
        }

        public IEnumerable<Topic> ReadTopics(string rightPartOfSampleLine)
        {
            return null;
        }
    }
}
