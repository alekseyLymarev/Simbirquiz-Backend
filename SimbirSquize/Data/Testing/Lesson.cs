using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data.Testing
{
    [Table("lessons")]
    public class Lesson : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Content { get; set; }
        
        public Guid CourseId { get; set; }
    }
}