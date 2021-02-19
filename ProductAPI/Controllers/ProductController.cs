using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProductAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: Product
        [System.Web.Http.HttpPost]
        public string AddProduct(Product product)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("AddProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Saved Successfully";
        }
        [System.Web.Http.HttpGet]
        public List<Product> ListProduct()
        {
            List<Product> products = new List<Product>();
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("ListProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product product = new Product();
                product.Id = (int)dr["Id"];
                product.Name = (string)dr["Name"];
                product.Brand = (string)dr["Brand"];
                product.Quantity = (string)dr["Quantity"];
                product.Price = (string)dr["Price"];
                products.Add(product);
            }
            connect.Close();
            return products;
        }
        [System.Web.Http.HttpPost]
        public string EditProduct(Product product)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("EditProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Update Successfully";
        }
        [System.Web.Http.HttpGet]
        public string DeleteProduct(int id)
        {
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=ProductDatabase;Trusted_Connection=true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("DeleteProduct", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Data Delete Successfully";
        }
    }
}