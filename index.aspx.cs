using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string conStr = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                string query = "SELECT TALEP_KATEGORI_AD FROM TALEP_KATEGORILERI";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = reader["TALEP_KATEGORI_AD"].ToString();
                            DropDownList1.Items.Add(item);
                        }

                    }
                }
                string query1 = "SELECT TALEP_ONCELIGI_AD FROM TALEP_ONCELIGI";
                using (OracleCommand command = new OracleCommand(query1, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListItem item1 = new ListItem();
                            item1.Text = reader["TALEP_ONCELIGI_AD"].ToString();
                            DropDownList2.Items.Add(item1);
                        }

                    }
                }
                string query3 = "SELECT TALEP_SORUMLU_AD_SOYAD FROM TALEP_SORUMLULARI";
                using (OracleCommand command = new OracleCommand(query3, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListItem item3 = new ListItem();
                            item3.Text = reader["TALEP_SORUMLU_AD_SOYAD"].ToString();
                            DropDownList3.Items.Add(item3);
                        }

                    }
                }
            }
            string connectionString = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TK.TALEP_KATEGORI_AD, TOA.TALEP_ONCELIGI_AD, TS.TALEP_SORUMLU_AD_SOYAD, T.TALEP_ICERIGI " +
                               "FROM TALEP T " +
                               "INNER JOIN TALEP_KATEGORILERI TK ON T.TALEP_KATEGORI_KOD = TK.TALEP_KATEGORI_KOD " +
                               "INNER JOIN TALEP_ONCELIGI TOA ON T.TALEP_ONCELIGI_KOD = TOA.TALEP_ONCELIGI_KOD " +
                               "INNER JOIN TALEP_SORUMLULARI TS ON T.TALEP_SORUMLU_TC = TS.TALEP_SORUMLU_TC";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    OracleDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("TALEP_KATEGORI_AD");
                    dataTable.Columns.Add("TALEP_ONCELIGI_AD");
                    dataTable.Columns.Add("TALEP_SORUMLU_AD_SOYAD");
                    dataTable.Columns.Add("TALEP_ICERIGI");

                    while (reader.Read())
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["TALEP_KATEGORI_AD"] = reader["TALEP_KATEGORI_AD"];
                        newRow["TALEP_ONCELIGI_AD"] = reader["TALEP_ONCELIGI_AD"];
                        newRow["TALEP_SORUMLU_AD_SOYAD"] = reader["TALEP_SORUMLU_AD_SOYAD"];
                        newRow["TALEP_ICERIGI"] = reader["TALEP_ICERIGI"];
                        dataTable.Rows.Add(newRow);
                    }

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }



        }


    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string kategoriAd = DropDownList1.SelectedValue; // Talep kategorisi adını al
        string oncelikAd = DropDownList2.SelectedValue; // Talep önceliği adını al
        string sorumluAdSoyad = DropDownList3.SelectedValue; // Talep sorumlusu adını al
        string talepIcerigi = TextBox1.Text; // Textbox'tan talep içeriğini al

        // Burada TALEP_KATEGORI_KOD, TALEP_ONCELIGI_KOD, TALEP_SORUMLU_TC ve TALEP_ICERIGI'yi veritabanına ekleyeceksiniz.

        // Veritabanı işlemleri için bağlantı cümlesi
        string conStr = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";

        using (OracleConnection connection = new OracleConnection(conStr))
        {
            // TALEP_KATEGORI_KOD, TALEP_ONCELIGI_KOD ve TALEP_SORUMLU_TC'yi veritabanından almak için SQL sorguları
            string kategoriKodQuery = "SELECT TALEP_KATEGORI_KOD FROM TALEP_KATEGORILERI WHERE TALEP_KATEGORI_AD = :kategoriAd";
            string oncelikKodQuery = "SELECT TALEP_ONCELIGI_KOD FROM TALEP_ONCELIGI WHERE TALEP_ONCELIGI_AD = :oncelikAd";
            string sorumluTcQuery = "SELECT TALEP_SORUMLU_TC FROM TALEP_SORUMLULARI WHERE TALEP_SORUMLU_AD_SOYAD = :sorumluAdSoyad";

            OracleCommand kategoriKodCommand = new OracleCommand(kategoriKodQuery, connection);
            OracleCommand oncelikKodCommand = new OracleCommand(oncelikKodQuery, connection);
            OracleCommand sorumluTcCommand = new OracleCommand(sorumluTcQuery, connection);

            kategoriKodCommand.Parameters.Add(new OracleParameter("kategoriAd", kategoriAd));
            oncelikKodCommand.Parameters.Add(new OracleParameter("oncelikAd", oncelikAd));
            sorumluTcCommand.Parameters.Add(new OracleParameter("sorumluAdSoyad", sorumluAdSoyad));

            connection.Open();

            // TALEP_KATEGORI_KOD, TALEP_ONCELIGI_KOD ve TALEP_SORUMLU_TC'yi al
            string kategoriKod = kategoriKodCommand.ExecuteScalar().ToString();
            string oncelikKod = oncelikKodCommand.ExecuteScalar().ToString();
            string sorumluTc = sorumluTcCommand.ExecuteScalar().ToString();

            // TALEP tablosuna ekleme işlemi
            string insertQuery = "INSERT INTO TALEP (TALEP_KATEGORI_KOD, TALEP_ONCELIGI_KOD, TALEP_SORUMLU_TC, TALEP_ICERIGI) VALUES (:kategoriKod, :oncelikKod, :sorumluTc, :talepIcerigi)";
            using (OracleCommand insertCommand = new OracleCommand(insertQuery, connection))
            {
                insertCommand.Parameters.Add(new OracleParameter("kategoriKod", kategoriKod));
                insertCommand.Parameters.Add(new OracleParameter("oncelikKod", oncelikKod));
                insertCommand.Parameters.Add(new OracleParameter("sorumluTc", sorumluTc));
                insertCommand.Parameters.Add(new OracleParameter("talepIcerigi", talepIcerigi));

                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Talep kaydedildi!');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "scrolltoBottom", "setTimeout(function() { window.scrollTo(0, document.body.scrollHeight); }, 100);", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Talep kaydedilemedi!');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "scrolltoBottom", "setTimeout(function() { window.scrollTo(0, document.body.scrollHeight); }, 100);", true);
                }
            }
        }
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}