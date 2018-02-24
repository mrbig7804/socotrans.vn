<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucArticlePublish.ascx.cs" Inherits="admin_ucArticlePublish" %>
<asp:DetailsView ID="dvwArticle" 
    runat="server"
    AutoGenerateRows="False" 
    BorderColor="Gray" 
    BorderStyle="Dotted" B
    orderWidth="1px"
    HeaderText="XUẤT BẢN"
    DataSourceID="objArticlePublish" 
    Width="100%" DefaultMode="Insert" DataKeyNames="ArticleID">
    <CommandRowStyle BackColor="DimGray" />
    <Fields>
        <asp:TemplateField HeaderText="Ng&#224;y xuất bản:">
                  <ItemTemplate>
                     <asp:Label ID="lblReleaseDate" runat="server" Text='<%# Eval("ReleaseDate", "{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                     <asp:TextBox ID="txtReleaseDate" runat="server" Text='<%# Bind("ReleaseDate","{0:dd/MM/yyyy hh:mm tt}") %>' CssClass="inputCommand" ></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy hh:mm tt"
                            TargetControlID="txtReleaseDate">
                    </ajaxToolkit:CalendarExtender>
                  </EditItemTemplate>
        </asp:TemplateField>        
        <asp:TemplateField HeaderText="Ng&#224;y hết hạn:">
                  <ItemTemplate>
                     <asp:Label ID="lblExpireDate" runat="server" Text='<%# Eval("ExpireDate", "{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                     <asp:TextBox ID="txtExpireDate" runat="server" Text='<%# Bind("ReleaseDate","{0:dd/MM/yyyy hh:mm tt}") %>' CssClass="inputCommand" ></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy hh:mm tt"
                            TargetControlID="txtExpireDate">
                    </ajaxToolkit:CalendarExtender>
                  </EditItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="Listed" HeaderText="Được hiển thị" SortExpression="Listed" />
        <asp:CheckBoxField DataField="Approved" HeaderText="Được duyệt" SortExpression="Approved" />
        <asp:CheckBoxField DataField="OnlyForMembers" HeaderText="Chỉ d&#224;nh cho th&#224;nh vi&#234;n" SortExpression="OnlyForMembers" />
        <asp:CheckBoxField DataField="CommentsEnabled" HeaderText="Cho ph&#233;p b&#236;nh luận" SortExpression="CommentsEnabled" />
        <asp:CommandField />
        <asp:CommandField ShowEditButton="True" UpdateText="Cập nhật" ShowInsertButton="True" />
    </Fields>
    <FieldHeaderStyle CssClass="gridViewHeader" Width="150px" />
    <HeaderStyle CssClass="gridViewHeader" />
</asp:DetailsView>
<asp:ObjectDataSource ID="objArticlePublish" runat="server" SelectMethod="GetArticlesBF"
    TypeName="Zensoft.Website.BusinessLayer.BusinessFacade.ArticlesBF" UpdateMethod="UpdatePublish">
    <SelectParameters>
        <asp:Parameter Name="articleID" Type="Int32"  />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="articleID" Type="Int32" />
        <asp:Parameter Name="releaseDate" Type="DateTime" />
        <asp:Parameter Name="expireDate" Type="DateTime" />
        <asp:Parameter Name="approved" Type="Boolean" />
        <asp:Parameter Name="listed" Type="Boolean" />
        <asp:Parameter Name="commentsEnabled" Type="Boolean" />
        <asp:Parameter Name="onlyForMembers" Type="Boolean" />
    </UpdateParameters>
</asp:ObjectDataSource>
