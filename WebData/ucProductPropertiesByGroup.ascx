<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductPropertiesByGroup.ascx.cs" Inherits="ucProductPropertiesByGroup" %>

<asp:Repeater ID="rptProperties" runat="server" OnItemDataBound="rptProperties_ItemDataBound" >
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>    
    <ItemTemplate>
        <li>
            <h3><%# Eval("Title") %></h3>
            <asp:Repeater runat="server" ID="rptPropertyValue" OnItemDataBound="rptPropertyValue_ItemDataBound" >
                <HeaderTemplate><ul></HeaderTemplate>
                <FooterTemplate></ul></FooterTemplate>
                <ItemTemplate>
                    <asp:Panel runat="server" ID="pnlPropertyValue">
                        <li>
                            <asp:HyperLink runat="server" ID="hplPropertyValue">
                                <asp:Label runat="server" ID="lblPropertyValue" />
                            </asp:HyperLink>
                        </li>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
        </li>
    </ItemTemplate>
</asp:Repeater>