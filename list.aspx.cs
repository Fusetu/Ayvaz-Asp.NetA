using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mainpage : System.Web.UI.Page
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

        DataList2.DataSource = objPds;
        DataList2.DataBind();

        baglanti.Close();
    }

    private void ItemsGet()
    {
        lblCurrentPage.Text = "Page: " + (CurrentPage + 1).ToString() + " of " + objPds.PageCount.ToString();
        btnFirst.Enabled = !objPds.IsFirstPage;
        btnPre.Enabled = !objPds.IsFirstPage && CurrentPage > 0;
        btnNext.Enabled = !objPds.IsLastPage && CurrentPage < objPds.PageCount - 1;
        btnLast.Enabled = !objPds.IsLastPage && CurrentPage < objPds.PageCount - 1;
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
        //if (CurrentPage < objPds.PageCount - 1)
        //{
            CurrentPage += 1;
            LoadData();
            ItemsGet();
        //}
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        int lastPageIndex = objPds.PageCount - 1;
        CurrentPage = lastPageIndex;
        LoadData();
        ItemsGet();
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
}
