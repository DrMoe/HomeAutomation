using Home_Automation.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Home_Automation.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeviceUtility _deviceUtility;

        public DeviceController(ILogger<HomeController> logger, IDeviceUtility deviceUtility)
        {
            _logger = logger;
            _deviceUtility = deviceUtility;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var devices = _deviceUtility.GetDevices();
            return View(devices);

        }

        [HttpGet]
        public async Task<IActionResult> ViewDevice()
        {
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            await _deviceUtility.SearchForNewDevices();
            return RedirectToAction("Index");
        }


    }
}