<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSupplierPrice.ascx.cs"
    Inherits="adm_ucSupplierPrice" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvProductPrice" BorderColor="Gray" BorderStyle="Dotted" BorderWidth="1px"
            runat="server" AutoGenerateColumns="False" DataSourceID="objProductPrice" DataKeyNames="ProductID,SupplierID">
            <Columns>
                <asp:BoundField ReadOnly="true" DataField="SupplierID" HeaderText="ID" SortExpression="SupplierID" />
                <asp:BoundField ReadOnly="true" DataField="SupplierName" HeaderText="T&#234;n cửa h&#224;ng"
                    SortExpression="SupplierName" />
                <asp:BoundField DataField="InputPrice" HeaderText="Gi&#225; nhập" SortExpression="InputPrice" />
                <asp:CommandField ButtonType="Image" EditImageUrl="Images/Edit.gif" UpdateImageUrl="Images/ok_16x16.gif"
                    CancelImageUrl="Images/redo1_16x16.gif" ShowEditButton="True">
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
        <asp:AsyncPostBackTrigger ControlID="btnAddPrice" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<asp:ObjectDataSource ID="objProductPrice" runat="server" SelectMethod="GetSupplierPricesByProductID"
    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SupplierPricesBF" DeleteMethod="Delete"
    UpdateMethod="Update">
    <SelectParameters>
        <asp:Parameter Name="productID" Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="supplierID" Type="Int32" />
        <asp:Parameter Name="productID" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="supplierID" Type="Int32" />
        <asp:Parameter Name="productID" Type="Int32" />
        <asp:Parameter Name="inputPrice" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:DropDownList ID="ddlSuppliers" runat="server" DataSourceID="objSuppliers" DataTextField="SupplierName"
    DataValueField="SupplierID">
</asp:DropDownList>
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
<asp:Button ID="btnAddPrice" runat="server" OnClick="btnAddPrice_Click" Text="Thêm giá" />
<asp:ObjectDataSource ID="objSuppliers" runat="server" SelectMethod="GetSuppliersAll"
    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SuppliersBF"></asp:ObjectDataSource>
