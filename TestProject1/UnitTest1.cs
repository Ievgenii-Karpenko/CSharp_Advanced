using ClassLibrary3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string path = "result.txt";
        Person person = new Person();

        [ClassInitialize]
        public void TestClassInit()
        {

        }

        [ClassCleanup]
        public void TestClassClean()
        {

        }

        [TestInitialize]
        public void TestInit()
        {
            Person.Number = 1;
        }

        [TestCleanup]
        public void CleanUpInit()
        {
            Person.Number = 0;
        }

        [TestMethod]
        public void Sum_Good_Test()
        {

            //Prepare
            int expected = 5;

            // Act
            int res = person.Sum(2, 3);

            //if (expected != res)
            //    Assert.Fail();

            // Assert

            Assert.IsNotNull(res);
            Assert.AreEqual(expected, res, "The method Sum failed");

            int[] arr1 = new int[5];
            int[] arr2 = new int[5];

            CollectionAssert.AreEqual(arr1, arr2);

            //for (int i = 0; i < 5; i++)
            //{
            //    Assert.AreEqual(arr1[i], arr2[i], "The method Sum failed");
            //}
            File.AppendAllText(path, "method1 ok");
        }

        [TestMethod]
        public void Sum_Good2_Test()
        {

            //Prepare
            int expected = 5;

            // Act
            int res = person.Sum(2, 3);

            //if (expected != res)
            //    Assert.Fail();

            // Assert

            Assert.IsNotNull(res);
            Assert.AreEqual(expected, res, "The method Sum failed");

            int[] arr1 = new int[5];
            int[] arr2 = new int[5];

            CollectionAssert.AreEqual(arr1, arr2);

            //for (int i = 0; i < 5; i++)
            //{
            //    Assert.AreEqual(arr1[i], arr2[i], "The method Sum failed");
            //}
            File.AppendAllText(path, "method1 ok");
        }

        [TestMethod]
        public void Div_Good_Test()
        {
            var pers = new Person();
            var method = typeof(Person).GetMethod("Div", BindingFlags.Instance | BindingFlags.NonPublic);
            var result = method?.Invoke(pers, new object[] { 10, 2 });

            int expected = 5;

            Assert.AreEqual(expected, result, "The method Sum failed");

            File.AppendAllText(path, "method2 ok");
        }

        [TestMethod]
        public void GetUserFromPR_OK_Test()
        {
            //Pull pl = new Pull() { Url = "bla-bla-bla" };
            //pl.User = new User() { Login = "TempUser" };

            //string gitHubResponse = JsonSerializer.Serialize(pl);

            //Mock<GitHubInfo> mock = new Mock<GitHubInfo>();
            //mock.CallBase = true;
            //mock.Setup(p => p.GetPullRequestAsync()).Returns(gitHubResponse);

            var gh_info = new GitHubInfo();
            var user = gh_info.GetUserFromPR();

            Assert.AreEqual("TempUser", user, "The method Sum failed");
        }

        [TestMethod]
        public void GetUserFromPR_Bad_Test()
        {
            string gitHubResponse = JsonSerializer.Serialize("dasfsdfsd");

            Mock<GitHubInfo> mock = new Mock<GitHubInfo>();
            mock.CallBase = true;
            mock.Setup(p => p.GetPullRequestAsync()).Returns(gitHubResponse);

            Assert.ThrowsException<JsonException>(mock.Object.GetUserFromPR);
        }

        [TestMethod]
        public void SavePullRequestToDіsk_OK_Test()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory, "myFile.txt");

            GitHubInfo mock = new GitHubInfo();
            Pull pl = new Pull();
            var check = mock.SavePullRequestToDіsk(path, out _, pl);

            Assert.AreEqual(File.Exists(path), check, "Failed test");
        }



        [TestMethod]
        public void SavePullRequestToDіsk_Fail_Test()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory, "myFile.txt");
            GitHubInfo mock = new GitHubInfo();
            Pull pl = new Pull();

            var check = mock.SavePullRequestToDіsk(path, out _, pl);
            Assert.IsFalse(File.Exists(path));
        }

        // some random tests

        [TestMethod]
        public void FolderAccessTest()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory, "myFile.txt");

            Pull pl = new Pull();
            GitHubInfo mock = new GitHubInfo();
            var test = mock.SavePullRequestToDіsk(path, out _, pl);

            var result = File.ReadAllText(path);

            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void GetAvailableFiles_EmptyFolder_ReturnsEmptyList()
        {
            // Arrange
            //IFileScanner scanner = new IFileScanner();

            //// Act
            //var list = scanner.GetAvailableFiles("dummy argument");

            //// Assert
            //Assert.IsTrue(list.Count == 0);
        }
    }
}
