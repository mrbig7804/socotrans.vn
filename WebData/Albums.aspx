<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true"
    CodeFile="Albums.aspx.cs" Inherits="Albums" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" runat="Server">
    <ul class="breadcrumbs">
        <li><a href="/">Trang chủ</a></li>
        <li>Thư viện ảnh</li>
    </ul>
    <div class="albumsPage">
        <asp:ListView ID="lvwAlbums" runat="server" DataSourceID="objAlbums" DataKeyNames="AlbumId" OnPreRender="lvwAlbums_PreRender">
            <ItemTemplate>
                <div class="col-sm-3 col-xs-6 album-items">
                    <figure class="image">
                        <a href='/thu-vien-anh/<%# Eval("AlbumId") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>'>
                            <img title='<%# Eval("Title") %>' src='<%# Eval("PictureUrl") %>' />
                        </a>
                    </figure>
                    <h3 class="title">
                        <a href='/thu-vien-anh/<%# Eval("AlbumId") %>/<%#VNString.TextToUrl(Eval("Title").ToString()) %>' title='<%# Eval("Title") %>'>
                            <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 20) %>
                        </a>
                    </h3>
                    <%--<p class="date">Ngày gửi: <%# Eval("AddedDate", "{0:dd/MM/yyyy}") %></p>--%>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clearfix"></div>
        <div class="pager">
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvwAlbums" PageSize="12">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowNextPageButton="false"
                        ShowPreviousPageButton="false" FirstPageText="First " PreviousPageText="Previous " ButtonCssClass="pre_pager" />
                    <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="crr_page" NumericButtonCssClass="num_page" NextPreviousButtonCssClass="nav_page" NextPageText="&raquo;" PreviousPageText="&laquo;" />
                    <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false" ShowNextPageButton="false"
                        ShowPreviousPageButton="false" LastPageText=" Last" NextPageText=" Next" ButtonCssClass="pre_pager" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
    <asp:ObjectDataSource ID="objAlbums" runat="server" SelectMethod="GetAlbumAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.AlbumBF">
    </asp:ObjectDataSource>

</asp:Content>
