using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStoreDbContext();
                listProducts = db.Products.Include(f => f.Category).ToList();
                //using Microsoft.EntityFrameworkCore in order to use Include()
            }
            catch(Exception e)
            {

            }
            return listProducts;
        }
        public static void SaveProduct(Product p)
        {
            try
            {
                using var context = new MyStoreDbContext();
                context.Products.Add(p);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using var context = new MyStoreDbContext();
                context.Entry<Product>(p).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e) 
            {
                throw;
            }
        }
        public static void DeleteProduct(Product p)
        {
            try
            {
                using var context = new MyStoreDbContext();
                var p1 =
                    context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                context.Products.Remove(p1);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public static Product GetProductById(int id)
        {
            using var db = new MyStoreDbContext();
            return db.Products.FirstOrDefault(c => c.ProductId.Equals(id));
        } 
    }
}
