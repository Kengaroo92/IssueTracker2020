namespace IssueTracker2020.Models.ChartModels
{
    public class BarChart
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }

    public class DonutChart
    {
        public string Label { get; set; }

        public int Value { get; set; }
    }
}