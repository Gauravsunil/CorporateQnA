using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Data.DataModels
{
    [Table("Categories")]

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
