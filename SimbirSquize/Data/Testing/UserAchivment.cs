using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data
{
    public class UserAchivment : BaseEntity
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }
        
        [Key, Column(Order = 2)]
        public Guid AchivmentId { get; set; }
    }
}