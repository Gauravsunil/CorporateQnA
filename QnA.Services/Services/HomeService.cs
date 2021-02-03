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
   public class HomeService:IHomeService
    {
        private readonly IDbConnection Db;
        private readonly IMapper Mapper;
        public HomeService(IConfiguration configuration,IMapper mapper)
        {
            this.Db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            this.Mapper = mapper;
        }

        public List<QuestionView> GetQuestions()
        {
            var sql = $"SELECT * FROM QuestionsView";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }

        public List<QuestionView> GetQuestionsByCategory(int categoryId)
        {
            var sql = $"SELECT * FROM QuestionsView WHERE CategoryId={categoryId}";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());

        }

        public int PostQuestion(Question question)
        {
            return (int)this.Db.Insert<QnA.Data.DataModels.Question>(this.Mapper.Map<QnA.Data.DataModels.Question>(question));
        }


        public int PostAnswer(Answer answer)
        {
            return (int)this.Db.Insert<QnA.Data.DataModels.Answer>(this.Mapper.Map<QnA.Data.DataModels.Answer>(answer)); 
        }

        public void PostLikes(List<string> likes,int answerId)
        {
            var answer = this.Mapper.Map<Answer>(this.Db.Get<QnA.Data.DataModels.Answer>(answerId));
            answer.Likes = likes;
            this.Db.Update<QnA.Data.DataModels.Answer>(this.Mapper.Map<QnA.Data.DataModels.Answer>(answer));
        }
        public void PostDislikes(List<string> dislikes, int answerId)
        {
            var answer = this.Mapper.Map<Answer>(this.Db.Get<QnA.Data.DataModels.Answer>(answerId));
            answer.Dislikes = dislikes;
            this.Db.Update<QnA.Data.DataModels.Answer>(this.Mapper.Map<QnA.Data.DataModels.Answer>(answer));
        }

        public void PostUpVotes(List<string> upVotes,int questionId)
        {
            var question = this.Mapper.Map<Question>(this.Db.Get<QnA.Data.DataModels.Question>(questionId));
            question.UpVotes=upVotes;
            this.Db.Update<QnA.Data.DataModels.Question>(this.Mapper.Map<QnA.Data.DataModels.Question>(question));
        }

        public void PostViews(int views,int questionId)
        {
            var question = this.Mapper.Map<Question>(this.Db.Get<QnA.Data.DataModels.Question>(questionId));
            question.Views++;
            this.Db.Update<QnA.Data.DataModels.Question>(this.Mapper.Map<QnA.Data.DataModels.Question>(question));
        }

        public List<QuestionView> GetSearchQuestions(string questionTitle)
        {
            var sql = $"SELECT * FROM QuestionsView WHERE Title LIKE '{questionTitle}%'";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }
        public void PostBestSolution(bool isBestSolution, int answerId)
        {
            var answer = this.Mapper.Map<Answer>(this.Db.Get<QnA.Data.DataModels.Answer>(answerId));
            answer.IsBestSolution = isBestSolution;
            this.Db.Update<QnA.Data.DataModels.Answer>(this.Mapper.Map<QnA.Data.DataModels.Answer>(answer));
        }

        public List<QuestionView> GetQuestionsByDate(int date)
        {
            var sql = $"SELECT * FROM QuestionsView WHERE CreatedOn>'{DateTime.Now.AddDays(-date)}'";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }

        public List<QuestionView> GetSolvedQuestions()
        {
            var sql = $"SELECT * FROM QuestionsView WHERE BestSolution IS NOT NULL";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }
        public List<QuestionView> GetUnSolvedQuestions()
        {
            var sql = $"SELECT * FROM QuestionsView WHERE BestSolution IS NULL";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }
        public List<QuestionView> GetUserParticipation(string userId)
        {
            var sql = $"SELECT * FROM QuestionsView WHERE AnswersUserId='{userId}'";
            return this.Mapper.Map<List<QuestionView>>(this.Db.Query<QnA.Data.DataModels.QuestionView>(sql).ToList());
        }
    }
}
