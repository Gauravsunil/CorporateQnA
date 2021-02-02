using AutoMapper;
using Newtonsoft.Json;
using QnA.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, QnA.Data.DataModels.Category>();
            CreateMap<QnA.Data.DataModels.Category, Category>();

            CreateMap<Question, QnA.Data.DataModels.Question>()
                .ForMember(d=>d.CategoryId,options=>options.MapFrom(s=>Convert.ToInt64(s.CategoryId)))
                .ForMember(d=>d.UpVotes,options=>options.MapFrom(s=>JsonConvert.SerializeObject(s.UpVotes)));
                
            CreateMap<QnA.Data.DataModels.Question, Question>()
                .ForMember(d=>d.UpVotes,options=>options.MapFrom(s=>JsonConvert.DeserializeObject<List<string>>(s.UpVotes)));

            CreateMap<Answer, QnA.Data.DataModels.Answer>()
                .ForMember(d => d.Likes, options => options.MapFrom(s => JsonConvert.SerializeObject(s.Likes)))
                .ForMember(d => d.Dislikes, options => options.MapFrom(s => JsonConvert.SerializeObject(s.Dislikes)));

            CreateMap<QnA.Data.DataModels.Answer, Answer>()
               .ForMember(d => d.Likes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Likes)))
               .ForMember(d => d.Dislikes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Dislikes)));

            CreateMap<QnA.Data.DataModels.AnswerView, AnswerView>()
                .ForMember(d => d.Likes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Likes)))
                .ForMember(d => d.Dislikes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Dislikes)));

            CreateMap<QnA.Data.DataModels.QuestionView, QuestionView>()
               .ForMember(d => d.UpVotes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.UpVotes)));
               

            CreateMap<QnA.Data.DataModels.UsersView, UsersView>()
                 .ForMember(d => d.Likes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Likes)))
                 .ForMember(d => d.Dislikes, options => options.MapFrom(s => JsonConvert.DeserializeObject<List<string>>(s.Dislikes)));

        }
    }
}
