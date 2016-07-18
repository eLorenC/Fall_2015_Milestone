<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact</title>
    <link type="text/css" rel="stylesheet" href="../CSS/Default.css" />
    <style>
        #formWrapper {
            margin: 0 auto;
            padding-top: 110px;
            background: #DBBCBC;
            width: 1000px;
            height: 800px;
            text-align: center;
            position: relative;
            top: 100px;
            z-index: 2;
        }
    </style>
</head>
<body>
    <%-- Navigation --%>
    <!--#include file="../HTML/nav.html"-->

    <%-- Main Body - ASP Form Elements --%>
    <main>
        <div id="wrapper" class="col-nf-10 center">
            <form id="mailForm" runat="server">
                <div>
                    <asp:Panel ID="emailForm" runat="server">
                        <p>Email Address:</p>
                        <asp:TextBox ID="senderEmail" runat="server" Width="255px" />
                        <asp:RequiredFieldValidator ID="senderEmailValidator" runat="server" ControlToValidate="senderEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="emailVal" runat="server"     
                                            ErrorMessage="Please enter a valid email" 
                                            ControlToValidate="senderEmail"     
                                            ValidationExpression="^([^\n\b\t\r\s][\w\.]{1,30})((\.){0,25})([@]{1})([\w]{1,30})(\.{1})([A-Za-z]{1,25})" 
                                            CssClass="fieldOverRide"/>--%>

                        <p>Subject:</p>
                        <asp:TextBox ID="subject" runat="server" Width="255px" />
                        <asp:RequiredFieldValidator ID="subjectValidator" runat="server"
                            ControlToValidate="subject">*</asp:RequiredFieldValidator>
                        <p>Message:</p>
                        <asp:TextBox ID="message" runat="server" Width="255px" TextMode="MultiLine" Height="80px" />
                        <asp:RequiredFieldValidator ID="messageValidator" runat="server"
                            ControlToValidate="message" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </asp:Panel>
                    <asp:Literal ID="sentEmail" runat="server" Visible="False"></asp:Literal>
                    <asp:Button ID="b1" Text="Submit" runat="server" />
                </div>
            </form>
        </div>
    </main>
    <!--#include file="../HTML/footer.html" -->
</body>

</html>
