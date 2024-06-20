using CapitalPlacement.Enums;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacement.Dtos.Applications
{
    public class CandidateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public required string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public required string Phone { get; set; }
        public Nationality Nationality { get; set; }
        public Countries CurrentResidence { get; set; }
        public int IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
