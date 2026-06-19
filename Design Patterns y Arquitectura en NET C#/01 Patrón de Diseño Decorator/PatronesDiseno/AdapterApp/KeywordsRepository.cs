namespace AdapterApp
{
    class KeywordsRepository
    {
        public IEnumerable<string> FindFor(string videoHandle) =>
            videoHandle == "laguna" ? new[] { "cinema","paraiso"}
            : Enumerable.Empty<string>();
    }
}
