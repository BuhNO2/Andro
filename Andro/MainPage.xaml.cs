using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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

        private string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(hash).Replace("-", "");
        }

        private string _isAuth = "2";
        private async void AuthClicked(object sender, EventArgs e)
        {
            /*            string postParameters = "login=" + GetHash(LoginUser.Text) + "&password=" + GetHash(PassUser.Text);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Auth?" + postParameters);
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                _isAuth = reader.ReadToEnd();
                            }
                        }
                        response.Close(); */

            if (_isAuth != "")
            {
                //var obj = JsonConvert.DeserializeObject<User>(_isAuth);
                var obj = new User()
                {
                    Password = "2",
                    Login = "1",
                    ID = 2,
                    Name = "ABa",
                    Surname = "11",
                    Patronomic = "fff",
                    Enterprice = "addd.",
                    DateofBirth = new DateTime()
                };
                await this.Navigation.PushModalAsync(new Menu(obj));
                //переход
            }
        }
    }
}
