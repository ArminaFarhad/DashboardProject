using DashboardProject.Models;
using DashboardProject.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DashboardProject.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DashboardDbContext _context;

        public DashboardRepository(DashboardDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dashboard>> GetDashboardAsync()
        {
            return await _context.Dashboard.ToListAsync();
        }

        public async Task<Widget> GetWidgetAsync(int Id)
        {
            return await _context.Widget.Where(q => q.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Widget>> GetWidgetsAsync()
        {
            return await _context.Widget.ToListAsync();
        }

        public async Task<List<DashboardWidget>> GetDashboardWidgetAsync(int DashboardId)
        {
            var dashboardWidgets = await _context.DashboardWidgets.Where(q => q.DashboardId == DashboardId)
                 .Include(q => q.Widget)
                 .ToListAsync();

            return dashboardWidgets;
        }

        public async Task SaveDashboardAsync(List<DashboardWidget> widgets)
        {
            var dashboardId = widgets.Select(q => q.DashboardId).FirstOrDefault();

            var oldDashBoardWidgets = await GetDashboardWidgetAsync(dashboardId);
            if (oldDashBoardWidgets != null)
            {
                foreach (var widget in oldDashBoardWidgets)
                {
                    _context.DashboardWidgets.Remove(widget);
                }
            }

            foreach (var widget in widgets)
            {
                await _context.DashboardWidgets.AddAsync(widget);
            }
        }
    }
}
