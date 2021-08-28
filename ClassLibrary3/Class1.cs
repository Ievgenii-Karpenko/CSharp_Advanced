using System;
using System.Collections.Generic;
using System.IO;
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
        public static int Number = 0;
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

        public int Sum(int a, int b)
        {
            Number = a + b;
            return Number;
        }

        private int Div(int a, int b) => a / b;
    }

    public class GitHubInfo
    {
        public List<Pull> PullRequests;

        public GitHubInfo()
        {
            PullRequests = new List<Pull>();
        }

        public virtual string GetPullRequestAsync()
        {
            HttpClient client = new HttpClient(); // Створюємо клієнт для відправки запросів

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

            Pull pull = JsonSerializer.Deserialize<Pull>(prJson);

            if (pull == null)
                return "";

            PullRequests.Add(pull);

            return pull.User.Login;
        }

        public bool SavePullRequestToDіsk(string path, out string error, Pull request = null)
        {
            string data = string.Empty;
            if (request == null)
            {
                
                foreach (var item in PullRequests)
                {
                    data += item.ToString();
                }
                File.WriteAllText(path, data);
            }
            else
            {
                data = request.ToString();
            }

            try
            {
                File.WriteAllText(path, data);
                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return false;
        }
    }

    public class Pull
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("body")]
        public string Description { get; set; }
    }

    public class User
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}
