using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {

    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
               Response.Write("<script>alert('User already registered!');</script>");
            }
            else
            {
               signupNewUser();

            }
        }
        
        //user defined methods

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from member_master_table where member_id='" + TextBox8.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
           
            
        }

        void signupNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email, state, city, postalcode, full_adress, member_id, password, account_status) VALUES (@full_name, @dob,@contact_no, @email, @state, @city, @postalcode, @full_adress, @member_id, @password, @account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text);
                cmd.Parameters.AddWithValue("@contact_no", TextBox5.Text);
                cmd.Parameters.AddWithValue("@email", TextBox4.Text);
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text);
                cmd.Parameters.AddWithValue("@postalcode", TextBox7.Text);
                cmd.Parameters.AddWithValue("@full_adress", TextBox3.Text);
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text);
                cmd.Parameters.AddWithValue("@password", TextBox9.Text);
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up successfully!');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
