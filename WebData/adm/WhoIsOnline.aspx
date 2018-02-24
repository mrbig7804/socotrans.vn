<%@ Page Language="C#" MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="WhoIsOnline.aspx.cs" Inherits="adm_WhoIsOnline" Title="Untitled Page" %>

<asp:content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" 
    Runat="Server">
        <asp:gridview ID="gvWhoIsOnline" runat="server" AutoGenerateColumns="False" 
            DataSourceID="WhoIsOnlineDataSource" 
    EmptyDataText="There are currently no authenticated users visiting the site...">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="UserID" 
                    DataNavigateUrlFormatString="~/ActivityHistoryByUser.aspx?UserID={0}" 
                    DataTextField="UserName" HeaderText="User" />
                <asp:TemplateField HeaderText="Activity" SortExpression="Activity">
                    <ItemTemplate>
                        <%# FormatActivity(Eval("Activity").ToString(), Eval("PageUrl").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Updated" SortExpression="ActivityDate">
                    <ItemTemplate>
                        <%# FormatLastUpdatedDate(Convert.ToDateTime(Eval("ActivityDate")), DateTime.Now )%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
    <asp:objectdatasource id="WhoIsOnlineDataSource" runat="server" 
    selectmethod="GetCurrentActivityForOnline" 
    typename="Zensoft.Website.BusinessLayer.BusinessFacade.ActivityLogsBF">
        <selectparameters>
            <asp:parameter defaultvalue="15" name="minutes" type="Int32" />
        </selectparameters>
</asp:objectdatasource>
</asp:content>

