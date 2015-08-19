using System.IO;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.File.Wpf;

namespace MvvmCross.Plugins.Test
{
    public class PluginFactory
    {
        public static IMvxFileStore CreateFileStore()
        {
            var temporaryDirectory = GetTemporaryDirectory();
            Directory.SetCurrentDirectory(temporaryDirectory);
            return new MvxWpfFileStore(temporaryDirectory);
        }

        public static string GetTemporaryDirectory()
        {
            return Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())).FullName;
        }
    }
}
