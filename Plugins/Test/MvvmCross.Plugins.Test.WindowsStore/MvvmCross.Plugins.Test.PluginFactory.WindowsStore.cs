using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.File.WindowsStore;

namespace MvvmCross.Plugins.Test
{
    public class PluginFactory
    {
        public static IMvxFileStore CreateFileStore()
        {
            return new MvxWindowsStoreFileStore();
        }
    }
}
