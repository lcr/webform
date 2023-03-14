<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="info_show_details" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>详细信息</title>
    <link href="../css/public.css" rel="stylesheet" type="text/css" />
    <link href="../css/details.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <div class="slideshow-container">
        <div class="slideShowImg">
            <img src="../img/img_nature_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_snow_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_mountains_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_lights_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_woods_wide.jpg" />
        </div>
        <div class="slideshow-dot-cantainer">
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
        </div>
    </div>

    <form id="form1" runat="server">
        <nav class="nav">
            <a href="../index.aspx">首页</a>
            <a href="list.aspx?class_name=繁中假字">繁中假字</a>
            <a href="../about.aspx">关于我们</a>
        </nav>

        <div class="details-content">
            <div class="details-this-page">
                <a href="../index.aspx">首页</a>&gt;
                <asp:HyperLink runat="server" Text='<%# Eval("name") %>' ID="DetailsHyper" NavigateUrl='<%# Eval("name") %>' />&gt;              
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="details-title">
                <h1>
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="details-title"></asp:Label></h1>
            </div>

            <div>
                <p class="details-time">发布时间：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 浏览次数：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
            </div>

            <div>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

    </form>
    <footer>
        <p>©2023 All Rights Reserved</p>
    </footer>

    <script src="../js/sideshow.js"></script>
    <script src="../js/calendar.js"></script>
</body>
</html>
