using System.IO;

namespace PasManPC.Core
{
    internal static class Settings
    {
        private static string _currentDirectory = Directory.GetCurrentDirectory();
        private static string _userDataFile = Path.Combine( _currentDirectory, "pdata/");
        public static string UserDataFile { get => _userDataFile;}
    }
}
