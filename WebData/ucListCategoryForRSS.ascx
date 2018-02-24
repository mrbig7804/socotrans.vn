<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListCategoryForRSS.ascx.cs" Inherits="ucListCategoryForRSS" %>
<asp:DataList ID="dlCategories" runat="server">
    <ItemTemplate>
        <a href='GetRSS.aspx?CategoryID=<%# Eval("CategoryID") %>' >
            <img src="images/rss.gif" />&nbsp;&nbsp; 
            <%# Eval("Title") %></a> 
    </ItemTemplate>
</asp:DataList>
