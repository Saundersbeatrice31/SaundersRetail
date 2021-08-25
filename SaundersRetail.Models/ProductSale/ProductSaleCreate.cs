using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SaundersRetail.Models.ProductSale
{
    public class ProductSaleCreate
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }       
    }
    //public class ProductDropDown
    //{
    //    private SelectList _ProductSelectList { get; set; }
    //    public SelectList ProductSelectList
    //    {
    //        get
    //        {
    //            if (_ProductSelectList != null)
    //                return _ProductSelectList;

    //            return new SelectList(DropDown(), "ID", "ProductName");
    //        }
    //        set
    //        {
    //            _ProductSelectList = value;
    //        }
    //    }
    //    private List<ProductSaleCreate> DropDown()
    //    {
    //        var productNames = new List<ProductSaleCreate>();
    //        productNames.Add(new ProductSaleCreate() { ID = 1, ProductName = "Shirts" });
    //        productNames.Add(new ProductSaleCreate() { ID = 2, ProductName = "Shorts" });
    //        productNames.Add(new ProductSaleCreate() { ID = 3, ProductName = "Purses" });
    //        productNames.Add(new ProductSaleCreate() { ID = 4, ProductName = "Pants" });
    //        productNames.Add(new ProductSaleCreate() { ID = 5, ProductName = "Shoes" });

    //        return productNames;
    //    }
    //}
}
