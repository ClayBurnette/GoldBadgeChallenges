using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repository
{
    public class Repository
    {
        private static void Main() { }
        private readonly List<Outings> _outings = new List<Outings>();
        public void AddOutings(Outings outings)
        {
            _outings.Add(outings);
        }
        public bool AddOutingsBool(Outings outingFun)
        {
            int startingOuting = _outings.Count();
            _outings.Add(outingFun);

            bool wasAdded = (_outings.Count > startingOuting) ? true : false;
            return wasAdded;
        }
        public decimal TotalOutingCosts()
        {
            decimal totalCost = 0;
            foreach (Outings outings in _outings)
            {
                totalCost += outings.CostOfEvent;
            }
            return totalCost;
        }
        public decimal TotalOutingCostsPerType(TypeOfEvent type)
        {
            decimal totalCostPerEvent = 0;
            foreach (Outings outings in _outings)
            {
                if (outings.Type == type)
                {
                    totalCostPerEvent += outings.CostOfEvent;
                }
            }
            return totalCostPerEvent;
        }
        public List<Outings> ListOutings()
        {
            return _outings;
        }
    }
}