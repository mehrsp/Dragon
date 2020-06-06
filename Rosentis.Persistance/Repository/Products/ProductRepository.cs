using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using Rosentis.Persistance.Core.Products;
using Rosentis.DomainModel.Products;
using System.Data.Entity;
using Rosentis.Core;
using Rosentis.DomainModel.Reports;
using Rosentis.Persistance.Facade;

namespace Rosentis.Persistance.Repository.Products
{
    public class ProductRepository : IProductRepository
	{
        private List<Expression<Func<Product, object>>> updateNavigation;
		internal RosentisContext context;
		public ProductRepository(DbContext dataContext)
		{
        }
        public decimal MaxPrice(Criteria criteria)
        {
            ParameterExpression argParam = Expression.Parameter(typeof(Product));
            var t = criteria.GetExpression(argParam);
            Expression nameProperty = Expression.Property(argParam, "Name");
            Expression namespaceProperty = Expression.Property(argParam, "Namespace");
            var val1 = Expression.Constant("Modules");
            var val2 = Expression.Constant("Namespace");
            Expression e1 = Expression.Equal(nameProperty, val1);
            Expression e2 = Expression.Equal(namespaceProperty, val2);
            var andExp = Expression.AndAlso(e1, e2);
            var lambda = Expression.Lambda<Func<Product, bool>>(andExp, argParam);
            return context.Products.Where(lambda).Max(x=>x.Price);
        }

        //public List<PieChart> GetTopsByPrice()
        //{
        //    var test = DataContext.Set<InvoiceDetails>()
        //        .GroupBy(a => a.ProductNumber)
        //        .Select(g => new { g.Key, Price = g.Sum(a => a.Price) }).OrderByDescending(x => x.Price).Take(10).ToList();
        //    var list = new List<PieChart>();
        //    foreach (var item in test)
        //    {
        //        var id = long.Parse(item.Key);
        //        var product = DataContext.Set<Product>().FirstOrDefault(x => x.Id == id);
        //        var title = item.Key;
        //        if (product != null)
        //        {
        //            title = product.Name;
        //        }
        //        int percentage = 0;
        //        if (item.Price > 0)
        //        {
        //            percentage = (int)Math.Round(item.Price * (decimal)100.0 / test.Sum(x => x.Price));
        //        }
        //        list.Add(new PieChart(title + "\n" + item.Price.ToString("#,##0") + " تومان", item.Price, percentage));
        //    }
        //    return list;
        //}
        //public List<PieChart> GetTopsByPopularity()
        //{
        //    var test = DataContext.Set<Product>().OrderByDescending(x => x.LikeCount).Take(10).ToList();
        //    var list = new List<PieChart>();
        //    foreach (var item in test)
        //    {
        //        int percentage = 0;
        //        if (item.LikeCount > 0)
        //        {
        //            percentage = (int)Math.Round(item.Price * (decimal)100.0 / test.Sum(x => x.Price));
        //        }
        //        list.Add(new PieChart(item.Name + "\n❤ " + item.LikeCount, item.LikeCount, percentage));
        //    }
        //    return list;
        //}

        //public List<LineChart> GetSoldByDays(int days)
        //{
        //    var beginDate = DateTime.Now.AddDays((-1) * days);
        //    var endDate = DateTime.Now;
        //    var test = DataContext.Set<InvoiceDetails>().Where(x=>x.CreatedDate> beginDate)
        //        .GroupBy(a => EntityFunctions.TruncateTime(a.CreatedDate))
        //        .Select(g => new { g.Key, Price = g.Sum(a => a.Price) }).OrderBy(x=>x.Key).ToList();
        //    var list = new List<LineChart>();
        //    int counter = 0;
        //    var dates = new List<DateTime>();
        //    for (var dt = beginDate; dt <= endDate; dt = dt.AddDays(1))
        //    {
        //        counter++;
        //        //var date = dt.StartOfDay();
        //        //var item = test.FirstOrDefault(x => x.Key.Value == date);
        //        //if (item != null)
        //        //{
        //        //    list.Add(new LineChart(counter.ToString(), counter, item.Price.ToString("#,##0") + " تومان", item.Price));
        //        //}
        //        //else
        //        //{
        //        //    list.Add(new LineChart(counter.ToString(), counter, "0 تومان", 0));
        //        //}
        //    }
        //    return list;
        //}

        public List<LineChart> GetSoldByMonth(int month)
        {
            var list = new List<LineChart>();
            return list;
        }
    }
}
