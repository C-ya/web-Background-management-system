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
    public partial class addteach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            int flagAddstu = 0;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string sql = "select * from TEACH where T#='" + TextBox1.Text.Trim() + "' AND C#='" + TextBox2.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("已经存在的授课信息！");
                }

                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    sql = "insert into TEACH(T#,C#)values('" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加授课信息成功！");
                    flagAddstu = 1;
                    //
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加授课信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
            if (flagAddstu != 0)
            {
                Response.Redirect("./teach.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("./teach.aspx");
        }

    }
}