<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/TemplateHome.master"
    CodeFile="Shopping.aspx.cs" Inherits="Shopping" %>

<%@ Import Namespace="Zensoft.Website.Configuration" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <div class="content">
        <div class="pagemumber" style="padding-bottom: 10px" >
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
        <div class="Product_list">
            <asp:ListView ID="lvProducts" runat="server" DataSourceID="objProducts" OnPreRender="lvProducts_PreRender">
                <EmptyDataTemplate>
                    <div style="clear:both; margin-top: 12px; font-size: 13px; color: #333">
                        <b>Không có mặt hàng nào trong mục này...</b>
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
                        <div class="price_product">
                            <small>Giá:</small><%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="clearfix"></div>
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
        <div class="clearfix"></div>
    </div>

    <asp:ObjectDataSource ID="objProducts" runat="server" SelectMethod="GetProductsByFilter"
        TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.ProductsBF" >
        <SelectParameters>
            <asp:QueryStringParameter Name="userName" QueryStringField="name" DefaultValue=" "
                Type="String" />
            <asp:QueryStringParameter Name="superDepartmentID" QueryStringField="SDep" Type="Int32" />
            <asp:QueryStringParameter Name="departmentID" QueryStringField="Dep" Type="Int32"
                DefaultValue="" />
            <asp:QueryStringParameter DefaultValue="" Name="gender" QueryStringField="gen" Type="String" />
            <asp:QueryStringParameter DefaultValue="0" Name="countryID" QueryStringField="country"
                Type="Int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="maxPrice" QueryStringField="max"
                Type="Int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="minPrice" QueryStringField="min"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
