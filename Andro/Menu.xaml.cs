
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Andro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {

        public Menu()
        {
            InitializeComponent();          
            Updating();
        }

        private void Updating()
        {
            TextName.Text = CurrentUser.user.Name;
            TextSurname.Text = CurrentUser.user.Surname;
            TextPatronomic.Text = CurrentUser.user.Patronomic;
            TextDateofBirth.Text = CurrentUser.user.DateofBirth;
            TextEnterprice.Text = CurrentUser.user.Enterprice;
        }

        private async void SaveUser()
        {
            string url = "https://apis.api-mauijobs.site/Users";
          
            SaveBut.IsEnabled = false;


            CurrentUser.user.Surname = TextSurname.Text;
            CurrentUser.user.Name = TextName.Text;
            CurrentUser.user.Patronomic = TextPatronomic.Text;
            CurrentUser.user.DateofBirth = TextDateofBirth.Text;
            CurrentUser.user.Enterprice = TextEnterprice.Text;

            string json = JsonConvert.SerializeObject(CurrentUser.user);
            HttpContent content = new StringContent(json);

            HttpClient client = new HttpClient();
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(@"application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var a = await responseContent.ReadAsStringAsync();
                CurrentUser.user = JsonConvert.DeserializeObject<User>(a);
                Updating();
                SaveBut.IsEnabled = true;
            }
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            Updating();
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            SaveUser();
        }

        private async void PickerSelected(object sender, EventArgs e)
        {

            if (SubMenu.SelectedIndex == 0)
            {
                await this.Navigation.PushModalAsync(new UsersGrid());
            }
            else if (SubMenu.SelectedIndex == 1)
            {

            }
            
         }
    }
}