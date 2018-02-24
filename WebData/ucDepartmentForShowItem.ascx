<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDepartmentForShowItem.ascx.cs" Inherits="ucDepartmentForShowItem" %>

<asp:Repeater runat="server" ID="rptDepartment" OnItemDataBound="rptDepartment_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <h3>
                <asp:HyperLink runat="server" ID="hplDep" NavigateUrl='<%# "/nha-dat/" + Eval("DepartmentID") + "/" + VNString.TextToUrl(Eval("Title").ToString()) %>' ToolTip='<%# Eval("Title") %>'><%# Eval("Title") %></asp:HyperLink>
            </h3>
        </li>
    </ItemTemplate>
</asp:Repeater>
