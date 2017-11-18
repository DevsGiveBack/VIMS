using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TJS.VIMS.DAL;
using TJS.VIMS.ViewModel;

namespace TJS.VIMS.Controllers
{
    /// <summary>
    /// Testing Routings, Bindings, Etc.. 
    /// </summary>
    public class TestController : Controller
    {
        private IEmployeeRepository employeeRepository;
        private ILookUpRepository lookUpRepository;
        private IVolunteerInfoRepository volunteerInfoRepository;

        public TestController(IEmployeeRepository employeeRepository, ILookUpRepository lookUpRepository, IVolunteerInfoRepository volunteerInfoRepository)
        {
            this.employeeRepository = employeeRepository;
            this.lookUpRepository = lookUpRepository;
            this.volunteerInfoRepository = volunteerInfoRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public void Test1(int? x, string s)
        {

        }

        public void Test2(int? x)
        {

        }

        [Authorize]
        public ActionResult TestView()
        {
            MyViewModel vm = new MyViewModel();
            vm.countries = lookUpRepository.GetCountries();
            return View(vm);
        }

        public void TestVM()
        {
            VIMSDBContext context = new VIMSDBContext();

            VolunteerViewModel vm = new VolunteerViewModel(context.Locations.ToList(), context.Organizations.ToList());
            
        }
    }
}