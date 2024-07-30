using System.Runtime.InteropServices;

namespace SignalRCourse.Helper
{
    public static class GenerateRandomString
    {
         
        public static string GenerateString()
        {
            var chars = "abcdefghijklmnoprstuwxyz0123456789";

            return new string(Enumerable.Repeat(chars, 15).Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }
    }
}
