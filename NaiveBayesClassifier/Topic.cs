namespace NaiveBayesClassifier
{
    public class Topic
    {
        private readonly object _value;

        public Topic(object value)
        {
            _value = value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Topic);
        }

        public bool Equals(Topic topic)
        {
            return _value != null && (topic != null && _value.Equals(topic._value));
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
