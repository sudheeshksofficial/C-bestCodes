using ADOdotnetwebappli.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADOdotnetwebappli.DataAccessingLayer
{
    public class ProductDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();
        

        // get all Products
        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();

            using(SqlConnection con = new SqlConnection(conString))
            {
                // SqlCommand  command= con.CreateCommand();
                // command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "sp_GetAllProducts";

                SqlCommand command = new SqlCommand("sp_GetAllProducts", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDA = new  SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();

                con.Open();
                sqlDA.Fill(dtProducts);
                con.Close();

                foreach (DataRow dr in dtProducts.Rows)
                { 
                    productList.Add(new Product
                        {
                            ProductID = Convert.ToInt32(dr["ProductID"]),
                            ProductName = dr["ProductName"].ToString(),
                            Price = Convert.ToDecimal(dr["Price"]),
                            City = dr["City"].ToString(),
                            Remarks = dr["Remarls"].ToString()
                        });

                }


            }

            return productList;
        }

        // INSERT PRODUCTS
        public bool InsertProduct(Product product)
        {
            int id = 0;
            using(SqlConnection connnection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertProducts", connnection);
                command.CommandType= CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductName",product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@City", product.City);
                command.Parameters.AddWithValue("@Remarks", product.Remarks);

                connnection.Open();
                id = command.ExecuteNonQuery();
                connnection.Close();

            }

            if (id>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get product  by id
        public List<Product> GetProductByID(int prodid)
        {
            List<Product> productList = new List<Product>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand  command= con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                 command.CommandText = "sp_GetProductByID";

                //SqlCommand command = new SqlCommand("sp_GetProductByID", con);
                //command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", prodid);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();

                con.Open();
                sqlDA.Fill(dtProducts);
                con.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    productList.Add(new Product
                    {
                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        ProductName = dr["ProductName"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        City = dr["City"].ToString(),
                        Remarks = dr["Remarls"].ToString()
                    });

                }


            }

            return productList;
        }

        //Upddate Products
        public bool UpdateProduct(Product product)
        {
            List<Product> productList = new List<Product>();
            int id = 0;

            using (SqlConnection con = new SqlConnection(conString))
            {
                // SqlCommand  command= con.CreateCommand();
                // command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "sp_GetAllProducts";

                SqlCommand command = new SqlCommand("sp_UpdateProducts", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@City", product.City);
                command.Parameters.AddWithValue("@Remarks", product.Remarks);


                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();

                con.Open();
                id = command.ExecuteNonQuery();
                con.Close();

            

                if (id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }

           
        }

        // delete a product sp_deleteProductById

        public string DeleteProduct(int productid)
        {
            string result = "";

            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deleteProductById", con);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters[0].Value = productid;
                command.Parameters.AddWithValue("@ProductId", productid);
                command.Parameters.Add("@OUTPUTMESSAGE", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;

                con.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@OUTPUTMESSAGE"].Value.ToString();  
                con.Close();

            }

            return result;
        }
    }
}