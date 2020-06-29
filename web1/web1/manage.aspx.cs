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
    public partial class manage : System.Web.UI.Page
    {
        private void proFile()
        {
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
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
            if (Session["logName"] != null && Session["email"] != null)
            {
                TextBox1.Text = Session["logName"].ToString();
                TextBox3.Text = Session["email"].ToString();
            }
            else
            {
                proFile();
            }
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
                if (TextBox2.Text != "")
                {
                    //判断密码是否正确
                    string checkNameSql = "select count(*) from [User] where LoginPwd='{0}'";
                    checkNameSql = string.Format(checkNameSql, TextBox2.Text);
                    //创建SqlCommand对象
                    SqlCommand cmdCheckName = new SqlCommand(checkNameSql, conn);
                    //执行SQL语句
                    int isRepeatName = (int)cmdCheckName.ExecuteScalar();
                    if (isRepeatName == 0)
                    {
                        //密码不正确，不执行操作
                        MessageBox.Show("密码不正确！");
                        return;
                    }
                    if (TextBox4.Text == "")
                    {
                        MessageBox.Show("密码不能为空！");
                        return;
                    }
                    //创建SqlCommand类的对象
                    string sql = "update [User] set LoginPwd='" + TextBox4.Text + "',mail='" + TextBox3.Text + "' where LoginName='" + TextBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行修改操作的SQL
                    cmd.ExecuteNonQuery();
                    //弹出成功提示
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    //创建SqlCommand类的对象
                    string sql = "update [User] set mail='" + TextBox3.Text + "' where LoginName='" + TextBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行修改操作的SQL
                    cmd.ExecuteNonQuery();
                    //弹出成功提示
                    MessageBox.Show("修改成功！");
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
            if (flagAddCour != 0)
            {
                Response.Redirect("./manager.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./profile.aspx");
        }
    }
}