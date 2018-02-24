<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" ValidateRequest="false" Inherits="Product" Title="" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/adm/ucSpecialProduct.ascx" TagName="ucSpecialProduct" TagPrefix="uc1" %>
<%@ Register Src="~/adm/ucProductProperties.ascx" TagName="ucProductProperties" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript" src="libs/processPrice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('a.lightbox').lightBox(); // Select all links with lightbox class
        });
    </script>


    <div class="content-header">
        <h1 class="title-page">Sản phẩm</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Sản phẩm</li>
        </ol>
    </div>

    <div class="content">
        <div class="box-tabs">
            <ul id="nav-box-tabs" class="nav-box-tabs">
                <li>
                    <a href="javascript:void(0)" ref="#tabProduct1" class="active">Thông tin</a>
                </li>
                <li>
                    <a href="javascript:void(0)" ref="#tabProduct2" >Phát hành</a>
                </li>
                <li>
                    <a href="javascript:void(0)" ref="#tabProduct3" >Mở rộng</a>
                </li>
            </ul>
            <div class="middle-box">
                <div id="tabProduct1" class="pane-box-tabs tbl-form">
                        <div class="row">
                            <label class="lbl lbl-small">Tên sản phẩm:</label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="txt" Width="52%" />
                            <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true"
                                ErrorMessage="Tên sản phẩm" ValidationGroup="Product" CssClass="err" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Ảnh minh họa:</label> 
                            <asp:FileUpload runat="server" ID="fuProductImages" CssClass="txt txt-file" Width="53.2%" />
                            <asp:LinkButton runat="server" ID="lbtnUpImage" Text="Up ảnh" CssClass="btn btn-blue" OnClick="lbtnUpImage_Click" ValidationGroup="Product" />
                            <span id="valRequireImage" style="display: none" class="err">Ảnh sản phẩm</span>
                            <script type="text/javascript">
                                $('#<%=lbtnUpImage.ClientID %>').click(function () {
                                    if ($('#<%=fuProductImages.ClientID %>').val() == '') {
                                        $('#valRequireImage').show();
                                        return false;
                                    } else {
                                        $('#valRequireImage').hide();
                                    }
                                })
                            </script>
                        </div>
                        <asp:Panel runat="server" ID="pnlProductImages" CssClass="row">
                            <asp:Repeater ID="rptProductImages" runat="server" DataSourceID="objProductImages" OnItemCommand="rptProductImages_ItemCommand">
                                <HeaderTemplate><div class="list-productImage"></HeaderTemplate>
                                <FooterTemplate><span style="display: block; clear: both"></span></div></FooterTemplate>
                                <ItemTemplate>
                                    <span class="item-productImage">
                                        <a href='<%# Eval("FullImage").ToString().Replace("~/","/") %>' class="lightbox">
                                            <img class="image" src='<%# Eval("SmallImage").ToString().Replace("~/","/")  %>' alt='Image' />
                                        </a>
                                        <asp:LinkButton ID="ImageButton1" runat="server" OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa ảnh minh họa này?') == false) return false;"
                                            CommandArgument='<%# Eval("ProductImageID") %>' CommandName="DeleteImage" Text="Xóa" CssClass="btn btn-red" />
                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:ObjectDataSource ID="objProductImages" runat="server" DeleteMethod="Delete" SelectMethod="GetProductImagesByProductID" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.ProductImagesBF">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="productID" QueryStringField="ProductID" Type="Int32" />
                                </SelectParameters>
                                <DeleteParameters>
                                    <asp:Parameter Name="productImageID" Type="Int32" />
                                </DeleteParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                        <div class="row">
                            <label class="lbl lbl-small">Nhóm hàng:</label>
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="txt" Width="53.2%" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Nhà sản xuất:</label>
                            <asp:TextBox ID="txtBrand" runat="server" CssClass="txt" Width="20%" />
                            <%--<asp:DropDownList ID="ddlBrand" runat="server" CssClass="txt" Width="53.2%" />--%>
                        </div>
                        <%--<div class="row">
                            <label class="lbl lbl-small">Nhãn hiệu:</label>
                            <asp:TextBox ID="txtBrand" runat="server" Width="20%" CssClass="txt" autocomplete="off" />
                        </div>--%>
                        <div class="row">
                            <label class="lbl lbl-small">Giá cũ:</label>
                            <asp:TextBox ID="txtPrice" runat="server" onkeypress="javascript:keypress(event)" CssClass="txt" Text="0" Width="20%" OnKeyup="javascript:Money_CheckCorrect('ctl00_cphAdmin_txtPrice');" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Giá mới:</label>
                            <asp:TextBox ID="txtSalePrice" runat="server" onkeypress="javascript:keypress(event)" CssClass="txt" Text="0" Width="20%" OnKeyup="javascript:Money_CheckCorrect('ctl00_cphAdmin_txtSalePrice');" />
                        </div>
                        <div class="row">
                            <label class="lbl lbl-small">Bảo hành:</label>
                            <asp:TextBox ID="txtProdutcode" runat="server" CssClass="txt" Width="20%" />
                        </div>
                    <div class="row">
                        <label class="lbl lbl-small">Mô tả:</label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" Rows="10" TextMode="MultiLine" Width="52%"></asp:TextBox>
                    </div>                    
                    <div class="row">
                        <CKEditor:CKEditorControl ID="fckDetail" BasePath="~/ckeditor"  runat="server" UIColor="#BFEE62" Language="en" />
                    </div>
                </div>
                <div id="tabProduct2" class="pane-box-tabs tbl-form">
                    <div class="row">
                        <asp:CheckBox ID="chkDescontinued" TextAlign="Right" runat="server" Text="Sản phẩm ngừng cung cấp" CssClass="chk" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkListed" TextAlign="Right" runat="server" Text="Sản phẩm đã kiểm duyệt" Checked="true" CssClass="chk" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkVote" TextAlign="Right" runat="server" Text="Sản phẩm trang chủ" Checked="false" CssClass="chk" />
                    </div>
                    <asp:Panel runat="server" ID="pnlSpecialProduct">
                        <div class="row">
                            <uc1:ucSpecialProduct runat="server" ID="ucSpecialProduct1" SpecialID='1' />
                        </div>
                        <div class="row">
                            <uc1:ucSpecialProduct runat="server" ID="ucSpecialProduct2" SpecialID='2' />
                        </div>
                        <div class="row">
                            <uc1:ucSpecialProduct runat="server" ID="ucSpecialProduct3" SpecialID='3' />
                        </div>
                    </asp:Panel>
                </div>
                <div id="tabProduct3" class="pane-box-tabs tbl-form ">
                    <asp:Panel runat="server" ID="pnlProductProperty" CssClass="pnlProductProperty">
                        <uc2:ucProductProperties runat="server" ID="ucProductProperties1" />
                    </asp:Panel>
                </div>
            </div>
            <div class="bottom-box">
                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-blue" ValidationGroup="Product" OnClick="btnSubmit_Click" Text="Lưu sản phẩm" />&nbsp;
                <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-green" ValidationGroup="Product" OnClick="btnView_Click" Text="Xem sản phẩm" />
            </div>
        </div>

        <asp:Panel ID="panUpload" runat="server" CssClass="box box-green">
            <div class="top-box">
                <h1 class="list">Ảnh đính kèm sản phẩm</h1>
            </div>
            <div class="middle-box">
                <%--<asp:Panel ID="panDownloadImage" runat="server">
                    <asp:Button ID="btnGenUrl" runat="server" CssClass="btn btn-blue" Text="Lẫy link ảnh" OnClick="btnGenUrl_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCopyImageToServer" runat="server" Visible="false" CssClass="btn btn-red" OnClick="btnCopyImageToServer_Click" Text="Tải về server" />
                    <asp:Repeater ID="rptUrlCopy" runat="server" >
                        <HeaderTemplate><ul class="listImgCopy-Product"></HeaderTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                        <ItemTemplate>
                            <li>
                                <div>
                                    <asp:CheckBox ID="chkCopy" Checked="true" runat="server" />
                                </div>
                                <img src='<%# ((DictionaryEntry)Container.DataItem).Key %>' class="image" alt="Administrator MB" />
                                <div>
                                    <span>
                                        <b>Tên file: </b><asp:TextBox ID="txtFile" CssClass="txt txt-disabled" runat="server" Text='<%# ((DictionaryEntry)Container.DataItem).Value %>' Width="50%" />
                                    </span>
                                    <span>
                                        <b>Url: </b><asp:Label ID="lblUrl" runat="server" Text='<%# ((DictionaryEntry)Container.DataItem).Key %>' />
                                    </span>
                                    <span>
                                        <asp:Label ID="lblMess" runat="server" />
                                    </span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>--%>
                <fieldset class="listImgAttach-Product">
                    <iframe src='<%# UploadUrl %>' frameborder="0" marginwidth="0" marginheight="0" scrolling="no" class="ifrUpload-Product"></iframe>
                    <iframe src='<%# AttachedUrl %>' frameborder="0" marginwidth="0" marginheight="0" id="articlePictureList" class="ifrAttach-Product"></iframe>
                </fieldset>
            </div>
            <div class="bottom-box"></div>
        </asp:Panel>
    </div>
</asp:Content>