<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Return_Book.aspx.cs" Inherits="week4Crud.BookReturn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               <asp:Label ID="Label1" runat="server" Text="Select TNumber  : "></asp:Label>
            <asp:DropDownList ID="DDL_TNO" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_TNO_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Select ISBN       :"></asp:Label>
        <asp:DropDownList ID="DDL_ISBN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_ISBN_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Student Name   :"></asp:Label>
        <asp:Label ID="LBL_StudentName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Student Email    : "></asp:Label><asp:Label ID="LBL_Email" runat="server" Text="Label"></asp:Label>
        <br>
        <asp:Label ID="Label7" runat="server" Text="Book Name   :"></asp:Label>
        <asp:Label ID="LBL_BookName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Book Subject :"></asp:Label>
        <asp:Label ID="LBL_bookSubject" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label11" runat="server" Text="Rent Date     :  "></asp:Label>
        <asp:Label ID="LBL_RentDate" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="Label13" runat="server" Text="Expected Return Date:"></asp:Label>
        <asp:Label ID="LBL_ReturnDate" runat="server" Text="Label"></asp:Label>
        <br /><br />
        <asp:Label ID="LBL_Message" runat="server"></asp:Label><br />
        <asp:Button ID="BTN_ReturnDate" runat="server" Text="Return Book" OnClick="BTN_ReturnDate_Click" /> <br /><br />
        <br />
        <br />
                        <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" />
                        <asp:Button ID="BTN_studentinfo" runat="server" OnClick="BTN_studentinfo_Click" Text="Back To Student Info" />
                        <asp:Button ID="Button2" runat="server" Text="Manage Book" OnClick="Button2_Click" />
                        <asp:Button ID="BTN_ReturnBook" runat="server" CausesValidation="False" OnClick="BTN_ReturnBook_Click" Text="Return Book" />
                    <br />

        </div>
    </form>
</body>
</html>
