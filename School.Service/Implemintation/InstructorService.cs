using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstractorRepository _instractorRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public InstructorService(IInstractorRepository instractorRepository, IHttpContextAccessor httpContextAccessor,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)
        {
            _instractorRepository = instractorRepository;
            _httpContextAccessor = httpContextAccessor;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Instractors", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            instructor.Image = baseUrl + imageUrl;
            try
            {
                await _instractorRepository.AddAsync(instructor);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteInstructorAsync(int id)
        {
            var instractor = await _instractorRepository.GetByIdAsync(id);
            if (instractor == null) return ("NotFound");
            var imageUrl = instractor.Image;
            var deleteResult = await _fileService.DeleteImage(imageUrl);
            if (!deleteResult) return "FailedToDeleteImage";
            try
            {
                await _instractorRepository.DeleteAsync(instractor);
                return "Success";
            }
            catch
            {
                return "failed";
            }
        }

        public async Task<string> EditInstructorAsync(Instructor instructor)
        {
            try
            {
                await _instractorRepository.UpdateAsync(instructor);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instractorRepository.GetByIdAsync(id);
        }

        public async Task<Instructor> GetByIdIncludeAsync(int id)
        {
            return await _instractorRepository.GetTableAsTracking().FirstOrDefaultAsync(x => x.InsId == id);
        }

        public async Task<List<Instructor>> GetInstactorsAsync()
        {
            return await _instractorRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<List<Instructor>> GetInstructorByDepartment(int DID)
        {
            return await _instractorRepository.GetTableNoTracking().Where(x => x.DID == DID).ToListAsync();
        }

        public async Task<bool> IsNameExcludeExists(string name, int id)
        {
            var instructor = await _instractorRepository.GetTableNoTracking().Where(x => x.IName == name && x.InsId != id).FirstOrDefaultAsync();
            if (instructor == null) return false;
            return true;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var instructor = await _instractorRepository.GetTableNoTracking().Where(x => x.IName == name).FirstOrDefaultAsync();
            if (instructor == null) return false;
            return true;
        }
    }
}
