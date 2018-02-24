<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/TemplateHome.master" CodeFile="RSS.aspx.cs" Inherits="RSS" %>
<%@ Register Src="ucListCategoryForRSS.ascx" TagName="ucListCategoryForRSS" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
<table style="border:solid 1px #666666; margin-right:2px; margin-left:2px;" cellpadding="2" cellspacing="2"><tr><td>
    <br />
    <table style="width: 100%" cellpadding="10">
        <tr>
            <td style="width: 45%; text-align: justify;" align="left" valign="top">    
            <p class="sectionTitle" style="text-align: right">RSS là gì?</p>

RSS (Really Simple Syndication) là định dạng dữ liệu dựa theo chuẩn XML được sử dụng để chia sẻ và phát tán nội dung Web. Việc sử dụng các chương trình đọc tin (News Reader, RSS Reader hay RSS Feeds) sẽ giúp bạn luôn xem được nhanh chóng tin tức mới nhất<br />
                &nbsp; &nbsp;

Mỗi tin dưới dạng RSS sẽ gồm : Tiêu đề, tóm tắt nội dung và đường dẫn nối đến trang Web chứa nội dung đầy đủ của tin.<br />
<p class="sectionTitle" style="text-align: right">Chương trình đọc RSS là gì?</p>
Rss Reader là phần mềm có chức năng tự động lấy tin tức đã được cấu trúc theo định dạng RSS. Một số phần mềm đọc RSS cho phép bạn lập lịch cập nhật tin tức. Với chương trình đọc RSS, bạn có thể nhấn chuột vào tiêu đề của 1 tin để đọc phần tóm tắt của hoặc mở ra nội dung của toàn bộ tin trong một cửa sổ trình duyệt mặc định.
    <br />
                &nbsp; &nbsp;

Hiện tại hầu hết trình duyệt web đã hỗ trợ khai thác tin qua định dạng RSS như: Opera, Firefox, Netscape, Safari, Internet Explorer 7...<br/>
            </td>
            <td style="width: 55%" valign="top"><br />
 <p class="sectionTitle">
     Các kênh RSS Zensoft cung cấp</p>
    <img src="images/spacer.gif" style="width: 30px; height: 1px" align="left" />
        <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
             <a class="LeftMenuSuper" href='GetRSS.aspx?ID=<%# Eval("SuperCategoryID") %>' >
            <img src="images/rss.gif" /> <%# Eval("Title") %></a><br /> 
            <uc1:ucListCategoryForRSS SuperCategoryID='<%# Eval("SuperCategoryID") %>' ID="UcListCategoryForRSS1" runat="server" />
        </ItemTemplate>
    </asp:DataList>
            </td>
        </tr>
    </table>    
     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSuperCategoriesAll"
        TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.SuperCategoriesBF"></asp:ObjectDataSource>
</td></tr></table>
</asp:Content>
