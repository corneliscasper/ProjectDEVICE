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
            //Console.WriteLine(list[0].intFormedYear);
        }
    }
}
