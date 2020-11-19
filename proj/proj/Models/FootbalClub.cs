using System;
using System.Collections.Generic;

namespace proj.Models
{
    public class FootbalClub
    {

        public string strTeam { get; set; }
        public string intFormedYear { get; set; }
        public string strLeague { get; set; }
        public string strStadium { get; set; }
        public string strStadiumThumb { get; set; }
        public string strStadiumDescription { get; set; }

        public FootbalClub()
        {
        }

        public static implicit operator List<object>(FootbalClub v)
        {
            throw new NotImplementedException();
        }
    }
}
