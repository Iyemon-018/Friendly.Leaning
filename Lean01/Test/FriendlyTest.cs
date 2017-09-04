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
    using System;
    using Codeer.Friendly.Windows.Grasp;

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
            // STEP1.
            // 複数のウィンドウ取得方法がある。
            // １．最前面のウィンドウを取得する。
            var main = WindowControl.FromZTop(_app);

            // ２．アセンブリの正式名称を指定してウィンドウを取得する。
            var main2 = WindowControl.IdentifyFromTypeFullName(_app, "WpfApplication.MainWindow");

            // ３．ウィンドウタイトルを指定してウィンドウを取得する。
            var main4 = WindowControl.IdentifyFromWindowText(_app, "Friendly Handson");

            // ４．Application からアクセスしてメインウィンドウ＝ターゲットのウィンドウを取得する。
            var appWindow = _app.Type<Application>().Current.MainWindow;
            var main3 = new WindowControl(appWindow);



            // STEP2.
            // LogicalTree から対象のコントロールを取得する。
            // ここで取得できるLogicalTree はFriendly 独自に列挙している。
            var logical = main2.LogicalTree();

            // .ByType<T>() で指定した型のコントロールを列挙する。
            // .Single() で一つのコントロール用データに変換する。
            AppVar tabCore = logical.ByType<TabControl>().Single();
            var tabControl = new WPFTabControl(tabCore);
            tabControl.EmulateChangeSelectedIndex(1);
            tabControl.EmulateChangeSelectedIndex(0);




            // STEP3. 
            // 独自コントロール（ユーザーコントロール）を取得する。
            // 基本的にユーザーコントロールは１画面に一つなので.ByType() がおすすめ。
            AppVar demoSimpleControlCore = logical.ByType("WpfApplication.DemoSimpleControl").Single();
            // ここで取得するLogicalTree はDemoSimpleControl.xaml のルート要素から取得できるものとなる。
            var innerLogicalTree = demoSimpleControlCore.LogicalTree();

            // こんな方法でアクセスもできる。
            var x = demoSimpleControlCore.Dynamic();
            var fullNameCore = x.GetType().FullName;
            string fullName = fullNameCore;
            Console.WriteLine(fullName);
            
            // 動作は上と同じ。
            //AppVar type = demoSimpleControlCore["GetType"]();
            //var fullNameCore = type["FullName"]();
            //string fullName = (string)fullNameCore.Core;

            // ユーザーコントロール配下のテキストボックスへアクセスする。
            // x:Name をつけていればコントロール名でアクセス可能。
            var textBox = new WPFTextBox(demoSimpleControlCore.Dynamic()._textBox);
            textBox.EmulateChangeText("abc");




            // STEP4.
            // Window のDataContext（ViewModel）からコントロールを取得する。
            var textBoxMail = new WPFTextBox(innerLogicalTree.ByBinding("Mail").Single());
            textBoxMail.EmulateChangeText("example@xyz.--");


            // Assertをかける。
            Assert.AreEqual("example@xyz.--", textBoxMail.Text);



            // ComboBox を取得する。
            var comboBoxLanguage = new WPFComboBox(innerLogicalTree.ByBinding("Language").Single());
            comboBoxLanguage.EmulateChangeSelectedIndex(1);



            // GUIのテストシナリオ
            // https://github.com/Ishikawa-Tatsuya/WPFFriendlySampleDotNetConf2016

            // シナリオテストをする場合、Driver は開発者、シナリオは開発者以外がかけるようになっている。



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
