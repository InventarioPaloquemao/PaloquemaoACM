using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Principal;

namespace PaloquemaoACM
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string struser;
        string strpass;
        public IPrincipal User { get; set; }       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logUser_Authenticate(object sender, AuthenticateEventArgs e)
        {

            TextBox txbUser = (TextBox)LoginView.FindControl("logUser").FindControl("UserName");
            TextBox txbPass = (TextBox)LoginView.FindControl("logUser").FindControl("password");
            struser = txbUser.Text;
            strpass = txbPass.Text;
            if (Membership.ValidateUser(struser, strpass))
            {
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void logUser_LoggedIn(object sender, EventArgs e)
        {
            MembershipUser objMemeberShip = Membership.GetUser(struser);

            if (Roles.IsUserInRole(objMemeberShip.UserName, "admin"))
            {
                Response.Redirect("/Default.aspx");
              //  Response.Write("<script> alert('')</script>");
            }
            else
            {
                Response.Redirect("/Default.aspx#image-1");
            }
        }
    }
}