using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Model.Classes;
using T1PJ.DataLayer.Model.Students;
using T1PJ.Repository.Services.Classes;
using T1PJ.Repository.Services.Students;

namespace T1PJ.WebApplication.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;

        public ClassesController(IMapper mapper, IClassService classService, IStudentService studentService)
        {
            _mapper = mapper;
            _classService = classService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var model = _mapper.Map<List<DataLayer.Model.Classes.IndexModel>>(await _classService.GetAll());
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var students = await _studentService.GetAll();
            ViewBag.StudentSelectList = new SelectList(
                    items: students,
                    dataValueField: nameof(Student.Id),
                    dataTextField: nameof(Student.FullName)
                );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] string Name, [FromForm] List<string> StudentSelectList)
        {
            if (ModelState.IsValid)
            {
                var results = new List<StudentClass>();
                if (StudentSelectList.Count > 0)
                {
                    foreach (var item in StudentSelectList)
                    {
                        results.Add(new StudentClass { StudentId = Int32.Parse(item) });
                    }
                }
                var model = new DataLayer.Model.Classes.CreateViewModel { Name = Name, StudentClasses = results };
                try
                {
                    await _classService.Create(_mapper.Map<Class>(model));
                    return Json(new { status = true });
                } catch (Exception ex)
                {
                    return Json(new {status = false, message = ex.Message});
                }
            }
            return View();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _classService.Delete(id);
                return Json(new { status = true });

            } catch (Exception ex)
            {
                return Json(new { status = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await _classService.GetClassById(id) == null)
            {
                return Json(new { status = false });
            }
            var result = await _classService.GetClassById(id);
            var ids = new List<int>();
            if (result.StudentClasses?.Count > 0)
            {
                foreach (var item in result.StudentClasses)
                {
                    ids.Add(item.StudentId);
                }
            }
            ViewBag.StudentSelectList = new SelectList(
                    items: await _studentService.GetAll(),
                    dataValueField: nameof(Student.Id),
                    dataTextField: nameof(Student.FullName)
                );

            var model = _mapper.Map<DataLayer.Model.Classes.EditViewModel>(result);
            model.StudentSelectList = ids;
            return View(model);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] int Id, [FromForm] string Name, [FromForm] List<string> StudentSelectList)
        {
            if (ModelState.IsValid)
            {
                var results = new List<StudentClass>();
                foreach (var item in StudentSelectList)
                {
                    results.Add(new StudentClass { StudentId = Int32.Parse(item), ClassId = Id });
                }
                try
                {
                    await _classService.Update(_mapper.Map<Class>(new DataLayer.Model.Classes.EditViewModel { Id = Id, Name = Name, StudentClasses = results}));
                    return Json(new { status = true });
                } catch (Exception ex)
                {
                    return Json(new { status = false, message =  ex.Message });
                }
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var c = await _classService.GetClassById(id);
            return View(_mapper.Map<DataLayer.Model.Classes.EditViewModel>(c));
        }
    }
}
