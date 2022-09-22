using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Andro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubMenuFlyout : ContentPage
    {
        public ListView ListView;

        public SubMenuFlyout()
        {
            InitializeComponent();

            BindingContext = new SubMenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class SubMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SubMenuFlyoutMenuItem> MenuItems { get; set; }

            public SubMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<SubMenuFlyoutMenuItem>(new[]
                {
                    new SubMenuFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new SubMenuFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new SubMenuFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new SubMenuFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new SubMenuFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}