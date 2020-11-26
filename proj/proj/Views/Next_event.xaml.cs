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
        public Next_event(string teamid)
        {
            InitializeComponent();
            this.teamid = teamid;
            Getevent();
        }

        private async Task Getevent()
        {
            List<Events> list = await FootballRepo.GetEvents(teamid);
            Hometeam.Text = list[0].strHomeTeam;
            Awayteam.Text = list[0].strAwayTeam;
            
        }

        async void BtnFeedback_Clicked(System.Object sender, System.EventArgs e)
        {
         
            Trellocard card = new Trellocard();
            card.Name= Feedback.Text;
            await FootballRepo.AddFeedback("5fbf760ec952e73423a16be3", card);
            Navigation.PushAsync(new MainPage());
        }
    }
}
