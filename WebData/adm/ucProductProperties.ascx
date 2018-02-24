<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductProperties.ascx.cs" Inherits="adm_ucProductProperties" %>

<asp:Repeater runat="server" ID="rptProperty" OnItemDataBound="rptProperty_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <FooterTemplate></ul></FooterTemplate>
    <ItemTemplate>
        <li>
            <h3><%# Eval("Title") %></h3>
            <asp:GridView runat="server" ID="gvwPropertyValue" AutoGenerateColumns="false" ShowHeader="false" CssClass="tbl-grid"
                DataKeyNames="PropertiesValueID" >
            <Columns>
                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPropertyValue" Width="98%" Text='<%# Eval("Value") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%"
                    FooterStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center" FooterStyle-Width="8%" >
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSetValue" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
            <headerstyle cssclass="tbl-gridHeader" />
            <alternatingrowstyle cssclass="tbl-gridAlternate" />
            <SelectedRowStyle CssClass="tbl-GridSelected" />
            <PagerStyle CssClass="tbl-gridPager" />
        </asp:GridView>
            <%--<asp:UpdatePanel runat="server" ID="udpPropertyValue">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="gvwPropertyValue" AutoGenerateColumns="false" ShowHeader="false" ShowFooter="true" CssClass="tbl-grid"
                         DataKeyNames="PropertiesValueID" OnRowEditing="gvwPropertyValue_RowEditing" OnRowUpdating="gvwPropertyValue_RowUpdating"
                         OnRowCancelingEdit="gvwPropertyValue_RowCancelingEdit" >
                        <Columns>
                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left">
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
                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%"
                                FooterStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center" FooterStyle-Width="8%" >
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkSetValue" />
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
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
        </li>
    </ItemTemplate>
</asp:Repeater>