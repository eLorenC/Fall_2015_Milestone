using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ASPX_ASPXCS_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            try
            {
                ShoppingCart newCart = (ShoppingCart)Session["cart"];

                this.shopCartGrid.DataSource = newCart.Basket;
                this.shopCartGrid.DataBind();

                SubTotal_lbl.Text = string.Format("{0:C}", newCart.SubTotal);
                Tax_lbl.Text = string.Format("{0:C}", newCart.Tax);
                Total_lbl.Text = string.Format("{0:C}", newCart.Total);
            }
            catch (Exception err) { }
        
    }

    protected void shopCartGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = shopCartGrid.SelectedRow;
    }

    protected void shopCartGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = shopCartGrid.Rows[e.NewSelectedIndex];
    }

    protected void shopCartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try { 
        ShoppingCart temp = (ShoppingCart)Session["cart"];
            var key = (int)shopCartGrid.DataKeys[e.RowIndex].Value;
        temp.removeItem(key);
            Session["cart"] = temp;
        shopCartGrid.DataSource = temp.Basket; 
        shopCartGrid.DataBind();
        Response.Redirect("cart.aspx");

        //SubTotal_lbl.Text = string.Format("{0:C}", temp.SubTotal);
        //Tax_lbl.Text = string.Format("{0:C}", temp.Tax);
        //Total_lbl.Text = string.Format("{0:C}", temp.Total);
    }
        catch (Exception err) { Response.Write(err.Message + " " + err.StackTrace); }
    }
}
