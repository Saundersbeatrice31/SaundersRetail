using SaundersRetail.Data;
using SaundersRetail.Models.ProductSaleData;
using SaundersRetail.Models.SaleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Services
{
    public class SaleDataService
    {       
        public bool CreateSaleData(SaleDataCreate model)
        {
            var entity =
            new SaleData()
            {                                               
                ProductID = model.ProductID,
                Quantity = model.Quantity,
                PurchasePrice = model.PurchasePrice,
                PurchaseDate= DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.saleData.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SaleDataListItem> GetSaleData()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .saleData                
                .Select(
                e =>
                new SaleDataListItem
                {
                    SDID= e.SDID,
                    ProductID = e.ProductID,
                    Quantity = e.Quantity,
                    PurchasePrice = e.PurchasePrice,
                    //Tax = e.Tax,
                    PurchaseDate = e.PurchaseDate
                }
            );
                return query.ToArray();
            }
        }
        public SaleDataDetail GetSaleDataById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .saleData
                        .Single(e => e.ProductID == id );
                return
                    new SaleDataDetail
                    {
                        SDID = entity.SDID,
                        ProductID = entity.ProductID,
                        Quantity = entity.Quantity,
                        PurchasePrice= entity.PurchasePrice,
                        PurchaseDate = entity.PurchaseDate,
                        Tax = entity.Tax
                    };
            }
        }
        public bool UpdateSaleData(SaleDataEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .saleData
                        .Single(e => e.ProductID == model.ProductID );
                entity.SDID = model.SDID;
                entity.Quantity = model.Quantity;
                entity.PurchasePrice = model.PurchasePrice;
                entity.PurchaseDate = DateTimeOffset.UtcNow;                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSaleData(int saleDataId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .saleData
                        .Single(e => e.ProductID == saleDataId);
                ctx.saleData.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateProductSaleData(ProductSaleDataCreate model)
        {
            var entity =
            new ProductSaleData()
            {
                ID = model.ID,
                SDID = model.ID,
                ProductName = model.ProductName,
                Quantity = model.Quantity

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductSaleDatas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

