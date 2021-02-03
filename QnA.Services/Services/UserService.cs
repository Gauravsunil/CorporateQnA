using AutoMapper;
using Dapper;
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
    public class UserService:IUserService
    {
        private readonly IDbConnection Db;
        private readonly IMapper Mapper;
        public UserService(IConfiguration configuration,IMapper mapper)
        {
            this.Db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            this.Mapper = mapper;
        }
        public List<UsersView> GetUsers()
        {
            var sql = "SELECT * FROM UsersView";
            return this.Mapper.Map<List<UsersView>>(this.Db.Query<QnA.Data.DataModels.UsersView>(sql).ToList());
        }

        public UsersView GetUser(string userId)
        {
            var sql = $"SELECT * FROM UsersView WHERE Id='{userId}'";
            return this.Mapper.Map<UsersView>(this.Db.Query<QnA.Data.DataModels.UsersView>(sql).FirstOrDefault());
        }

        public List<QuestionView> GetUserQuestions(string userId)
        {
            var sql = $"SELECT * FROM QuestionsView WHERE UserId='{userId}'";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }

        public List<UsersView> GetSearchUser(string userName)
        {
            var sql = $"SELECT * FROM UsersView WHERE UserName LIKE '{userName}%'";
           return this.Mapper.Map<List<UsersView>>(this.Db.Query<QnA.Data.DataModels.UsersView>(sql).ToList());
        }

        public List<AnswerView> GetAnswers(int questionId)
        {
            var sql = $"SELECT * FROM AnswersView WHERE QuestionId={questionId}";
            var answers=this.Mapper.Map<List<AnswerView>>(this.Db.Query<QnA.Data.DataModels.AnswerView>(sql).ToList());
            return answers;

        }
    }
}
