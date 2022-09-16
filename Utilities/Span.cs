using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Utilities;

public static class Span
{
    public static void ReadonlyForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var x in CollectionsMarshal.AsSpan(collection.ToList()))
        {
            action(x);
        }
    }
}