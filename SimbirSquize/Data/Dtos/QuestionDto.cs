using System;

namespace SimbirSquize.Data.Dtos
{
    public class QuestionDto
    {
        public string Text { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string RightOption { get; set; }
        
        public Guid CourseId { get; set; }
    }
}