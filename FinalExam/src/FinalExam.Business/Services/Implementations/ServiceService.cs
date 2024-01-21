using FinalExam.Business.CustomExceptions.ServiceExceptions;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Core.Models;
using FinalExam.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IWebHostEnvironment _env;

        public ServiceService(IServiceRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task CommitAsync()
        {
            await _repository.CommitAsync();
        }

        public async Task CreateAsync(Service service)
        {
            if (service.ImageFile is null)
                throw new ServiceRequiredImageException("ImageFile", "Image is required!");

            if (service.ImageFile.Length > 2097152)
                throw new ServiceImageLengthException("ImageFile", "Image size must be lower than 2mb");

            if (service.ImageFile.ContentType != "image/jpeg" && service.ImageFile.ContentType != "image/png")
                throw new ServiceImageContentTypeException("ImageFile", "Upload only jpg(jpeg) or png format");

            service.ImageUrl = Helpers.FileManager.Save(_env.WebRootPath, "uploads/serviceImages", service.ImageFile);

            await _repository.CreateAsync(service);
            await _repository.CommitAsync();
        }

        public async Task<List<Service>> GetAllAsync(Expression<Func<Service, bool>>? expression = null, params string[]? includes)
        {
            return await _repository.GetAllAsync(expression, includes).ToListAsync();
        }

        public async Task<Service> GetAsync(Expression<Func<Service, bool>>? expression = null, params string[]? includes)
        {
            return await _repository.GetAsync(expression, includes);
        }

        public IQueryable<Service> GetQuery(Expression<Func<Service, bool>>? expression = null, params string[]? includes)
        {
            return _repository.GetAllAsync(expression, includes);
        }

        public async Task HardDeleteAsync(int id)
        {
            var wanted = await _repository.GetAsync(x => x.Id == id);
            if (wanted is null) throw new ServiceNotFoundException();

            Helpers.FileManager.Delete(_env.WebRootPath, "uploads/serviceImages", wanted.ImageUrl);

            _repository.Delete(wanted);
            await _repository.CommitAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var wanted = await _repository.GetAsync(x => x.Id == id);
            if (wanted is null) throw new ServiceNotFoundException();

            wanted.IsDeleted = !wanted.IsDeleted;
            await _repository.CommitAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            var exist = await _repository.GetAsync(x => x.Id == service.Id);
            if (exist is null) throw new ServiceNotFoundException();

            if (service.ImageFile is not null)
            {
                if (service.ImageFile.Length > 2097152)
                    throw new ServiceImageLengthException("ImageFile", "Image size must be lower than 2mb");

                if (service.ImageFile.ContentType != "image/jpeg" && service.ImageFile.ContentType != "image/png")
                    throw new ServiceImageContentTypeException("ImageFile", "Upload only jpg(jpeg) or png format");
                Helpers.FileManager.Delete(_env.WebRootPath, "uploads/serviceImages", exist.ImageUrl);
                exist.ImageUrl = Helpers.FileManager.Save(_env.WebRootPath, "uploads/serviceImages", service.ImageFile);
            }

            exist.Title = service.Title;
            exist.Description = service.Description;
            exist.TitleUrl = service.TitleUrl;
            exist.IsDeleted = service.IsDeleted;

            await _repository.CommitAsync();
        }
    }
}
