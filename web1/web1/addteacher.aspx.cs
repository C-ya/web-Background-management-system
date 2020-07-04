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
    public partial class addteacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }
        private void clean()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                if (TextBox1.Text.Trim() != "")
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string sql = "select * from T where T#='" + TextBox1.Text.Trim() + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("已经存在的教师工号！");
                    }

                    else
                    {
                        if (TextBox1.Text != "")
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;
                            string gender = RadioButton1.Checked ? "男" : "女";
                            sql = "insert into T(T#,TNAME,TSEX,TBIRTHIN,TITLEOF,TRSECTION,TEL)values('" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + gender + "','" + Calendar1.SelectedDate.ToShortDateString() + "','" + TextBox7.Text.Trim() + "','" + TextBox6.Text.Trim() + "','" + TextBox7.Text.Trim() + "')";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("添加教师成功！");
                            clean();
                        }
                        else
                        {
                            MessageBox.Show("教师姓名不能为空！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("教师工号不能为空！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加教师失败！" + ex.Message);
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("./teacher.aspx");
        }
    }
}