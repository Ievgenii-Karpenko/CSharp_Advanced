using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ClassLibrary3
{

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            private int myInt; // private fields are ignored

            public Person()
            { }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void SetMyInt(int val)
            {
                myInt = val;
            }

            public int Sum(int a, int b) => a + b;
            private int Div(int a, int b) => a / b;
        }

    public class GitHubInfo
    {
        public virtual string GetPullRequestAsync()
        {
            HttpClient client = new HttpClient(); // Створюємо клієн для відправки запросів

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/Ievgenii-Karpenko/CSharp_Advanced/pulls/1");

            var productValue = new ProductInfoHeaderValue("X-GitHub-Media-Type", "github.v3");
            request.Headers.UserAgent.Add(productValue);

            HttpResponseMessage response = client.Send(request);

            string json = response.Content.ReadAsStringAsync().Result;

            return json;
        }

        public string GetUserFromPR()
        {
            string prJson = GetPullRequestAsync();

            var pull = JsonSerializer.Deserialize<Pull>(prJson);

            if (pull != null)
                return "";

            return pull.User.Login;
        }
    }

    public class Pull
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}
