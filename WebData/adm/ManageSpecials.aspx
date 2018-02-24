<%@ page language="C#" masterpagefile="~/adm/AdminTemplate.master" autoeventwireup="true"
    codefile="ManageSpecials.aspx.cs" inherits="adm_ManageSpecials" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
     <div class="headerText">
        <img src="/images/ManageProducts.png" />Quản trị hàng hóa
    </div>
    <table width="100%">
        <tr>
            <td width="180px" valign="top">
            <img src="/images/spacer.gif"  width="180px" height="1px" />
                <asp:repeater id="rptDepartment" runat="server" 
                    datasourceid="ObjectDataSource2">
                    <itemtemplate>
                        <asp:hyperlink id="lnkDepartment" navigateurl='<%# "/adm/ManageSpecials.aspx?ID=" + Eval("SpecialID").ToString()%>'
                            runat="server"><%#Eval("Title") %> </asp:hyperlink>
                    </itemtemplate>
                    <separatortemplate>
                        <br />
                    </separatortemplate>
                </asp:repeater>
            </td>
            <td width="100%" valign="top">
                <asp:gridview id="gvwProducts" runat="server" autogeneratecolumns="False" width="98%"
                    datakeynames="ProductID" borderstyle="None" gridlines="None" borderwidth="1px"
                    allowpaging="True" datasourceid="ObjectDataSource1" showheader="False" cellpadding="0"
                    onrowcommand="gvwProducts_RowCommand">
                    <columns>
                        <asp:templatefield>
                            <itemtemplate>
                                <div style="border-bottom: solid 1px #6b6b6b">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100px">
                                                <a href='/san-pham/<%# Eval("UniqueTitle")%>'>
                                                    <asp:image id="Image1" runat="server" imageurl='<%# Eval("SmallPictureUrl")%>' />
                                                </a>
                                            </td>
                                            <td>
                                                <strong><a href='/san-pham/<%# Eval("UniqueTitle")%>'>
                                                    <%# Eval("Title")%></a></strong><br />
                                                Giá: <strong>
                                                    <%# Zensoft.Website.Configuration.Helpers.PriceFormat(Convert.ToInt32(Eval("UnitPrice"))) %></strong>
                                                | Lượt Xem:
                                                <%#Eval("ViewCount") %><br />
                                                Ngày đăng:
                                                <%#Eval("AddedDate", "{0:dd.MM.yyyy}")%><br />
                                                <div class="dot">
                                                <asp:imagebutton imageurl="~/Images/Delete.gif" onclientclick="if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này?') == false) return false;"
                                                    id="btnDelete" commandname="DeleteSpecial" commandargument='<%# Eval("ProductID")%>'
                                                    runat="server" tooltip="Xóa" />
                                                &nbsp;&nbsp;|&nbsp;&nbsp; <a href='/adm/product.aspx?action=edit&productID=<%# Eval("ProductID")%>'
                                                    title="Sửa">
                                                    <img src="/images/edit.gif" align="asbmiddle" /></a> 
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </itemtemplate>
                        </asp:templatefield>
                    </columns>
                </asp:gridview>
            </td>
        </tr>
    </table>
    <asp:objectdatasource id="ObjectDataSource1" runat="server" deletemethod="Delete"
        selectmethod="GetProductsBySpecialID" 
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.ProductsBF">
        <deleteparameters>
            <asp:parameter name="productID" type="Int32" />
        </deleteparameters>
        <selectparameters>
            <asp:querystringparameter defaultvalue="1" name="specialID" 
                querystringfield="ID" type="Int32" />
        </selectparameters>
    </asp:objectdatasource>
    <asp:objectdatasource id="ObjectDataSource2" runat="server" 
        selectmethod="GetSpecialsAll" 
        typename="Zensoft.Website.BusinessLayer.BusinessFacade.SpecialsBF">
    </asp:objectdatasource>
</asp:content>
