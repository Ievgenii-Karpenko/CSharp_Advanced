using ClassLibrary3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Text.Json;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum_Good_Test()
        {
            Person person = new Person();
            int expected = 5;

            int res = person.Sum(2, 3);

            //if (expected != res)
            //    Assert.Fail();

            Assert.AreEqual(expected, res, "The method Sum failed");
        }

        [TestMethod]
        public void Div_Good_Test()
        {
            var pers = new Person();
            var method = typeof(Person).GetMethod("Div", BindingFlags.Instance | BindingFlags.NonPublic);
            var result = method?.Invoke(pers, new object[] { 10, 2 });

            int expected = 5;

            Assert.AreEqual(expected, result, "The method Sum failed");
        }

        [TestMethod]
        public void GetUserFromPR_OK_Test()
        {
            Pull pl = new Pull() { Url = "bla-bla-bla" };
            pl.User = new User() { Login = "TempUser" };

            string gitHubResponse = JsonSerializer.Serialize(pl);

            Mock<GitHubInfo> mock = new Mock<GitHubInfo>();
            mock.CallBase = true;
            mock.Setup(p => p.GetPullRequestAsync()).Returns(gitHubResponse);

            var user = mock.Object.GetUserFromPR();

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
    }
}
