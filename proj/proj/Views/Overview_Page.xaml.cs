using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using proj.Models;
using proj.Repos;

using Xamarin.Forms;

namespace proj.Views
{
    public partial class Overview_Page : ContentPage
    {
        public List<FootbalClub> list_football { get; set; }
        public string Team { get; set; }
        public Overview_Page(string Team)
        {
            InitializeComponent();
            this.Team = Team;
            GetInfo();
            

        }

        private async Task GetInfo()
        {
            List<FootbalClub> list = await FootballRepo.GetRegistrationsAsync(Team);
            list_football = list;
            Console.WriteLine(list[0].intFormedYear);
            Console.WriteLine(list[0].strLeague);
            Console.WriteLine(list[0].strStadium);
            Console.WriteLine(list[0].strStadiumThumb);
            Console.WriteLine(list[0].strTeam);
            NaamTeam.Text = list[0].strTeam;
            NaamLeague.Text = list[0].strLeague;
            NaamStadium.Text = list[0].strStadium;
            



        }

        void BtnStadium_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DetailPage(list_football));
        }
    }
}
