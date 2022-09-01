using System;
using System.Linq;
using System.Collections.Generic;

namespace Utilities;
public static class Ensure
{

    public static bool ItIsNotNull<T>(T value)
        => Ensure.ItIsTrue(value is not null);

    public static bool ItIsEmpty<T>(IEnumerable<T> collection)
        => Ensure.ItIsTrue(collection.Any());

    public static bool ItIsNotEmpty<T>(IEnumerable<T> collection)
        => Ensure.ItIsTrue(!collection.Any());

    public static bool ItIsTrue(bool condition)
    {
        if (!condition)
        {
            throw new ArgumentException(null, nameof(condition));
        }
        return true;
    }

    public static bool ItIsTrue(Func<bool> expression)
    {
        if (!expression())
        {
            throw new ArgumentException(null, nameof(expression));
        }
        return true;
    }
}
