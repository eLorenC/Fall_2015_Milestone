using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Products : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateDatagrid();
        }
    }
    protected void searchBtn_OnClick(object sender, EventArgs e)
    {
        try
        {
            string connectionString
               = ConfigurationManager.ConnectionStrings["WeLoveWhiskey"].ConnectionString;

            statusL.Text = "Searching for " + searchTerm.Text;
            string sqlQuery = "USE WeLoveWhiskey; SELECT  productID, productName, pType, size, price " +
                               " FROM Product " +
                               "Where productName LIKE ''";


            string[] searchTerms = searchTerm.Text.Replace(";"," ").Replace("\'","").Replace(","," ").Split(' ');

            foreach (string term in searchTerms)
            {
                sqlQuery += " OR productName like '%" + term + "%' ";
            }
            sqlQuery += ";";
            SqlDataAdapter outlookRecords =
                    new SqlDataAdapter(sqlQuery, connectionString);

            // Create and fill a DataSet.
            DataSet ds = new DataSet();
            outlookRecords.Fill(ds);
            DataView dv = new DataView(ds.Tables[0]);
            ProductsGrid.DataSource = dv ;
            ProductsGrid.DataBind();
        }
        catch (Exception exc)
        {

            statusL.Text = exc.Message + "\n " + exc.StackTrace;
        }
    }

    public void PopulateDatagrid()
    {
        try
        {
            string connectionString
               = ConfigurationManager.ConnectionStrings["WeLoveWhiskey"].ConnectionString;
            string sqlQuery = "SELECT productID, productName, pType, size, price " +
                              " FROM Product; ";
            SqlDataAdapter outlookRecords =
                new SqlDataAdapter(sqlQuery, connectionString);

            // Create and fill a DataSet.
            DataSet ds = new DataSet();
            outlookRecords.Fill(ds);
            DataView dv = new DataView(ds.Tables[0]);
            ProductsGrid.DataSource = dv;
            ProductsGrid.DataBind();

        }
        catch (Exception exc)
        {
            statusL.Text = exc.Message;
        }

    }

}
