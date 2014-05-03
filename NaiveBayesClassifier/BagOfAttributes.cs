
using System.Collections.Generic;
using System.Linq;

namespace NaiveBayesClassifier
{
    public class BagOfAttributes
    {
        public readonly AttributeOccurrence[] AttributeOccurrences;

        public readonly Attribute[] Attributes;

        public BagOfAttributes(IEnumerable<AttributeOccurrence> attributeOccurrences)
        {
            AttributeOccurrences = attributeOccurrences.ToArray();
            Attributes = AttributeOccurrences.Select(e => e.Attribute).ToArray();
        }
    }
}
