using SaundersRetail.Data;
using SaundersRetail.Models.ProductSale;
using SaundersRetail.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Services
{
   public class SaleService
    {
        private readonly Guid _userId;
        public SaleService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSale(SaleCreate model)
        {
            var entity =
            new Sale()
            {
                SaleID = model.SaleID,
                CashierID = _userId,
                SaleDate= DateTimeOffset.Now
                
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sales.Add(entity);
                bool AddProducts = ctx.SaveChanges() == 1;               
                model.SaleID = entity.SaleID;
                return AddProducts;
            }
        }        
        public IEnumerable<SaleListItem> GetSales()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Sales
                .Where(e => e.CashierID == _userId).ToList()
                .Select(
                e =>
                new SaleListItem
                {
                    SaleID = e.SaleID,
                    SubTotal = e.SubTotal,
                    Tax = e.Tax,
                    Total = e.Total, 
                    SaleDate= e.SaleDate
                }
            );
                return query.ToArray();
                
            }
        }
        public SaleDetail GetSaleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == id && e.CashierID == _userId);
                return
                    new SaleDetail
                    {
                        SaleID = entity.SaleID,
                        SubTotal= entity.SubTotal,
                        Tax = entity.Tax,
                        Total = entity.Total,
                        SaleDate = entity.SaleDate,
                        
                    };
            }
        }
        public bool UpdateSale(SaleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID==model.SaleID && e.CashierID == _userId);                             
                entity.SaleDate = DateTimeOffset.UtcNow;                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateProductSale(ProductSaleCreate model)
        {
            var entity =
            new ProductSale()
            {
                SaleID = model.SaleID,
                ID = model.ID,
                ProductName = model.ProductName,
                Quantity= model.Quantity
                             
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductSales.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSale(int saleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == saleId && e.CashierID == _userId);
                ctx.Sales.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
