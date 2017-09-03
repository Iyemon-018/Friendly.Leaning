using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using System.Windows;
using Codeer.Friendly.Dynamic;
using RM.Friendly.WPFStandardControls;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;

namespace Test
{
    [TestClass]
    public class FriendlyTest
    {
        WindowsAppFriend _app;

        [TestInitialize]
        public void TestInitialize()
        {
            var pathExe = Path.GetFullPath("../../../WpfApplication/bin/Release/WpfApplication.exe");
            _app = new WindowsAppFriend(Process.Start(pathExe));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            var id = _app.ProcessId;
            Process.GetProcessById(id).Kill();
        }

        [TestMethod]
        public void コントロール特定()
        {
        }


        [TestMethod]
        public void コントロール特定2()
        {
        }

        [TestMethod]
        public void コントロール特定3()
        {
        }
    }
}
