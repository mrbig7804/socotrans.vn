<%@ page language="C#" masterpagefile="~/TemplateHome.master" autoeventwireup="true"
    codefile="ItemSearch.aspx.cs" inherits="ItemSearch" title="Tìm kiếm" %>

<asp:content id="Content1" runat="server" contentplaceholderid="cphHomePage">
    <br />
    <div class="pageHeaderText">
        Tìm Kiếm</div>
    <div class="dot" style="width: 225px">
    </div>
    <br />
    <strong>Từ Khóa:</strong>
    <asp:textbox cssclass="inputCommand" id="txtKeywords" runat="server" width="320px"></asp:textbox>
    &nbsp;&nbsp;<asp:button cssclass="inputCommand" id="btnSearch" runat="server" text="Tìm Kiếm"
        width="95px" onclick="btnSearch_Click" />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;<asp:label id="lblNote" runat="server" text="*Gợi ý: Để tìm kiếm một cụm từ bạn hãy để cụm từ đó trong ngoặc kép"
        font-italic="True"></asp:label><asp:label id="lblMessage" runat="server" font-bold="False"></asp:label><br />
    <br />
    <asp:gridview id="gvProducts" runat="server" width="100%" autogeneratecolumns="False"
        datakeynames="ProductID" showheader="False" allowpaging="True" cellpadding="0"
        editindex="0" borderstyle="None" borderwidth="0px" gridlines="None" 
        selectedindex="0" onpageindexchanging="gvProducts_PageIndexChanging">
        <columns>
            <asp:templatefield>
                <itemtemplate>
                    <div style="padding: 3px;margin: 5px; ">
                        <div class="itemBorder itemOnShoping" style="float: left; text-align: center; overflow: hidden;">
                            <a href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                                <asp:image id="imgPicPreview" runat="server" imageurl='<%# Eval("SmallPictureUrl") %>'
                                    alternatetext='<%# Eval("Title") %>' cssclass="imageOnShoping" /></a>
                        </div>
                        <div style="float: left; position:relative;width:500px; margin: 2px 2px 2px 5px;">
                            <a class="superCategoryTitle" href='<%# "/san-pham/"+Eval("UniqueTitle") %>' title='<%# Eval("Title") %>'>
                                <%# Eval("Title") %>
                            </a>
                            <br />
                            <small>
                                <%# Eval("Addeddate", "{0:dd/MM/yyyy}")%>
                            </small>
                            <br />
                            Người bán: <strong><a href='<%# "/"+Eval("Addedby") %>'>
                                <%# Eval("AddedBy") %></a></strong><br />
                            <div style="font-weight: bold; margin: 15px 5px 5px 5px;">
                                <span style="font-size: 24px">
                                    <%#  Convert.ToInt32(Eval("UnitPrice"))/1000%></span><span style="font-size: 16px">.000vnđ</span>
                            </div>
                        </div>
                    </div>
                </itemtemplate>
                <itemstyle borderwidth="0px" />
            </asp:templatefield>
        </columns>
        <pagersettings firstpagetext="Trang đầu" lastpagetext="Trang cuối" mode="NumericFirstLast"
            nextpagetext="Trang tiếp" previouspagetext="Trang trước" />
        <rowstyle borderwidth="0px" />
    </asp:gridview>
    &nbsp;
    <asp:label id="lblQuery" runat="server" visible="False"></asp:label>
</asp:content>
