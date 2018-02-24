<%@ Page Title="" Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="ManageDepartmentProperties.aspx.cs" Inherits="adm_ManageDepartmentProperties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <div class="content-header">
        <h1 class="title-page">Thông số dòng SP:&nbsp;<asp:Label runat="server" ID="lblTitlePage" /></h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Thông số dòng SP</li>
        </ol>
    </div>
    <div class="content">
        <div class="col-left-50">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="info">Danh sách nhóm đặc tính dòng&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountGroupProperty" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:gridview id="gvwGroupProperty" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="6"
                        datakeynames="PropertyGroupID" CssClass="tbl-grid" OnPageIndexChanging="gvwGroupProperty_PageIndexChanging"
                        OnRowDeleting="gvwGroupProperty_RowDeleting" OnRowCreated="gvwGroupProperty_RowCreated" onselectedindexchanged="gvwGroupProperty_SelectedIndexChanged" >
                        <Columns>
                            <asp:boundfield datafield="Title" headertext="Tên nhóm" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" />
                            <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/blue-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa"
                                showselectbutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                            </asp:commandfield>
                            <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa"
                                showdeletebutton="True">
                                <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                            </asp:commandfield>
                        </Columns>
                        <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                        <headerstyle cssclass="tbl-gridHeader" />
                        <alternatingrowstyle cssclass="tbl-gridAlternate" />
                        <SelectedRowStyle CssClass="tbl-GridSelected" />
                        <PagerStyle CssClass="tbl-gridPager" />
                    </asp:gridview>
                </div>
                <div class="bottom-box"></div>
            </div>
        </div>
        <div class="col-right-50">
            <div class="box box-red">
                <div class="top-box">
                    <h1 class="info">Thông tin nhóm đặc tính</h1>
                </div>
                <div class="middle-box tbl-form">
                    <asp:HiddenField runat="server" ID="hdfGroupProperty" />
                    <div class="row">
                        <label class="lbl lbl-small">Tên nhóm:</label>
                        <asp:TextBox runat="server" ID="txtTitleGroup" CssClass="txt" width="45%" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleGroup" 
                            ErrorMessage="Nhập tên nhóm" CssClass="err" ValidationGroup="GRoupProperty" Display="Dynamic" SetFocusOnError="true" />
                    </div>
                </div>
                <div class="bottom-box">
                    <asp:LinkButton runat="server" ID="btnInsertGroupProperty" CssClass="btn btn-blue" ValidationGroup="GRoupProperty" onclick="btnInsertGroupProperty_Click" />
                    <asp:LinkButton runat="server" ID="btnCancel" Text="Bỏ qua" CssClass="btn btn-green" onclick="btnCancel_Click" />
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <%--THE END GROUP PROPERTIES--%>

        <asp:Panel runat="server" ID="pnlProperty" Visible="false">
            <div class="col-left-50">
                <div class="box box-green">
                    <div class="top-box">
                        <h1 class="info">Danh sách đặc tính dòng&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountProperty" CssClass="badge" /></h1>
                    </div>
                    <div class="middle-box">
                        <asp:gridview id="gvwProperty" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="15"
                            datakeynames="PropertyID" CssClass="tbl-grid" OnPageIndexChanging="gvwProperty_PageIndexChanging"
                            OnRowDeleting="gvwProperty_RowDeleting" OnRowCreated="gvwProperty_RowCreated" onselectedindexchanged="gvwProperty_SelectedIndexChanged" >
                            <Columns>
                                <asp:boundfield datafield="Title" headertext="Tên đặc tính" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" />
                                <asp:templatefield headertext="Phê duyệt">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="ckbAllow" Checked='<%# Eval("AllowSearch") %>' AutoPostBack="true" OnCheckedChanged="ckbAllow_CheckedChanged" />
                                    </ItemTemplate>
                                    <itemstyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                </asp:templatefield>
                                <asp:commandfield buttontype="Image" selectimageurl="/adm/images_adm/blue-edit-icon.png" selecttext="Edit poll" HeaderText="Sửa"
                                    showselectbutton="True">
                                    <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                                </asp:commandfield>
                                <asp:commandfield buttontype="Image" deleteimageurl="/adm/images_adm/red-delete-icon.png" deletetext="Delete poll" HeaderText="Xóa"
                                    showdeletebutton="True">
                                    <itemstyle horizontalalign="Center" VerticalAlign="Middle" width="8%" />
                                </asp:commandfield>
                            </Columns>
                            <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                            <headerstyle cssclass="tbl-gridHeader" />
                            <alternatingrowstyle cssclass="tbl-gridAlternate" />
                            <SelectedRowStyle CssClass="tbl-GridSelected" />
                            <PagerStyle CssClass="tbl-gridPager" />
                        </asp:gridview>
                    </div>
                    <div class="bottom-box"></div>
                </div>
            </div>
            <div class="col-right-50">
                <div class="box box-red">
                    <div class="top-box">
                        <h1 class="info">Thông tin đặc tính dòng</h1>
                    </div>
                    <div class="middle-box tbl-form">
                        <asp:HiddenField runat="server" ID="hdfProperty" />
                        <div class="row">
                            <label class="lbl lbl-small">Tên đặc tính:</label>
                            <asp:TextBox runat="server" ID="txtTitleProperty" CssClass="txt" width="45%" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitleProperty" 
                                ErrorMessage="Nhập tên đặc tính dòng" CssClass="err" ValidationGroup="Property" Display="Dynamic" SetFocusOnError="true" />
                        </div>
                    </div>
                    <div class="bottom-box">
                        <asp:LinkButton runat="server" ID="btnInsertProperty" CssClass="btn btn-blue" ValidationGroup="Property" onclick="btnInsertProperty_Click" />
                        <asp:LinkButton runat="server" ID="btnCancelProperty" Text="Bỏ qua" CssClass="btn btn-green" onclick="btnCancelProperty_Click" />
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </asp:Panel>
        <%--THE END PROPERTIES--%>

        <asp:Panel runat="server" ID="pnlPropertyValue" Visible="false">
            <div class="box box-green">
                <div class="top-box">
                    <h1 class="info">Danh sách thông số: <asp:Label runat="server" ID="lblTitlePropertyValue" />&nbsp;&nbsp;<asp:Label runat="server" ID="lblCountPropertyValue" CssClass="badge" /></h1>
                </div>
                <div class="middle-box">
                    <asp:UpdatePanel runat="server" ID="upnPropertyValue">
                        <ContentTemplate>
                            <asp:gridview id="gvwPropertyValue" runat="server" autogeneratecolumns="False" AllowPaging="true" PageSize="100" datakeynames="PropertiesValueID"
                                 CssClass="tbl-grid" ShowFooter="true" ShowHeader="false" OnPageIndexChanging="gvwPropertyValue_PageIndexChanging"
                                 OnRowEditing="gvwPropertyValue_RowEditing" onrowcancelingedit="gvwPropertyValue_RowCancelingEdit" onrowupdating="gvwPropertyValue_RowUpdating" >
                                <Columns>
                                    <asp:TemplateField headertext="" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPropertyValue" Width="98%" Text='<%# Eval("Value") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPropertyValue" Width="98%" Text='<%# Eval("Value") %>' CssClass="txt" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtPropertyValue" Width="98%" CssClass="txt" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField headertext="" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%"
                                        FooterStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center" FooterStyle-Width="8%" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDelPropertyValue" runat="server" CommandArgument='<%# Eval("PropertiesValueID") %>' Text="Xóa" CssClass="btn btn-red" 
                                                OnClientClick="return confirm('Bạn có chắc chắn muốn xóa thông số này?')" OnClick="lbtnDelPropertyValue_Click"/>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lbtnInsertPropertyValue" runat="server" Text="Thêm" CssClass="btn btn-blue" OnClick="lbtnInsertPropertyValue_Click" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" EditText="Sửa" UpdateText="Cập nhật" InsertText="Thêm mới" CancelText="Hủy bỏ" HeaderText="" 
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="12%" />
                                </Columns>
                                <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                                <headerstyle cssclass="tbl-gridHeader" />
                                <alternatingrowstyle cssclass="tbl-gridAlternate" />
                                <SelectedRowStyle CssClass="tbl-GridSelected" />
                                <PagerStyle CssClass="tbl-gridPager" />
                            </asp:gridview>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="bottom-box"></div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

