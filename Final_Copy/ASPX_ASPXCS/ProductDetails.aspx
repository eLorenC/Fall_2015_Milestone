<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
    <link type="text/css" rel="Stylesheet" href="../CSS/Default.css" />
</head>
<body>
    <!--#include file="../HTML/nav.html"-->
    <main>
        <div id="wrapper" class="col-nf-10 center">
            <div class="row col-np-12" style="padding: 15px;">
                <div id="box-lg" class="row-child">IMG</div>
            </div>
            <div class="row">
                <form id="form2" runat="server">
                    <div id="grid">
                        <div>
                            <asp:Label runat="server" ID="pID_lbl" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="pN_lbl" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="pT_lbl" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="pPrice_lbl" />
                        </div>
                    </div>
                    <asp:DropDownList ID="pQuantityList" runat="server">
                            <asp:ListItem Value="1" Text="1" Selected="True" />
                            <asp:ListItem Value="2" Text="2" />
                            <asp:ListItem Value="3" Text="3" />
                            <asp:ListItem Value="4" Text="4" />
                            <asp:ListItem Value="5" Text="5" />
                        </asp:DropDownList>
                    <asp:Button ID="addCart" CssClass="btn-rec-sm btn-mod-rd-lg" Text="Add To Cart" runat="server" OnClick="addCart_btn_Click" />
                    <asp:HiddenField ID="product_ID" runat="server" />
                </form>
            </div>
            <div class="row"></div>
        </div>
    </main>
    <!--#include file="../HTML/footer.html"-->
</body>
</html>
