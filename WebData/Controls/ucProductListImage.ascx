<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductListImage.ascx.cs" Inherits="Controls_ucProductListImage" %>

<asp:repeater id="rptProductImages" runat="server" OnItemDataBound="rptProductImages_ItemDataBound">
    <headertemplate><ul class="listProductImage"></headertemplate>
    <footertemplate></ul></footertemplate>
    <itemtemplate>
        <li>
            <asp:HyperLink runat="server" ID="hplImage" CssClass="lightbox">
                <img src='<%# Eval("MedImage").ToString().Replace("~/", "/") %>' alt="Siêu thị nhà đất bán"/>
            </asp:HyperLink>
        </li>
    </itemtemplate>
</asp:repeater>
