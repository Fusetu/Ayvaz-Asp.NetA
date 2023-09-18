using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class MasterPage : System.Web.UI.MasterPage
{

    string connection = "Data Source=HKAYA-L\\SQLEXPRESS;Initial Catalog=Sefa;Integrated Security=True";
    //string connection = "Data Source=localhost;Initial Catalog=Sefa;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btn_add_Click1(object sender, EventArgs e)
    {
        string script = "$('#add').modal('show');";
        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", script, true);
    }

    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        if (txtlogname.Text == "" || txtpass.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtauth.Text == "" || txtbday.Text == "" || txtsalary.Text == "")
        {
            Response.Write("<script>alert('Lütfen veri girmek için boş alanları doldurunuz.');</script>");
            txtlogname.Text = "";
            txtpass.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtauth.Text = "";
            txtbday.Text = "";
            txtsalary.Text = "";
        }
        else
        {
            using (SqlConnection baglanti = new SqlConnection(connection))
            {
                using (SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Login_Name = @Login_Name", baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@Login_Name", txtlogname.Text);

                    baglanti.Open();

                    int kullaniciSayisi = (int)kontrolKomut.ExecuteScalar();

                    if (kullaniciSayisi > 0)
                    {
                        Response.Write("<script>alert('Bu kullanıcı adı zaten mevcut. Lütfen farklı bir kullanıcı adı seçin.');</script>");
                        txtlogname.Text = "";
                        txtpass.Text = "";
                        txtfname.Text = "";
                        txtlname.Text = "";
                        txtauth.Text = "";
                        txtbday.Text = "";
                        txtsalary.Text = "";
                    }
                    else
                    {
                        using (SqlCommand komut = new SqlCommand("INSERT INTO Users VALUES(@Login_name, @Password, @First_name, @Last_name, @Authority_level, @Birthday, @Salary)", baglanti))
                        {

                            komut.Parameters.AddWithValue("@Login_name", txtlogname.Text);
                            komut.Parameters.AddWithValue("@Password", txtpass.Text);
                            komut.Parameters.AddWithValue("@First_name", txtfname.Text);
                            komut.Parameters.AddWithValue("@Last_name", txtlname.Text);
                            komut.Parameters.AddWithValue("@Authority_level", txtauth.Text);
                            komut.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(txtbday.Text));
                            komut.Parameters.AddWithValue("@Salary", txtsalary.Text);

                            int affectedRows = komut.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                Response.Redirect("delete.aspx?mesaj=Veri başarıyla eklendi.");
                            }
                            else
                            {
                                Response.Redirect("delete.aspx?mesaj=Veri eklenirken bir hata oluştu.");
                            }
                        }
                    }
                }
                baglanti.Close();
            }
        }
    }
}
