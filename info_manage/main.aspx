<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="info_manage_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>后台管理</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="body-form">
        <div class="main-top">
            <p>欢迎来到后台管理系统</p>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="main-signout">退出登录</asp:LinkButton>
            </div>
        </div>


        <div class="layout-flex-parent">
            <div class="layout-flex-left">
                <asp:TreeView ID="TreeView1" runat="server" CssClass="treeview" ImageSet="Simple">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <Nodes>
                        <asp:TreeNode Text="系统菜单" Value="系统菜单">

                            <asp:TreeNode Text="信息查询" Value="信息查询"
                                NavigateUrl="~/info_manage/info_list.aspx" Target="content"></asp:TreeNode>

                            <asp:TreeNode Text="信息添加" Value="信息添加"
                                NavigateUrl="~/info_manage/info_add.aspx" Target="content"></asp:TreeNode>

                            <asp:TreeNode Text="用户管理" Value="用户管理"
                                NavigateUrl="~/info_manage/user_list.aspx" Target="content"></asp:TreeNode>

                            <asp:TreeNode Text="用户添加" Value="用户添加 "
                                NavigateUrl="~/info_manage/user_add.aspx" Target="content"></asp:TreeNode>

                            <asp:TreeNode Text="日志管理" Value="日志管理 "
                                NavigateUrl="~/info_manage/log_manage.aspx" Target="content"></asp:TreeNode>

                            <asp:TreeNode Text="密码修改" Value="密码修改 "
                                NavigateUrl="~/info_manage/user_password_modify.aspx" Target="content"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"
                        HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </div>


            <div class="layout-flex-right">
                <iframe name="content" scrolling="no" src="info_list.aspx" class="main-iframe"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
