using SaundersRetail.Data;
using SaundersRetail.Models.Cashier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Services
{
    public class CashierService
    {
        public bool CreateCashier(CashierCreate model)
        {
            var entity =
            new Cashier()
            {
                CashierID = model.CashierID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                CreatedDate = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.cashiers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CashierListItem> GetCashiers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .cashiers                
                .Select(
                e =>
                new CashierListItem
                {
                    CashierID = e.CashierID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    EmailAddress = e.EmailAddress,
                    CreatedDate = e.CreatedDate
                }
            );
                return query.ToArray();
            }
        }
        public CashierDetail GetCashierById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .cashiers
                        .Single(e => e.CashierID == id );
                return
                    new CashierDetail
                    {
                        CashierID = entity.CashierID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                        CreatedDate = entity.CreatedDate,
                       
                    };
            }
        }
        public bool UpdateCashier(CashierEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .cashiers
                        .Single(e => e.CashierID == model.CashierID );
                entity.CashierID = model.CashierID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                
                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCashier(int cashierId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .cashiers
                        .Single(e => e.CashierID == cashierId );
                ctx.cashiers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

