﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Models.Models
{
   public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string UserId { get; set; }
        public List<string> UpVotes { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
