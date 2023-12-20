using DashboardProject.Models;
using DashboardProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DashboardProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet(Name = "dashboarddd")]
        public async Task<List<Dashboard>> GetDashboardAsync()
        {
            return await _dashboardRepository.GetDashboardAsync();
        }

        [HttpGet(Name = "widget")]
        public async Task<Widget> GetWidgetAsync(int Id)
        {
            return await _dashboardRepository.GetWidgetAsync(Id);
        }

        [HttpGet(Name = "widgetlist")]
        public async Task<List<Widget>> GetWidgetsAsync()
        {
            return await _dashboardRepository.GetWidgetsAsync();
        }

        [HttpGet(Name = "dashboardWidget")]

        public async Task<List<DashboardWidget>> GetDashboardWidgetAsync(int DashboardId)
        {
            return await _dashboardRepository.GetDashboardWidgetAsync(DashboardId);
        }

        [HttpGet(Name = "save")]
        public async Task SaveDashboardAsync(List<DashboardWidget> widgets)
        {
            await _dashboardRepository.SaveDashboardAsync(widgets);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
