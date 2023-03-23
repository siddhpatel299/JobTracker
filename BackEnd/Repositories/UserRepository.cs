using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Npgsql;

namespace BackEnd.Repositories
{
    public class UserRepository : CommonRepository, IUserRepository
    {
        public bool ChangeProfile(t_user data)
        {
             cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"Update t_user set c_username=@uname,c_address=@address,c_city=@city,c_contact=@contact
                                                    ,c_image=@image,c_degree=@degree where c_userid = @uid;", cn);
            cmd.Parameters.AddWithValue("@uid", data.UserId);
            cmd.Parameters.AddWithValue("@uname", data.UserName);
        
            cmd.Parameters.AddWithValue("@address", data.Address);
            cmd.Parameters.AddWithValue("@city", data.City);
            cmd.Parameters.AddWithValue("@contact", data.Contact);
            cmd.Parameters.AddWithValue("@image", data.Image);
            cmd.Parameters.AddWithValue("@degree", data.Degree);

            int n = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            if (n == 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProfile(int id)
        {
            cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("delete from t_user where c_userid = @c_userid", cn);
            cmd.Parameters.AddWithValue("@c_userid", id);
           
            int n = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public t_user GetProfile(int id)
        {
             cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from t_user t , t_role r where t.c_roleid=r.c_roleid", cn);
            DataTable dt = new DataTable();
            NpgsqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                dt.Load(sdr);
            }

            t_user UserList = (from DataRow dr in dt.Rows
                               where int.Parse(dr["c_userid"].ToString()) == id
                               select new t_user()
                               {
                                   UserId = Convert.ToInt32(dr["c_userid"]),
                                   UserName = dr["c_username"].ToString(),
                                   Email = dr["c_email"].ToString(),
                                   Password = dr["c_password"].ToString(),
                                   Gender = dr["c_gender"].ToString(),
                                   Address = dr["c_address"].ToString(),
                                   City = dr["c_city"].ToString(),
                                   Contact = Convert.ToInt64(dr["c_contact"]),
                                   Image = dr["c_image"].ToString(),
                                   RoleId = Convert.ToInt32(dr["c_roleid"]),
                                   RoleName = dr["c_rolename"].ToString(),
                                   Degree = dr["c_degree"].ToString()
                               }).ToList().FirstOrDefault();
            cn.Close();
            return UserList;
        }

        public bool Login(vm_login data)
        {
             cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from t_user where c_email =@c_email and c_password=@c_password", cn);
            cmd.Parameters.AddWithValue("@c_email", data.Email);
            cmd.Parameters.AddWithValue("@c_password", data.Password);

            NpgsqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                // HttpContext.Current.Session["username"] = sdr["c_username"].ToString();
                // HttpContext.Session.SetString("userid" , dr["c_userid"].ToString());

                return true;
            }
            cn.Close();
            return false;
        }

        public bool Register(t_user data)
        {
           cn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into t_user(c_username,c_email,c_password,c_gender,c_address,c_city,c_contact,c_image,c_roleid,c_degree)
                                                values(@uname,@email,@password,@gender,@address,@city,@contact,@image,@roleid,@degree)", cn);

            cmd.Parameters.AddWithValue("@uname", data.UserName);
            cmd.Parameters.AddWithValue("@email", data.Email);
            cmd.Parameters.AddWithValue("@password", data.Password);
            cmd.Parameters.AddWithValue("@gender", data.Gender);
            cmd.Parameters.AddWithValue("@address", data.Address);
            cmd.Parameters.AddWithValue("@city", data.City);
            cmd.Parameters.AddWithValue("@contact", data.Contact);
            cmd.Parameters.AddWithValue("@image", data.Image);
            cmd.Parameters.AddWithValue("@roleid", data.RoleId);
            cmd.Parameters.AddWithValue("@degree", data.Degree);

            
            int n = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            if (n == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ChangePassword(ChangePassword data)
        {
            if (data.NewPassword == data.ConfirmPassword)
            {
                NpgsqlCommand cm = new NpgsqlCommand(@"update t_user set c_password=@newpassword 
                                                        where c_id=@c_id and c_password=@oldpassword", cn);
                cm.Parameters.AddWithValue("@newpassword", data.NewPassword);
                cm.Parameters.AddWithValue("@oldpassword", data.OldPassword);
                //cm.Parameters.AddWithValue("@c_id", int.Parse(HttpContext.Current.Session["UserId"].ToString()));
                cn.Open();
                int ans = cm.ExecuteNonQuery();
                cn.Close();
                return ans;
            }
            else
            {
                return -1;
            }
        }

        public bool forget(string email, string pass)
        {
            cn.Open();
            NpgsqlCommand cm = new NpgsqlCommand(@"update public.t_user set c_password=@c_password where c_email=@c_email;",cn);
            cm.Parameters.AddWithValue("@c_password",pass);
            cm.Parameters.AddWithValue("@c_email",email);
            // cm.ExecuteNonQuery();
            // return true;
            int n = Convert.ToInt32(cm.ExecuteScalar());
            cn.Close();
            if(n == 0){
                return true;
            }
            return false;
        }
    }
}