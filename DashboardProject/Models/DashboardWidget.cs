namespace DashboardProject.Models
{
    public class DashboardWidget
    {
        public int Id { get; set; }
        public int DashboardId { get; set; }
        public int WidgetId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Dashboard Dashboard { get; set; }
        public Widget Widget { get; set; }
    }
}
