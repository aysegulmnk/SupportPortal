using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected bool checkLogin(string userName,string pass)
    {
        //microsoft dll
        string conStr = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";


        OracleConnection con = new OracleConnection(conStr);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "select t.* from GONDEREN_KULLANICI_BILGILERI t where t.kullanici_adi='"+userName+"' and t.kullanici_sifre='"+pass+"'";
        cmd.Connection = con;
        con.Open();
        OracleDataReader dr = cmd.ExecuteReader();

        

        if (dr.HasRows)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
 
    }



    protected void btnLogin_Click(object sender, EventArgs e)
    {

        if (txtUserName.Text == "") { lblSonuc.Text = "Kullanıcı adı girilmedi"; return; }
        if (txtPass.Text == "") {lblSonuc.Text = "Şifre girilmedi"; return; }

        if (!checkLogin(txtUserName.Text, txtPass.Text))
        {
            lblSonuc.Text = "Kullanıcı adı veya şifre hatalı";
            return;
        }

        lblSonuc.Text = "Giriş Başarılı!";

        Response.Redirect("index.aspx");

    }

    protected void txtPass_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }
}