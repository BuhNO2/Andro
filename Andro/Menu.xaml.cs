
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Andro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        User user;
        public Menu(User user)
        {
            InitializeComponent();
            this.user = user;
            Updating(user);
        }

        private void SaveData(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void UpdateBut(object sender, EventArgs e)
        {
            Updating(user);
        }

        private void Updating(User user)
        {
            TextName.Text = user.Name;
            TextSurname.Text = user.Surname;
            TextPatronomic.Text = user.Patronomic;
            TextDateofBirth.Text = user.DateofBirth.ToString();
            TextEnterprice.Text = user.Enterprice;
        }

        private void SaveUser()
        {
           /* bool isOkay;
            string jsonString = JsonSerializer.Serialize<User>(new User()
            {
                ID = user.ID,
                Name = TextName.Text,
                Surname = TextSurname.Text,
                Patronomic = TextPatronomic.Text,
                DateofBirth = DateTime.Parse(TextDateofBirth.Text),
                Enterprice = TextEnterprice.Text,
            });

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Users?" + jsonString);
            request.Method = "POST";
            request.ContentType = "text/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    isOkay = Convert.ToBoolean(reader.ReadToEnd());
                }
            }
            response.Close();*/


        }

    }
}