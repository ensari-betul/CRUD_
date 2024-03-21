<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookMnagerLogin2.aspx.cs" Inherits="week4Crud.BookMnagerLogin2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2" colspan="4"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style3">Enter your Email:</td>
                    <td colspan="4">
                        <asp:TextBox ID="TXT_Email" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Email" ErrorMessage="*Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
    <td>&nbsp;</td>
    <td class="auto-style3" > Enter your password</td>
    <td colspan="4">
        <asp:TextBox ID="TXT_Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_Password" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
    <td>&nbsp;</td>
</tr>
                <tr>
    <td>&nbsp;</td>
        <td>&nbsp;</td>
</tr>
                <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
        <asp:Button ID="TXT_Login" runat="server" Text="Login" OnClick="TXT_Login_Click" />
       
    <td> <input id="Reset1" type="reset" value="Reset" /></td></td>
    
</tr>
            </table>
        </div>
    </form>
</body>
</html>
