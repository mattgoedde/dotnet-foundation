
using System;

namespace DotnetExtensions
{
    public static partial class NumberExtensions
    {
        public static decimal FahrenheitToCelsius(decimal tempF)
            => tempF.Wrap()
                .Bind(x => x - 32)
                .Bind(x => x * 5)
                .Bind(x => x / 9)
                .Bind(x => Math.Round(x, 2));

        public static float FahrenheitToCelsius(float tempF)
            => tempF.Wrap()
                    .Bind(x => x - 32)
                    .Bind(x => x * 5)
                    .Bind(x => x / 9);

        public static decimal CelsiusToFahrenheit(decimal tempC)
            => tempC.Wrap()
                .Bind(x => x * 9)
                .Bind(x => x / 5)
                .Bind(x => x + 32)
                .Bind(x => Math.Round(x, 2));

        public static float CelsiusToFahrenheit(float tempC)
            => tempC.Wrap()
                .Bind(x => x * 9)
                .Bind(x => x / 5)
                .Bind(x => x + 32);
    }
}