using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetExtensions
{
    public static partial class UtilityExtensions
    {

        /// <summary>
        /// Performs the mapping operation on the input.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input">The input</param>
        /// <param name="func">The operation</param>
        /// <returns>The result of the func</returns>
        public static TOutput Map<TInput, TOutput>(this TInput input, Func<TInput, TOutput> func)
        => func(input);

        /// <summary>
        /// Performs the operations on the input. Then joins all of those outputs with the join func
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input">The input to operate on</param>
        /// <param name="joinFunc">The func to combine the results from the operations into a single output</param>
        /// <param name="operations">Each operation to perform on the input</param>
        /// <returns></returns>
        public static TOutput Fork<TInput, TOutput>(this TInput input, Func<IEnumerable<TOutput>, TOutput> joinFunc, params Func<TInput, TOutput>[] operations)
        => operations.Select(x => x(input)).Map(joinFunc);


        /// <summary>
        /// Returns true if all rules are true
        /// </summary>
        /// <typeparam name="TInput">The type of the item operated on</typeparam>
        /// <param name="item">The item to validate</param>
        /// <param name="rules">Functions to run on the item to see if true</param>
        /// <returns></returns>
        public static bool Validate<TInput>(this TInput item, params Func<TInput, bool>[] rules)
        => rules.All(x => x(item));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="output"></param>
        /// <param name="elseFunc"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static TOutput IfDefaultDo<TInput, TOutput>(this TOutput output, Func<TInput, TOutput> elseFunc, TInput input)
        => EqualityComparer<TOutput>.Default.Equals(output, default(TOutput)!)
                ? elseFunc(input)
                : output;

        /// <summary>
        /// Given the input, will perform the first operation.
        /// If the results from the first operation are null/default, will perform the second operation.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input"></param>
        /// <param name="func1">The operation to run first.</param>
        /// <param name="func2">The operation to run second if first is null or default.</param>
        /// <returns>The result from one of the operations.</returns>
        public static TOutput Alt<TInput, TOutput>(this TInput input, Func<TInput, TOutput> func1, Func<TInput, TOutput> func2)
        => func1(input).IfDefaultDo(func2, input);
    }
}
