using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected bool connectGetRec()
    {
        //microsoft dll
        string conStr = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";


        OracleConnection con = new OracleConnection(conStr);
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = "select * from TALEP_KATEGORILERI";
        cmd.Connection = con;
        con.Open();
        OracleDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            Response.Write("<table border='1'>");
            Response.Write("<tr><th>Name</th><th>Roll No</th></tr>");
            while (dr.Read())
            {

                Response.Write("<tr>");
                Response.Write("<td>" + dr["TALEP_KATEGORI_KOD"].ToString() + "</td>");
                Response.Write("<td>" + dr["TALEP_KATEGORI_AD"].ToString() + "</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
        else
        {
            Response.Write("No Data In DataBase");
        }
        con.Close();

        return true;
    }


    protected void btnLoadData_Click(object sender, EventArgs e)
    {

        connectGetRec();


    }

    protected void btnYaz_Click(object sender, EventArgs e)
    {
        lblSonuc.Text = txtIcerik.Text+"<br>";

        lblSonuc.Text += drpKategori.SelectedValue.ToString();

    }
}