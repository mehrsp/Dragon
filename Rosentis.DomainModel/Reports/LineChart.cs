namespace Rosentis.DomainModel.Reports
{
    public class LineChart
    {
        public LineChart(string xAxisLabel, decimal xAxisValue,string yAxisLabel,decimal yAxisValue)
        {
            XAxisLabel = xAxisLabel;
            XAxisValue = xAxisValue;
            YAxisLabel = yAxisLabel;
            YAxisValue = yAxisValue;
        }
        public string XAxisLabel { get; set; }
        public decimal XAxisValue { get; set; }
        public string YAxisLabel { get; set; }
        public decimal YAxisValue { get; set; }
    }
}
