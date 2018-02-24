<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="Statistics.aspx.cs" inherits="adm_Statistics" title="" %>

<asp:content id="Content1" contentplaceholderid="cphAdmin" runat="Server">
    <div class="content-header">
        <h1 class="title-page">Thống kê website</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Thống kê</li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-blue">
            <div class="middle-box">
                <span style="text-decoration: underline"><strong>Thông Tin Người Sử Dụng</strong></span>:<br />
                &nbsp; &nbsp; &nbsp; - Tổng số tài khoản:<asp:label id="lblTotal" runat="server"></asp:label><br />
                &nbsp; &nbsp; &nbsp; - Số người đang online:
                <asp:label id="lblUserOnline" runat="server" text=""></asp:label><br />
                &nbsp; &nbsp; &nbsp; - Số lượt ghé thăm:
                <asp:label id="lblUserVisited" runat="server" text=""></asp:label><br />
                &nbsp; &nbsp; &nbsp; - Số thành viên đang online:<asp:label id="lblAccOnline" runat="server"></asp:label><br />
                <br />
                <span style="text-decoration: underline"><strong>Thông Tin Bài Viết</strong></span>:<br />
                &nbsp; &nbsp; &nbsp; - Tổng số bài viết:<asp:label id="lblTotalArticles" runat="server"></asp:label>
            </div>
        </div>
    </div>
</asp:content>
