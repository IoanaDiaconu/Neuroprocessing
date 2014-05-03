namespace NaiveBayesClassifier
{
    public class Attribute
    {
        private readonly object _value;

        public Attribute(object value)
        {
            _value = value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Attribute);
        }

        public bool Equals(Attribute attribute)
        {
            return attribute != null && _value.Equals(attribute._value);
        }
    }
}
