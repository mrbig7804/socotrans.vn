<%@ page language="C#" autoeventwireup="true" masterpagefile="~/adm/AdminTemplate.master"
    codefile="ManageAdLocations.aspx.cs" inherits="adm_ManageAdLocations" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

                <div class="headerText">
                    Mục quảng cáo
                </div>
                <asp:scriptmanager id="ScriptManager1" runat="server">
                </asp:scriptmanager>
                <table width="100%">
                    <tr>
                        <td valign="top" width="50%">
                            <asp:gridview id="gvwAdLocations" runat="server" autogeneratecolumns="False" datakeynames="AdLocationID"
                                datasourceid="objAdLocations" width="100%" bordercolor="Gray" borderstyle="Dotted"
                                borderwidth="1px" onrowcreated="gvwAdLocations_RowCreated" 
                                onrowdeleted="gvwAdLocations_RowDeleted" 
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
                                typename="Zensoft.Website.BusinessLayer.BusinessFacade.AdLocationsBF" 
                                deletemethod="Delete">
                                <deleteparameters>
                                    <asp:parameter name="adLocationID" type="Int32" />
                                </deleteparameters>
                            </asp:objectdatasource>
                        </td>
                        <td valign="top" width="50%">
                            <asp:detailsview id="dvwAdLocation" runat="server" autogeneraterows="False" datasourceid="objCurrAdLocation"
                                width="100%" datakeynames="AdLocationID" headertext="Chi tiết mục quảng cáo"
                                defaultmode="Insert" bordercolor="#999999" borderstyle="Solid" borderwidth="1px"
                                cellpadding="3" gridlines="Vertical" 
                                oniteminserted="dvwAdLocation_ItemInserted" 
                                onitemupdated="dvwAdLocation_ItemUpdated" 
                                onitemcreated="dvwAdLocation_ItemCreated">
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
</asp:content>
