using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    class Time 
    {
        public long TeamID { get; set; }
        public string TeamName { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }

        public Time()
        {

        }

        public Time(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            TeamID = id;
            TeamName = name;
            CreateDate = createDate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;

        }
        



     }           
}

