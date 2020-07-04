using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class chanstu : System.Web.UI.Page
    {
        private void QueryAllStu()
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库
                conn.Open();
                string sql = "SELECT S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 FROM S INNER JOIN SS ON S.SCODE# = SS.SCODE#";
                //SELECT S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 FROM S INNER JOIN SS ON S.SCODE# = SS.SCODE#
                //创建SqlDataAdapter类的对象
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = new SqlConnection(connStr);
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
            TextBox1.Text = (Session["stuid"] != null) ? Session["stuid"].ToString().Trim() : "无信息";
            TextBox2.Text = (Session["name"] != null) ? Session["name"].ToString().Trim() : "无信息";
            TextBox3.Text = (Session["ssex"] != null) ? Session["ssex"].ToString().Trim() : "无信息";
            TextBox4.Text = (Session["sbirth"] != null) ? Session["sbirth"].ToString().Trim() : "无信息";
            TextBox5.Text = (Session["place"] != null) ? Session["place"].ToString().Trim() : "无信息";
            TextBox6.Text = (Session["scode"] != null) ? Session["scode"].ToString().Trim() : "无信息";
            TextBox7.Text = (Session["sclass"] != null) ? Session["sclass"].ToString().Trim() : "无信息";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库
                conn.Open();
                //创建SqlCommand类的对象
                if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "")
                {
                    string sql = "update S set SNAME='" + TextBox2.Text.Trim() + "',SSEX='" + TextBox3.Text.Trim() + "',SBIRTHIN='" + Convert.ToDateTime(TextBox4.Text) + "',PLACEOFB='" + TextBox5.Text.Trim() + "',SCODE#='" + TextBox6.Text.Trim() + "',CLASS='" + TextBox7.Text.Trim() + "' where S#='" + TextBox1.Text + "'";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行修改操作的SQL
                    int num  = cmd.ExecuteNonQuery();
                    //弹出成功提示
                    if (num > 0)
                    {
                        MessageBox.Show("修改成功！");
                        QueryAllStu();
                        Response.Redirect("./home.aspx");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("信息不完整！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
            //Response.Redirect("./home.aspx");
        }
        //取消按钮单击事件

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./home.aspx");
        }


    }
}