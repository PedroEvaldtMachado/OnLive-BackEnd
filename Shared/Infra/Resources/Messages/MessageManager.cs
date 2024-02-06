using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Shared.Infra.Resources.Messages
{
    public static class MessageManager
    {
        private static readonly ResourceManager _rm = new("Shared.Infra.Resources.Messages", Assembly.GetExecutingAssembly());

        public static string? Get(string key, string culture)
        {
            return _rm.GetString(key, CultureInfo.GetCultureInfo(culture));
        }

        public static string? Get(string key, CultureInfo culture)
        {
            return _rm.GetString(key, culture);
        }

        public static string? Get(string key)
        {
            return _rm.GetString(key);
        }

        public static string GetMessage(this char[] key, string culture)
        {
            return Get(key.ToString()!, culture)!;
        }

        public static string GetMessage(this char[] key, CultureInfo culture)
        {
            return Get(key.ToString()!, culture)!;
        }

        public static string GetMessage(this char[] key)
        {
            return Get(key.ToString()!)!;
        }
    }
}