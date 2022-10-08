<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log_manage.aspx.cs" Inherits="info_manage_log_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>日志管理</title>

    <link href="../css/main.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">日志管理</p>


        <div class="margin-top-bottom-rem">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                Width="100%"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting"
                DataKeyNames="ID" PageSize="12">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True"
                                OnCheckedChanged="CheckBox2_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="登录名" />
                    <asp:BoundField DataField="ip" HeaderText="IP地址" />
                    <asp:BoundField DataField="log_time" HeaderText="时间" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="operate" HeaderText="操作" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <PagerSettings Visible="false" />
                <RowStyle CssClass="gridview_row" />
                <HeaderStyle CssClass="gridview_head" />
            </asp:GridView>
        </div>

        <div class="margin-top-bottom-rem">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="pagination-button">首页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="pagination-button">上一页</asp:LinkButton>
            <span>第<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="pagination-button"
                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>页</span>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="pagination-button">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="pagination-button">尾页</asp:LinkButton>
            <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button2_Click" Text="批量删除" />
        </div>

    </form>

</body>
</html>
