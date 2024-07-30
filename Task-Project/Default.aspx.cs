using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task-Project
{
    public partial class _Default : Page
    {
        private readonly string connectionString = "Data Source=KETAN\\SAMIKSHA_SQLSERV;Initial Catalog=Company_Info;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecords();
            }
        }

        private void LoadRecords()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                using (SqlCommand comm = new SqlCommand("SELECT * FROM users", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridViewUsers.DataSource = dt;
                        GridViewUsers.DataBind();
                    }
                }

                using (SqlCommand comm = new SqlCommand("SELECT * FROM product", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridViewProduct.DataSource = dt;
                        GridViewProduct.DataBind();
                    }
                }

                using (SqlCommand comm = new SqlCommand("SELECT * FROM category", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridViewCategory.DataSource = dt;
                        GridViewCategory.DataBind();
                    }
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Insert into users table
                string usersquery = "INSERT INTO users (UserName, address) VALUES (@UserName, @address)";
                using (SqlCommand comm = new SqlCommand(usersquery, con))
                {
                    comm.Parameters.AddWithValue("@UserName", TextBox2.Text);
                    comm.Parameters.AddWithValue("@address", TextBox3.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                }

                // Insert into product table
                string productquery = "INSERT INTO product (ProductName, description) VALUES (@ProductName, @description)";
                using (SqlCommand comm = new SqlCommand(productquery, con))
                {
                    comm.Parameters.AddWithValue("@ProductName", TextBox5.Text);
                    comm.Parameters.AddWithValue("@description", TextBox6.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                }

                // Insert into category table
                string categoryquery = "INSERT INTO category (CategoryName) VALUES (@CategoryName)";
                using (SqlCommand comm = new SqlCommand(categoryquery, con))
                {
                    comm.Parameters.AddWithValue("@CategoryName", TextBox8.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                }

                con.Close();
                LoadRecords();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update users table
                string usersquery = "UPDATE users SET UserName = @UserName, address = @address WHERE userId = @userId";
                using (SqlCommand comm = new SqlCommand(usersquery, con))
                {
                    comm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));
                    comm.Parameters.AddWithValue("@UserName", TextBox2.Text);
                    comm.Parameters.AddWithValue("@address", TextBox3.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                }
                
                // Update product table
                string productquery = "UPDATE product SET ProductName = @ProductName, description = @description WHERE productId = @productId";
                using (SqlCommand comm = new SqlCommand(productquery, con))
                {
                    comm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));
                    comm.Parameters.AddWithValue("@ProductName", TextBox5.Text);
                    comm.Parameters.AddWithValue("@description", TextBox6.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                }
               
                // Update category table
                string categoryquery = "UPDATE category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                using (SqlCommand comm = new SqlCommand(categoryquery, con))
                {
                    comm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));
                    comm.Parameters.AddWithValue("@CategoryName", TextBox8.Text);

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                }

                con.Close();
                LoadRecords();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Delete from users table
                string usersquery = "DELETE FROM users WHERE userId = @userId";
                using (SqlCommand comm = new SqlCommand(usersquery, con))
                {
                    comm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                }
                
                // Delete from product table
                string productquery = "DELETE FROM product WHERE productId = @productId";
                using (SqlCommand comm = new SqlCommand(productquery, con))
                {
                    comm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                }
                
                // Delete from category table
                string categoryquery = "DELETE FROM category WHERE CategoryId = @CategoryId";
                using (SqlCommand comm = new SqlCommand(categoryquery, con))
                {
                    comm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));

                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                }

                con.Close();
                LoadRecords();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Select from users table
                string usersquery = "SELECT * FROM users WHERE userId = @userId";
                using (SqlCommand comm = new SqlCommand(usersquery, con))
                {
                    comm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            TextBox2.Text = dr["UserName"].ToString();
                            TextBox3.Text = dr["address"].ToString();
                        }
                    }
                }

                // Select from product table
                string productquery = "SELECT * FROM product WHERE productId = @productId";
                using (SqlCommand comm = new SqlCommand(productquery, con))
                {
                    comm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            TextBox5.Text = dr["ProductName"].ToString();
                            TextBox6.Text = dr["description"].ToString();
                        }
                    }
                }

                // Select from category table
                string categoryquery = "SELECT * FROM category WHERE CategoryId = @CategoryId";
                using (SqlCommand comm = new SqlCommand(categoryquery, con))
                {
                    comm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));

                    using (SqlDataReader dr = comm.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            TextBox8.Text = dr["CategoryName"].ToString();
                        }
                    }
                }

                con.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
        }
    }
}
