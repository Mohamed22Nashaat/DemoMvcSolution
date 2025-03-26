using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentsController(IDepartmentServices _departmentServices) : Controller
    {

        // GET Base URL/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _departmentServices.GetAllDepartments();
            return View(Departments);
        }
    }
}
