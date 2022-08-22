using System;
using System.Linq;

namespace DotnetExtensions
{
    public static partial class UtilityExtensions
    {
        public static bool Validate<TInput>(this TInput item, params Func<TInput, bool>[] predicates) => predicates.All(x => x(item));
    }
}
