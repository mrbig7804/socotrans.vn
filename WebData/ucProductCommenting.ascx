<%@ control language="C#" autoeventwireup="true" codefile="ucProductCommenting.ascx.cs"
    inherits="ucProductCommenting" %>
<style type="text/css" media="all">
    @import "/Library/jtip/css/global.css";
</style>

<script src="/Library/jquery.js" type="text/javascript"></script>

<script src="/Library/jtip/jtip.js" type="text/javascript"></script>

<asp:repeater id="rptProductRelate" runat="server">
    <headertemplate>
        <div class="itemBox">
            <div class="itemBoxCaption">
                <strong>ĐANG BÌNH LUẬN</strong>
            </div>
    </headertemplate>
    <itemtemplate>
        <asp:panel cssclass="itemBorder itemOnCommenting" id="panImagePreview" runat="server">
            <div style="text-align: center; overflow: hidden;">
                <asp:hyperlink navigateurl='<%# "/GetCommenting.aspx?id=" + Eval("ProductID").ToString() %>'
                    id="HyperLink1" runat="server" class="jTip" name='<%# Eval("Title") %>' onclick='<%# "javascript:window.location=\"/san-pham/"+ Eval("UniqueTitle").ToString()+"\"" %>'>
                    <asp:image id="Image1" runat="server" imageurl='<%# Eval("SmallPictureUrl") %>' height="50px" />
                </asp:hyperlink>
            </div>
        </asp:panel>
    </itemtemplate>
    <footertemplate>
        </div>
    </footertemplate>
</asp:repeater>
