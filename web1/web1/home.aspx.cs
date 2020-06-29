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
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.Text = (Session["CurrentUser"] != null) ? Session["CurrentUser"].ToString() : "未登录";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //查询全部学生
        private void QueryAllStu()
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
                string sql = "SELECT S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 FROM S INNER JOIN SS ON S.SCODE# = SS.SCODE#";
                //SELECT S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 FROM S INNER JOIN SS ON S.SCODE# = SS.SCODE#
                //创建SqlDataAdapter类的对象
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
                //设置表格控件的DataSource属性
                //GridView2.DataSource = ds.Tables[0];
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
            string id = this.GridView2.Rows[index].Cells[0].Text.ToString();
            //数据库连接串
            string connStr = "Data Source=.;Initial Catalog=jxgl;User ID=sa;Password=123456";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            if (e.CommandName == "edit")
            {
                // int index = Convert.ToInt32(e.CommandArgument);
                //...
                DataKey keys = GridView2.DataKeys[index];      //行中的数据;
            //获取学号
            string stuid = GridView2.Rows[index].Cells[0].Text;
            //获取姓名
            string name = GridView2.Rows[index].Cells[1].Text;
            //获取性别
            string ssex = GridView2.Rows[index].Cells[2].Text;
            //获取出生日期
            string sbirth = GridView2.Rows[index].Cells[3].Text;
            //获取籍贯
            string place = GridView2.Rows[index].Cells[4].Text;
            //获取学院
            string scode = GridView2.Rows[index].Cells[5].Text;
            //获取班级
             string sclass = GridView2.Rows[index].Cells[7].Text;
                
                Session["stuid"] = stuid;
                Session["name"] = name;
                Session["ssex"] = ssex;
                Session["sbirth"] = sbirth;
                Session["place"] = place;
                Session["scode"] = scode;
                Session["sclass"] = sclass;

                Response.Redirect("./chanstu.aspx");

            }
            else if (e.CommandName == "Del")
            {
                try
                {
                    conn = new SqlConnection(connStr);
                    //打开数据库
                    conn.Open();
                    string sql = "delete from S where S#='" + id + "'";

                    //创建SqlCommand类的对象
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //执行SQL语句
                    cmd.ExecuteNonQuery();
                    //弹出消息提示删除成功
                    MessageBox.Show("删除成功！");
                    //调用查询全部的方法，刷新DataGridView控件中的数据
                    QueryAllStu();
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
                    string sql = "select S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 from S INNER JOIN SS ON S.SCODE# = SS.SCODE# where (S.S# like '%" + TextBox1.Text + "%') or (S.SNAME like '%" + TextBox1.Text + "%')";

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