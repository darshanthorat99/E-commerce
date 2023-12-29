using System.Collections.Generic;
using System.Data.SqlClient;


namespace E_commerce.Models
{
    public class ProductDAL
    {

        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Product> GetAllProduct()
        {

            List<Product> list = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr[" pid"]);
                    p.Pname = dr["pname"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Catid = Convert.ToInt32(dr["catid"]);
                    list.Add(p);
                }
            }
            con.Close();
            return list;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where  pid=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Pid = Convert.ToInt32(dr[" pid"]);
                    p.Pname = dr["pname"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Catid = Convert.ToInt32(dr["catid"]);



                }
            }

            con.Close();
            return p;




        }






        //public int AddProduct(Product product)
        //{
        //    string qry = "insert into Product values(@pname,@price,@catid)";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@pname", product.Pname);
        //    cmd.Parameters.AddWithValue("@price", product.Price);
        //    cmd.Parameters.AddWithValue("@catid", product.Catid);
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}

        //public int UpdateProduct(Product product)
        //{
        //    string qry = "update Product set pname=@pname,,price=@price,catid=@catid where pid=@pid";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@pname", product.Pname);
        //    cmd.Parameters.AddWithValue("@price", product.Price);
        //    cmd.Parameters.AddWithValue("@catid", product.Catid);

        //    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(product.Pid));
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;
        //}
        //public int DeleteProduct(int id)
        //{
        //    string qry = "delete from customer where pid=@pid";
        //    cmd = new SqlCommand(qry, con);
        //    cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(id));
        //    con.Open();
        //    int result = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return result;



        //}
    }
}
       


        
    

