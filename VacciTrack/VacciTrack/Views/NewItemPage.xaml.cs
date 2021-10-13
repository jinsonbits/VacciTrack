using System;
using System.Collections.Generic;
using System.ComponentModel;
using VacciTrack.Models;
using VacciTrack.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacciTrack.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}