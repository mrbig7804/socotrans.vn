<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListCategories.ascx.cs" Inherits="admin_ucListCategories" %>
&nbsp;
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Zensoft.Website.DataLayer.DataObject.Category"
    DeleteMethod="Delete" SelectMethod="GetCategoriesBySuperCategoryID" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.CategoriesBF"
    UpdateMethod="Update">
    <SelectParameters>
        <asp:Parameter Name="superCategoryID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="CategoryID" OnRowUpdating="GridView1_RowUpdating">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
        <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" SortExpression="AddedDate" />
        <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" SortExpression="AddedBy" />
        <asp:BoundField DataField="SuperCategoryID" HeaderText="SuperCategoryID" SortExpression="SuperCategoryID" />
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        <asp:BoundField DataField="Importance" HeaderText="Importance" SortExpression="Importance" />
        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        <asp:BoundField DataField="ImageUrl" HeaderText="ImageUrl" SortExpression="ImageUrl" />
    </Columns>
</asp:GridView>
