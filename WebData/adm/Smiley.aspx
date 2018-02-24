<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true"
    CodeFile="Smiley.aspx.cs" Inherits="adm_Smiley" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Biểu tượng cảm xúc&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <br />
    <p>
    </p>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvwSuperCategories" runat="server" AutoGenerateColumns="False"
                            BorderColor="Gray" BorderStyle="Dotted" BorderWidth="1px" DataSourceID="objSuperCategories"
                            OnRowCreated="gvwSuperCategories_RowCreated" OnRowDeleted="gvwSuperCategories_RowDeleted"
                            OnSelectedIndexChanged="gvwSuperCategories_SelectedIndexChanged" Width="100%"
                            DataKeyNames="SmileyID" AllowPaging="True">
                            <Columns>
                                <asp:BoundField DataField="SmileyID" HeaderText="ID" SortExpression="SmileyID">
                                    <ItemStyle Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:Image  runat="server" ImageUrl='<%# "~/images/emoticons/" + Eval("Icon").ToString() %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="Mô tả" DataField="Emoticon"></asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="Images/Edit.gif" SelectText="Edit poll"
                                    ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="Images/Delete.gif" DeleteText="Delete poll"
                                    ShowDeleteButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:CommandField>
                            </Columns>
                            <EmptyDataTemplate>
                                <b>Không có dữ liệu</b></EmptyDataTemplate>
                            <AlternatingRowStyle CssClass="gridViewAlternatingRow" />
                            <HeaderStyle CssClass="gridViewHeader" />
                            <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="dvwSuperCategory" EventName="ItemUpdated" />
                        <asp:AsyncPostBackTrigger ControlID="dvwSuperCategory" EventName="ItemInserted" />
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp;
                <asp:ObjectDataSource ID="objSuperCategories" runat="server" SelectMethod="GetSmileysAll"
                    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SmileysBF"></asp:ObjectDataSource>
            </td>
            <td valign="top" width="40%">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DetailsView ID="dvwSuperCategory" runat="server" AutoGenerateRows="False" BorderColor="#999999"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="objCurrSuperCategory"
                            DefaultMode="Insert" GridLines="Vertical" HeaderText="Chi tiết " OnItemCommand="dvwSuperCategory_ItemCommand"
                            OnItemCreated="dvwSuperCategory_ItemCreated" OnItemInserted="dvwSuperCategory_ItemInserted"
                            OnItemUpdated="dvwSuperCategory_ItemUpdated" Width="100%" DataKeyNames="SmileyID">
                            <CommandRowStyle CssClass="DimGray" />
                            <PagerStyle VerticalAlign="Bottom" />
                            <Fields>
                                <asp:BoundField DataField="Code" HeaderText="Code:" SortExpression="Code">
                                    <ControlStyle CssClass="inputCommand" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Icon" HeaderText="Icon:" SortExpression="Icon">
                                    <ControlStyle CssClass="inputCommand" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Emoticon" HeaderText="M&#244; tả:" SortExpression="Emoticon">
                                    <ControlStyle CssClass="inputCommand" />
                                </asp:BoundField>
                                <asp:CommandField CancelText=" Bỏ qua" InsertText=" Th&#234;m mới  " ShowEditButton="True"
                                    ShowInsertButton="True" UpdateText=" Cập nhật " />
                            </Fields>
                            <FieldHeaderStyle CssClass="gridViewHeader" Width="120px" />
                            <HeaderStyle CssClass="gridViewHeader" />
                        </asp:DetailsView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvwSuperCategories" EventName="Load" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:ObjectDataSource ID="objCurrSuperCategory" runat="server" SelectMethod="GetSmiley"
                    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SmileysBF" UpdateMethod="Update"
                    InsertMethod="Insert">
                    <UpdateParameters>
                        <asp:Parameter Name="smileyID" Type="Int32" />
                        <asp:Parameter Name="code" Type="String" />
                        <asp:Parameter Name="icon" Type="String" />
                        <asp:Parameter Name="emoticon" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwSuperCategories" Name="smileyID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="smileyID" Type="Int32" />
                        <asp:Parameter Name="code" Type="String" />
                        <asp:Parameter Name="icon" Type="String" />
                        <asp:Parameter Name="emoticon" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />
    <asp:FileUpload ID="fuSmiley" runat="server" />
    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /><br />
    
            <asp:Repeater ID="rptAttachedFiles" runat="server" OnItemCreated="rptAttachedFiles_ItemCreated"
            OnItemDataBound="rptAttachedFiles_ItemDataBound" OnItemCommand="rptAttachedFiles_ItemCommand">
            <HeaderTemplate>
                <table width="100%" border="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td width="50px">
                        <asp:Image ID="imgPreview" runat="server" ImageUrl='<%# FileUrl + Container.DataItem %>'
                            BorderWidth="1" BorderColor="ActiveBorder" />
                        <asp:Image ID="imgUnknowFile" runat="server" ImageUrl="~/adm/images/playlist.png"
                            Width="50px" />
                    </td>
                    <td width="100%">
                        <asp:Label ID="lblFileName" runat="server" Text='<%# Container.DataItem %>'
                            CommandArgument='<%# Container.DataItem %>' />
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="if (confirm('Bạn có chắc chắn muốn xóa file đính kèm này không?') == false) return false;"
                            CommandName="DeleteAttachedFile">Xóa file</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

</asp:Content>
