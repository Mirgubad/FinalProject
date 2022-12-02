﻿using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.LastestNews;

namespace Web.Areas.Admin.Services.Concrete
{
    public class LastestNewsService : ILastestNewsService
    {
        private readonly IFileService _fileService;
        private readonly ILastestNewsRepository _lastestNewsRepository;
        private readonly ModelStateDictionary _modelState;

        public LastestNewsService(IFileService fileService,
            ILastestNewsRepository lastestNewsRepository,
            IActionContextAccessor actionContextAccessor)
        {
            _fileService = fileService;
            _lastestNewsRepository = lastestNewsRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> CreateAsync(LastestNewsCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            int maxSize = 1000;
            if (!_fileService.CheckPhoto(model.Photo))
            {
                _modelState.AddModelError("Photo", "File must be image");
                return false;
            }
            else if (!_fileService.MaxSize(model.Photo, maxSize))
            {
                _modelState.AddModelError("Photo", $"Photo size must be less than {maxSize} kb");
                return false;
            }
            var lastetsNews = await _lastestNewsRepository.GetAllAsync();
            int order = lastetsNews.Count;
            if (order == 0)
            {
                order = 1;
            }
            else
            {
                order++;
            }
            var lastestNews = new LastestNews
                {
                    CreatedAt = DateTime.Now,
                    Title = model.Title,
                    Type = model.Type,
                    PhotoName = await _fileService.UploadAsync(model.Photo),
                    Order = order
                };

                await _lastestNewsRepository.CreateAsync(lastestNews);
           

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var lastestNews = await _lastestNewsRepository.GetAsync(id);
            await _lastestNewsRepository.DeleteAsync(lastestNews);
        }

        public async Task<LastestNewsIndexVM> GetAllAsync()
        {
            var lastestNews = await _lastestNewsRepository.GetAllAsync();
            var model = new LastestNewsIndexVM
            {
                LastestNews = lastestNews
            };
            return model;
        }

        public async Task<LastestNewsUpdateVM> GetUpdateModelAsync(int id)
        {
            var lastestNews = await _lastestNewsRepository.GetAsync(id);
            var model = new LastestNewsUpdateVM
            {
                Order = lastestNews.Order,
                Title = lastestNews.Title,
                Type = lastestNews.Type,
            };
            return model;
        }

        public async Task<bool> UpdateAsync(LastestNewsUpdateVM model)
        {
            var lastestNews = await _lastestNewsRepository.GetAsync(model.Id);
            if (!_modelState.IsValid) return false;
            lastestNews.Title = model.Title;
            lastestNews.ModifiedAt = DateTime.Now;
            lastestNews.Order = model.Order;
            lastestNews.Type = model.Type;

            if (model.Photo != null)
            {
                int maxSize = 1000;
                if (!_fileService.CheckPhoto(model.Photo))
                {
                    _modelState.AddModelError("Photo", "File must be image");
                    return false;
                }
                else if (!_fileService.MaxSize(model.Photo, maxSize))
                {
                    _modelState.AddModelError("Photo", $"Photo size must be less than {maxSize} kb");
                    return false;
                }
                _fileService.Delete(lastestNews.PhotoName);
                lastestNews.PhotoName = await _fileService.UploadAsync(model.Photo);
            }
            await _lastestNewsRepository.UpdateAsync(lastestNews);
            return true;
        }
    }
}
