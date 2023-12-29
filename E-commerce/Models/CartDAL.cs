using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace E_commerce.Models
{
    public class CartDAL
    {
        public readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        private bool CheckCartData(Cart cart)
        {

            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@pid,@userid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@pid", cart.Pid);
                cmd.Parameters.AddWithValue("@userid", cart.Userid);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromCart(string userid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.pid,p.pname,p.price,p.catid, c.cartid,c.userid from Product p " +
                        " inner join cart c on c.cartid = p.pid " +
                        " where c.userid = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(userid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr["pid"]);
                    p.Pname = dr["pname"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Catid = Convert.ToInt32(dr["catid"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromCart(int cid)
        {

            string qry = "delete from Cart where  cartid=@cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", cid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }

        
}
