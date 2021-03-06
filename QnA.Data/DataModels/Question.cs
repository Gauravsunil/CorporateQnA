﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QnA.Data.DataModels
{
    [Table("Questions")]
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
        public string UpVotes { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }

        public Question()
        {
            this.CreatedOn = DateTime.Now;
        }
    }
}
