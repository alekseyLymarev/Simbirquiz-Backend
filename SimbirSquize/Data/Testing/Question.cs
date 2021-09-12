using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data.Testing
{
    [Table("questions")]
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        
        public string QuestionText { get; set;}
        
        public Guid CourseId { get; set; }
        
        public string RightAnswerId { get; set; }
        
        [ForeignKey("TestId")]
        public virtual List<TestAnswer>? Answers { get; set; }
        
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}