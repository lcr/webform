<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>WebApplication</title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />
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
            <a href="index.aspx" class="nav-active">首页</a>
            <a href="info_show/list.aspx?class_name=繁中假字">繁中假字</a>
            <a href="about.aspx">关于我们</a>
        </nav>


        <div class="layout-flex-parent">
            <div class="layout-flex-left">
                <div class="girdview-flex-space-between">
                    <div class="girdview-index">
                        <div class="flex-space-between girdview-index-title-div">
                            <p class="girdview-index-title">Lipsum</p>
                            <a href="info_show/list.aspx?class_name=Lipsum" class="girdview-index-more">查看更多&gt;&gt;</a>
                        </div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                            BorderWidth="0" OnRowDataBound="GridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a class="girdview-index-item" href="info_show/details.aspx?id=<%#Eval("id")%>"><%#Eval("title").ToString().Length > 17 ? Eval("title").ToString().Substring(0,17)+"..." : Eval("title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>


                    <div class="girdview-index">
                        <div class="flex-space-between girdview-index-title-div">
                            <p class="girdview-index-title">简中假文</p>
                            <a href="info_show/list.aspx?class_name=简中假文" class="girdview-index-more">查看更多&gt;&gt;</a>
                        </div>

                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" GridLines="None"
                            BorderWidth="0" OnRowDataBound="GridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a class="girdview-index-item" href="info_show/details.aspx?id=<%#Eval("id")%>"><%#Eval("title").ToString().Length > 17 ? Eval("title").ToString().Substring(0,17)+"..." : Eval("title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="girdview-flex-space-between">
                    <div class="girdview-index">
                        <div class="flex-space-between girdview-index-title-div">
                            <p class="girdview-index-title">日本语</p>
                            <a href="info_show/list.aspx?class_name=日本语" class="girdview-index-more">查看更多&gt;&gt;</a>
                        </div>
                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" GridLines="None"
                            BorderWidth="0" OnRowDataBound="GridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField ControlStyle-BorderColor="red">
                                    <ItemTemplate>
                                        <a class="girdview-index-item" href="info_show/details.aspx?id=<%#Eval("id")%>"><%#Eval("title").ToString().Length > 17 ? Eval("title").ToString().Substring(0,17)+"..." : Eval("title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>


                    <div class="girdview-index">
                        <div class="flex-space-between girdview-index-title-div">
                            <p class="girdview-index-title">ABCDE</p>
                            <a href="info_show/list.aspx?class_name=ABCDE" class="girdview-index-more">查看更多&gt;&gt;</a>
                        </div>
                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" GridLines="None"
                            BorderWidth="0" OnRowDataBound="GridView_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a class="girdview-index-item" href="info_show/details.aspx?id=<%#Eval("id")%>"><%#Eval("title").ToString().Length > 17 ? Eval("title").ToString().Substring(0,17)+"..." : Eval("title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>


            <div class="layout-flex-right">
                <p>账号:</p>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="login-textbox"></asp:TextBox>

                <p class="login-text">密码:</p>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="login-textbox" TextMode="Password"></asp:TextBox>

                <asp:Button OnClick="Login_Click" runat="server" ID="LoginButton" Text="登录后台" CssClass="login-button" />
                <%-- <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/dl.jpg" OnClick="ImageButton1_Click" />--%>
                <%-- <asp:Button OnClick="Reset_Click" runat="server" ID="ResetButton" Text="重置" CssClass="login-button" />--%>
            </div>
        </div>
    </form>
    <footer>
        <p>©2022 All Rights Reserved</p>
    </footer>
    <script src="js/sideshow.js"></script>
</body>
</html>
