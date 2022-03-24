using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoBadges
{
    public class Repository
    {
        private static void Main() { }
        private readonly Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>(); // New Dictonary
        public Dictionary<int, List<string>> GetDictonary() 
        {
            return _doorAccess;
        }
        public void AddBadge(Badges badge) 
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }
        public bool CreateNewBadge(Badges badge)
        {
            int startingCount = _doorAccess.Count;
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);

            bool wasAdded = (_doorAccess.Count > startingCount);
            return wasAdded;
        }
        public Badges GetBadgeByID(int idNum)
        {
            if (_doorAccess.ContainsKey(idNum))
            {
                Badges badge = new Badges(idNum)
                {
                    DoorAccess = _doorAccess[idNum]
                };
                return badge;
            }
            return null;
        }
        public void GiveAccess(int badgeid, string doorAccess) // Adds A Door
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }
        public void RemoveAccess(int badgeid, string doorAccess) // Remove A Door
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Remove(doorAccess);
        }
    }
}