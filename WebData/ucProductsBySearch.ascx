<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductsBySearch.ascx.cs" Inherits="ucProductsBySearch" %>

<asp:UpdatePanel runat="server" ID="upSearch">
    <ContentTemplate>
        <table>
            <tr>
                <td>Từ khóa:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtKey" Width="155px" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlParentDepartment" Width="125px" AutoPostBack="true" 
                         DataValueField="SuperDepartmentID" DataTextField="Title" onselectedindexchanged="ddlParentDepartment_SelectedIndexChanged" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDepartment" Width="125px" DataValueField="DepartmentID" DataTextField="Title" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMinPrice" Width="80px">
                        <asp:ListItem Text="Giá từ..." Value="0" Selected="True" />
                        <asp:ListItem Text="300,000" Value="300000"/>
                        <asp:ListItem Text="1,000,000" Value="1000000"/>
                        <asp:ListItem Text="2,000,000" Value="2000000"/>
                        <asp:ListItem Text="3,000,000" Value="3000000"/>
                        <asp:ListItem Text="5,000,000" Value="5000000"/>
                        <asp:ListItem Text="7,000,000" Value="7000000"/>
                        <asp:ListItem Text="9,000,000" Value="9000000"/>
                        <asp:ListItem Text="12,000,000" Value="12000000"/>
                        <asp:ListItem Text="15,000,000" Value="15000000"/>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMaxPrice" Width="85px">
                        <asp:ListItem Text="Giá đến..." Value="0" Selected="True" />
                        <asp:ListItem Text="500,000" Value="500000"/>
                        <asp:ListItem Text="1,000,000" Value="1000000"/>
                        <asp:ListItem Text="2,000,000" Value="2000000"/>
                        <asp:ListItem Text="4,000,000" Value="4000000"/>
                        <asp:ListItem Text="6,000,000" Value="6000000"/>
                        <asp:ListItem Text="8,000,000" Value="8000000"/>
                        <asp:ListItem Text="10,000,000" Value="10000000"/>
                        <asp:ListItem Text="11,000,000" Value="11000000"/>
                        <asp:ListItem Text="13,000,000" Value="13000000"/>
                        <asp:ListItem Text="14,000,000" Value="14000000"/>
                        <asp:ListItem Text="18,000,000" Value="18000000"/>
                        <asp:ListItem Text="50,000,000" Value="50000000"/>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" Text="Tìm kiếm" onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="pnSearchResult" Visible="false">
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
            <div class="Product_list">
                <asp:ListView ID="lvProducts" runat="server" OnPreRender="lvProducts_PreRender" >
                    <EmptyDataTemplate>
                        <div style="clear:both; margin-top: 12px; font-size: 13px; color: #333">
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
                            <div class="price_product">
                                <small>Giá:</small><%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice")), Convert.ToInt32(Eval("SalePrice")))%>
                            </div>
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
