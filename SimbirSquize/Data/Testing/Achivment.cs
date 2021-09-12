using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data
{
    [Table("achivments")]
    public class Achivment
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string ImageSrc { get; set; }
    }
}