using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj.Models;
using proj.Repos;
using Xamarin.Forms;
 

namespace proj
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetInfo();
        }

        private async Task GetInfo()
        {
            List<FootbalClub> list = await FootballRepo.GetRegistrationsAsync("Arsenal");
        }
    }
}
