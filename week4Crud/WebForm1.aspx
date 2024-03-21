
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="week4Crud.WebForm1" %>

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
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">SN:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_SN" runat="server"></asp:TextBox>
                
                    </td>
                    <td>
                  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXTBox_SN" ErrorMessage="*Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                         <asp:CustomValidator ID="CustomValidator1" runat="server"  ControlToValidate="TXTBox_SN" ErrorMessage="*Dublicate SN" ForeColor="#CC0000" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        
                    </td>       
                            
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">Book ISBN:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_BookISBN" runat="server"></asp:TextBox>
                    </td>
                         <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXTBox_BookISBN" ErrorMessage="*Required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TXTBox_BookISBN" ForeColor="#CC0000" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">Book Name:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TXTBox_BookName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TXTBox_BookName"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">Subject:</td>
                    <td class="auto-style4">
                        <asp:Localize ID="Localize1" runat="server"></asp:Localize>
                        <asp:DropDownList ID="Subject_Item" runat="server">
                            <asp:ListItem>CS</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>CSEC</asp:ListItem>
                        </asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource1"></asp:SqlDataSource>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="LBL_SMessage2" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="BTN_AddBook" runat="server" OnClick="BTN_AddBook_Click" Text="Add Book" Width="129px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
