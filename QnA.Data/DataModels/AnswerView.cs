﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Data.DataModels
{
    public class AnswerView
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string UserId { get; set; }
        public bool IsBestSolution { get; set; }

        public string ProfileImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }

    }
}
