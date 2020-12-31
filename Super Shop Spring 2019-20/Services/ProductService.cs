using Super_Shop_Spring_2019_20.Entities;
using Super_Shop_Spring_2019_20.Interfaces;
using Super_Shop_Spring_2019_20.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop_Spring_2019_20.Services
{
    public class ProductService
    {
        IRepository<Product> repo;
        public ProductService()
        {
            this.repo = new ProductRepository();
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAll();
        }
        public List<Product> GetProductById(int id)
        {
            var data = repo.Get(id);
            Product product = new Product();
            product.Id = data.Id;
            product.Name = data.Name;
            product.Price = data.Price;
            List<Product> list = new List<Product>();
            list.Add(product);
            return list;
        }

        public int AddProduct(string name,float price)
        {
            //Product product = new Product();
            //product.Name = name;
            //product.Price = price;
            int result = repo.Insert(new Product() {Name=name,Price=price });
            return result;
        }

        public int EditProduct(int id,string name, float price)
        {
            //Product product = new Product();\
            //Product.Id = id;
            //product.Name = name;
            //product.Price = price;
            int result = repo.Update(new Product() { Id=id,Name = name, Price = price });
            return result;
        }

        public int RemoveProduct(int id)
        {
            int result = repo.Delete(id);
            return result;
        }
    }
}
