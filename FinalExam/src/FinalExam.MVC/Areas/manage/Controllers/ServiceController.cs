using FinalExam.Business.CustomExceptions.ServiceExceptions;
using FinalExam.Business.PaginationHelper;
using FinalExam.Business.Services.Interfaces;
using FinalExam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serivice;

        public ServiceController(IServiceService serivice)
        {
            _serivice = serivice;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var services = await _serivice.GetAllAsync();
        //    return View(services);
        //}

        public async Task<IActionResult> Index(int page = 1)
        {
            page = page < 1 ? 1 : page;

            var serviceQuery = _serivice.GetQuery();

            var paginated = PaginatedList<Service>.Create(serviceQuery, page, 2);

            return View(paginated);
        }

        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid) return View(service);
            try
            {
                await _serivice.CreateAsync(service);
            }
            catch (ServiceRequiredImageException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(service);
            }
            catch (ServiceImageContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(service);
            }
            catch (ServiceImageLengthException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(service);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var wanted = await _serivice.GetAsync(x => x.Id == id);
            if (wanted is null) return NotFound();
            return View(wanted);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> Update(Service service)
        {
            if (!ModelState.IsValid) return View(service);
            try
            {
                await _serivice.UpdateAsync(service);
            }
            catch (ServiceNotFoundException)
            {
                return NotFound();
            }
            catch (ServiceImageContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(service);
            }
            catch (ServiceImageLengthException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(service);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _serivice.SoftDeleteAsync(id);
            }
            catch (ServiceNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> HardDelete(int id)
        {
            var wanted = await _serivice.GetAsync(x => x.Id == id);
            if (wanted is null) return NotFound();
            return View(wanted);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public async Task<IActionResult> HardDelete(Service service)
        {
            try
            {
                await _serivice.HardDeleteAsync(service.Id);
            }
            catch (ServiceNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
