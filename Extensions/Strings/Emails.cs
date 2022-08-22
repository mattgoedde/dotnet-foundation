using System;
using System.Net.Mail;

namespace Extensions
{
    public static partial class Extensions
    {
        // Email extensions
        public static Func<string, bool> IsEmail = x => { try { new MailAddress(x); return true; } catch { return false; } };
        public static bool ValidateEmail(this string email) => email.Validate(IsEmail);
    }
}
