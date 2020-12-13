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
            List<FootbalClub> list = await FootballRepo.GetTeam(Team);
            list_football = list;
            Console.WriteLine(list[0].intFormedYear);
            Console.WriteLine(list[0].strLeague);
            Console.WriteLine(list[0].strStadium);
            Console.WriteLine(list[0].strStadiumThumb);
            Console.WriteLine(list[0].strTeam);
            NaamTeam.Text = list[0].strTeam.ToUpper();
            NaamLeague.Text = list[0].strLeague;
            NaamStadium.Text = list[0].strStadium;
            Getevent( list_football[0].idTeam);



        }
        private async Task Getevent(string teamid)
        {
            List<Events> list = await FootballRepo.GetEvents(teamid);


            Hometeam.Text = list[0].strHomeTeam;
            Awayteam.Text = list[0].strAwayTeam;

        }

        void BtnStadium_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DetailPage(list_football));
        }

        void BtnEvent_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Next_event(list_football[0].idTeam,list_football[0].strTeam));
        }


    }
}
