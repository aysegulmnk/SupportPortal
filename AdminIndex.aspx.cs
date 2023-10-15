using System;
using System.Data.OracleClient;
using System.Data;
using System.Web.UI.WebControls;

public partial class AdminIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string connectionString = "Data Source=ORCL;User ID=DESTEK_PORTAL;Password=1;Unicode=True";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TK.TALEP_KATEGORI_AD AS Kategori, " +
                               "TD.TALEP_DURUM_AD AS Durum, " +
                               "GK.KULLANICI_AD_SOYAD AS Gonderen, " +
                               "TSAD.TALEP_SORUMLU_AD_SOYAD AS Sorumlu, " +
                               "TOA.TALEP_ONCELIGI_AD AS Oncelik, " +
                               "T.UNIVERSITE_KOD AS UniversiteKod, " +
                               "T.YAPILAN_ISLEM AS YapilanIslem " +
                               "FROM TALEP T " +
                               "INNER JOIN TALEP_KATEGORILERI TK ON T.TALEP_KATEGORI_KOD = TK.TALEP_KATEGORI_KOD " +
                               "INNER JOIN TALEP_DURUMLARI TD ON T.TALEP_DURUM_KOD = TD.TALEP_DURUM_KOD " +
                               "INNER JOIN GONDEREN_KULLANICI_BILGILERI GK ON T.GONDEREN_KULLANICI_NO = GK.GONDEREN_KULLANICI_NO " +
                               "INNER JOIN TALEP_SORUMLULARI TS ON T.TALEP_SORUMLU_TC = TS.TALEP_SORUMLU_TC " +
                               "INNER JOIN TALEP_ONCELIGI TOA ON T.TALEP_ONCELIGI_KOD = TOA.TALEP_ONCELIGI_KOD " +
                               "INNER JOIN TALEP_SORUMLU_AD_SOYAD TSAD ON TS.TALEP_SORUMLU_TC = TSAD.TALEP_SORUMLU_TC";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    OracleDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Kategori");
                    dataTable.Columns.Add("Durum");
                    dataTable.Columns.Add("Gonderen");
                    dataTable.Columns.Add("Sorumlu");
                    dataTable.Columns.Add("Oncelik");
                    dataTable.Columns.Add("UniversiteKod");
                    dataTable.Columns.Add("YapilanIslem");

                    while (reader.Read())
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["Kategori"] = reader["Kategori"];
                        newRow["Durum"] = reader["Durum"];
                        newRow["Gonderen"] = reader["Gonderen"];
                        newRow["Sorumlu"] = reader["Sorumlu"];
                        newRow["Oncelik"] = reader["Oncelik"];
                        newRow["UniversiteKod"] = reader["UniversiteKod"];
                        newRow["YapilanIslem"] = reader["YapilanIslem"];
                        dataTable.Rows.Add(newRow);
                    }

                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();
                }
            }
        }
    }
}
