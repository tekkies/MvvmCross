using System;
using System.Linq;
using Cirrious.MvvmCross.Plugins.File;
using MvvmCross.Plugins.Test;


#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using NUnit.Framework;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestContext = System.Object;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
#endif


namespace MvvmCross.Plugins.Cirrious
{
    [TestClass]
    public class FileTest
    {
        [TestMethod]
        public void TestGetFilesIn_ReturnsFullPath()
        {
            IMvxFileStore store = PluginFactory.CreateFileStore();
            var root = store.NativePath(string.Empty);
            var fileNameA = Guid.NewGuid().ToString();
            var fileNameB = Guid.NewGuid().ToString();
            store.WriteFile(store.PathCombine(root, fileNameA), Guid.NewGuid().ToString());
            store.WriteFile(store.PathCombine(root, fileNameB), Guid.NewGuid().ToString());

            var files = store.GetFilesIn(root);

            Assert.IsTrue(files.Any(o => o.Equals(store.PathCombine(root, fileNameA))));
            Assert.IsTrue(files.Any(o => o.Equals(store.PathCombine(root, fileNameB))));
        }

        [TestMethod]
        public void TestEnsureFolderExists_AbsolutePath()
        {
            IMvxFileStore store = PluginFactory.CreateFileStore();
            var root = store.NativePath(string.Empty);
            var folderToCreate = store.PathCombine(root, Guid.NewGuid().ToString());

            store.EnsureFolderExists(folderToCreate);

            Assert.IsTrue(store.FolderExists(folderToCreate));
        }

        [TestMethod]
        public void TestEnsureFolderExists_RelativePath()
        {
            IMvxFileStore store = PluginFactory.CreateFileStore();
            var root = store.NativePath(string.Empty);
            var relativePath = Guid.NewGuid().ToString();
            var absolutePath = store.PathCombine(root, relativePath);

            store.EnsureFolderExists(relativePath);

            Assert.IsTrue(store.FolderExists(absolutePath));
        }

        [TestMethod]
        public void TestEnsureFolderExists_AbsolutePath_2LevelsDeep()
        {
            IMvxFileStore store = PluginFactory.CreateFileStore();
            var root = store.NativePath(string.Empty);
            var relativePath = store.PathCombine(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            var folderToCreate = store.PathCombine(root, relativePath);

            store.EnsureFolderExists(folderToCreate);

            Assert.IsTrue(store.FolderExists(folderToCreate));
        }

        [TestMethod]
        public void TestEnsureFolderExists_RelativePath_2LevelsDeep()
        {
            IMvxFileStore store = PluginFactory.CreateFileStore();
            var root = store.NativePath(string.Empty);
            var relativePath = store.PathCombine(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            var absolutePath = store.PathCombine(root, relativePath);

            store.EnsureFolderExists(relativePath);

            Assert.IsTrue(store.FolderExists(absolutePath));
        }
    }
}
