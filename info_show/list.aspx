<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="info_show_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>查看更多</title>
    <link href="../css/public.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
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

        <div class="list-content">
            <p class="archive-title"><a href="../index.aspx">首页</a>&gt;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" Width="100%" BorderWidth="0" GridLines="None"
                OnRowDataBound="GridView_RowDataBound" PageSize="10" OnDataBound="GridView1_DataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="flex-space-between girdview-list-item">
                                <a href="details.aspx?id=<%#Eval("id")%>"><%#Eval("title")%></a>
                                <span><%#Convert.ToDateTime(Eval("ptime")).ToString("yyyy-MM-dd")%></span>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="false" />
            </asp:GridView>


            <div class="list-pagination">
                <div class="list-pagination-label">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>

                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="list-pagination-button">首页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="list-pagination-button">上一页</asp:LinkButton>
                    <span>第<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        CssClass="list-pagination-dropdown">
                    </asp:DropDownList>页</span>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="list-pagination-button">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="list-pagination-button">尾页</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>

    <footer>
        <p>©2023 All Rights Reserved</p>
    </footer>
    <script src="../js/sideshow.js"></script>
</body>
</html>
