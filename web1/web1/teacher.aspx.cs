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
    public partial class teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }
        //查询全部学生
        private void QueryAllTea()
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
                string sql = "select * from T";
                //创建SqlDataAdapter类的对象
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                GridView1.DataSourceID = null;
                //设置表格控件的DataSource属性
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
            string id = this.GridView1.Rows[index].Cells[0].Text.ToString();
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            if (e.CommandName == "Edit")
            {
                // int index = Convert.ToInt32(e.CommandArgument);
                //...
                DataKey keys = GridView1.DataKeys[index];      //行中的数据;
                                                               //string perid = keys.Value.ToString();
                                                               //Response.Redirect("chanstu.aspx?perid=" + perid);

                //获取DataGridView控件中的值
                //获取工号
                string teaid = GridView1.Rows[index].Cells[0].Text;
                //获取姓名
                string name = GridView1.Rows[index].Cells[1].Text;
                //获取性别
                string tsex = GridView1.Rows[index].Cells[2].Text;
                //获取出生日期
                string tbirth = GridView1.Rows[index].Cells[3].Text;
                //获取职称
                string titl = GridView1.Rows[index].Cells[4].Text;
                //获取学院
                string scode = GridView1.Rows[index].Cells[5].Text;
                //获取电话
                string tel = GridView1.Rows[index].Cells[6].Text;

                Session["teaid"] = teaid;
                Session["name"] = name;
                Session["tsex"] = tsex;
                Session["tbirth"] = tbirth;
                Session["titl"] = titl;
                Session["scode"] = scode;
                Session["tel"] = tel;

                Response.Redirect("./chanteacher.aspx");

            }
            else if (e.CommandName == "Del")
            {
                try
                {
                    conn = new SqlConnection(connStr);
                    //打开数据库
                    conn.Open();
                    string sql = "delete from T where T#='" + id + "'";

                    //创建SqlCommand类的对象
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行SQL语句
                    cmd.ExecuteNonQuery();
                    //弹出消息提示删除成功
                    MessageBox.Show("删除成功！");
                    //调用查询全部的方法，刷新DataGridView控件中的数据
                    QueryAllTea();
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
                string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
                //创建SqlConnection的实例
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connStr);
                    //打开数据库
                    conn.Open();
                    string sql = "select * from T where (T# like '%" + TextBox1.Text + "%') or (TNAME like '%" + TextBox1.Text + "%')";

                    //创建SqlDataAdapter类的对象
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    //创建DataSet类的对象
                    DataSet ds = new DataSet();
                    //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                    sda.Fill(ds);
                    GridView1.DataSourceID = null;
                    //设置表格控件的DataSource属性
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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