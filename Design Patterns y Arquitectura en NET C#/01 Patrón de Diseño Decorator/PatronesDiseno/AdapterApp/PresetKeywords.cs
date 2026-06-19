namespace AdapterApp
{
    public class PresetKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private IWithSimpleKeywords Target { get; }
        private IEnumerable<string> SubstituteKeywords { get; }


        public IEnumerable<string> Keywords =>
            SubstituteKeywords.Any() ? SubstituteKeywords : Target.Keywords;

        public PresetKeywords(IWithSimpleKeywords target, IEnumerable<string> keywords)
        {
            Target = target;
            SubstituteKeywords = keywords.ToList();
        }

        public bool Equals(IWithSimpleKeywords? other) =>
            other is PresetKeywords preset && Equals(preset);

        private bool Equals(PresetKeywords other) =>
            Target.Equals(other.Target);

        public override string ToString() =>
            Target!.ToString();
        

    }
}
