<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_list_modify.aspx.cs" Inherits="info_manage_user_list_modify" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改用户</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../js/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../js/kindeditor/plugins/code/prettify.css" />
    <script src="../js/calendar.js" type="text/javascript"></script>
    <script charset="utf-8" src="../js/kindeditor/kindeditor.js"></script>
    <script charset="utf-8" src="../js/kindeditor/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../js/kindeditor/plugins/code/prettify.js"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#content1', {
                cssPath: '../js/kindeditor/plugins/code/prettify.css',
                uploadJson: '../js/kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../js/kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">修改用户</p>
        <div class="margin-top-bottom-rem">
            <span>账号：</span>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <div class="margin-top-bottom-rem">
            <span>权限：</span>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist"></asp:DropDownList>
        </div>

        <div class="margin-top-bottom-rem">
            <span>密码：</span>
            <asp:TextBox ID="tb_password" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>邮箱：</span>
            <asp:TextBox ID="tb_email" runat="server" onfocus="setDay(this)" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>电话：</span>
            <asp:TextBox ID="tb_tel" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>部门：</span>
            <asp:TextBox ID="tb_department" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
