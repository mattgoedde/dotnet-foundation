using System.Collections.Generic;
using System.Linq;

namespace Extensions.Collections
{
    public static partial class Extensions
    {
        public static IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> source)
            => source ?? Enumerable.Empty<TSource>();

        public static IEnumerable<TSource> OmitLast<TSource>(this IEnumerable<TSource> source, int n)
            => source.EmptyIfNull().Reverse().Skip(n).Reverse();

        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int n)
            => source.EmptyIfNull().Reverse().Take(n).Reverse();

        public static IDictionary<TSource, int> Frequency<TSource>(this IEnumerable<TSource> source)
        {
            var freq = new Dictionary<TSource, int>();
            foreach (var t in source)
            {
                if (freq.ContainsKey(t))
                    freq[t]++;
                else
                    freq[t] = 1;
            }
            return freq;
        }

        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int batchSize)
        {
            TSource[]? batch = null;
            var i = 0;
            foreach (var item in source)
            {
                if (batch is null)
                    batch = new TSource[batchSize];

                batch[i++] = item;

                if (i == batchSize)
                {
                    yield return batch;

                    batch = null;
                    i = 0;
                }
            }
            if (batch is not null && i > 0)
                yield return batch.Take(i).ToArray();
        }
    }
}