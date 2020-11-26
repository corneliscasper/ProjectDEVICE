using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj.Models;
using proj.Repos;
using proj.Views;
using Xamarin.Forms;
 

namespace proj
{
    public partial class MainPage : ContentPage
    {
        public string Team { get; set; }
        public MainPage()
        {

            InitializeComponent();
            GetInfo();
        }

        private async Task GetInfo()
        {
            //List<FootbalClub> list = await FootballRepo.GetRegistrationsAsync("Arsenal");
            //Console.WriteLine(list[0].intFormedYear);
            
            
        }

        async void Btn_TEAM(System.Object sender, System.EventArgs e)
        {
            Team = entTeam.Text;
            List<Existingteam> list = await FootballRepo.GetExistingteam(Team);

            if (entTeam.Text == "")
            {
                await DisplayAlert("ERROR", "You need to give a teamname","OK");
            }
            else
            
                if (list[0].teams == null)
                {
                    await DisplayAlert("ERROR", "Teamname incorrect", "OK");
                }
            
            else
            {   
                Navigation.PushAsync(new Overview_Page(Team));
            }
        }

    }
}
