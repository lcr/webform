<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_list.aspx.cs" Inherits="info_manage_info_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息查询</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">信息查询</p>

        <div class="margin-top-bottom-rem">
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="dropdownlist"></asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" CssClass="textbox"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查询" CssClass="button" />
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="5" AllowPaging="True"
            OnDataBound="GridView1_DataBound" CssClass="gridview" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" PageSize="12">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" CssClass="girdview-checkbox" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="girdview-checkbox" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="info_list_modify.aspx?id={0}" DataTextField="title" HeaderText="标题" />
                <asp:BoundField DataField="name" HeaderText="类别" />
                <asp:BoundField DataField="publisher" HeaderText="发布人" />
                <asp:BoundField DataField="clicks" HeaderText="点击率" />
                <asp:BoundField DataField="ptime" HeaderText="发布时间" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <HeaderStyle CssClass="gridview_head" />
            <AlternatingRowStyle BackColor="#eeeeee" />
            <RowStyle CssClass="gridview_row" />
            <PagerStyle />
            <PagerSettings Visible="false" />
        </asp:GridView>


        <div class="margin-top-bottom-rem">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="pagination-button">首页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="pagination-button">上一页</asp:LinkButton>
            <span>第<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="pagination-dropdown"
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>页</span>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="pagination-button">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="pagination-button">尾页</asp:LinkButton>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="批量删除" CssClass="button" />
        </div>

    </form>
</body>
</html>
