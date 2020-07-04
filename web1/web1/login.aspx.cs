using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

namespace web1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            SqlConnection conn = null;
            //获取文本框中的值
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username.Equals("") || password.Equals(""))//用户名或密码为空
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else//用户名或密码不为空
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select * from [User] where LoginName='" + username + "' and LoginPwd='" + password + "'";
                
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int count = (int)cmd.ExecuteScalar();
                //到数据库中验证
                if (count > 0)//如果信息>0则说明匹配成功
                {
                    MessageBox.Show("信息验证成功");

                    //跳转到主页面
                    Session["CurrentUser"] = textBox1.Text;
                    Response.Redirect("./home.aspx");


                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
            }
        }
    }
}