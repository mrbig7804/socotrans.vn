<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductProperties.ascx.cs" Inherits="ucProductProperties" %>

<asp:Repeater ID="rptProperties" runat="server" OnItemDataBound="rptProperties_ItemDataBound" >
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>    
    <ItemTemplate>
        <li>
            <span><%# Eval("Title") %></span>
            <span><asp:Literal runat="server" ID="ltrValue" /></span>
        </li>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <li class="even">
            <span><%# Eval("Title") %></span>
            <span><asp:Literal runat="server" ID="ltrValue" /></span>
        </li>
    </AlternatingItemTemplate>
</asp:Repeater>
