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

    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建 SqlConnection的实例
            SqlConnection conn = null;
            int CanRegister = 0;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //判断用户名是否重复
                string checkNameSql = "select count(*) from [User] where LoginName='{0}'";
                checkNameSql = string.Format(checkNameSql, textBox1.Text);
                //创建SqlCommand对象
                SqlCommand cmdCheckName = new SqlCommand(checkNameSql, conn);
                //执行SQL语句
                int isRepeatName = (int)cmdCheckName.ExecuteScalar();
                if (isRepeatName != 0)
                {
                    //用户名重复，则不执行注册操作
                    MessageBox.Show("用户名已存在！");
                    return;
                }
                string sql = "insert into [User](LoginName,LoginPwd) values('{0}','{1}')";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("注册成功！");
                    CanRegister = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
            if (CanRegister != 0)
            {
                Session["CurrentUser"] = textBox1.Text;
                Response.Redirect("home.aspx");
            }
        }
    }
}