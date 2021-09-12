using System;

namespace SimbirSquize.Data.Dtos
{
    public class ScoreDto
    {
        public Guid CourseId { get; set; }
        
        public int Score { get; set; }
        
        public double RightCount { get; set; }
    }
}