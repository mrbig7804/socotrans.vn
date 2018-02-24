<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideos.ascx.cs" Inherits="ucListVideos" %>

<div class="embed-responsive embed-responsive-16by9">
    <asp:Literal runat="server" ID="ltrVideo" />
</div>

<asp:Repeater runat="server" ID="rptPreVideo" >
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
    <li>
        <%--<a href='/thu-vien-video/<%# Eval("CategoriesID") %>/<%# Eval("VideoID") %>/<%# VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' class="image">
                <asp:Image runat="server" ID="imgAvatar" ImageUrl='<%# Eval("ImageUrl") %>' ToolTip='<%# Eval("Title") %>' />
            </a>--%>
        <h3 class="title">
            <a href='/thu-vien-video/<%# Eval("CategoriesID") %>/<%# Eval("VideoID") %>/<%# VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' ><%# Eval("Title") %></a>
        </h3>
    </li>
    </ItemTemplate>
</asp:Repeater>
