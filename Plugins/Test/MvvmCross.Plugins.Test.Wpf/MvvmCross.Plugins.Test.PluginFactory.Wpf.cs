using System.IO;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.File.Wpf;

namespace MvvmCross.Plugins.Test
{
    public class PluginFactory
    {
        public static IMvxFileStore CreateFileStore()
        {
            return new MvxWpfFileStore(GetTemporaryDirectory());
        }

        public static string GetTemporaryDirectory()
        {
            return Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())).FullName;
        }
    }
}
