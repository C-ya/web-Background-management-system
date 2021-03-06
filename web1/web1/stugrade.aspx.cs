using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace web1
{
    public partial class stugrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }
        private void QueryAllGrade()
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
                string sql = "select * from SC";
                //创建SqlDataAdapter类的对象
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                GridView2.DataSourceID = null;
                //设置表格控件的DataSource属性
                GridView2.DataSource = ds;
                GridView2.DataBind();
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
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //获取DataGridView控件中选中行的编号列的值
            string sid = this.GridView2.Rows[index].Cells[0].Text.ToString();
            string cid = this.GridView2.Rows[index].Cells[1].Text.ToString();
            //数据库连接串
            string connStr = ConfigurationManager.ConnectionStrings["jxglConnectionString"].ConnectionString;
            //创建SqlConnection的实例
            SqlConnection conn = null;
            if (e.CommandName == "Edit")
            {
                // int index = Convert.ToInt32(e.CommandArgument);
                //...
                DataKey keys = GridView2.DataKeys[index];      //行中的数据;
                                                               //string perid = keys.Value.ToString();
                                                               //Response.Redirect("chanstu.aspx?perid=" + perid);

                //获取DataGridView控件中的值
                //获取学号
                string stuid = GridView2.Rows[index].Cells[0].Text;
                //获取姓名
                string couid = GridView2.Rows[index].Cells[1].Text;
                //获取性别
                string grade = GridView2.Rows[index].Cells[2].Text;

                Session["stuid"] = stuid;
                Session["couid"] = couid;
                Session["grade"] = grade;

                Response.Redirect("./chanstugrade.aspx");

            }
            else if (e.CommandName == "Del")
            {
                try
                {
                    conn = new SqlConnection(connStr);
                    //打开数据库
                    conn.Open();
                    string sql = "delete from SC where S#='" + sid + "' AND C#='" + cid + "'";

                    //创建SqlCommand类的对象
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行SQL语句
                    cmd.ExecuteNonQuery();
                    //弹出消息提示删除成功
                    MessageBox.Show("删除成功！");
                    //调用查询全部的方法，刷新DataGridView控件中的数据
                    QueryAllGrade();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！" + ex.Message);
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
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
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
                    string sql = "select * from SC where (S# like '%" + TextBox1.Text + "%') or (C# like '%" + TextBox1.Text + "%')";

                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    GridView2.DataSourceID = null;
                    //设置表格控件的DataSource属性
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误！" + ex.Message);
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
        }
    }
}