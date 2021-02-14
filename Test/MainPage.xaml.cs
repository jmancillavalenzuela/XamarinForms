using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.Repository;
using Xamarin.Forms;

namespace Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ClientRepository clientRepo = new ClientRepository();
            var client = clientRepo.GetClients();
            listview.ItemsSource = client;
        }
    }
}
