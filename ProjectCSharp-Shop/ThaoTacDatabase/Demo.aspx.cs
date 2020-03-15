using ProjectCSharp_Shop.DAO;
using ProjectCSharp_Shop.ThaoTacDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectCSharp_Shop.ThaoTacDatabase
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account a = new Account();
            DemoDAO dao = new DemoDAO();
            //giống session.setAttribute("listAccount", dao.GetAccount())
            
           Session["listAccount"] = dao.GetAccount();
        }
    }
}