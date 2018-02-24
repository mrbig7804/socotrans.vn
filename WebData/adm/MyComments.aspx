<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="MyComments.aspx.cs" Inherits="adm_MyComments" Title="Admin - Quản trị bình chọn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="border:solid 1px #666666; margin-right:2px; margin-left:2px; width:100%" cellpadding="2" cellspacing="2"><tr><td>
   <div class="headerText">
    Nhận xét bài viết</div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; + <a href="Comments.aspx"> Những nhận
        xét gần đầy</a>.<br />
<br />   
    
       <script type="text/javascript">
      function toggleDivState(divName)
      {
         var ctl = window.document.getElementById(divName);
         if (ctl.style.display == "none")
            ctl.style.display = "";
         else
            ctl.style.display = "none";
      }
   </script>

   <p  class="sectionTitle">Những nhận xét của tôi.</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
     DataSourceID="ObjectDataSource1" DataKeyNames="CommentID" Width="100%" 
     BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"  GridLines="Vertical" 
     ShowHeader="False" AllowPaging="True" >
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                   <a href="javascript:toggleDivState('comment<%# Eval("CommentID") %>');">
                   <img src="../images/ArrowR2.gif" alt="" style="vertical-align: middle; border-width: 0px;" /><%# Eval("ArticleTitle") %></a> - 
                   <small>(<%# Eval("AddedDate", "{0:dd/MM/yyyy hh:mm tt}")%>)</small>
                   <div style="display: none;" id="comment<%# Eval("CommentID") %>">
                       &nbsp;&nbsp;&nbsp;&nbsp;•<a href='../ShowArticle.aspx?ID=<%# Eval("ArticleID") %>' > Xem bài viết</a> <br />
                       <asp:Localize ID="Localize1" runat="server" Text='<%# Eval("Body").ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n","<br/>") %>'></asp:Localize> 
                   </div>
                   
                </ItemTemplate>
           </asp:TemplateField>
           </Columns>
        <SelectedRowStyle CssClass="gridViewSelectedRow" />
        <HeaderStyle CssClass="gridViewHeader" />
        <AlternatingRowStyle CssClass="gridViewAlternatingRow" />    
        <PagerSettings Mode="NextPrevious" NextPageText=" Trang ti&#234;́p &amp;gt;" PreviousPageText="&amp;lt; Trang trước " />
        <EmptyDataTemplate>
            Chưa có nhận xét nào...
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCommentsByUser" TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.CommentsBF">
        <SelectParameters>
            <asp:ProfileParameter Name="name" PropertyName="UserName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;&nbsp;<br />
</td></tr></table>
</asp:Content>


