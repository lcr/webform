<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_add.aspx.cs" Inherits="info_manage_user_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">添加用户</p>

        <div class="margin-top-bottom-rem">
            <span>账号:</span>
            <asp:TextBox ID="tb_name" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>密码:</span>
            <asp:TextBox ID="tb_password" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>权限:</span>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist"></asp:DropDownList>
        </div>

        <div class="margin-top-bottom-rem">
            <span>部门:</span>
            <asp:TextBox ID="tb_department" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>邮箱:</span>
            <asp:TextBox ID="tb_email" runat="server" CssClass="textbox"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="tb_email" ErrorMessage="RegularExpressionValidator"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>

        <div class="margin-top-bottom-rem">
            <span>电话:</span>
            <asp:TextBox ID="tb_tel" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加"  CssClass="button"  />
        </div>
    </form>
</body>
</html>
