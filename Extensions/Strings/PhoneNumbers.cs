using System;
using System.Text.RegularExpressions;
using DotnetExtensions.Classes;

namespace DotnetExtensions
{
    public static partial class Extensions
    {
        // Phone Number extensions
        private static Func<string, string> RemoveNonNumeric = x => Regex.Replace(x, "[^0-9]", string.Empty);
        private static Func<string, string> FormatAreaCode = x => x.Insert(0, "(").Insert(3, ")");
        private static Func<string, string> InsertDash = x => x.Insert(7, "-");
        public static Func<string, bool> IsNumeric = x => new Regex("[0-9]").IsMatch(x);

        public static string FormatPhoneNumber(this string phoneNumber)
            => phoneNumber.Wrap()
                .Bind(RemoveNonNumeric)
                .Bind(FormatAreaCode)
                .Bind(InsertDash);

        public static bool ValidatePhoneNumber(this string phoneNumber) => phoneNumber.Validate(IsNumeric);
    }
}
