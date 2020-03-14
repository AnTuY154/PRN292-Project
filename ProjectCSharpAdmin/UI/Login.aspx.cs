using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCSharpAdmin.UI
{
    public partial class Login : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies["userInfo"];
            if (cookie != null)
            {
                string User_name = cookie["UserName"].ToString();
                string User_pass = cookie["UserPassWord"].ToString();
                string type = cookie["type"].ToString();
                TextBox1.Text = User_name;
                TextBox2.Text = User_pass;
                checkLogin(type);
            }
        }
        public void setCookie(string username,string password,string type)
        {
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["UserName"] = username;
            userInfo["UserPassWord"] = password;
            userInfo["type"] = type;
            userInfo.Expires.Add(new TimeSpan(0, 5, 0));
            Response.Cookies.Add(userInfo);
        }
       public void checkLogin(string type)
        {
            if ((TextBox1.Text.Trim() == "" || TextBox1.Text == null) && (TextBox2.Text.Trim() == "" || TextBox2.Text == null))
            {
                string message = "Your username and password is emty";
                string script = String.Format("alert('{0}');", message);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                return;
            }
            else if (TextBox1.Text.Trim() == "" || TextBox1.Text == null)
            {
                string message = "Your username is emty";
                string script = String.Format("alert('{0}');", message);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                return;
            }
            else if (TextBox2.Text.Trim() == "" || TextBox2.Text == null)
            {
                string message = "Your password is emty";
                string script = String.Format("alert('{0}');", message);
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                return;
            }
            else
            {
                Button2.Text = TextBox1.Text;
                SqlConnection con = new SqlConnection(connStr);
                SqlDataAdapter da = new SqlDataAdapter("select * from Account where username='" + TextBox1.Text.Trim() + "'", con);
                DataTable tb = new DataTable();
                da.Fill(tb);
                int count = 0;
                foreach (DataRow row in tb.Rows)
                {
                    count++;
                }
                if (count == 0)
                {
                    string message = "Your account do not exit";
                    string script = String.Format("alert('{0}');", message);
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                    //return;
                }
                else
                {
                    string username = tb.Rows[0][0].ToString();
                    string password = tb.Rows[0][1].ToString();
                    if (password.Equals(TextBox2.Text.Trim()) == false)
                    {
                        string message = "Your password is incoreect";
                        string script = String.Format("alert('{0}');", message);
                        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                        return;
                    }
                    else
                    {
                        if (type.Equals("1"))
                        {
                            if (tb.Rows[0][2].ToString().Equals("1"))
                            {
                                if (checkBox1.Checked)
                                {
                                    setCookie(username, password,"1");
                                }
                                Response.Redirect("Index.aspx");
                            }
                            else
                            {
                                string message = "You do not have permit";
                                string script = String.Format("alert('{0}');", message);
                                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
                                return;
                            }
                        }
                        else if(type.Equals("0"))
                        {
                            if (checkBox1.Checked)
                            {
                                setCookie(username, password,"0");
                            }
                            Response.Redirect("Index.aspx");
                        }
                       
                    }

                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            checkLogin("1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            checkLogin("0");
        }
    }
}