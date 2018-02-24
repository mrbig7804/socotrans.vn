<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductGroupPropertiesByDepartment.ascx.cs" Inherits="ucProductGroupPropertiesByDepartment" %>

<%@ Register Src="ucProductPropertiesByGroup.ascx" TagName="ucProductPropertiesByGroup" TagPrefix="uc1" %>

<asp:Repeater ID="rptPropertiesGroups" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <h3><%# Eval("Title") %></h3>
            <uc1:ucProductPropertiesByGroup ID="ucProductPropertiesByGroup1" runat="server" PropertyGroupID='<%# Eval("PropertyGroupID") %>' DepartmentID='<%# Eval("DepartmentID") %>' />
        </li>
    </ItemTemplate>
</asp:Repeater>
