
using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using QnA.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QnA.Services.Services
{
   public class CategoryService:ICategoryService
    {
        private readonly IDbConnection Db;
        private readonly IMapper Mapper;
        public CategoryService(IConfiguration configuration,IMapper mapper)
        {
            this.Db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            this.Mapper = mapper;
        }

        public List<Category> GetCategories()
        {
            return this.Mapper.Map<List<Category>>(this.Db.GetAll<QnA.Data.DataModels.Category>().ToList());
        }

        public List<object> GetCategoryQuestionLookup()
        {
            var sql = "SELECT * FROM CategoriesView";
            return this.Db.Query<object>(sql).ToList();
        }

        public List<object> SearchCategories(string category)
        {
            var sql = $"SELECT * FROM CategoriesView WHERE Name LIKE '{category}%'";
            return this.Db.Query<object>(sql).ToList();
        }

        public int PostCategory(Category category)
        {
            return (int)this.Db.Insert<QnA.Data.DataModels.Category>(this.Mapper.Map<QnA.Data.DataModels.Category>(category));
        }

    }
}
