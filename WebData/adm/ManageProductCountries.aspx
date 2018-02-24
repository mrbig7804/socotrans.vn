<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true"
    CodeFile="ManageProductCountries.aspx.cs" Inherits="adm_ManageProductCountries"
    Title="Admin - Quản trị xuất xứ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="headerText">
        Danh mục nhóm hàng&nbsp;</div>
    <br />
    <asp:GridView ID="gvwSuperCategories" runat="server" AutoGenerateColumns="False"
        BorderColor="Gray" BorderStyle="Dotted" BorderWidth="1px" DataSourceID="objSuperCategories"
        OnRowCreated="gvwSuperCategories_RowCreated" OnRowDeleted="gvwSuperCategories_RowDeleted"
        OnSelectedIndexChanged="gvwSuperCategories_SelectedIndexChanged" Width="100%" DataKeyNames="CountryID">
        <Columns>
            <asp:BoundField DataField="CountryID" HeaderText="ID" SortExpression="CountryID" >
                <ItemStyle Width="20px" />
            </asp:BoundField>
            <asp:BoundField DataField="CountryName" HeaderText="Su&#226;́t xứ" SortExpression="CountryName" />
            <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" />
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
    <asp:ObjectDataSource ID="objSuperCategories" runat="server" DeleteMethod="Delete"
        SelectMethod="GetCountriesAll" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.CountriesBF">
        <DeleteParameters>
            <asp:Parameter Name="countryID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <p>
    </p>
    <table width="100%">
        <tr>
            <td style="width: 42%" valign="top">
                <asp:DetailsView ID="dvwSuperCategory" runat="server" AutoGenerateRows="False" BorderColor="#999999"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="objCurrSuperCategory"
                    DefaultMode="Insert" GridLines="Vertical" HeaderText="Chi tiết nhãn hiệu" OnItemCommand="dvwSuperCategory_ItemCommand"
                    OnItemCreated="dvwSuperCategory_ItemCreated" OnItemInserted="dvwSuperCategory_ItemInserted"
                    OnItemUpdated="dvwSuperCategory_ItemUpdated" Width="100%" DataKeyNames="CountryID">
                    <CommandRowStyle CssClass="DimGray" />
                    <PagerStyle VerticalAlign="Bottom" />
                    <Fields>
                        <asp:BoundField DataField="CountryName"  HeaderText="CountryName" SortExpression="CountryName" >
                            <ControlStyle CssClass="inputCommand" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Note" HeaderText="Note"  SortExpression="Note" >
                            <ControlStyle CssClass="inputCommand" />
                        </asp:BoundField>
                                                <asp:CommandField CancelText=" Bỏ qua" InsertText=" Th&#234;m mới  " ShowEditButton="True"
                            ShowInsertButton="True" UpdateText=" Cập nhật " />

                    </Fields>
                    <FieldHeaderStyle CssClass="gridViewHeader" Width="120px" />
                    <HeaderStyle CssClass="gridViewHeader" />
                </asp:DetailsView>
                <asp:ObjectDataSource ID="objCurrSuperCategory" runat="server" SelectMethod="GetCountriesBF"
                    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.CountriesBF" UpdateMethod="Update"
                    InsertMethod="Insert">
                    <UpdateParameters>
                        <asp:Parameter Name="countryID" Type="Int32" />
                        <asp:Parameter Name="countryName" Type="String" />
                        <asp:Parameter Name="note" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwSuperCategories" Name="countryID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="countryID" Type="Int32" />
                        <asp:Parameter Name="countryName" Type="String" />
                        <asp:Parameter Name="note" Type="String" />
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
