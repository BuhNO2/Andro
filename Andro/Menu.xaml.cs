using System;

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

            FormFilling(user);
        }

        private void UpdateBut(object sender, EventArgs e)
        {
            FormFilling(user);
        }

        private void FormFilling(User user)
        {
            TextName.Text = user.Name;
            TextSurname.Text = user.Surname;
            TextPatronomic.Text = user.Patronomic;
            TextDateofBirth.Text = user.DateofBirth.ToString();
            TextEnterprice.Text = user.Enterprice;
        }

        private void SaveUserChanges()
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

             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://apis.api-mauijobs.site/Auth?" + jsonString);
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

        private void SaveChangesUser_Clicked(object sender, EventArgs e)
        {
            SaveUserChanges();
        }
    }
}