using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public enum TypeOfEvent
    {
        Golf = 1,
        Bowling = 2,
        AmusementPark = 3,
        Concert = 4
    }
    public class Outings
    {
        public Outings() { }
        public TypeOfEvent Type { get; set; }
        public int People { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent { get; set; }
        public Outings(TypeOfEvent type, DateTime dateOfEvent, int people, decimal costPerPerson, decimal costOfEvent)
        {
            Type = type;
            DateOfEvent = dateOfEvent;
            People = people;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }
    }
}