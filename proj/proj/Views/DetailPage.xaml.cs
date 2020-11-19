using System;
using System.Collections.Generic;
using proj.Models;
using Xamarin.Forms;

namespace proj.Views
{
    public partial class DetailPage : ContentPage
    {
        public List<FootbalClub> List_football { get; set; }
        public DetailPage(List<FootbalClub>football_list)
        {
            this.List_football = football_list;

            InitializeComponent();
            GetInfo();
        }

        private void GetInfo()
        {
            PhotoStadium.Source = List_football[0].strStadiumThumb;
            StadiumInfo.Text = List_football[0].strStadiumDescription;
        }
    }
}
