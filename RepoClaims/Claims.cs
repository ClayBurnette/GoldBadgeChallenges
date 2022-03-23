using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoClaims
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home,
        Theft
    }
    public class Claims
    {
        public Claims() { }
        public int ClaimID { get; set; }
        public TypeOfClaim Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public Claims(int claimId, TypeOfClaim type, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimId;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}