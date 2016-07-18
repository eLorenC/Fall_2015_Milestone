<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="ASPX_ASPXCS_Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link type="text/css" rel="stylesheet" href="../CSS/Default.css" />
    <script src="../JS_FRAMEWORKS/jquery-1.11.3.min.js"></script>
<%--    <script src="../SCRIPTS/side-cart-menu.js"></script>--%>
    <title>Cart</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
</head>
<body>
    <!--#include file="../HTML/nav.html"-->
    <main>
        <div id="wrapper" class="col-nf-10 center">
            <form id="form1" runat="server">
                <div id="SideCart" <%--hidden="hidden"--%>>
                    <asp:LinkButton ID="GoToCart" runat="server" Text="My Cart" />
                    <ul id="SideDrop" class="col-nf-1 .trans-short-ease">
                        <li><a href="#">ge</a></li>
                        <li><a href="#">ge</a></li>
                        <li><a href="#">ge</a></li>
                        <li><a href="#">ge</a></li>
                    </ul>
                </div>
                <div class="row">
                    <div class="col-f-12">
                    <asp:GridView ID="shopCartGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="IID" 
                                  OnSelectedIndexChanged="shopCartGrid_SelectedIndexChanged"
                                  OnSelectedIndexChanging="shopCartGrid_SelectedIndexChanging"
                                  OnRowDeleting="shopCartGrid_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="IID" HeaderText="Product ID" />
                            <asp:BoundField DataField="IName" HeaderText="Name" />
                            <asp:BoundField DataField="IDesc" HeaderText="Description" />
                            <asp:BoundField DataField="IPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>
                            <asp:BoundField DataField="IQuant" HeaderText="Quantity" />
                            <asp:BoundField DataField="IItemTotal" HeaderText="Item (Quantity * Unit Price)" DataFormatString="{0:c}"/>
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete"/>
                        </Columns>   
                    </asp:GridView>
                       
                    
                    </div>
                </div>
                <div id="CartTotals" class="row">
                    <p><b>Sub Total:&nbsp;</b><asp:Label ID="SubTotal_lbl" CssClass="" runat="server" /></p>
                    <p><b>Tax:&nbsp;</b><asp:Label ID="Tax_lbl" CssClass="" runat="server" /></p>
                    <p><b>Total:&nbsp;</b><asp:Label ID="Total_lbl" CssClass="" runat="server" /></p>
                </div>
            </form>
        </div>
    </main>
    <!--#include file="../HTML/footer.html" --> <!--generates footer-->
</body>
</html>