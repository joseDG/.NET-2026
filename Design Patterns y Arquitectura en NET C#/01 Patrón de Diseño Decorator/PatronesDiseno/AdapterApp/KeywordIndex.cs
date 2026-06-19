using AdapterApp.Common;

namespace AdapterApp
{
    public class KeywordIndex<TItem> where TItem : IWithSimpleKeywords
    {

        private IDictionary<string, IList<TItem>> Index { get; } = new Dictionary<string, IList<TItem>>();

        public void Add(TItem item)
        {
            foreach (var keyword in item.Keywords!)
            {
                Add(keyword.ToLowerInvariant(), item);
            }
        }

        private void Add(string keyword, TItem item)
        {
            GetListFor(keyword).Add(item);
        }

        private IList<TItem> GetListFor(string keyword) => Index.TryGetValue(keyword, out IList<TItem>? list) ? list : CreateListFor(keyword);

        private IList<TItem> CreateListFor(string keyword)
        {
            IList<TItem> list = new List<TItem>();
            Index[keyword] = list;
            return list;
        }

        public IEnumerable<TItem> Find(string keyword) =>
            Index.TryGetValue(keyword.ToLowerInvariant(), out IList<TItem>? libros) ? libros : Enumerable.Empty<TItem>();

        public override string ToString() =>
            Index
                .SelectMany(keyValue => keyValue.Value.Select(item => (keyword: keyValue.Key, item: item)))
                 .Select(tuple => $"{tuple.keyword} -> {tuple.item}")
                 .Join(Environment.NewLine);


        public IEnumerable<TItem> FindApproximate(string keyword) =>
            Index.Where(entry => entry.Key.Contains(keyword.ToLowerInvariant()))
            .SelectMany(entry => entry.Value)
            .Distinct();
    }
}
