using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Andro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        
        private async void AuthClicked(object sender, EventArgs e)
        {
            AuthBut.IsEnabled = false;

            string url = "https://apis.api-mauijobs.site/Auth";

            User userAuth = new User()
            {
                ID = 1,
                Login = LoginUser.Text,
                Password = HashingString.HashingPassword(PassUser.Text),
                Enterprice = "",
                Surname = "",
                Name = "",
                Patronomic = "",
                DateofBirth = "",
                RoleId = 3
            };

            string json = JsonConvert.SerializeObject(userAuth);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();
                CurrentUser.user = JsonConvert.DeserializeObject<User>(a);

                await this.Navigation.PushModalAsync(new Menu());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверное имя пользователя или пароль!", "ОК");
                AuthBut.IsEnabled = true;
            }
            AuthBut.IsEnabled = true;
        }

    }
}

