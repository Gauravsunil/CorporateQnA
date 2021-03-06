﻿using QnA.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Services.Services
{
   public interface IUserService
    {
        List<UsersView> GetUsers();
        UsersView GetUser(string userId);
        List<QuestionView> GetUserQuestions(string userId);
        List<UsersView> GetSearchUser(string userName);
        List<AnswerView> GetAnswers(int questionId);


    }
}
