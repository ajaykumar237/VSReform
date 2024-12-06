using Microsoft.AspNetCore.Mvc;
using Reform.Models;

namespace Reform.Controllers
{
    public class EmployeeController : Controller
    {
        DAL.EmployeeDal objdal = new DAL.EmployeeDal();
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    EmployeeModel model = new EmployeeModel();
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Index (Models.EmployeeModel e1, string b1)
        //{
        //    int i = objdal.AddEmployee(e1);
        //    if (i == 1)
        //    {
        //        ViewBag.Message = "Employee Added";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Failed";
        //    }
        //    return View();
        //}



        public IActionResult Employees()
        {
            List<EmployeeDetailModel> model = new List<EmployeeDetailModel>();
            model = objdal.GetEmployee();
            return View(model);
        }


        

        public IActionResult Music()
        {
            List<MusicModel> model = new List<MusicModel>();
            model = objdal.GetMusic();
            return View(model);
        }
    }
}
