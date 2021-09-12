using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SimbirSquize.Data.Testing
{
    [Table("topics")]
    public class Course : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string ImageSrc { get; set; }
        
        [ForeignKey("CourseId")]
        public List<Lesson> Lessons { get; set; }
    }
}