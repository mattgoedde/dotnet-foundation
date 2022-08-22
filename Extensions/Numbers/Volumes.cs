using System;
using Extensions.Classes;

namespace Extensions.Numbers
{
    public static partial class Extensions
    {
        public static decimal GallonToLiter(decimal gallons)
            => gallons.Wrap()
                .Bind(x => x * 3.78541M)
                .Bind(x => Math.Round(x, 2));

        public static float GallonToLiter(float gallons)
            => gallons.Wrap()
                .Bind(x => x * 3.78541f);

        public static decimal LiterToGallon(decimal liters)
            => liters.Wrap()
                .Bind(x => x / 3.78541M)
                .Bind(x => Math.Round(x, 2));

        public static float LiterToGallon(float liters)
            => liters.Wrap()
                .Bind(x => x / 3.78541f);
    }
}