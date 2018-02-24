<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Thư viện video</li>
    </ul>
    <div class="main-cc videosPage">
        <div class="videoShow">
            <asp:Literal runat="server" ID="ltrVideo" />
        </div>
        
        <asp:Repeater ID="rptListVideo" runat="server">
            <HeaderTemplate><ul class="videoList"></HeaderTemplate>
            <FooterTemplate></ul></FooterTemplate>
            <ItemTemplate>
                <li>
                    <a href='/thu-vien-video/<%# Eval("CategoriesID") %>/<%# Eval("VideoID") %>/<%# VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' class="image">
                        <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("Title") %>' />
                        <span class="bg_img_video"></span>
                    </a>
                    <h3 class="title">
                        <a href='/thu-vien-video/<%# Eval("CategoriesID") %>/<%# Eval("VideoID") %>/<%# VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' ><%# Eval("Title") %></a>
                    </h3>
                    <span class="view"><%# Eval("ViewCount") %>&nbsp;Lượt xem</span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</asp:Content>

