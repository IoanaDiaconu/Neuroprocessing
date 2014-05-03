namespace NaiveBayesClassifier
{
    public class AttributeOccurrence
    {
        public readonly Attribute Attribute;

        public readonly int Count;

        public AttributeOccurrence(Attribute attribute, int count)
        {
            Attribute = attribute;
            Count = count;
        }
    }
}
