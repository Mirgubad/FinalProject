﻿using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Admin.ViewModels.MedicalDepartment;
using Web.Areas.Admin.ViewModels.Question;

namespace Web.Areas.Admin.Services.Abstract
{
    public interface IQuestionService
    {
        Task<bool> CreateAsync(QuestionCreateVM model);
        //Task<MedicalDepartmentIndexVM> GetAllAsync();
        Task<QuestionIndexVM> GetQuestionWithCategoryAsync();
        Task<bool> UpdateAsync(QuestionUpdateVM model);
        Task<List<SelectListItem>> GetCategoriesAsync();
        public Task<QuestionCreateVM> GetCategoriesCreateModelAsync();
        Task<QuestionUpdateVM> GetUpdateModelAsync(int id);
        Task DeleteAsync(int id);
    }
}
