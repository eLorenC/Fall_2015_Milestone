<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>We Love Whiskey</title>
    <script type="text/javascript" src="../SCRIPTS/Navigation.js"></script>
    <script type="text/javascript" src="../JS_FRAMEWORKS/jquery-1.11.3.min.js"></script>
    <link type="text/css" rel="stylesheet" href="../CSS/Default.css" />
    <style>

        #mainBackground {
            width: 100%;
            opacity: .85;
            z-index: 4;
        }

        #logo {
            z-index: 5;
            position: relative;
            width: 30%;
            height: 30%;
            right: 50px;
            top: 300px;
            opacity: 1.5;
        }
    </style>
</head>

<body>
<%--    <img id="glassBack" title="" alt="" src="../IMAGES/WhiskeyBack.png" />--%>
    <div id="hdTop" style="opacity: 1.0;">
        <div class="introPic" style="opacity:1.0">

            <!--Insert Main Pic -->
            <img src="../IMAGES/Logo_1.png" id="logo" />
        </div>
    </div>

    <!--Navigation bar-->
    <!--#include file="../HTML/nav.html"-->

    <main style="text-align:center; vertical-align: middle;">
        <div id="wrapper" class="col-nf-10 center">
        </div>
    </main>

    <!--generates footer-->
    <!--#include file="../HTML/footer.html" -->
</body>

</html>
