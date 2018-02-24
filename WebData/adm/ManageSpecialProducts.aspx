<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true" codefile="ManageSpecialProducts.aspx.cs" inherits="adm_ManageSpecialProducts" title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:content id="Content1" contentplaceholderid="cphAdmin" runat="Server">
    <div class="content-header">
        <h1 class="title-page">Quản lý sản phẩm đặc biệt</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Sản phẩm đặc biệt</li>
        </ol>
    </div>

    <div class="content">
        <div class="col-left">

            <div class="box box-blue">
                <div class="top-box">
                    <h1 class="info">Tìm kiếm</h1>
                </div>
                <div class="middle-box tbl-form">
                    <div class="row">
                        <label class="lbl lbl-medium">Từ ngày:</label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt txt-datetime" Width="60%" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtFromDate" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Đến ngày:</label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txt txt-datetime" Width="60%" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy HH:mm" TargetControlID="txtToDate" />
                    </div>
                    <div class="row">
                        <label class="lbl lbl-medium">Trạng thái:</label>
                        <asp:DropDownList runat="server" ID="ddlStatus" Width="64.5%" CssClass="slt">
                            <asp:ListItem Text="Tất cả" Value="2" Selected="True" />
                            <asp:ListItem Text="Hoạt động" Value="0" />
                            <asp:ListItem Text="Tạm dừng" Value="1" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="lbtnSearch" Text="Tìm kiếm" OnClick="lbtnSearch_Click" CssClass="btn btn-blue" />
                </div>
            </div>
            <asp:repeater id="rptSpecial" runat="server" datasourceid="odsSpecial">
                <HeaderTemplate><ul class="box box-red list-catSpecial"></HeaderTemplate>
                <FooterTemplate></ul></FooterTemplate>
                <itemtemplate>
                    <li>
                        <a href='<%# "/adm/ManageSpecialProducts.aspx?SpecID=" + Eval("SpecialID").ToString() %>' ><%#Eval("Title") %></a>
                    </li>
                </itemtemplate>
            </asp:repeater>
            <asp:objectdatasource id="odsSpecial" runat="server" selectmethod="GetSpecialsAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.SpecialsBF" />
        </div>
        <div class="col-right">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="list">Danh sách sản phẩm&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountProduct" CssClass="badge" /></h1>
                </div>
                <ul class="middle-box">
                    <asp:ListView id="gvwProducts" runat="server" datakeynames="ProductID" OnItemDataBound="gvwProducts_ItemDataBound"
                        OnItemCommand="gvwProducts_ItemCommand" OnItemDeleting="gvwProducts_ItemDeleting" OnPagePropertiesChanging="gvwProducts_PagePropertiesChanging" >
                        <itemtemplate>
                            <li class="row-listProduct">
                                <asp:HiddenField runat="server" ID="hdfSpecialID" Value='<%# Eval("SpecialID") %>' />
                                <span class="image">
                                    <asp:image id="imgAvatar" runat="server" />
                                </span>
                                <span class="title"><asp:HyperLink runat="server" ID="hplTitle" /></span>
                                <span class="info">
                                    Lượt Xem: <asp:Label runat="server" ID="lblView" />&nbsp;|&nbsp;
                                    Ngày hết hạn: <%#Eval("ExpireDate", "{0:dd.MM.yyyy}")%>
                                </span>
                                <span class="exten">
                                    <asp:CheckBox runat="server" ID="ckbListed" Text="Hoạt động" Checked='<%# Eval("Listed") %>' AutoPostBack="true" OnCheckedChanged="ckbListed_CheckedChanged" CssClass="chk" />
                                </span>
                                <span class="action">
                                    <a href='/adm/product.aspx?action=edit&productID=<%# Eval("ProductID")%>' title="Sửa thông tin sản phẩm" class="btn btn-blue" >Sửa</a>&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("ProductID")%>' ToolTip="Xóa sản phẩm" Text="Xóa"
                                        onclientclick="if (confirm('Bạn có chắc chắn muốn xóa sản phẩm khỏi mục này?') == false) return false;" CssClass="btn btn-red" />
                                </span>
                            </li>
                        </itemtemplate>
                    </asp:ListView>
                </ul>
                <div class="bottom-box">
                    <asp:DataPager ID="dpProducts" runat="server" PagedControlID="gvwProducts" PageSize="10">
                        <Fields>
                            <asp:NumericPagerField ButtonCount="10" CurrentPageLabelCssClass="crr-pagernumber" NumericButtonCssClass="pagenumber" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>            
        </div>
    </div>
</asp:content>