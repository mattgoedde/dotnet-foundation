namespace Extensions.Strings
{
    public static partial class Extensions
    {
        /// <summary>
        /// Converts string to int or defaults to 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str) =>
            int.TryParse(str, out int result)
            ? result
            : 0;
        /// <summary>
        /// Converts string to double or defaults to 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(this string str) =>
            double.TryParse(str, out double result)
            ? result
            : 0;
        /// <summary>
        /// Converts string to decimal or defaults to 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str) =>
            decimal.TryParse(str, out decimal result)
            ? result
            : 0;
        /// <summary>
        /// Converts string to float or defaults to 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str) =>
            float.TryParse(str, out float result)
            ? result
            : 0;
    }
}