namespace Rosentis.DomainModel.Reports
{
    public class PieChart
    {
        public PieChart(string title,decimal value,int percentage)
        {
            Title = title;
            Value = value;
            Percentage = percentage;
        }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public int Percentage { get; set; }
    }
}
