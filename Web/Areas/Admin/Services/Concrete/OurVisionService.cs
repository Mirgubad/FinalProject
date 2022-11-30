using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.HomeMainSlider;
using Web.Areas.Admin.ViewModels.OurVision;

namespace Web.Areas.Admin.Services.Concrete
{
    public class OurVisionService : IOurVisionService
    {
        private readonly IOurVisionRepository _ourVisionRepository;
        private readonly IFileService _fileservice;
        private readonly ModelStateDictionary _modelState;

        public OurVisionService(IOurVisionRepository ourVisionRepository,
            IActionContextAccessor actionContextAccessor,
            IFileService fileservice)
        {
            _fileservice = fileservice;
            _ourVisionRepository = ourVisionRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<bool> CreateAsync(OurVisionCreateVM model)
        {
            if (!_modelState.IsValid) return false;
            var isExist = await _ourVisionRepository.AnyAsync(ov => ov.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This title already created");
                return false;
            }
            int maxSize = 1000;
            if (!_fileservice.CheckPhoto(model.Photo))
            {
                _modelState.AddModelError("Photo", "File must be image");
                return false;

            }
            else if (!_fileservice.MaxSize(model.Photo, maxSize))
            {
                _modelState.AddModelError("Photo", $"Photo size must be less than {maxSize}");
                return false;
            }
            var ourVision = new OurVision
            {
                CreatedAt = DateTime.Now,
                Description = model.Description,
                Title = model.Title,
                PhotoName = await _fileservice.UploadAsync(model.Photo)
            };

            await _ourVisionRepository.CreateAsync(ourVision);
            return true;
        }
    }
}
