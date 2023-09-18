using System.Data.SqlClient;

public class Sqlsinif
{
    public SqlConnection baglanti()
    {
        SqlConnection baglan = new SqlConnection(@"Server=HKAYA-L\\SQLEXPRESS;Database=Sefa;User Id=deneme;Password='123456789s+'");
        baglan.Open();
        return baglan;
    }
}