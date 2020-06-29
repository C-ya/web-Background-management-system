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

namespace web1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //获取文本框中的值
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username.Equals("") || password.Equals(""))//用户名或密码为空
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else//用户名或密码不为空
            {
                //到数据库中验证
                string selectSql = "select * from [User] where LoginName='" + username + "' and LoginPwd='" + password + "'";
                sqlHelp sqlHelper = new sqlHelp();
                int count = sqlHelper.SqlServerRecordCount(selectSql);//返回符合的结果数量
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