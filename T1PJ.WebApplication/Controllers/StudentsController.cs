using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Paginations;
using T1PJ.DataLayer.Model.Students;
using T1PJ.Repository.Services.Students;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<IActionResult> Index(int? id)
        {
            var students = await _service.GetAll();
            if (id != null)
            {
                var model1 = _mapper.Map<List<IndexModel>>(await _service.GetStudentsOfClass((int)id));
                return View(model1);
            }
            var model = _mapper.Map<List<IndexModel>>(students);
            return View(model);
        }

        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel
            {
                Dob = DateOnly.FromDateTime(DateTime.Now),
            };
            return View(model);
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
                    return Json(new { status = true });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await _service.GetStudentById(id) == null)
            {
                return Json(new { status = false });
            }
            var result = await _service.GetStudentById(id);
            EditViewModel model = _mapper.Map<EditViewModel>(result);
            return View(model);
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
                    return Json(new { status = true });
                }
            }
            return View(model);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Json(new { status = true });

            } catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await _service.GetStudentById(id) == null)
            {
                return Json(new { status = false }); 
            }
            var result = await _service.GetStudentById(id);

            return View(_mapper.Map<EditViewModel>(result));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> LoadTable(Pagination<IndexModel> model)
        {
            var results = await _service.GetAll();
            int pageSize = model.Length != null ? Convert.ToInt32(model.Length) : 0;
            int skip = model.Start != null ? Convert.ToInt32(model.Start) : 0;
            int recordsTotal = 0;
            var customerData = _mapper.Map<List<IndexModel>>(results);
            //if (!(string.isnullorempty(sortcolumn) && string.isnullorempty(sortcolumndirection)))
            //{
            //    customerdata = customerdata.orderby(sortcolumn + " " + sortcolumndirection);
            //}
            if (!string.IsNullOrEmpty(model.Search.Value))
            {
                customerData = customerData.Where(m => m.FullName.Contains(model.Search.Value)
                                            || m.Address.Contains(model.Search.Value)).ToList();
            }
            recordsTotal = customerData.Count();
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = model.Draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Json(jsonData);

        }
    }
}
