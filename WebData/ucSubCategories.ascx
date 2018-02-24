<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSubCategories.ascx.cs"
    Inherits="ucSubCategories" %>
<asp:DataList ID="DataList1" runat="server" Width="150" BorderWidth="0px" CellPadding="0">
    <ItemTemplate>
        <li><a href='ShowCategory.aspx?ID=<%# Eval("CategoryID") %>' title='<%# Eval("Description") %>'>
            &nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("Title") %></a> </td> </li>
    </ItemTemplate>
</asp:DataList>
