using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class deldata : System.Web.UI.Page
{
    string connection = "Data Source=HKAYA-L\\SQLEXPRESS;Initial Catalog=Sefa;Integrated Security=True";
    //string connection = "Data Source=localhost;Initial Catalog=Sefa;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    PagedDataSource objPds = new PagedDataSource();

    protected void LinkBtnDelete_Command(object sender, CommandEventArgs e)
    {
        SqlConnection baglanti = new SqlConnection(connection);
        baglanti.Open();
        SqlCommand komut = new SqlCommand();
        komut.Connection = baglanti;
        komut.CommandText = ("DELETE FROM Users where User_ID = " + e.CommandArgument.ToString() + "");
        komut.ExecuteNonQuery();
        baglanti.Close();
        loaddata();
    }

    void loaddata()
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

        using (SqlConnection con = new SqlConnection(connection))
        {
            con.Open();

            string query = "SELECT Login_name, Password, First_name, Last_name, Authority_level, CONVERT(varchar(10), Birthday, 120) as Birthday, Salary FROM Users WHERE User_ID=@id";
            using (SqlCommand komut = new SqlCommand(query, con))
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
                        txtbday.Text = dataReader["Birthday"].ToString().Substring(0, 10);
                        txtsalary.Text = dataReader["Salary"].ToString();
                    }
                }
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "OpenUpdateScript", "$('#update').modal('show');", true);
    }


    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string id = hdid.Value;
        using (SqlConnection con = new SqlConnection(connection))
        {
            con.Open();
            SqlCommand cmd;
            if (!string.IsNullOrEmpty(hdid.Value))
            { 
                cmd = new SqlCommand("Update Users set Login_name = @lo_name, password = @pass, First_name = @f_name, " +
                    "Last_name = @l_name, Authority_Level = @auth, Birthday = @bday, Salary = @salary where User_ID = @id");
                cmd.Parameters.AddWithValue("@id", id);
            }
            else
            {
                cmd = new SqlCommand("insert into Users (Login_name,Password,First_name,Last_name,Authority_Level,Birthday" +
                    ",Salary values (@lo_name, @pass, @f_name, @l_name, @auth, @bday, @salary");
            }

            cmd.Parameters.AddWithValue("@lo_name",txtlogname.Text);
            cmd.Parameters.AddWithValue("@pass",txtpass.Text);
            cmd.Parameters.AddWithValue("@f_name",txtfname.Text);
            cmd.Parameters.AddWithValue("@l_name",txtlname.Text);
            cmd.Parameters.AddWithValue("@auth",txtauth.Text);
            cmd.Parameters.AddWithValue("@bday",Convert.ToDateTime(txtbday.Text));
            cmd.Parameters.AddWithValue("@salary",txtsalary.Text);

            cmd.Connection = con;

            int rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            if(rowsaffected > 0)
            {
                lblmsg.Text = "Veri başarılı bir şekilde güncellendi.";
                Page.Response.Redirect(Page.Request.Url.ToString(), false);
            }
            else
            {
                lblmsg.Text = "Veri güncellenirken bir hata oldu.";
            }
            string script = "$('#mymodal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
            con.Close();
        }
    }

    private void LoadData()
    {
        SqlConnection baglanti = new SqlConnection(connection);
        string komut = string.Format("SELECT * FROM Users");

        baglanti.Open();

        SqlCommand command = new SqlCommand(komut, baglanti);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);

        objPds.AllowPaging = true;
        objPds.PageSize = 5;

        if (CurrentPage < 0)
        {
            CurrentPage = 0;
        }


        objPds.DataSource = dataSet.Tables[0].DefaultView;
        objPds.CurrentPageIndex = CurrentPage;

        lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of " + objPds.PageCount.ToString();
        pageCount.Text = objPds.PageCount.ToString();

        DataList2.DataSource = objPds;
        DataList2.DataBind();

        baglanti.Close();
    }

    private void ItemsGet()
    {
        lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of " + objPds.PageCount.ToString();
        btnFirst.Enabled = !objPds.IsFirstPage;
        btnPre.Enabled = !objPds.IsFirstPage && CurrentPage > 0;
        btnNext.Enabled = !objPds.IsLastPage && CurrentPage < objPds.PageCount;
        btnLast.Enabled = !objPds.IsLastPage && CurrentPage < objPds.PageCount;
    }

    public int CurrentPage
    {
        get
        {
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
            {
                return 0;
            }
            else
            {
                return (int)o;
            }
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }

    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        LoadData();
        ItemsGet();
    }

    protected void btnPre_Click(object sender, EventArgs e)
    {
        if (CurrentPage > 0)
        {
            CurrentPage -= 1;
            LoadData();
            ItemsGet();
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        LoadData();
        ItemsGet();
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        int lastPageIndex = Convert.ToInt32(pageCount.Text) - 1;
        CurrentPage = lastPageIndex;
        LoadData();
        ItemsGet();
    }
}