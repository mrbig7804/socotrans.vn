<%@ page language="C#" title="" autoeventwireup="true" masterpagefile="~/adm/AdminTemplate.master" codefile="ManageFeedbacks.aspx.cs" inherits="admin_Feedbacks" %>

<asp:content id="Content1" runat="server" contentplaceholderid="cphAdmin">
    <script type="text/javascript">
        function toggleDivState(divName) {
            var ctl = window.document.getElementById(divName);
            if (ctl.style.display == "none")
                ctl.style.display = "";
            else
                ctl.style.display = "none";
        }
    </script>

    <div class="content-header">
        <h1 class="title-page">Quản lý liên hệ - phản hồi</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Liên hệ - phản hồi</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-green">
            <div class="top-box">
                <h1 class="list">Danh sách phản hồi từ người dùng</h1>
            </div>
            <div class="middle-box">
                <asp:gridview id="gvwFeedbacks" runat="server" autogeneratecolumns="False" datasourceid="ObjectDataSource1" datakeynames="ContactID" showheader="False" 
                    CssClass="tbl-grid" allowpaging="True">
                    <columns>
                        <asp:templatefield>
                            <itemtemplate>
                                <a href="javascript:toggleDivState('feedback<%# Eval("ContactID") %>');">
                                    <img src="../images/ArrowR2.gif" alt="" style="vertical-align: middle; border-width: 0px;" /><%# Eval("Title") %></a>
                                - <small>
                                    <%# Eval("FullName")%>(<%# Eval("FeedbackDate", "{0:dd/MM/yyyy hh:mm tt}")%>)</small>
                                <div style="display: none;" id='feedback<%# Eval("ContactID") %>'>
                                    <strong>Email: </strong>
                                    <%# Eval("Email") %>
                                    <br />
                                    <strong>Họ tên: </strong>
                                    <%# Eval("FullName") %>
                                    <br />
                                    <strong>Điện thoại: </strong>
                                    <%# Eval("Tel") %>
                                    <br />
                                    <asp:localize id="Localize1" runat="server" text='<%# Eval("Detail").ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n","<br/>") %>'></asp:localize>
                                </div>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:templatefield>
                            <itemtemplate>
                                <asp:linkbutton runat="server" id="btnDelete" commandname="Delete" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa mục này?') == false) return false;">Xóa</asp:linkbutton>
                                <itemstyle horizontalalign="Center" width="30px" />
                            </itemtemplate>
                        </asp:templatefield>
                    </columns>
                    <emptydatatemplate><b>Không có dữ liệu</b></emptydatatemplate>
                    <headerstyle cssclass="tbl-gridHeader" />
                    <alternatingrowstyle cssclass="tbl-gridAlternate" />
                    <SelectedRowStyle CssClass="tbl-GridSelected" />
                    <PagerStyle CssClass="tbl-gridPager" />
                </asp:gridview>
                <asp:objectdatasource id="ObjectDataSource1" runat="server" deletemethod="Delete"
                    selectmethod="GetFeedbacksAll" typename="Zensoft.Website.BusinessLayer.BusinessFacade.FeedbacksBF">
                    <deleteparameters>
                        <asp:parameter name="contactID" type="Int32" />
                    </deleteparameters>
                </asp:objectdatasource>
            </div>
            <div class="bottom-box"></div>
        </div>
    </div>
</asp:content>
