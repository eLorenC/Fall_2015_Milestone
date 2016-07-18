<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../CSS/Default.css" />
</head>
<body>
    <%-- Navigation --%>
    <!--#include file="../HTML/nav.html"-->

    <%-- Main Body - ASP Form Elements --%>
    <main>
        <div id="wrapper" class="col-nf-10 center">
            <form id="form1" runat="server">
                <h1>Our Products</h1>
                SEARCH:
                <asp:TextBox ID="searchTerm" runat="server" />
                <asp:Button ID="searchBtn" runat="server"
                    Text="Search" OnClick="searchBtn_OnClick" />
                <br />
                <asp:Label ID="statusL" runat="server" />
                <div id="grid">
                    <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="false" OnSortCommand="dgSearchList_SortClick">
                        <Columns>
                            <asp:BoundField DataField="productID" HeaderText="Product ID" />
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:HyperLink ID="nameLink" runat="server"
                                        NavigateUrl='<%# "./ProductDetails.aspx?ProductID=" + Eval("productID") %>'
                                        Text='<%# Eval("productName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="size" HeaderText="Size" />
                            <asp:BoundField DataField="price" HeaderText="Price" />
                        </Columns>
                    </asp:GridView>
                </div>
            </form>
        </div>
    </main>
    <!--#include file="../HTML/footer.html" -->
</body>
</html>
