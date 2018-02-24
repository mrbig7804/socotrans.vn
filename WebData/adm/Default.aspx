<%@ Page Language="C#"  MasterPageFile="~/adm/AdminTemplate.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphAdmin">
    <%--CHÀO MỪNG: <%= Page.User.Identity.Name %>--%>
    <div class="content-header">
        <h1 class="title-page">Control panel</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
        </ol>
    </div>
    <div class="content">
        <div class="box box-blue">
            <br/><br/><br/><br/><br/>
        </div>
    </div>
</asp:Content>
