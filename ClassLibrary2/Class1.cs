using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ClassLibrary2
{
    //extern alias MoqV1;
    //extern alias MoqV2;

    //using Class1V1 = MoqV1::Moq.Mock;
    //using Class1V2 = MoqV2::Moq.Mock;

    namespace ClassLibrary1
    {
        public enum A
        { }


        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            private int myInt; // private fields are ignored

            //public Company Company { get; set; }

            // we need default c-tor for work
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

                //Class1V1 o1 = new Class1V1();
            }

            public int Sum(int a, int b) => a + b;
            private int Div(int a, int b) => a / b;
        }
    }

    public class GitHubInfo
    {
        public async Task<string> GetPullRequestAsync()
        {
            HttpClient client = new HttpClient(); // Створюємо клієн для відправки запросів

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/Ievgenii-Karpenko/CSharp_Advanced/pulls/1");

            var productValue = new ProductInfoHeaderValue("X-GitHub-Media-Type", "github.v3");
            request.Headers.UserAgent.Add(productValue);

            HttpResponseMessage response = await client.SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }

        public virtual string GetUserFromPR()
        {
            string prJson = GetPullRequestAsync().Result;

            var pull = JsonSerializer.Deserialize<Pull>(prJson);

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
