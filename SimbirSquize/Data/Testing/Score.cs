using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data
{
    [Table("scores")]
    public class Score
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }
        
        [Key, Column(Order = 2)]
        public Guid CourseId { get; set; }
        
        public int ScoreId { get; set; }
        
        public double RightCount { get; set; }
    }
}