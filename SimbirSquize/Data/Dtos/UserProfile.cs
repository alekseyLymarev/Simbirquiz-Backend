using System;
using System.ComponentModel.DataAnnotations;

namespace SimbirSquize.Data.Dtos
{
    public class UserProfile
    {
        [Key]
        public Guid UserId { get; set; }
        
        public double Coins { get; set; }
        
        public int Level { get; set; }
    }
}