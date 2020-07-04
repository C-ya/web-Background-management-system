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
    public partial class profile : System.Web.UI.Page
    {
        private void proFile()
        {
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            //定义SqlDataReader类的对象
            SqlDataReader dr = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库
                conn.Open(); ;
                //创建SqlCommand类的对象
                string sql = "select LoginName,mail from [User] where LoginName='{0}'";
                //填充SQL语句
                sql = string.Format(sql, CurrentUser.Text);
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行Sql语句
                dr = cmd.ExecuteReader();
                //判断SQL语句是否执行成功
                if (dr.Read())
                {
                    TextBox1.Text = dr[0].ToString();
                    TextBox3.Text = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！" + ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    //判断dr不为空，关闭SqlDataReader对象
                    dr.Close();
                }
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
            proFile();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string logName = TextBox1.Text;
            string email = TextBox3.Text;
            Session["logName"] = logName;
            Session["email"] = email;
            Response.Redirect("./manage.aspx");
        }
    }
}