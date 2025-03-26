using Demo.BLL.DataTransferObjects;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentServices _departmentServices, ILogger<DepartmentsController> _logger, IWebHostEnvironment _environment) : Controller
    {

        // GET Base URL/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _departmentServices.GetAllDepartments();
            return View(Departments);
        }

        #region Create Department
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid) //Server Side Validation
            {

                try
                {
                    int result = _departmentServices.AddDepartment(departmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Department not created");

                    }
                }
                catch (Exception ex)
                {

                    //Log Exception
                    if (_environment.IsDevelopment())
                    {
                        //1. Developmet => Log error in consloe and return same view wuth error message
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else
                    {
                        //2. Deployment => Log error in file | table and return error view
                        _logger.LogError(ex, ex.Message);

                    }
                }

            }

            return View(departmentDto);

            #endregion

        
        }
        #region Details Of Department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion
    }
}
