using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class chanstugrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
            TextBox1.Text = (Session["stuid"] != null) ? Session["stuid"].ToString() : "无信息";
            TextBox2.Text = (Session["couid"] != null) ? Session["couid"].ToString() : "无信息";
            TextBox3.Text = (Session["grade"] != null) ? Session["grade"].ToString() : "无信息";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库
                conn.Open();
                //创建SqlCommand类的对象
                string sql = "update SC set grade='" + TextBox3.Text  + "' where S#='" + TextBox1.Text.Trim() + "' and C#='" + TextBox2.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行修改操作的SQL
                cmd.ExecuteNonQuery();
                //弹出成功提示
                MessageBox.Show("修改成功！");
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
            Response.Redirect("./stugrade.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./stugrade.aspx");
        }
    }
}