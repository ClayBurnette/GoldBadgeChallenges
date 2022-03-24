using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoBadges
{
    public class Badges
    {
        public Badges() { }
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
        public Badges(int id)
        {
            BadgeID = id;
        }
        public Badges(int badgeid, List<string> doorAccess)
        {
            BadgeID = badgeid;
            DoorAccess = doorAccess;
        }
    }
}