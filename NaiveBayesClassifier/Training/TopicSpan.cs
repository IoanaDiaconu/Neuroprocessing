using System.Collections.Generic;
using System.Linq;

namespace NaiveBayesClassifier.Training
{
    public class TopicSpan
    {
        private readonly Dictionary<Attribute, int> _frequencies; 

        public readonly int TotalNumberOfAttributeOccurrences;

        public TopicSpan(IEnumerable<BagOfAttributes> bags)
        {
            var occurrences = bags.SelectMany(bag => bag.AttributeOccurrences).ToArray();
            
            TotalNumberOfAttributeOccurrences = occurrences.Sum(e => e.Count);
            _frequencies = ObtainFrequencies(occurrences);
        }

        private Dictionary<Attribute, int> ObtainFrequencies(
            IEnumerable<AttributeOccurrence> occurrences)
        {
            return occurrences.GroupBy(e => e.Attribute)
                .ToDictionary(group => group.Key, group => group.Sum(e => e.Count));
        }

        public int GetFrequencyOfAttribute(Attribute attribute)
        {
            int result;
            _frequencies.TryGetValue(attribute, out result);
            return result;
        }
    }
}
