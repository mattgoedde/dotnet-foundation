using System;

namespace DotnetExtensions.Classes
{
    public class Box<T>
    {
        public T Value { get; }

        public Box(T value)
        {
            Value = value;
        }

        public static implicit operator Box<T>(T input) => input.Wrap();
        public static implicit operator T(Box<T> input) => input.Value;
    }

    public static class BoxExtensions
    {
        /// <summary>
        /// Put something in a box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The thing to put in a box</param>
        /// <returns>A new box with the thing in it</returns>
        public static Box<T> Wrap<T>(this T input)
            => new Box<T>(input);

        /// <summary>
        /// Unwrap the box, operate on the thing, put it in a new box.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="input">The old box</param>
        /// <param name="func">The operation to perform on the thing in the box</param>
        /// <returns>A new box</returns>
        public static Box<TOutput> Bind<TInput, TOutput>(this Box<TInput> input, Func<TInput, TOutput> func)
            => func(input.Value).Wrap();
    }
}