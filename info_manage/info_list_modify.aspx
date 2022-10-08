<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_list_modify.aspx.cs" Inherits="info_manage_info_add" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息修改</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../js/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../js/kindeditor/plugins/code/prettify.css" />
</head>
<body>
    <form id="form1" runat="server">
        <p class="ifrme-title">信息修改</p>

        <div class="margin-top-bottom-rem">
            <span>标题：</span>
            <asp:TextBox ID="tb_title" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>类别：</span>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist"></asp:DropDownList>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="删除" CssClass="button" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="添加"  CssClass="button" />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <textarea id="content1" runat="server" cols="100" rows="8" style="width: 880px; height: 400px; visibility: hidden;"></textarea>
        </div>

        <div>
            <asp:Button ID="Button1" runat="server" Text="修改"  OnClick="Button1_Click" CssClass="button"/>
        </div>
    </form>

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
</body>
</html>
