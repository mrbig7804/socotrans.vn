<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="adm_ManageProducts" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript">
        function showhideToggle() {
            if (document.getElementById("linkShowHide").innerHTML != 'Hide') {
                document.getElementById("linkShowHide").innerHTML = 'Hide';
                document.getElementById("linkShowHide").className = 'breadcrumbClose';
            }
            else {
                document.getElementById("linkShowHide").innerHTML = 'Show';
                document.getElementById("linkShowHide").className = 'breadcrumbOpen';
            }
            return false;
        }
    </script>

    <div class="content-header">
        <h1 class="title-page">Quản lý sản phẩm</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Quản lý sản phẩm</li>
        </ol>
    </div>
    
    <div class="content">
        <div class="col-left">
            <asp:Repeater runat="server" ID="rptSuperDep" DataSourceID="objSuperDepartment" OnItemDataBound="rptSuperDep_ItemDataBound" >
                <HeaderTemplate><ul id="browse_tree" class="box box-blue"></HeaderTemplate>
                <FooterTemplate></ul></FooterTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" ID="hplSuperDep" NavigateUrl="/adm/ManageProducts.aspx" ><%# Eval("Title")  %></asp:HyperLink>
                        <asp:Literal runat="server" ID="ltrDep" />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="objSuperDepartment" runat="server" DeleteMethod="Delete" SelectMethod="GetSuperDepartmentsAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SuperDepartmentsBF">
                <DeleteParameters>
                    <asp:Parameter Name="superDepartmentID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>

            <ul class="box box-green list-catSpecial">
                <li>
                    <a href="/adm/ManageProducts.aspx?listed=false">Sản phẩm chờ duyệt</a>
                </li>
                <li>
                    <a href="/adm/ManageProducts.aspx?discontinue=true">Sản phẩm ngừng cung cấp</a>
                </li>
            </ul>
        </div>
        <div class="col-right">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info"><asp:Label runat="server" ID="lblTitleDep" /></h1>
                    <a id="linkShowHide" onclick="return showhideToggle()" class="breadcrumbClose" href="javascript:void(0)">Hide</a>
                </div>
                <div id="showHide">
                    <div class="middle-box tbl-form">
                        <asp:HiddenField runat="server" ID="hdfDepID" />
                        <div class="row">
                            <label class="lbl lbl-small">Tiêu đề:</label>
                            <asp:TextBox runat="server" ID="txtTitle" Width="52%" CssClass="txt" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ErrorMessage="Bạn chưa nhập tiêu đề" ValidationGroup="Department" CssClass="err" SetFocusOnError="true"/>
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Mô tả:</label>
                            <asp:TextBox runat="server" ID="txtDesc" Width="52%" CssClass="txt" TextMode="MultiLine" Rows="4" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Nhóm hàng:</label>
                            <asp:DropDownList runat="server" ID="ddlDepartment" Width="53.8%" CssClass="slt" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Đường dẫn ảnh:</label>
                            <asp:Panel runat="server" ID="pnImage">
                                <asp:FileUpload runat="server" ID="fuImage" CssClass="txt txt-file" Width="53.8%" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="fuImage" Display="Dynamic" ErrorMessage="Chọn đúng định dạng ảnh" CssClass="err"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\(). ])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$" ValidationGroup="Department" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnChangeImage">
                                <asp:TextBox runat="server" ID="txtImageUrl" Width="52%" CssClass="txt txt-disabled" Enabled="false" />
                                <asp:LinkButton runat="server" ID="hplChange" Text="Xóa ảnh" onclick="hplChange_Click" CssClass="btn btn-blue" />
                            </asp:Panel>
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Kích thước ảnh:</label>
                            <asp:TextBox ID="txtImgWidth" runat="server" Width="10%" CssClass="txt txt-disabled" Enabled="false" /> x <asp:TextBox ID="txtImgHeight" runat="server" Width="10%"  CssClass="txt txt-disabled" Enabled="false" />
                        </div>
                    </div>
                    <div class="bottom-box">
                        <asp:LinkButton runat="server" ID="lbtnUpdate" ValidationGroup="Department" onclick="lbtnUpdate_Click" CssClass="btn btn-blue" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnCancle" Text="Bỏ qua" onclick="lbtnCancle_Click" CssClass="btn btn-green" />&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="lbtnDel" Text="Xóa" onclick="lbtnDel_Click" CssClass="btn btn-red" />
                    </div>
                </div>
            </div>
            
            
            <asp:Panel ID="panProduct" runat="server" CssClass="box box-green">
                <div class="top-box">
                    <h1 class="list">Sản phẩm<asp:Label runat="server" ID="lblTitleGridProduct" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountProduct" CssClass="badge" /></h1>
                </div>
                <ul class="middle-box">
                    <asp:ListView id="gvwProducts" runat="server" datakeynames="ProductID" OnItemCommand="gvwProducts_RowCommand" OnItemDeleting="gvwProducts_RowDeleting"  OnPagePropertiesChanging="gvwProducts_PagePropertiesChanging" >
                        <itemtemplate>
                            <li class="row-listProduct">
                                <span class="image">
                                    <asp:image id="Image1" runat="server" imageurl='<%# Eval("SmallPictureUrl")%>' AlternateText='<%# Eval("Title") %>' />
                                </span>
                                <span class="title"><a href='/showitem/<%# Eval("UniqueTitle")%>'><%# Eval("Title")%></a></span>
                                <span class="info">
                                    Giá: <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice"))) %>&nbsp;&nbsp;|&nbsp;
                                    Lượt Xem: <%#Eval("ViewCount") %>&nbsp;&nbsp;|&nbsp;
                                    Ngày đăng: <%#Eval("AddedDate", "{0:dd.MM.yyyy}")%>&nbsp;&nbsp;|&nbsp;
                                    Đăng bởi: <a href='/adm/ManageMemberProducts.aspx?member=<%# Eval("AddedBy") %>'><b><%# Eval("AddedBy") %></b></a>
                                </span>
                                <span class="exten">
                                    <asp:CheckBox runat="server" ID="ckbListed" Text="Đã kiểm duyệt" AutoPostBack="true" Checked='<%# Eval("Listed") %>' OnCheckedChanged="ckbListed_CheckedChanged" CssClass="chk" />
                                </span>
                                <span class="action">
                                    <a href='/adm/product.aspx?action=edit&productID=<%# Eval("ProductID")%>' title="Sửa thông tin sản phẩm" class="btn btn-blue" >Sửa</a>&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("ProductID")%>' ToolTip="Xóa sản phẩm" Text="Xóa"
                                            onclientclick="if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này?') == false) return false;" CssClass="btn btn-red" />
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
            </asp:Panel>
        </div>
    </div>
</asp:Content>
