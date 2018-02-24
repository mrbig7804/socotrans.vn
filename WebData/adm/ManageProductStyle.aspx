<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true"
    CodeFile="ManageProductStyle.aspx.cs" Inherits="adm_ManageProductStyle" Title="Admin - Quản trị phong cách" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Danh mục phong cách</div>
    <br />
    <asp:GridView ID="gvwSuperCategories" runat="server" AutoGenerateColumns="False"
        BorderColor="Gray" BorderStyle="Dotted" BorderWidth="1px" DataKeyNames="StyleID"
        DataSourceID="objSuperCategories" OnRowCreated="gvwSuperCategories_RowCreated"
        OnRowDeleted="gvwSuperCategories_RowDeleted" OnSelectedIndexChanged="gvwSuperCategories_SelectedIndexChanged"
        Width="100%">
        <Columns>
            <asp:BoundField DataField="StyleID" HeaderText="ID" SortExpression="StyleID">
                <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="StyleName" HeaderText="Phong cách" SortExpression="StyleName" />
            <asp:BoundField DataField="Description" HeaderText="M&#244; tả" SortExpression="Description" />
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
            <b>Không có dữ liệu</b>
        </EmptyDataTemplate>
        <SelectedRowStyle CssClass="gridViewSelectedRow" />
        <HeaderStyle CssClass="gridViewHeader" />
        <AlternatingRowStyle CssClass="gridViewAlternatingRow" />
    </asp:GridView>
    <asp:ObjectDataSource ID="objSuperCategories" runat="server" DeleteMethod="Delete"
        SelectMethod="GetStyleAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.StyleBF">
        <DeleteParameters>
            <asp:Parameter Name="styleID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <p>
    </p>
    <table width="100%">
        <tr>
            <td style="width: 42%" valign="top">
                <asp:DetailsView ID="dvwSuperCategory" runat="server" AutoGenerateRows="False" BorderColor="#999999"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="objCurrSuperCategory"
                    DefaultMode="Insert" GridLines="Vertical" HeaderText="Chi tiết " OnItemCommand="dvwSuperCategory_ItemCommand"
                    OnItemCreated="dvwSuperCategory_ItemCreated" OnItemInserted="dvwSuperCategory_ItemInserted"
                    OnItemUpdated="dvwSuperCategory_ItemUpdated" Width="100%">
                    <CommandRowStyle CssClass="DimGray" />
                    <PagerStyle VerticalAlign="Bottom" />
                    <Fields>
                        <asp:BoundField ControlStyle-CssClass="inputCommand" DataField="StyleName" HeaderText="StyleName" SortExpression="StyleName" />
                        <asp:BoundField ControlStyle-CssClass="inputCommand" DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:CommandField CancelText=" Bỏ qua" InsertText=" Th&#234;m mới  " ShowEditButton="True"
                            ShowInsertButton="True" UpdateText=" Cập nhật " />
                    </Fields>
                    <FieldHeaderStyle CssClass="gridViewHeader" Width="120px" />
                    <HeaderStyle CssClass="gridViewHeader" />
                </asp:DetailsView>
                <asp:ObjectDataSource ID="objCurrSuperCategory" runat="server" DeleteMethod="Delete"
                    SelectMethod="GetStyleBF" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.StyleBF"
                    UpdateMethod="Update" InsertMethod="Insert">
                    <DeleteParameters>
                        <asp:Parameter Name="styleID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="styleID" Type="Int32" />
                        <asp:Parameter Name="styleName" Type="String" />
                        <asp:Parameter Name="description" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwSuperCategories" Name="styleID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="styleID" Type="Int32" />
                        <asp:Parameter Name="styleName" Type="String" />
                        <asp:Parameter Name="description" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
                <br />
            </td>
            <td valign="top" width="50%">
                &nbsp;<p>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
