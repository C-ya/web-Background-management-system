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
    public partial class chancourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
            TextBox1.Text = (Session["cid"] != null) ? Session["cid"].ToString() : "无信息";
            TextBox2.Text = (Session["name"] != null) ? Session["name"].ToString() : "无信息";
            TextBox3.Text = (Session["ch"] != null) ? Session["ch"].ToString() : "无信息";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            int flagAddCour = 0;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库
                conn.Open();
                //创建SqlCommand类的对象
                string sql = "update C set CNAME='" + TextBox2.Text.ToString() + "',CLASSH='" + TextBox3.Text.ToString() + "' where C#='" + TextBox1.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行修改操作的SQL
                cmd.ExecuteNonQuery();
                //弹出成功提示
                MessageBox.Show("修改成功！");
                Response.Redirect("./course.aspx");
                //flagAddCour = 1;
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
            //if (flagAddCour != 0)
            //{//
            //    Response.Redirect("./course.aspx");
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./course.aspx");
        }
    }
}