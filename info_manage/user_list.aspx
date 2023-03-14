<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_list.aspx.cs" Inherits="info_manage_news_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">用户管理</p>

        <div class="margin-top-bottom-rem">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                Width="100%" CellPadding="5" AllowPaging="True" PageSize="10"
                OnDataBound="GridView1_DataBound" CssClass="gridview" DataKeyNames="id"
                OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="账号" />
                    <%-- <asp:BoundField DataField="password" HeaderText="密码" />--%>
                    <asp:BoundField DataField="power" HeaderText="权限" />
                    <asp:BoundField DataField="email" HeaderText="邮箱" />
                    <asp:BoundField DataField="tel" HeaderText="电话" />
                    <asp:HyperLinkField DataTextField="name" HeaderText="修改" DataTextFormatString="修改" DataNavigateUrlFields="id" DataNavigateUrlFormatString="user_list_modify.aspx?id={0}" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <HeaderStyle CssClass="gridview_head" />
                <AlternatingRowStyle BackColor="#eeeeee" />
                <RowStyle CssClass="gridview_row" />
                <PagerStyle />
                <PagerSettings Visible="false" />
            </asp:GridView>
        </div>

        <div class="margin-top-bottom-rem">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="pagination-button">首页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="pagination-button">上一页</asp:LinkButton>
            <span>第<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="pagination-button"
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>页</span>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="pagination-button">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="pagination-button">尾页</asp:LinkButton>
        </div>
    </form>
</body>
</html>
