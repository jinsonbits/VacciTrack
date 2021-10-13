using System.ComponentModel;
using VacciTrack.ViewModels;
using Xamarin.Forms;

namespace VacciTrack.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}