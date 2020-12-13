using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using proj.Models;
using proj.Repos;
using Xamarin.Forms;

namespace proj.Views
{
    public partial class Next_event : ContentPage
    {
        public string teamid { get; set; }
        public string team { get; set; }
        public List<Events> list { get; set; }
        public Next_event(string teamid,string team)
        {
            InitializeComponent();
            this.teamid = teamid;
            this.Title = team;
            
            Getevent();
        }

        private async Task Getevent()
        {
            list= await FootballRepo.GetEvents(teamid);
            
            Hometeam.Text = list[0].strHomeTeam;
            Awayteam.Text = list[0].strAwayTeam;
            Shedule.Source = list[0].strthumb;
            
        }

        async void BtnBETTING_Clicked(System.Object sender, System.EventArgs e)
        {

            Trellocard card = new Trellocard();
            try
            {
                int Hometeam = Int32.Parse(BETTING_HOMETEAM.Text);
                int Awayteam = Int32.Parse(BETTING_AWAYTEAM.Text);
                card.Name = list[0].strHomeTeam + "-" + list[0].strAwayTeam + " = " + BETTING_HOMETEAM.Text + "-" + BETTING_AWAYTEAM.Text;
                await FootballRepo.AddBetting("5fbf760ec952e73423a16be3", card);
                Navigation.PushAsync(new MainPage());
            }

            catch (FormatException)
            {
                await DisplayAlert("ERROR", "ONLY NUMBERS(1,2,3...)", "OK");
            }
            
            
        }
    }
}
