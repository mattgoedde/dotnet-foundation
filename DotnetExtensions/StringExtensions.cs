using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DotnetExtensions
{
    public static partial class StringExtensions
    {
        // Phone Number extensions
        public static Func<string, bool> IsNumeric = x => new Regex("[0-9]").IsMatch(x);
        public static bool ValidatePhoneNumber(this string phoneNumber) => phoneNumber.Validate(IsNumeric);

        // Email extensions
        public static Func<string, bool> IsEmail = x => { try { new MailAddress(x); return true; } catch { return false; } };
        public static bool ValidateEmail(this string email) => email.Validate(IsEmail);
    }
}
