using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class addstu : System.Web.UI.Page
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
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            //int flagAddstu = 0;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                if (TextBox1.Text == "")
                {
                    MessageBox.Show("学生学号有误！");
                    // return;
                }
                else
                {
                    string sql = "select * from S where S#='" + TextBox1.Text.Trim() + "'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("已经存在的学生学号！"); //return;

                    }
                    else
                    {
                        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
                        {
                            string ssql = "select * from SS where SCODE#='" + TextBox6.Text.Trim() + "'";
                            SqlDataAdapter sadp = new SqlDataAdapter(ssql, conn);
                            DataSet sds = new DataSet();
                            sadp.Fill(sds);
                            if (sds.Tables[0].Rows.Count > 0)
                            {

                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                string gender = RadioButton1.Checked ? "男" : "女";

                                sql = "insert into S(S#,SNAME,SSEX,SBIRTHIN,PLACEOFB,SCODE#,CLASS)values('" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + gender + "','" + Calendar1.SelectedDate + "','" + TextBox5.Text.Trim() + "','" + TextBox6.Text.Trim() + "','" + TextBox7.Text.Trim() + "')";
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("添加学生成功！");
                                clean();
                            }
                            else
                            {
                                MessageBox.Show("学院号有问题！");
                                //return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("信息填写不完整！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加学生失败！" + ex.Message);
                //clean();
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
            Response.Redirect("./home.aspx");
        }
    }
}