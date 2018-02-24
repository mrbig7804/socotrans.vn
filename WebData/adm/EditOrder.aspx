<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="EditOrder.aspx.cs" Inherits="adm_EditOrder" Title="Admin - Thông tin đơn hàng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="sectiontitle">
       Quản trị đơn hàng</div>
   <p></p>
   <asp:DetailsView ID="dvwOrder" runat="server" AutoGenerateEditButton="True"
      AutoGenerateRows="False" DataKeyNames="OrderID" DataSourceID="objCurrOrder"
      DefaultMode="Edit" HeaderText="Order Details" OnDataBound="dvwOrder_DataBound">
      <FieldHeaderStyle Width="130px" />
      <Fields>
         <asp:BoundField DataField="OrderID" HeaderText="ID" ReadOnly="True" />
         <asp:BoundField DataField="AddedDate" HeaderText="Ngày đặt hàng:" ReadOnly="True" HtmlEncode="False" DataFormatString="{0:f}" />
         <asp:TemplateField HeaderText="Khách hàng">
            <ItemTemplate>
               <asp:HyperLink runat="server" ID="lnkCustomer" Text='<%# Eval("AddedBy") %>'
                  NavigateUrl='<%# "mailto:" + Eval("CustomerEmail") %>' /><br />
               - Điện thoại: <%# Eval("CustomerPhone") %><br />
               - Di động: <%# Eval("CustomerMoblie")%>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Địa chỉ:">
            <ItemTemplate>
               <%# Eval("ShippingFullName")%><br />
               <%# Eval("ShippingAddress") %><br />
               <%# Eval("ShippingCity") %>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Mặt hàng">
            <ItemTemplate>
               <asp:Repeater runat="server" ID="repOrderItems" DataSource='<%# Eval("OrderItems") %>'>                  
                  <ItemTemplate>
                     <img src="../Images/ArrowR3.gif" border="0" alt="" />                      
                      <asp:HyperLink runat="server" ID="lnkProduct" Text='<%# Eval("Title") %>'
                        NavigateUrl='<%# "/san-pham/" + Eval("UniqueTitle") %>' />
                     <small>(Size: <%# Eval("Size") %>, Color: <%# Eval("Color") %>) - Số lượng = <%# Eval("Quantity") %></small>
                     <br />
                  </ItemTemplate>
               </asp:Repeater>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField DataField="Total" HeaderText="Tổng ti&#234;n:" ReadOnly="True" HtmlEncode="False"  />         
         <asp:TemplateField HeaderText="Trạng th&#225;i">
            <EditItemTemplate>
               <asp:DropDownList ID="ddlOrderStatuses" runat="server" DataSourceID="objAllStatuses"
                  DataTextField="Title" DataValueField="OrderStatusID" SelectedValue='<%# Bind("StatusID") %>' Width="100%" />
               <asp:ObjectDataSource ID="objAllStatuses" runat="server" SelectMethod="GetOrderStatusAll"
                  TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.OrderStatusBF"></asp:ObjectDataSource>   
            </EditItemTemplate>
         </asp:TemplateField>         
         <asp:TemplateField HeaderText="Ngày gửi hàng:">
            <ItemTemplate>
               <asp:Label ID="lblShippedDate" runat="server" Text='<%# Eval("ShippedDate") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtShippedDate" runat="server" Text='<%# Bind("ShippedDate", "{0:d}") %>' Width="100%" MaxLength="256"></asp:TextBox>
               <asp:CompareValidator ID="valShippedDateType" runat="server" Operator="DataTypeCheck" Type="Date"
                  ControlToValidate="txtShippedDate" Text="The format of the Shipped Date field is not valid."
                  ToolTip="The format of the Shipped Date field is not valid." Display="dynamic" />
            </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Ghi ch&#250; của kh&#225;ch h&#224;ng:">
            <ItemTemplate>
               <asp:Label ID="lblTrackingID" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Ghi ch&#250;">
            <ItemTemplate>
               <asp:Label ID="lblTransactionID" runat="server" Text='<%# Eval("Note") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtTransactionID" TextMode="MultiLine" Rows="5" runat="server" Text='<%# Bind("Note") %>' Width="100%" ></asp:TextBox>
            </EditItemTemplate>
         </asp:TemplateField>
      </Fields>
   </asp:DetailsView>
   <asp:ObjectDataSource ID="objCurrOrder" runat="server"
      SelectMethod="GetOrdersBF" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.OrdersBF" UpdateMethod="Update">
      <SelectParameters>
         <asp:QueryStringParameter Name="orderID" QueryStringField="ID" Type="Int32" />
      </SelectParameters>
       <UpdateParameters>
           <asp:Parameter Name="orderID" Type="Int32" />
           <asp:Parameter Name="statusID" Type="Int32" />
           <asp:Parameter Name="shippedDate" Type="DateTime" />
           <asp:Parameter Name="description" Type="String" />
           <asp:Parameter Name="note" Type="String" />
       </UpdateParameters>
   </asp:ObjectDataSource>  
</asp:Content>

