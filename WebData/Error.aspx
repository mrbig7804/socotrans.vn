<%@ Page Language="C#" EnableTheming="false" AutoEventWireup="true" CodeFile="Error.aspx.cs"
    MasterPageFile="~/TemplateHome.master" Inherits="_Error" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphHomePage">
    <br />
    <div class="sectionTitle">
        Đã Phát Sinh Ngoại Lệ!</div>
    <p>
    </p>
    <asp:Label runat="server" ID="lbl404"><img src="images/file_del.gif" alt="" align="absMiddle" />Nội dung bạn yêu cầu không tồn tại hoặc đã bị xóa.</asp:Label>
    <asp:Label runat="server" ID="lbl408" Text="Hệ Thống bị quá tải do có quá nhiều người đang truy cập, Xin hãy thử lại sau." />
    <asp:Label runat="server" ID="lbl505" Text="Có một số lỗi nhỏ làm Server không thể thực hiện được yêu cầu của bạn ngay bây giờ, Xin hãy thử lại sau." />
    <asp:Label runat="server" ID="lblError" Visible="false" Text="Có một số vấn đề nhỏ trong quá trình xử lý. Chi tiết về lỗi này sẽ được thông báo cho người quản trị trong ít phút nữa." />
    <p>
    </p>
    Hãy vào trang <strong>
        <asp:HyperLink runat="server" ID="lnkContact" Text="Liên hệ" NavigateUrl="~/feedback.aspx" /></strong>
    để liên hệ trực tiếp với Webmaster về chi tiết các lỗi hoặc quay lại <strong><a href="/"
        title="Trang chủ">Trang chủ.</a> </strong>
</asp:Content>
