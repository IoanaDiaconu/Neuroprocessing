using System.Linq;

namespace NaiveBayesClassifier
{
    public class Document
    {
        private readonly Attribute[] _attributes;

        public Document(params Attribute[] attributes)
        {
            _attributes = attributes;
        }

        public BagOfAttributes ToBag()
        {
            var occurrences =
                _attributes.GroupBy(attribute => attribute)
                    .Select(group => new AttributeOccurrence(group.Key, group.Count()));

            return new BagOfAttributes(occurrences);
        }
    }
}
