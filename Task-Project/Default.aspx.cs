
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
                using (SqlCommand comm = new SqlCommand("SELECT * FROM Company_Info", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string userQuery = "INSERT INTO Company_Info (UserName, address) VALUES (@UserName, @address)";
                using (SqlCommand userComm = new SqlCommand(userQuery, con))
                {
                    userComm.Parameters.AddWithValue("@UserName", TextBox2.Text);
                    userComm.Parameters.AddWithValue("@address", TextBox3.Text);
                    userComm.ExecuteNonQuery();
                }

                string productQuery = "INSERT INTO Company_Info (ProductName, description) VALUES (@ProductName, @description)";
                using (SqlCommand productComm = new SqlCommand(productQuery, con))
                {
                    productComm.Parameters.AddWithValue("@ProductName", TextBox5.Text);
                    productComm.Parameters.AddWithValue("@description", TextBox6.Text);
                    productComm.ExecuteNonQuery();
                }

                string categoryQuery = "INSERT INTO Company_Info (CategoryName) VALUES (@CategoryName)";
                using (SqlCommand categoryComm = new SqlCommand(categoryQuery, con))
                {
                    categoryComm.Parameters.AddWithValue("@CategoryName", TextBox8.Text);
                    categoryComm.ExecuteNonQuery();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                LoadRecords();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string userQuery = "UPDATE Company_Info SET UserName = @UserName, address = @address WHERE userId = @userId";
                using (SqlCommand userComm = new SqlCommand(userQuery, con))
                {
                    userComm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));
                    userComm.Parameters.AddWithValue("@UserName", TextBox2.Text);
                    userComm.Parameters.AddWithValue("@address", TextBox3.Text);
                    userComm.ExecuteNonQuery();
                }

                string productQuery = "UPDATE Company_Info SET ProductName = @ProductName, description = @description WHERE productId = @productId";
                using (SqlCommand productComm = new SqlCommand(productQuery, con))
                {
                    productComm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));
                    productComm.Parameters.AddWithValue("@ProductName", TextBox5.Text);
                    productComm.Parameters.AddWithValue("@description", TextBox6.Text);
                    productComm.ExecuteNonQuery();
                }

                string categoryQuery = "UPDATE Company_Info SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
                using (SqlCommand categoryComm = new SqlCommand(categoryQuery, con))
                {
                    categoryComm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));
                    categoryComm.Parameters.AddWithValue("@CategoryName", TextBox8.Text);
                    categoryComm.ExecuteNonQuery();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                LoadRecords();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string userQuery = "DELETE FROM Company_Info WHERE userId = @userId";
                using (SqlCommand userComm = new SqlCommand(userQuery, con))
                {
                    userComm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));
                    userComm.ExecuteNonQuery();
                }

                string productQuery = "DELETE FROM Company_Info WHERE productId = @productId";
                using (SqlCommand productComm = new SqlCommand(productQuery, con))
                {
                    productComm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));
                    productComm.ExecuteNonQuery();
                }

                string categoryQuery = "DELETE FROM Company_Info WHERE CategoryId = @CategoryId";
                using (SqlCommand categoryComm = new SqlCommand(categoryQuery, con))
                {
                    categoryComm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));
                    categoryComm.ExecuteNonQuery();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                LoadRecords();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string userQuery = "SELECT * FROM Company_Info WHERE userId = @userId";
                using (SqlCommand userComm = new SqlCommand(userQuery, con))
                {
                    userComm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));
                    using (SqlDataAdapter da = new SqlDataAdapter(userComm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }

                string productQuery = "SELECT * FROM Company_Info WHERE productId = @productId";
                using (SqlCommand productComm = new SqlCommand(productQuery, con))
                {
                    productComm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));
                    using (SqlDataAdapter da = new SqlDataAdapter(productComm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }

                string categoryQuery = "SELECT * FROM Company_Info WHERE CategoryId = @CategoryId";
                using (SqlCommand categoryComm = new SqlCommand(categoryQuery, con))
                {
                    categoryComm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));
                    using (SqlDataAdapter da = new SqlDataAdapter(categoryComm))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string userQuery = "SELECT * FROM Company_Info WHERE userId = @userId";
                using (SqlCommand userComm = new SqlCommand(userQuery, con))
                {
                    userComm.Parameters.AddWithValue("@userId", int.Parse(TextBox1.Text));
                    using (SqlDataReader reader = userComm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBox2.Text = reader["UserName"].ToString();
                            TextBox3.Text = reader["address"].ToString();
                        }
                    }
                }

                string productQuery = "SELECT * FROM Company_Info WHERE productId = @productId";
                using (SqlCommand productComm = new SqlCommand(productQuery, con))
                {
                    productComm.Parameters.AddWithValue("@productId", int.Parse(TextBox4.Text));
                    using (SqlDataReader reader = productComm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBox5.Text = reader["ProductName"].ToString();
                            TextBox6.Text = reader["description"].ToString();
                        }
                    }
                }

                string categoryQuery = "SELECT * FROM Company_Info WHERE CategoryId = @CategoryId";
                using (SqlCommand categoryComm = new SqlCommand(categoryQuery, con))
                {
                    categoryComm.Parameters.AddWithValue("@CategoryId", int.Parse(TextBox7.Text));
                    using (SqlDataReader reader = categoryComm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TextBox8.Text = reader["CategoryName"].ToString();
                        }
                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
        }
    }
}
