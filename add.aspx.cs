using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class adddata : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox8.Text == "")
        {
            Response.Write("<script>alert('Lütfen veri girmek için boş alanları doldurunuz.');</script>");
        }
        else
        {
            using (SqlConnection baglanti = new SqlConnection(connection))
            {
                using (SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Login_Name = @Login_Name", baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@Login_Name", TextBox2.Text);

                    baglanti.Open();

                    int kullaniciSayisi = (int)kontrolKomut.ExecuteScalar();

                    if (kullaniciSayisi > 0)
                    {
                        Response.Write("<script>alert('Bu kullanıcı adı zaten mevcut. Lütfen farklı bir kullanıcı adı seçin.');</script>");
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                        TextBox7.Text = "";
                        TextBox8.Text = "";
                    }
                    else
                    {
                        using (SqlCommand komut = new SqlCommand("INSERT INTO Users VALUES(@Login_name, @Password, @First_name, @Last_name, @Authority_level, @Birthday, @Salary)", baglanti))
                        {

                            komut.Parameters.AddWithValue("@Login_name", TextBox2.Text);
                            komut.Parameters.AddWithValue("@Password", TextBox3.Text);
                            komut.Parameters.AddWithValue("@First_name", TextBox4.Text);
                            komut.Parameters.AddWithValue("@Last_name", TextBox5.Text);
                            komut.Parameters.AddWithValue("@Authority_level", TextBox6.Text);
                            komut.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(TextBox7.Text));
                            komut.Parameters.AddWithValue("@Salary", TextBox8.Text);

                            int affectedRows = komut.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                Response.Redirect("add.aspx?mesaj=Veri başarıyla eklendi.");
                                TextBox2.Text = "";
                                TextBox3.Text = "";
                                TextBox4.Text = "";
                                TextBox5.Text = "";
                                TextBox6.Text = "";
                                TextBox7.Text = "";
                                TextBox8.Text = "";
                            }
                            else
                            {
                                Response.Redirect("add.aspx?mesaj=Veri eklenirken bir hata oluştu.");
                            }
                        }
                    }
                }
                baglanti.Close();
            }
        }
    }
}