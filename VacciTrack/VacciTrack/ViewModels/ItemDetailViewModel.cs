using VacciTrack.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VacciTrack.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private DateTime birthdate;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public DateTime BirthDate
        {
            get => birthdate;
            set => SetProperty(ref birthdate, value);
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                BirthDate = item.BirthDate;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
