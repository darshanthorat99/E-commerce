using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace E_commerce.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public UserDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public int UsersRegister(Users user)
        {

            string qry = "insert into UsersData values(@email@pass,@role)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", user.Emailid);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@role", 2);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Users UsersLogin(Users user)
        {
            Users users = new Users();
            string qry = "select * from UserData where Email=@email and Password=@Password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("email", users.Emailid);
            cmd.Parameters.AddWithValue("@password", users.Password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.Userid = Convert.ToInt32(dr["user_id"]);

                    users.Emailid = dr["Email"].ToString();
                    users.Roleid = Convert.ToInt32(dr["role_id"]);

                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}
