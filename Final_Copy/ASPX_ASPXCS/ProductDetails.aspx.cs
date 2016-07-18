using System;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    private WLW db = new WLW();
    protected void Page_Load(object sender, EventArgs e)
    {
        string pID, pName, pTp, pPrice;
        int uID;
        
        if (!Page.IsPostBack)
        {
            try
            {
                //Save value of url parameter ProductID as int uID
                int uID = Convert.ToInt16(Request["ProductID"]);
                product_ID.Value = uID.ToString();

                //Instance of Table to represent underlying database table -> contains Product Class Object(s).  Run GetTable() on database to retrieve <Product> table.
                Table<Product> Product = db.GetTable<Product>();
                db.Log = Console.Out;

                //use Queryable Interface to evaluate Product
                IQueryable<Product> pQuery =
                    from p in Product
                    where p.ProductID == uID
                    select p;

                pID = pQuery.FirstOrDefault().ProductID.ToString();
                pName = pQuery.FirstOrDefault().productName;
                pTp = pQuery.FirstOrDefault().pType;
                pPrice = pQuery.FirstOrDefault().price.ToString();

                pID_lbl.Text = pID;
                pN_lbl.Text = pName;
                pT_lbl.Text = pTp;
                pPrice_lbl.Text = pPrice;
            }
            catch (Exception err)
            {
                Response.Write("<p>Error:" + err.Message + "</p>");
            }
        }
        else
        {
            uID = Convert.ToInt16(Request["ProductID"]);
            product_ID.Value = uID.ToString();

            Table<Product> Product = db.GetTable<Product>();
            db.Log = Console.Out;

            //use Queryable Interface to evaluate Product
            IQueryable<Product> pQuery =
                from p in Product
                where p.ProductID == uID
                select p;

            pID = pQuery.FirstOrDefault().ProductID.ToString();
            pName = pQuery.FirstOrDefault().productName;
            pTp = pQuery.FirstOrDefault().pType;
            pPrice = pQuery.FirstOrDefault().price.ToString();

            pID_lbl.Text = pID;
            pN_lbl.Text = pName;
            pT_lbl.Text = pTp;
            pPrice_lbl.Text = pPrice;
        }
    }

    protected void addCart_btn_Click(object sender, EventArgs e)
    {
        int pQty, hfID;
        
        try
        {
            int.TryParse(pQuantityList.SelectedValue, out pQty);
            Button btn = (Button)sender;
            HiddenField hf = (HiddenField)btn.FindControl("product_ID");
            int.TryParse(hf.Value, out hfID);

            if (Session["cart"] == null)
            {
                ShoppingCart newCart = new ShoppingCart();
                newCart.addItem(new Item(hfID, pQty));
                Session["cart"] = newCart;
            }
            else
            {
                ShoppingCart newCart = (ShoppingCart)Session["cart"];
                newCart.addItem(new Item(hfID, pQty));
                Session["cart"] = newCart;
            }
        }
        catch (Exception err)
        {
            Response.Write(err.Message + " " + err.StackTrace.ToString());
        }
        Response.Redirect("Cart.aspx");
    }
}
