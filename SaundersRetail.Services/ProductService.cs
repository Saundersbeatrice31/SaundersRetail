using SaundersRetail.Data;
using SaundersRetail.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Services
{
    public class ProductService
    {
       
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
            new Product()
            {
                ProductName = model.ProductName,
                Description = model.Description,
                RetailPrice = model.RetailPrice,
                CreatedDate = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .products
                .Select(
                e =>
                new ProductListItem
                {
                    ID = e.ID,
                    ProductName = e.ProductName,
                    Description = e.Description,
                    RetailPrice = e.RetailPrice,
                    CreatedDate = e.CreatedDate
                }
            );
                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .products
                    .Single(e => e.ID == id);
                return new ProductDetail
                {
                    ID= entity.ID,
                    ProductName = entity.ProductName,
                    Description = entity.Description,
                    RetailPrice = entity.RetailPrice,
                    CreatedDate = entity.CreatedDate,
                    LastModified= entity.LastModified
                    

                };
            }
        }
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .products
                        .Single(e => e.ID == model.ID);
                entity.ProductName = model.ProductName;
                entity.Description = model.Description;
                entity.RetailPrice = model.RetailPrice;                
                entity.LastModified = DateTimeOffset.UtcNow;
                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .products
                        .Single(e => e.ID == productId );
                ctx.products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
