<%@ Page Language="C#" AutoEventWireup="true" ContentType="text/xml" MaintainScrollPositionOnPostback="false" EnableTheming="false" CodeFile="GetRSS.aspx.cs" Inherits="GetRSS" %><?xml version='1.0' encoding='utf-8'?><head id="Head1" runat="server" visible="false"></head><asp:Repeater id="rptRss" runat="server"><HeaderTemplate>
<rss version="2.0">
         <channel>
            <title><![CDATA[<%# RssTitle %>]]></title>
            <link><%# FullBaseUrl %></link>
   </HeaderTemplate>
   <ItemTemplate>
      <item>
         <title><![CDATA[<%# Eval("Title") %>]]></title>
         <author><![CDATA[<%# Eval("AddedBy") %>]]></author>
         <description><![CDATA[<%# Eval("Abstract") %>]]></description>
         <link><![CDATA[<%# FullBaseUrl + "ShowArticle.aspx?ID=" + Eval("ArticleID") %>]]></link>
         <pubDate><%# string.Format("{0:R}", Eval("AddedDate")) %></pubDate>
      </item>
   </ItemTemplate>
   <FooterTemplate>
         </channel>
</rss>  
   </FooterTemplate>
</asp:Repeater>