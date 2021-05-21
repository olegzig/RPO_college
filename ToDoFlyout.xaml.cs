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

namespace RPO_college
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoFlyout : ContentPage
    {
        public ListView ListView;

        public ToDoFlyout()
        {
            InitializeComponent();

            BindingContext = new ToDoFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class ToDoFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ToDoFlyoutMenuItem> MenuItems { get; set; }

            public ToDoFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<ToDoFlyoutMenuItem>(new[]
                {
                    new ToDoFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new ToDoFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new ToDoFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new ToDoFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new ToDoFlyoutMenuItem { Id = 4, Title = "Page 5" },
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