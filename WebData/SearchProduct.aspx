<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateHome.master" AutoEventWireup="true" CodeFile="SearchProduct.aspx.cs" Inherits="SearchProduct" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHomePage" Runat="Server">

    <div style="width: 190px; float: left; height: auto">
        <div class="support">
            <div style="color: #fff; font-weight: bold; font-size: 14px; padding-top: 18px; padding-bottom: 12px; background:url(/images/images_th/gach_chan.jpg) 20px 40px no-repeat">HỖ TRỢ TRỰC TUYẾN</div>
            <div class="yahoo"><a href="#<%--ymsgr:sendIM?mrbig7804--%>">Hỗ trợ Yahoo</a></div>
            <div class="skype"><a href="#<%--skype:mrbig7804?chat--%>">Hỗ trợ Skype</a></div>
            <div class="phone"><span style="line-height: 10px">Tel: 84.031.3757115</span><br /><span style="line-height: 10px">Fax: 84.031.3757116</span></div>
        </div>
    </div>
    <div class="content">
        <div class="title_uc">KẾT QUẢ TÌM KIẾM</div>
        <div class="pagemumber" >
            <asp:DataPager ID="DataPager2" runat="server" PagedControlID="lvProducts">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="true" ShowNextPageButton="false"
                        ShowPreviousPageButton="true" FirstPageText="Đầu" PreviousPageImageUrl="~/images/previous.png"
                        FirstPageImageUrl="~/images/first.png" />
                    <asp:NumericPagerField ButtonCount="10" />
                    <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="true" ShowNextPageButton="true"
                        ShowPreviousPageButton="false" NextPageImageUrl="~/images/next.png" LastPageImageUrl="~/images/last.png" />
                </Fields>
            </asp:DataPager>
        </div>
        <div style="padding-left: 5px" class="Product_list">
            <asp:ListView ID="lvProducts" runat="server" OnPreRender="lvProducts_PreRender" >
                <EmptyDataTemplate>
                    <div style="clear:both; font-size: 13px; color: #333; margin: 15px">
                        <b>Không tìm thấy mặt hàng nào...</b>
                    </div>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class='showproduct <%# (((Container.DataItemIndex+1) % 4)!=0)?"showproduct_bordder":""  %>'>
                        <div class="img_product">
                            <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                                <asp:Image ID="imgPicPreview" runat="server" ImageUrl='<%# Eval("SmallPictureUrl") %>' />
                            </a>
                        </div>
                        <div class="name_product">
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "~/san-pham/"+Eval("UniqueTitle") %>'
                                ToolTip='<%# Eval("Title") %>' runat="server"><%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 20) %></asp:HyperLink>
                        </div>
                        <div class="code_product" style="display: none">Mã SP:&nbsp;<%# Eval("AddedDate", "{0:ddMM}") %><%# Eval("ProductID") %></div>
                        <div class="price_product" style="display: none">
                            <small>Giá:</small><%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%>
                        </div>
                        <div class="card" style="display: none">
                            <asp:ImageButton runat="server" ID="btnAddToCart" ImageUrl="/images/images_Hmart/addcard02_bg.jpg" ToolTip="Thêm vào giỏ hàng"
                                CommandName="AddCard" CommandArgument='<%# Eval("ProductID") %>' /></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="clear_this"></div>
        <div class="pagemumber" >
            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvProducts" PageSize="20">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="true" ShowNextPageButton="false"
                        ShowPreviousPageButton="true" FirstPageText="Đầu" PreviousPageImageUrl="~/images/previous.png"
                        FirstPageImageUrl="~/images/first.png" />
                    <asp:NumericPagerField ButtonCount="10" />
                    <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="true" ShowNextPageButton="true"
                        ShowPreviousPageButton="false" NextPageImageUrl="~/images/next.png" LastPageImageUrl="~/images/last.png" />
                </Fields>
            </asp:DataPager>
        </div>
        <div class="clear_this"></div>
    </div>
</asp:Content>

