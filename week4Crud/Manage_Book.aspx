<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage_Book.aspx.cs" Inherits="week4Crud.Manage_Book" %>

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
            width: 131px;
        }
        .auto-style4 {
            height: 23px;
            width: 131px;
            text-align: right;
        }
        .auto-style5 {
            width: 136px;
            text-align: right;
        }
        .auto-style6 {
            width: 204px;
        }
        .auto-style7 {
            height: 23px;
            width: 204px;
        }
        .auto-style8 {
            width: 98px;
        }
        .auto-style9 {
            height: 23px;
            width: 98px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
               <tr>
                    <td class="auto-style8">
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Select Student TNo:</td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DDL_TNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_TNo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Button ID="BTN_Logout" runat="server" CausesValidation="False" OnClick="BTN_Logout_Click" Text="Logout" />
                    </td>
                    </td>
                    <td class="auto-style5">Student Name: </td>
                    <td class="auto-style6">
                        <asp:Label ID="LBL_StudentName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Student Email: </td>
                    <td class="auto-style6">
                        <asp:Label ID="LBL_Email" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Student Department: </td>
                    <td class="auto-style6">
                        <asp:Label ID="LBL_Dept" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                   <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Book ISBN: </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="DDL_ISBN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_ISBN_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Book Name: </td>
                    <td class="auto-style6">
                        <asp:Label ID="LBL_BookName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style4">Book Subject: </td>
                    <td class="auto-style7">
                        <asp:Label ID="LBL_BookSubject" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Total Book:</td>
                    <td class="auto-style6"><a href="Manage_Book.aspx.designer.cs"></a>
                        <asp:Label ID="LBL_TotalBook" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Remaining Book:</td>
                    <td class="auto-style6">
                        <asp:Label ID="LBL_ReaminingBook" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Select Rent Date:</td>
                    <td class="auto-style6">
                        <asp:Button ID="BTN_Rentdate" runat="server" OnClick="BTN_Rentdate_Click" Text="Click to Select Date" />
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server" Visible="False"></asp:Calendar>
                        <asp:Button ID="BTN_selectdateRent" runat="server" OnClick="BTN_selectdateRent_Click" Text="Select Rent Date" Visible="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">Select return date:</td>
                    <td class="auto-style6">
                        <asp:Button ID="BTN_ReturnDate" runat="server" OnClick="BTN_ReturnDate_Click" Text="Click to Select Date" />
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar2" runat="server" Visible="False"></asp:Calendar>
                        <asp:Button ID="BTN_SelectdateReturn" runat="server" OnClick="BTN_SelectdateReturn_Click" Text="Select Return date" Visible="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>
                        <asp:Label ID="LBL_Message" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="BTN_Rent" runat="server" OnClick="BTN_Rent_Click" Text="Rent Book" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
