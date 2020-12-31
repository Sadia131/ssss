using Super_Shop_Spring_2019_20.Entities;
using Super_Shop_Spring_2019_20.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Shop_Spring_2019_20.Repository
{
    public class ProductRepository:IRepository<Product>
    {
        DataAccess dataAccess;
        public ProductRepository()
        {
            this.dataAccess = new DataAccess();
        }
        public List<Product> GetAll()
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Product> productList = new List<Product>();
            while(reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["Id"]);
                product.Name = reader["Name"].ToString();
                product.Price = Convert.ToSingle(reader["Price"]);
                productList.Add(product);
            }
            dataAccess.Dispose();
            return productList;
        }

        public Product Get(int id)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT * FROM Products WHERE Id="+id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Product product = new Product();
            product.Id = Convert.ToInt32(reader["Id"]);
            product.Name = reader["Name"].ToString();
            product.Price = Convert.ToSingle(reader["Price"]);
            dataAccess.Dispose();
            return product;
        }

        public int Insert(Product entity)
        {
            dataAccess = new DataAccess();
            string sql = "INSERT INTO Products(Name,Price) VALUES('"+entity.Name+"',"+entity.Price+")";
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Update(Product entity)
        {
            dataAccess = new DataAccess();
            string sql = "UPDATE Products SET Name='"+entity.Name+"',Price="+entity.Price+"  WHERE Id="+entity.Id;
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }

        public int Delete(int id)
        {
            dataAccess = new DataAccess();
            string sql = "DELETE FROM Products WHERE Id="+id;
            int result = dataAccess.ExecuteQuery(sql);
            dataAccess.Dispose();
            return result;
        }
    }
}
