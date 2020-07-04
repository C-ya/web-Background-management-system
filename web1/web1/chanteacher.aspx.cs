using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class chanteacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
            TextBox1.Text = (Session["teaid"] != null) ? Session["teaid"].ToString() : "无信息";
            TextBox2.Text = (Session["name"] != null) ? Session["name"].ToString() : "无信息";
            TextBox3.Text = (Session["tsex"] != null) ? Session["tsex"].ToString() : "无信息";
            TextBox4.Text = (Session["tbirth"] != null) ? Session["tbirth"].ToString() : "无信息";
            TextBox5.Text = (Session["titl"] != null) ? Session["titl"].ToString() : "无信息";
            TextBox6.Text = (Session["scode"] != null) ? Session["scode"].ToString() : "无信息";
            TextBox7.Text = (Session["tel"] != null) ? Session["tel"].ToString() : "无信息";
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
                string sql = "update T set TNAME='" + TextBox2.Text + "',TSEX='" + TextBox3.Text + "',TBIRTHIN='" + TextBox4.Text + "',TITLEOF='" + TextBox5.Text + "',TRSECTION='" + TextBox6.Text + "',TEL='" + TextBox7.Text + "' where T#='" + TextBox1.Text + "'";
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
            Response.Redirect("./teacher.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./teacher.aspx");
        }
    }
}