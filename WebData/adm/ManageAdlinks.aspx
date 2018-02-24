<%@ page language="C#" title="" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true" codefile="ManageAdlinks.aspx.cs" inherits="adm_ManagerAdlinks" validaterequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register src="../ucAdLink.ascx" tagname="ucAdLink" tagprefix="uc1" %>--%>

<asp:content id="Content1" contentplaceholderid="cphAdmin" runat="Server">
    <div class="content-header">
        <h1 class="title-page">Danh mục quảng cáo</h1>
        <ol class="nav-page">
            <li class="home">
                <a href="/">Trang chủ</a>
            </li>
            <li class="current">Danh mục quảng cáo</li>
        </ol>
    </div>
    <div class="content">
    </div>

    <table width="100%">
        <tr>
            <td valign="top" width="50%">
                <asp:gridview id="gvwAdLocations" runat="server" autogeneratecolumns="False" datakeynames="AdLocationID"
                    datasourceid="objAdLocations" width="100%" bordercolor="Gray" borderstyle="Dotted"
                    borderwidth="1px" onrowcreated="gvwAdLocations_RowCreated" onrowdeleted="gvwAdLocations_RowDeleted"
                    onselectedindexchanged="gvwAdLocations_SelectedIndexChanged">
                    <columns>
                        <asp:boundfield datafield="AdLocationID" headertext="ID" sortexpression="AdLocationID">
                            <itemstyle width="15px" />
                        </asp:boundfield>
                        <asp:boundfield datafield="Title" headertext="Tiêu đề" sortexpression="Title">
                            <itemstyle width="200px" />
                        </asp:boundfield>
                        <asp:boundfield datafield="Description" headertext="Description" sortexpression="Description" />
                        <asp:commandfield buttontype="Image" selectimageurl="Images/Edit.gif" selecttext="Edit poll"
                            showselectbutton="True">
                            <itemstyle horizontalalign="Center" width="20px" />
                        </asp:commandfield>
                        <asp:commandfield buttontype="Image" deleteimageurl="Images/Delete.gif" deletetext="Delete poll"
                            showdeletebutton="True">
                            <itemstyle horizontalalign="Center" width="20px" />
                        </asp:commandfield>
                    </columns>
                    <emptydatatemplate>
                        <b>Không có dữ liệu</b></emptydatatemplate>
                    <alternatingrowstyle cssclass="gridViewAlternatingRow" />
                    <headerstyle cssclass="gridViewHeader" />
                    <selectedrowstyle cssclass="gridViewSelectedRow" />
                </asp:gridview>
                <asp:objectdatasource id="objAdLocations" runat="server" selectmethod="GetAdLocationsAll"
                    typename="Zensoft.Website.BusinessLayer.BusinessFacade.AdLocationsBF" deletemethod="Delete">
                    <deleteparameters>
                        <asp:parameter name="adLocationID" type="Int32" />
                    </deleteparameters>
                </asp:objectdatasource>
            </td>
            <td valign="top" width="50%">
                <asp:detailsview id="dvwAdLocation" runat="server" autogeneraterows="False" datasourceid="objCurrAdLocation"
                    width="100%" datakeynames="AdLocationID" headertext="Chi tiết mục quảng cáo"
                    defaultmode="Insert" bordercolor="#999999" borderstyle="Solid" borderwidth="1px"
                    cellpadding="3" gridlines="Vertical" oniteminserted="dvwAdLocation_ItemInserted"
                    onitemupdated="dvwAdLocation_ItemUpdated" onitemcreated="dvwAdLocation_ItemCreated">
                    <headerstyle cssclass="gridViewHeader" />
                    <fieldheaderstyle width="120px" cssclass="gridViewHeader" />
                    <fields>
                        <asp:templatefield headerstyle-verticalalign="Top" headertext="Ti&#234;u đề:">
                            <itemtemplate>
                                <asp:label id="lblSCTitle" runat="server" text='<%# Eval("Title") %>'></asp:label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:textbox id="txtTitle" runat="server" text='<%# Bind("Title") %>' maxlength="250"
                                    width="98%" cssclass="inputCommand"></asp:textbox>
                                <asp:requiredfieldvalidator id="valTitle" runat="server" controltovalidate="txtTitle"
                                    setfocusonerror="true" text="Bạn chưa nhập tiêu đề." tooltip="Tiêu đề không được để trống."
                                    display="Dynamic" validationgroup="AdLocation"></asp:requiredfieldvalidator>
                            </edititemtemplate>
                        </asp:templatefield>
                        <asp:templatefield headerstyle-verticalalign="Top" headertext="Mô tả:">
                            <itemtemplate>
                                <asp:label id="lblDescription" runat="server" text='<%# Eval("Description") %>'></asp:label>
                            </itemtemplate>
                            <edititemtemplate>
                                <asp:textbox id="lblDescription" runat="server" text='<%# Bind("Description") %>'
                                    textmode="MultiLine" rows="3" width="98%" cssclass="inputCommand"></asp:textbox>
                            </edititemtemplate>
                        </asp:templatefield>
                        <asp:commandfield canceltext=" Bỏ qua" inserttext=" Th&#234;m mới  " showeditbutton="True"
                            showinsertbutton="True" updatetext=" Cập nhật " />
                    </fields>
                    <commandrowstyle cssclass="DimGray" />
                    <pagerstyle verticalalign="Bottom" />
                </asp:detailsview>
                <asp:objectdatasource id="objCurrAdLocation" runat="server" selectmethod="GetAdLocationsBF"
                    typename="Zensoft.Website.BusinessLayer.BusinessFacade.AdLocationsBF" deletemethod="Delete"
                    insertmethod="Insert" updatemethod="Update">
                    <deleteparameters>
                        <asp:parameter name="adLocationID" type="Int32" />
                    </deleteparameters>
                    <updateparameters>
                        <asp:parameter name="adLocationID" type="Int32" />
                        <asp:parameter name="title" type="String" />
                        <asp:parameter name="description" type="String" />
                    </updateparameters>
                    <selectparameters>
                        <asp:controlparameter controlid="gvwAdLocations" name="adLocationID" propertyname="SelectedValue"
                            type="Int32" />
                    </selectparameters>
                    <insertparameters>
                        <asp:parameter name="adLocationID" type="Int32" />
                        <asp:parameter name="title" type="String" />
                        <asp:parameter name="description" type="String" />
                    </insertparameters>
                </asp:objectdatasource>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td valign="top" width="50%">
                <asp:gridview id="gvAllAdLinks" runat="server" bordercolor="#999999" borderstyle="Solid"
                    borderwidth="1px" cellpadding="3" gridlines="Vertical" allowpaging="True" autogeneratecolumns="False"
                    datasourceid="odsGetAllAdlinks" width="100%" datakeynames="AdLinkID" onrowcreated="gvAllAdLinks_RowCreated"
                    onrowdeleted="gvAllAdLinks_RowDeleted" onselectedindexchanged="gvAllAdLinks_SelectedIndexChanged">
                    <columns>
                        <asp:boundfield datafield="AdLinkID" headertext="ID" itemstyle-width="15px" sortexpression="AdLinkID">
                            <itemstyle width="15px"></itemstyle>
                        </asp:boundfield>
                        <asp:boundfield datafield="Title" headertext="Tiêu đề" sortexpression="Title" />
                        <asp:boundfield datafield="Click" headertext="Lượt Click" itemstyle-width="75px"
                            sortexpression="Click">
                            <itemstyle width="75px"></itemstyle>
                        </asp:boundfield>
                        <asp:boundfield datafield="ExpireDate" headertext="Ngày Hết Hạn" dataformatstring="{0:dd/MM/yyyy}"
                            itemstyle-width="150px" sortexpression="ExpireDate">
                            <itemstyle width="150px"></itemstyle>
                        </asp:boundfield>
                        <asp:commandfield buttontype="Image" selectimageurl="Images/Edit.gif" selecttext="Edit poll"
                            showselectbutton="True">
                            <itemstyle horizontalalign="Center" width="20px" />
                        </asp:commandfield>
                        <asp:commandfield buttontype="Image" deleteimageurl="Images/Delete.gif" deletetext="Delete poll"
                            showdeletebutton="True">
                            <itemstyle horizontalalign="Center" width="20px" />
                        </asp:commandfield>
                    </columns>
                    <emptydatatemplate>
                        <b>Không có dữ liệu</b>
                    </emptydatatemplate>
                    <selectedrowstyle cssclass="gridViewSelectedRow" />
                    <headerstyle cssclass="gridViewHeader" />
                    <alternatingrowstyle cssclass="gridViewAlternatingRow" />
                </asp:gridview>
                <asp:objectdatasource id="odsGetAllAdlinks" runat="server" deletemethod="Delete"
                    selectmethod="GetAdLinksByAdLocationID" typename="Zensoft.Website.BusinessLayer.BusinessFacade.AdLinksBF">
                    <deleteparameters>
                        <asp:parameter name="adLinkID" type="Int32" />
                    </deleteparameters>
                    <selectparameters>
                        <asp:controlparameter controlid="gvwAdLocations" name="adLocationID" propertyname="SelectedValue"
                            type="Int32" />
                    </selectparameters>
                </asp:objectdatasource>
                <%--<uc1:ucadlink id="ucAdLink1" showavailableadonly="false" runat="server" />--%>
            </td>
            <td valign="top">
                <asp:detailsview id="dvAdLinkDetails" runat="server" autogeneraterows="False" defaultmode="Insert" width="100%" bordercolor="#312A2D" borderstyle="Dotted" borderwidth="1px"
                    gridlines="Vertical" datakeynames="AdLinkID" headertext="Chi Tiết" onitemcommand="dvAdLinkDetails_ItemCommand"
                    onitemcreated="dvAdLinkDetails_ItemCreated" onitemdeleted="dvAdLinkDetails_ItemDeleted"
                    oniteminserted="dvAdLinkDetails_ItemInserted" onitemupdated="dvAdLinkDetails_ItemUpdated"
                    datasourceid="odsAdLinkDetails">
                    <fieldheaderstyle width="100px" cssclass="gridViewHeader" />
                    <fields>
                        <asp:boundfield datafield="Title" headertext="Tiêu đề:" sortexpression="Title">
                            <controlstyle cssclass="inputCommand" width="90%" />
                        </asp:boundfield>
                        <asp:templatefield headerstyle-verticalalign="Top" headertext="Mô tả:">
                            <itemtemplate>
                                <asp:textbox id="txtDescription" width="97%" cssclass="inputCommand" runat="server"
                                    text='<%# Bind("Description") %>' rows="2" textmode="MultiLine"></asp:textbox>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:templatefield headerstyle-verticalalign="Top" headertext="Khu Vực:">
                            <itemtemplate>
                                <asp:textbox id="txtAdLocation" width="100px" cssclass="inputCommand" runat="server"
                                    text='<%# Bind("AdLocationID") %>' ></asp:textbox>
                            </itemtemplate>
                        </asp:templatefield>
<%--                        <asp:boundfield datafield="AdLocationID" headertext="Khu Vực:" sortexpression="AdLocationID">
                            <controlstyle cssclass="inputCommand" />
                        </asp:boundfield>--%>
                        <asp:boundfield datafield="Importance" headertext="Mức Quan Trọng:" sortexpression="Importance">
                            <controlstyle cssclass="inputCommand" />
                        </asp:boundfield>
                        <asp:boundfield datafield="Image" headertext="Đường Dẫn Ảnh:" sortexpression="Image">
                            <controlstyle cssclass="inputCommand" width="90%" />
                        </asp:boundfield>
                        <asp:boundfield datafield="Link" headertext="Link Li&#234;n Kết:" sortexpression="Link">
                            <controlstyle cssclass="inputCommand" width="90%" />
                        </asp:boundfield>
                        <asp:templatefield headerstyle-verticalalign="Top" headertext="Code:">
                            <itemtemplate>
                                <asp:textbox id="txtCode" width="97%" cssclass="inputCommand" runat="server" text='<%# Bind("Code") %>'
                                    rows="6" textmode="MultiLine"></asp:textbox>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:checkboxfield datafield="IsCode" headertext="" sortexpression="Code" />
                        <asp:templatefield headertext="Ng&#224;y bắt đầu:">
                            <itemtemplate>
                                <asp:textbox id="txtRegionDate" cssclass="inputCommand" runat="server" text='<%# Bind("RegionDate","{0:dd/MM/yyyy  hh:mm tt}") %>'></asp:textbox>
                                <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" format="dd/MM/yyyy hh:mm tt"
                                    targetcontrolid="txtRegionDate">
                                </ajaxtoolkit:calendarextender>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:templatefield headertext="Ngày hết hạn:">
                            <itemtemplate>
                                <asp:textbox id="txtExpireDate" cssclass="inputCommand" runat="server" text='<%# Bind("ExpireDate","{0:dd/MM/yyyy hh:mm tt}") %>'></asp:textbox>
                                <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" format="dd/MM/yyyy hh:mm tt"
                                    targetcontrolid="txtExpireDate">
                                </ajaxtoolkit:calendarextender>
                            </itemtemplate>
                        </asp:templatefield>
                        <asp:commandfield canceltext=" Bỏ qua" inserttext=" Th&#234;m mới  " showeditbutton="True"
                            showinsertbutton="True" updatetext=" Cập nhật " />
                    </fields>
                    <fieldheaderstyle cssclass="gridViewHeader" width="130px" />
                    <headerstyle cssclass="gridViewHeader" />
                </asp:detailsview>
                <asp:objectdatasource id="odsAdLinkDetails" runat="server" selectmethod="GetAdLinksBF"
                    typename="Zensoft.Website.BusinessLayer.BusinessFacade.AdLinksBF" insertmethod="Insert"
                    updatemethod="Update" deletemethod="Delete">
                    <selectparameters>
                        <asp:controlparameter controlid="gvAllAdLinks" name="adLinkID" propertyname="SelectedValue"
                            type="Int32" />
                    </selectparameters>
                    <deleteparameters>
                        <asp:parameter name="adLinkID" type="Int32" />
                    </deleteparameters>
                    <updateparameters>
                        <asp:parameter name="adLinkID" type="Int32" />
                        <asp:parameter name="title" type="String" />
                        <asp:parameter name="description" type="String" />
                        <asp:parameter name="link" type="String" />
                        <asp:parameter name="image" type="String" />
                        <asp:parameter name="code" type="String" />
                        <asp:parameter name="isCode" type="Boolean" />
                        <asp:parameter name="regionDate" type="DateTime" />
                        <asp:parameter name="expireDate" type="DateTime" />
                        <asp:parameter name="importance" type="Int32" />
                        <asp:parameter name="click" type="Int32" />
                        <asp:parameter name="adLocationID" type="Int32" />
                    </updateparameters>
                    <insertparameters>
                        <asp:parameter name="adLinkID" type="Int32" />
                        <asp:parameter name="title" type="String" />
                        <asp:parameter name="description" type="String" />
                        <asp:parameter name="link" type="String" />
                        <asp:parameter name="image" type="String" />
                        <asp:parameter name="code" type="String" />
                        <asp:parameter name="isCode" type="Boolean" />
                        <asp:parameter name="regionDate" type="DateTime" />
                        <asp:parameter name="expireDate" type="DateTime" />
                        <asp:parameter name="importance" type="Int32" />
                        <asp:parameter name="click" type="Int32" />
                        <asp:parameter name="adLocationID" type="Int32" />
                    </insertparameters>
                </asp:objectdatasource>
            </td>
        </tr>
    </table>
    <br />
    <div style="width: 100%;" class="gridViewHeader">
        Upload file
    </div>
    <iframe src="uploadfile.aspx" frameborder="0" marginwidth="0" marginheight="0" allowtransparency="true"
        style="width: 100%; height: 159px; border: 0;"></iframe>
</asp:content>
