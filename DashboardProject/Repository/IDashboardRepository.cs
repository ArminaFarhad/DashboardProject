using DashboardProject.Models;

namespace DashboardProject.Repository
{
    public interface IDashboardRepository
    {
        Task<List<Dashboard>> GetDashboardAsync();
        Task<List<DashboardWidget>> GetDashboardWidgetAsync(int DashboardId);
        Task<Widget> GetWidgetAsync(int Id);
        Task<List<Widget>> GetWidgetsAsync();
        Task SaveDashboardAsync(List<DashboardWidget> widgets);
    }
}
