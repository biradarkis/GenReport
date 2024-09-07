namespace GenReport.Infrastructure.Static.Externsions
{
    using System;

    /// <summary>
    /// Defines the <see cref="StringExtensions" />
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// checks if the given string is a valid email or not
        /// </summary>
        /// <param name="str">The str<see cref="string"/></param>
        /// <returns>The <see cref="bool"/> true if valid false otherwise </returns>
        public static bool IsEmail(this string str)
        {
            try
            {
                // Use the MailAddress class to validate the email format
                var mailAddress = new System.Net.Mail.MailAddress(str);
                return mailAddress.Address == str;
            }
            catch (FormatException)
            {
                // If the string is not a valid email format, return false
                return false;
            }
        }
    }
}
