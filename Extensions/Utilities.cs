
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Extensions
{
    public static partial class Extensions
    {
        public static async Task<IEnumerable<T>> WhenAll<T>(params Task<T>[] tasks) => await tasks.AsEnumerable().WhenAll();
        public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            var allTasks = Task.WhenAll(tasks);

            try
            {
                return await allTasks;
            }
            catch (Exception) { }

            throw allTasks.Exception ?? throw new Exception();
        }

        /// <summary>
        /// Ensures that the argument is not null. Else throws standardized exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="argumentName">use nameof()</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T ArgumentNotNull<T>(this T arg, string? argumentName = null) where T : class
            =>
            arg is null ?
                throw new ArgumentNullException(argumentName, $"The provided argumet {argumentName} must not be Null.")
            : arg;

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
