using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Data.DataModels
{
    [Table("Answers")]
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public bool IsBestSolution { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
