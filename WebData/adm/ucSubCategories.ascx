<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSubCategories.ascx.cs" Inherits="ucSubCategories" %>
<asp:DataList ID="DataList1" runat="server" Width="100%" EnableTheming="False" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" >
<HeaderTemplate>
    <table class="navlist" border = "0" cellpadding = "0" cellspacing="0"width = "100%">
</HeaderTemplate>
    <ItemTemplate>
       <tr class="navcontainer">
            <td class= "active"  >       
              <a class="current" href='Edit_Category.aspx?ID=<%# Eval("CategoryID") %>' title='<%# Eval("Description") %>'><%# Eval("Title") %></a>        
            </td> 
        </tr>                      
     </ItemTemplate>      
     <FooterTemplate>
     </table> 
     </FooterTemplate>                                    

</asp:DataList>
