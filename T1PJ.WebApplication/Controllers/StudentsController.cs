using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Students;
using T1PJ.Repository.Services.Students;

namespace T1PJ.WebApplication.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _service;

        public StudentsController(IMapper mapper, IStudentService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search()
        {
            List<Student> students = await _service.GetAll();
            var model = _mapper.Map<List<IndexModel>>(students);
            return PartialView("_Search", model);
        }

        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel
            {
                Dob = DateOnly.FromDateTime(DateTime.Now),
            };
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _mapper.Map<Student>(model);
                if (await _service.Create(student) != null)
                {
                    return Json(new { status = "success" });
                }
            }
            return PartialView("_Create", model);
        }

        public IActionResult Edit(int id)
        {
            if (_service.GetStudentById(id) == null)
            {
                return null;
            }
            var result = _service.GetStudentById(id);
            EditViewModel model = _mapper.Map<EditViewModel>(result);
            return PartialView("_Edit", model);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LastUpdated = DateTime.Now;
                var student = _mapper.Map<Student>(model);
                if (await _service.Update(student) != null)
                {
                    return Json(new { status = "success" });
                }
            }
            return PartialView("Students\\_Edit", model);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Json(new { status = "success" });
        }

        public IActionResult Details(int id)
        {
            if (_service.GetStudentById(id) == null)
            {
                return null;
            }
            var result = _service.GetStudentById(id);

            return PartialView("_Details", _mapper.Map<EditViewModel>(result));
        }
    }
}
