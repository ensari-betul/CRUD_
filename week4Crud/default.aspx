<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="week4Crud.AddStudentInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 294px;
        }
        .auto-style3 {
            width: 209px;
        }
        .auto-style4 {
            width: 162px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="BTN_Logout" runat="server" CausesValidation="False" OnClick="BTN_Logout_Click" Text="Logout" />

                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="BTN_MNGBook" runat="server" CausesValidation="False" OnClick="BTN_MNGBook_Click" Text="Manage Book" />
                    </td>

                    <td class="auto-style2">Student T number:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_TNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button runat="server" Text="Return Book" ID="BTN_ReturnBook" OnClick="BTN_ReturnBook_Click"></asp:Button>&nbsp;</td>
                    <td class="auto-style2">Student Name</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_StudentName" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">Student Email:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_Email" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">Student Department:</td>
                    <td class="auto-style4">
                        <asp:Localize ID="Localize1" runat="server"></asp:Localize>
                        <asp:DropDownList ID="DDL_Department" runat="server">
                            <asp:ListItem>CS</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>CSEC</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="LBL_SMessage" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="BTN_AddStudent" runat="server" OnClick="BTN_AddStudent_Click" Text="Add Student" Width="129px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
