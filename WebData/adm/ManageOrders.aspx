<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true"
    CodeFile="ManageOrders.aspx.cs" Inherits="adm_ManageOrders" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý đơn hàng</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Quản lý đơn hàng</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Mở rộng</h1>
                </div>
                <div class="middle-box tbl-form">
                    <div class="row">
                        <label class="lbl lbl-medium">Giảm giá %:</label>
                        <asp:TextBox ID="txtPromotion" runat="server" CssClass="txt" Width="15%" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton ID="btnSetupOrder" runat="server" OnClick="btnSetupOrder_Click" Text="Xác nhận" CssClass="btn btn-red"/>
                </div>
            </div>
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Lọc tìm đơn hàng</h1>
                </div>
                <div class="middle-box tbl-form">
                    <div class="row">
                        <label class="lbl lbl-medium">Từ ngày:</label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt txt-datetime" Width="60%" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDate" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Tới ngày:</label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txt txt-datetime" Width="60%" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Trạng thái:</label>
                        <asp:DropDownList ID="ddlOrderStatuses" runat="server" DataSourceID="objAllStatuses"  CssClass="slt" DataTextField="Title" DataValueField="OrderStatusID" Width="64.5%" />
                        <asp:ObjectDataSource ID="objAllStatuses" runat="server" SelectMethod="GetOrderStatusAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.OrderStatusBF" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton ID="btnFilterOrder" runat="server" OnClick="btnFilterOrder_Click" Text="Lọc tìm" CssClass="btn btn-blue"/>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnAllOrder" runat="server" OnClick="btnAllOrder_Click" Text="Xem tất cả đơn hàng" CssClass="btn btn-red" />
                </div>
            </div>
        </div>
        <div class="col-right">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Danh sách đơn hàng&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountOrder" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:GridView ID="grvBilling" runat="server" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" CssClass="tbl-grid" gridlines="Vertical" width="100%" DataKeyNames="OrderID"
                         OnSelectedIndexChanged="grvBilling_SelectedIndexChanged"  OnPageIndexChanging="grvBilling_PageIndexChanging" OnRowDeleting="grvBilling_RowDeleting"
                         OnRowDataBound="grvBilling_RowDataBound" onrowcreated="grvBilling_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ShippingFullName" HeaderText="Khách hàng">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="28%" />
                            </asp:BoundField>
                            <%--<asp:commandfield buttontype="Link" selecttext='<%# Eval("ShippingFullName") %>' HeaderText="Khách hàng" showselectbutton="True">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="28%" />
                            </asp:commandfield>--%>
                            <asp:TemplateField HeaderText="Trạng thái HĐ">
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hdfStatus" Value='<%# Eval("StatusID") %>' />
                                    <asp:Label runat="server" ID="lblStatus" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày mua">
                                <ItemTemplate><%# Eval("AddedDate", "{0:dd/MM/yyyy}")%></ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="14%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giá trị HĐ">
                                <ItemTemplate><%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("GrossOrder").ToString()))%></ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="12%" />
                            </asp:TemplateField>
                            <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/blue-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa" 
                                showselectbutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="5%" />
                            </asp:commandfield>
                            <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa" 
                                showdeletebutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="5%" />
                            </asp:commandfield>
                        </Columns>
                        <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                        <headerstyle cssclass="tbl-gridHeader" />
                        <alternatingrowstyle cssclass="tbl-gridAlternate" />
                        <SelectedRowStyle CssClass="tbl-GridSelected" />
                        <PagerStyle CssClass="tbl-gridPager" />
                    </asp:GridView>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
        <div class="clearfix"></div>
        <asp:Panel runat="server" ID="pnlBill" CssClass="col-left-50" Visible="false">
            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="info">Thông tin hóa đơn</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfOrderID" />
                    <div class="row">
                        <label class="lbl lbl-medium">Mã Hóa đơn:</label>
                        <asp:TextBox runat="server" ID="lblOrderId" CssClass="txt txt-disabled" Width="160px" Enabled="false" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Tên người nhận:</label>
                        <asp:TextBox ID="txtReceiverName" runat="server" CssClass="txt" Width="250px" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Điện thoại:</label>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="txt" Width="160px" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Email người nhận:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="250px" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Địa chỉ người nhận:</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="250px" TextMode="MultiLine" Rows="5" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Ghi chú:</label>
                        <asp:TextBox ID="txtNote" runat="server" CssClass="txt" Width="250px" TextMode="MultiLine" Rows="5" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Ngày mua:</label>
                        <asp:TextBox ID="txtDateShipping" runat="server" CssClass="txt" Width="160px" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateShipping" Format="dd/MM/yyyy" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Trạng thái hóa đơn:</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="objAllStatuses" DataTextField="Title" DataValueField="OrderStatusID" CssClass="slt" Width="174px" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium" style="padding-bottom: 50px">Thanh toán:</label>
                        <asp:RadioButton ID="rdbCOD_1" runat="server" Text="Nội thành Hải Phòng (COD)" GroupName="PaymentMethod" /><br />
                        <asp:RadioButton ID="rdbCOD_2" runat="server" Text="Ngoại thành Hải Phòng (COD)" GroupName="PaymentMethod" /><br />
                        <asp:RadioButton ID="rdbCOD_3" runat="server" Text="Các tỉnh khác (COD)" GroupName="PaymentMethod" /><br />
                        <asp:RadioButton ID="rdbATM_1" runat="server" Text="Thành phố Hải Phòng (ATM)" GroupName="PaymentMethod" /><br />
                        <asp:RadioButton ID="rdbATM_2" runat="server" Text="Các tỉnh khác (ATM)" GroupName="PaymentMethod" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Giá trị hóa đơn:</label>
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="txt txt-disabled" Width="160px" Enabled="false" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Số lượng sản phẩm:</label>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="txt txt-disabled" Width="160px" Enabled="false" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Giảm giá (<asp:Label ID="lblSale" runat="server" />%):</label>
                        <asp:Label ID="lblPromotion" runat="server" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Phí Ship:</label>
                        <asp:Label ID="lblShipPrice" runat="server" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Tổng giá thanh toán:</label>
                        <asp:Label runat="server" ID="lblGrossOrder" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Cập nhật" CssClass="btn btn-blue" OnClick="btnEdit_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlProducts" CssClass="col-right-50" Visible="false">
            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="info list">Sản phẩm trong đơn hàng&nbsp;&nbsp;<asp:Label runat="server" ID="lblProductInOrder" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:GridView ID="gvwProducts" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False" CssClass="tbl-grid" 
                        gridlines="Vertical" width="100%" DataKeyNames="OrderItemID" OnRowDataBound="gvwProducts_RowDataBound" >
                        <Columns>
                            <asp:templatefield headertext="Hình ảnh">
                                <itemtemplate>
                                    <asp:Image runat="server" ID="imgProduct" Width="80px" Height="65px" CssClass="image" />
                                </itemtemplate>
                                <itemstyle width="20%" HorizontalAlign="Center" VerticalAlign="Middle"  />
                            </asp:templatefield>
                            <asp:templatefield headertext="Tên sản phẩm">
                                <itemtemplate>
                                    <asp:HyperLink runat="server" ID="hplTitle" ToolTip='Xem chi tiết: <%# Eval("Title") %>' target="_blank" />
                                </itemtemplate>
                                <itemstyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" Width="40%" />
                            </asp:templatefield>
                            <asp:templatefield headertext="SL">
                                <itemtemplate><%# Eval("Quantity") %></itemtemplate>
                                <itemstyle width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:templatefield headertext="Đơn giá">
                                <itemtemplate><%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("unitPrice").ToString()))%></itemtemplate>
                                <itemstyle width="15%" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </asp:templatefield>
                            <asp:templatefield headertext="Tổng tiền">
                                <ItemTemplate>
                                    <%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("unitPrice").ToString())*int.Parse(Eval("Quantity").ToString()))%>
                                </ItemTemplate>
                                <itemstyle width="15%" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </asp:templatefield>
                        </Columns>
                    <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                    <headerstyle cssclass="tbl-gridHeader" />
                    <alternatingrowstyle cssclass="tbl-gridAlternate" />
                    <SelectedRowStyle CssClass="tbl-GridSelected" />
                    <PagerStyle CssClass="tbl-gridPager" />
                </asp:GridView>
                </div>
                <div class="bottom-box"></div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>