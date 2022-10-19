using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.DataGrid;
using Newtonsoft.Json;
using System.Net.Http;

namespace Andro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersGrid : ContentPage
    {
        public UsersGrid()
        {
            InitializeComponent();
            TableInfo();
        }

        private async void TableInfo()
        {
                        DataGrid UGrid = new DataGrid();


            string url = "https://apis.api-mauijobs.site/Users";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            HttpContent responseContent = response.Content;
            var a = await responseContent.ReadAsStringAsync();

            User[] UserItems = JsonConvert.DeserializeObject<User[]>(a);
            
            UGrid.ItemsSource = UserItems;

        }
    }
}