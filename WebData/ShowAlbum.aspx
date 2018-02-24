<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true"
    CodeFile="ShowAlbum.aspx.cs" Inherits="ShowAlbum" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Thư viện ảnh</li>
    </ul>
    <div class="showAlbum">
        <h3 class="title">
            <asp:Label runat="server" ID="lblTitle" />
        </h3>
        <%--<div class="addedDate">
            <b>Ngày đăng:</b>&nbsp;<asp:Label runat="server" ID="lblDate" />
            <%# Eval("AddedDate", "{0:dd/MM/yyyy | HH:mm}") %>
        </div>
        <div class="desc">
            <asp:Literal runat="server" ID="ltrDesc" />
        </div>--%>

        <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_ItemDataBound">
            <ItemTemplate>
                <div class="col-sm-3 col-xs-6 image-items">
                    <figure class="image">
                        <asp:HyperLink runat="server" ID="hplPreview" CssClass="lightbox">
                            <img title='<%# Eval("Title") %>' src='<%# Eval("PreviewUrl") %>' />
                        </asp:HyperLink>
                    </figure>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <%--<span>Bộ ảnh liên quan</span>
        <ul class="albumRelate">
            <asp:ListView ID="lvwAlbumOther" runat="server" OnItemDataBound="lvwAlbumOther_ItemDataBound" DataKeyNames="AlbumId">
                <ItemTemplate>
                <li>
                    <a href='/thu-vien-anh/<%# Eval("AlbumId") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>' class="image">
                        <img alt='<%# Eval("Title") %>' src='<%# Eval("PreviewUrl") %>' />
                    </a>
                    <h3 class="title">
                        <a href='/thu-vien-anh/<%# Eval("AlbumId") %>/<%#VNString.TextToUrl(Eval("Title").ToString())%>'><%# Eval("Title") %></a>
                    </h3>
                    <span class="date">Ngày gửi: <%# Eval("AddedDate", "{0:dd/MM/yyyy}") %></span>
                </li>
                </ItemTemplate>
            </asp:ListView>
        </ul>--%>
    </div>
        

</asp:Content>
