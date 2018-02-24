<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductGroupProperties.ascx.cs" Inherits="ucProductGroupProperties" %>

<%@ Register Src="ucProductProperties.ascx" TagName="ucProductProperties" TagPrefix="uc1" %>

<asp:Repeater ID="rptPropertiesGroups" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <h3><%# Eval("Title") %></h3>
            <uc1:ucProductProperties ID="ucProductProperties" runat="server" PropertyGroupID='<%# Eval("PropertyGroupID") %>' ProductID='<%# this.ProductID %>' />
        </li>
    </ItemTemplate>
</asp:Repeater>
