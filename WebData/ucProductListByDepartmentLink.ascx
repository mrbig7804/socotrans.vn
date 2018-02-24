<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductListByDepartmentLink.ascx.cs" Inherits="ucProductListByDepartmentLink" %>

<ul>
    <asp:ListView ID="rptProduct" runat="server">
        <ItemTemplate>
            <li>
                <span class="num"><%# Container.DataItemIndex + 1 %></span>
                <h3 class="title">
                    <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                        <%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 22) %>
                    </a>
                </h3>
            </li>
        </ItemTemplate>
    </asp:ListView>
</ul>
