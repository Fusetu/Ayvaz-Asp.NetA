using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class update : System.Web.UI.Page
{

    string connection = "Data Source=HKAYA-L\\SQLEXPRESS;Initial Catalog=Sefa;Integrated Security=True";
    //string connection = "Data Source=localhost;Initial Catalog=Sefa;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(connection);
        string komut = string.Format("SELECT [User_ID], [Login_name], [Password], [First_name], [Last_name], [Authority_Level], [Birthday], [Salary] FROM Users");

        baglanti.Open();
        SqlCommand command = new SqlCommand(komut, baglanti);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        DataList2.DataSource = dataSet;
        DataList2.DataBind();
        baglanti.Close();

    }

    protected void LinkBtnUpdate_Click(object sender, EventArgs e)
    {
        string script = "$('#update').modal('show');";
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
    }

    protected void LinkBtnUpdate_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        hdid.Value = id;

        using (SqlConnection conn = new SqlConnection(connection))
        {
            conn.Open();

            string cmd = "SELECT * FROM Users WHERE User_ID=@id";
            using (SqlCommand komut = new SqlCommand(cmd, conn))
            {
                komut.Parameters.AddWithValue("@id", id);

                using (SqlDataReader dataReader = komut.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        txtlogname.Text = dataReader["Login_name"].ToString();
                        txtpass.Text = dataReader["Password"].ToString();
                        txtfname.Text = dataReader["First_name"].ToString();
                        txtlname.Text = dataReader["Last_name"].ToString();
                        txtauth.Text = dataReader["Authority_level"].ToString();
                        txtbday.Text = dataReader["Birthday"].ToString();
                        txtsalary.Text = dataReader["Salary"].ToString();
                    }
                }
            }
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "OpenUpdateScript", "$('#update').modal('show');", true);
    }
}
