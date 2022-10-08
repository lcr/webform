<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_password_modify.aspx.cs" Inherits="info_manage_user_password_modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>密码修改</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">密码修改</p>
        <div class="margin-top-bottom-rem">
            <span>旧 密 码: </span>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="  "></asp:Label>
        </div>


        <div class="margin-top-bottom-rem">
            <span>新 密 码: </span>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox2" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
        </div>

        <div class="margin-top-bottom-rem">
            <span>密码确认</span>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server"
                ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="两次密码不一致"></asp:CompareValidator>
        </div>

        <div>
            <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
