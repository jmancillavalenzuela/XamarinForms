using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Repository;
using Test.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        public bool OnButtonClicked()
        {
            Client client = new Client
            {
                RUT = RUT.Text,
                Password = Password.Text
            };
            ClientRepository clientRepo = new ClientRepository();
            var hasAccess = clientRepo.LoginAccess(client);
            return hasAccess;
        }
    }
}