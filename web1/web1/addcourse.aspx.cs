using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class addcourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }
        private void clean()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                if (TextBox1.Text != "")
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string sql = "select * from C where C#='" + TextBox1.Text.Trim() + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("已经存在的课程号！");
                    }

                    else
                    {
                        if (TextBox1.Text != "" && TextBox2.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            sql = "insert into C(C#,CNAME,CLASSH)values('" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + TextBox3.Text.Trim() + "')";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("添加课程成功！");
                            clean();
                        }
                        else
                        {
                            MessageBox.Show("信息不完整！");
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("课号不能为空！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加课程失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./course.aspx");
        }
    }
}