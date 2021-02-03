using QnA.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA.Services.Services
{
   public interface ICategoryService
    {
        List<Category> GetCategories();

        int PostCategory(Category category);
        
        List<object> GetCategoryQuestionLookup();
        
        List<object> SearchCategories(string category);

    }
}
