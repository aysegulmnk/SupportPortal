using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected bool checkLogin(string userName, string pass)
    {
        //microsoft dll
        string conStr = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";


        OracleConnection con = new OracleConnection(conStr);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "select t.* from TALEP_SORUMLULARI t where t.TALEP_SORUMLU_TC='" + userName + "' and t.SORUMLU_SIFRE='" + pass + "'";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "") { lblSonuc.Text = "Kullanıcı adı girilmedi"; return; }
        if (txtPass.Text == "") { lblSonuc.Text = "Şifre girilmedi"; return; }

        if (!checkLogin(txtUserName.Text, txtPass.Text))
        {
            lblSonuc.Text = "Kullanıcı adı veya şifre hatalı";
            return;
        }

        lblSonuc.Text = "Giriş Başarılı!";

        Response.Redirect("AdminIndex.aspx");
    }
}