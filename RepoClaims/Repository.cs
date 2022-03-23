using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoClaims
{
    public class Repository
    {   private static void Main() { }
        private readonly Queue<Claims> _claims = new Queue<Claims>();
        public Queue<Claims> GetList()
        {
            return _claims; 
        }
        public void AddClaim(Claims newClaim)
        {
            _claims.Enqueue(newClaim); 
        }
        public void RemoveClaim()
        {
            _claims.Dequeue(); 
        }
        public void IsValid(Claims claim) 
        {
            if (claim.DateOfClaim < claim.DateOfAccident)
                claim.DateOfClaim = claim.DateOfAccident;

            TimeSpan difference = claim.DateOfClaim - claim.DateOfAccident;
            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }
    }
}