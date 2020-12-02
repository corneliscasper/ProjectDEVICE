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
            Player1.Source = ImageSource.FromResource("proj.Img." + "football-player-setting-ball" + ".png");
            Player2.Source = ImageSource.FromResource("proj.Img." + "football-player-attempting-to-kick-ball" + ".png");
            Player3.Source = ImageSource.FromResource("proj.Img." + "football-player-setting-ball" + ".png");
            Player4.Source = ImageSource.FromResource("proj.Img." + "football-player-attempting-to-kick-ball" + ".png");
            Goal2.Source= ImageSource.FromResource("proj.Img." + "soccer-goal" + ".png");
            Goal1.Source = ImageSource.FromResource("proj.Img." + "soccer-goal" + ".png");




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
            if (list == null)
            {
                await DisplayAlert("ERROR", "Incorrect teamname", "OK");
            }
            
            else
            {   
                Navigation.PushAsync(new Overview_Page(Team));
            }
        }

    }
}
