using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimbirSquize.Data.Testing
{
    [Table("test_answers")]
    public class TestAnswer : BaseEntity
    {
        [Key, Column(Order = 0)]
        public Guid QuestionId { get; set; }
        
        [Key, Column(Order = 1)]
        public string Id { get; set; }
        
        public string Text { get; set; }
        
        public Question Question { get; set; }
    }
}