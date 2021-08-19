using SaundersRetail.Data;
using SaundersRetail.Models.Inventory;
using SaundersRetail.Models.InventorySale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Services
{
   public class InventoryService
    {
        
        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
            new Inventory()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                Quantity = model.Quantity,
                PurchasePrice = model.PurchasePrice,
                PurchaseDate = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.inventories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InventoryListItem> GetInventories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .inventories
                .Select(
                e =>
                new InventoryListItem
                {
                   
                    ProductID = e.ProductID,
                    ProductName = e.ProductName,
                    PurchasePrice = e.PurchasePrice,
                    Quantity = e.Quantity,                   
                    PurchaseDate = e.PurchaseDate
                }
            );
                return query.ToArray();
            }
        }
        public InventoryDetail GetInventoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .inventories
                        .Single(e => e.ProductID == id);
                return
                    new InventoryDetail
                    {
                        ProductID = entity.ProductID,
                        ProductName = entity.ProductName,
                        Quantity = entity.Quantity,
                        EndQuantity = entity.EndQuantity,
                        PurchaseDate = entity.PurchaseDate,
                        PurchasePrice = entity.PurchasePrice,
                       
                    };
            }
        }
        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .inventories
                        .Single(e => e.ProductID == model.ProductID);
                entity.ProductID = model.ProductID;
                entity.ProductName = model.ProductName;
                entity.Quantity = model.Quantity;
                entity.PurchasePrice = model.PurchasePrice;
                
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteInventory(int inventoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .inventories
                        .Single(e => e.ProductID == inventoryId);
                ctx.inventories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateInventorySale(InventorySaleCreate model)
        {
            var entity =
            new InventorySale()
            {
                SaleID = model.SaleID,
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                Quantity = model.Quantity
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.InventorySales.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

