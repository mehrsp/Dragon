using Rosentis.Core;
using Rosentis.DomainModel.Products;
using Rosentis.DomainModel.Reports;
using System.Collections.Generic;

namespace Rosentis.Persistance.Core.Products
{
    public interface IProductRepository 
    {
        //Product SaveOrUpdate(Product product);
        decimal MaxPrice(Criteria criteria);
        //List<PieChart> GetTopsByPrice();
        //List<PieChart> GetTopsByPopularity();
        //List<LineChart> GetSoldByDays(int days);
        //List<LineChart> GetSoldByMonth(int month);
    }
}