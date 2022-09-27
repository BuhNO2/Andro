using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;


namespace Andro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(hash).Replace("-", "");
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        private async void AuthClicked(object sender, EventArgs e)
        {
            if (LoginUser.Text == null || PassUser.Text == null)
                return;

            string url = "https://apis.api-mauijobs.site/Auth";
            string urlLocal = "https://localhost:25565/Auth";

            string postParameters = "login=" + GetHash(LoginUser.Text) + "&password=" + GetHash(PassUser.Text);/*
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Auth?" + postParameters);

             request.Method = "POST";
             request.ContentType = "application/json";

             HttpWebResponse response = (HttpWebResponse)request.GetResponse();*/

            // сериализация объекта с помощью Json.NET

            User userAuth = new User()
            {
                ID = 1,
                Login = GetHash(LoginUser.Text),
                Password = GetHash(PassUser.Text),
                Enterprice = "",
                Surname = "",
                Name = "",
                Patronomic = "",
                DateofBirth = ""
            };

            HttpClient httpClient = new HttpClient();
            string a = JsonConvert.SerializeObject(userAuth);
            var stringContent = new StringContent(JsonConvert.SerializeObject(userAuth), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(urlLocal, stringContent);

            User newUser = JsonConvert.DeserializeObject<User>(a);

            /*string json = JsonConvert.SerializeObject(userAuth);
            HttpContent content = new StringContent(json);
            content.Body
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(urlLocal, content);
            LoginUser.Text = await response.Content.ReadAsStringAsync();*/

            /*            if (response.Result != null)
                        {
                            *//*User user = JsonConvert.DeserializeObject<User>(userAuth);*//*

                            //Application.Current.MainPage = new Menu(response.Result.ToString());
                        }
            */




            /*using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    userAuth = reader.ReadToEnd();
                }
            }
            response.Close();*/

            /*  if (userAuth != "")
              {
                  *//*User user = JsonConvert.DeserializeObject<User>(userAuth);*//*

                  Application.Current.MainPage = new Menu(user);      
              }*/
        }
    }
}
