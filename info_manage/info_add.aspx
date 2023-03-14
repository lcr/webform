<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_add.aspx.cs" Inherits="info_manage_info_add" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息添加</title>
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

        <p class="ifrme-title">信息添加</p>

        <div class="margin-top-bottom-rem">
            <span>标题:</span>
            <asp:TextBox ID="tb_title" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <span>类别:</span>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist"></asp:DropDownList>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="删除" CssClass="button"  />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="添加" CssClass="button"  />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
        </div>

        <div class="margin-top-bottom-rem">
            <textarea id="content1" runat="server" cols="100" rows="8" style="width: 880px; height: 400px; visibility: hidden;"></textarea>
        </div>

        <div>
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="button" />
        </div>

        <%--        
            <div>
            <p>图片新闻</p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <p>图片上传</p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上传" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        </div>
        --%>
    </form>
</body>
</html>
