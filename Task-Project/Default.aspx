<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VolleyBall_Final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 542px">
        <div style="font-size:x-large; text-align: center;">Task-Project</div> 
        <table class="w-100" style="width: 576px; height: 250px;">
            <tr>
                <td colspan="3"></td>
                <td>users</td>
                <td colspan="2">product</td>
                <td>category</td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userId&nbsp; </td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td colspan="2">
                    productId&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>CategoryId&nbsp; <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>&nbsp;&nbsp; UserName</td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td colspan="2">
                    ProductName&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>CategoryName&nbsp; <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; address</td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td colspan="2">
                    description&nbsp; <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="3"></td>
                <td>
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get" Width="75px" />
                    <asp:Button ID="Button6" runat="server" Text="Reset" Width="75px" OnClick="Button6_Click" />
                </td>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" Width="75px" />
                    <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" Width="75px" />
                &nbsp;
                </td>
                <td>
                     <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" Width="75px" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Search" Width="75px" />
                </td>
                <td colspan="2"></td>
            </tr>
        </table>
       
        <asp:GridView ID="GridViewUsers" runat="server" Width="50%" Style="margin-top: 20px; margin: 0 auto;" AutoGenerateColumns="True"></asp:GridView>
      
        <asp:GridView ID="GridViewProduct" runat="server" Width="50%" Style="margin: 0 auto; margin-top: 20px;" AutoGenerateColumns="True"></asp:GridView>
   
        <asp:GridView ID="GridViewCategory" runat="server" Width="50%" Style="margin: 0 auto; margin-top: 20px;" AutoGenerateColumns="True"></asp:GridView>
  
    </div>
</asp:Content>
