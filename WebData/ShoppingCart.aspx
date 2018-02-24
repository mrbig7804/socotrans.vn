<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateShopping.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphShoppingPage" Runat="Server">
    <script src="/Library/Cart/jquery.numeric.js" type="text/javascript"></script>
    <script src="/Library/Cart/jsCart.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Library/bootstrapModal/bootstrap.min.js"></script>
    <link rel="stylesheet" href="/Library/bootstrapModal/bootstrap.min.css" />

    <div class="col-sm-12">
        <ul class="breadcrumbs">
            <li><a href="/">Trang chủ</a></li>
            <li><a href="/san-pham">Sản phẩm</a></li>
            <li>Đơn hàng</li>
        </ul>
    </div>
    
    <asp:Panel runat="server" ID="pnlCart">
        <div class="yInfo col-sm-8">
            <div class="main-cc-cart">
                <h3 class="ttl">Thông tin đặt hàng</h3>
                <ul class="infoCus col-sm-6">
                    <li class="inf">Thông tin khách hàng</li>
                    <li class="inf">
                        <span>Họ tên<i>*</i></span>
                        <span>
                            <asp:TextBox ID="txtCusName" runat="server" CssClass="inputText" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCusName" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập họ tên" CssClass="err" >Vui lòng nhập họ tên</asp:RequiredFieldValidator>
                        </span>
                    </li>
                    <li class="inf">
                        <span>Số điện thoại<i>*</i></span>
                        <span>
                            <asp:TextBox ID="txtCusMobile" runat="server" CssClass="inputText" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCusMobile" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập số điện thoại" CssClass="err" >Vui lòng nhập số điện thoại</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCusMobile" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Số điện thoại không hợp lệ" ValidationExpression="^0[0-9]+" CssClass="err" >Số điện thoại không hợp lệ</asp:RegularExpressionValidator>
                        </span>
                    </li>
                    <li class="inf">
                        <span>Email</span>
                        <span>
                            <asp:TextBox ID="txtCusEmail" runat="server" CssClass="inputText" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCusEmail" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập email" CssClass="err" >Vui lòng nhập email</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCusEmail" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Email không hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="err" >Email không hợp lệ</asp:RegularExpressionValidator>--%>
                        </span>
                    </li>
                    <li class="inf">
                        <span>Địa chỉ<i>*</i></span>
                        <span>
                            <asp:TextBox ID="txtCusAddress" runat="server" CssClass="inputText" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCusAddress" ValidationGroup="EndCart"
                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập địa chỉ" CssClass="err" >Vui lòng nhập địa chỉ</asp:RequiredFieldValidator>
                        </span>
                    </li>
                    
                    <li class="inf">
                        <span>Ghi chú</span>
                        <span>
                            <asp:TextBox ID="txtNote" runat="server" CssClass="inputText" TextMode="MultiLine" Rows="5" />
                        </span>
                    </li>
                    <%--<li>
                        <asp:ValidationSummary runat="server" ID="vldsCart" ValidationGroup="EndCart" CssClass="grErrCart" />
                    </li>--%>
                </ul>
                <ul class="infoShip col-sm-6">
                    <li>Thông tin vận chuyển:<a href="javascript:void(0)" data-toggle="modal" data-target="#myModal" id="editInfoShip"></a></li>
                    <li><b>Họ tên:</b>&nbsp;<asp:Label runat="server" ID="lblCusName" /></li>
                    <li><b>Số điện thoại:</b>&nbsp;<asp:Label runat="server" ID="lblCusMobile" /></li>
                    <li><b>Email:</b>&nbsp;<asp:Label runat="server" ID="lblCusEmail" /></li>
                    <li><b>Địa chỉ:</b>&nbsp;<asp:Label runat="server" ID="lblCusAddress" /></li>
                </ul>
                <%--START MODAL INFO SHIP--%>
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog modal-sm">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <h3>Thông tin vận chuyển</h3>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                <ul class="infoCusShip">
                                    <li class="inf">
                                        <span>Họ tên<i>*</i></span>
                                        <span>
                                            <asp:TextBox ID="_shipName" runat="server" CssClass="inputText" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="_shipName" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập họ tên" CssClass="err" >Vui lòng nhập họ tên</asp:RequiredFieldValidator>
                                        </span>
                                    </li>
                                    <li class="inf">
                                        <span>Số điện thoại<i>*</i></span>
                                        <span>
                                            <asp:TextBox ID="_shipMobile" runat="server" CssClass="inputText" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="_shipMobile" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập số điện thoại" CssClass="err" >Vui lòng nhập số điện thoại</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="_shipMobile" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Số điện thoại không hợp lệ" ValidationExpression="^0[0-9]+" CssClass="err" >Số điện thoại không hợp lệ</asp:RegularExpressionValidator>
                                        </span>
                                    </li>
                                    <li class="inf">
                                        <span>Email<i>*</i></span>
                                        <span>
                                            <asp:TextBox ID="_shipEmail" runat="server" CssClass="inputText" />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="_shipEmail" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập email" CssClass="err" >Vui lòng nhập email</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="_shipEmail" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Email không hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="err" >Email không hợp lệ</asp:RegularExpressionValidator>--%>
                                        </span>
                                    </li>
                                    <li class="inf">
                                        <span>Địa chỉ<i>*</i></span>
                                        <span>
                                            <asp:TextBox ID="_shipAddress" runat="server" CssClass="inputText" TextMode="MultiLine" Rows="5" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="_shipAddress" ValidationGroup="infoShip"
                                                Display="Dynamic" SetFocusOnError="true" ErrorMessage="Vui lòng nhập địa chỉ" CssClass="err" >Vui lòng nhập địa chỉ</asp:RequiredFieldValidator>
                                        </span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <%--END MODAL INFO SHIP--%>
            </div>
            <div class="main-cc-cart">
                <h3 class="ttl">Hình thức thanh toán</h3>
                <ul class="payment">
                    <li>
                        <span>&nbsp;<b>Giao hàng nhận tiền (COD)</b></span>
                        <span class="pay cod">
                            Trong thời gian từ thứ 2 - thứ 7 ngày làm việc, nhân viên của chúng tôi sẽ giao hàng đến tận
                            nơi cho quý khách. Quý khách sẽ thanh toán bằng tiền mặt khi nhận hàng.
                        </span>
                        <ol>
                            <li><asp:RadioButton runat="server" ID="rdbCOD_1" Text="&nbsp;<b>Nội thành Hải Phòng: 10.000 đ</b>" Checked="true" GroupName="payment" /></li>
                            <li><asp:RadioButton runat="server" ID="rdbCOD_2" Text="&nbsp;<b>Ngoại thành Hải Phòng: 20.000 đ</b>" GroupName="payment" /></li>
                            <li><asp:RadioButton runat="server" ID="rdbCOD_3" Text="&nbsp;<b>Các tỉnh khác: 30.000 đ</b>" GroupName="payment" /></li>
                        </ol>
                    </li>
                    <li>
                        <span>&nbsp;<b>Chuyển khoản qua tài khoản ATM</b></span>
                        <span class="pay atm-bank">
                            Thanh toán thông qua hình thức chuyển khoản ngân hàng. Quý khách có thể nhận hàng sau khi chuyển khoản.
                            <br /><b>Lê Mạnh Khôi - ngân hàng ACB Hải Phòng. Số tài khoản: 150435989</b>
                            <%--<br />Lê Mạnh Khôi - ngân hàng Techcombank Hải Phòng. Số tk: 19028187331016--%>
                        </span>
                        <ol>
                            <li><asp:RadioButton runat="server" ID="rdbATM_1" Text="&nbsp;<b>Thành phố Hải Phòng: Miễn phí</b>" GroupName="payment" /></li>
                            <li><asp:RadioButton runat="server" ID="rdbATM_2" Text="&nbsp;<b>Các tỉnh khác: 15.000 đ</b>" GroupName="payment" /></li>
                        </ol>
                    </li>
                    <li>
                        <span>&nbsp;<b>Chuyển khoản qua Western Union</b></span>
                        <span class="pay western-union">
                            Thanh toán thông qua hình thức chuyển khoản Western Union. Quý khách có thể nhận hàng sau khi chuyển khoản.<br />
                        </span>
                    </li>
                </ul>
            </div>
        </div>
        <div class="yCart col-sm-4">
            <div class="main-cc-cart">
                <h3 class="countPr">Đơn hàng <asp:Label ID="lblCountProduct" runat="server" /></h3>
                <asp:Repeater ID="rptCart" runat="server" OnItemDataBound="rptCart_ItemDataBound" OnItemCommand="rptCart_ItemCommand" >
                    <HeaderTemplate><ul class="listPr"></HeaderTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HiddenField runat="server" ID="hdfCartID" Value='<%# Eval("ID") %>' Visible="false" />
                            <div class="col image">
                                <span>
                                    <asp:Image runat="server" ID="imgAvartar" ImageUrl='<%# Eval("SmallPictureUrl")%>' alt='<%# Eval("Title") %>' />
                                </span>
                            </div>
                            <div class="col info">
                                <h3 class="name"><asp:HyperLink runat="server" ID="hplProduct" ToolTip='<%# Eval("Title") %>'><%# Zensoft.Website.Utils.SliptString(Eval("Title").ToString(), 50) %></asp:HyperLink></h3>
                                <span class="qty">
                                    <b>Số lượng:</b>
                                    <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("Quantity")%>' CssClass="inputText" />
                                </span>
                            </div>
                            <div class="col liquidate">
                                <span class="price">
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("UnitPrice").ToString())) %>' />
                                </span>
                                <span class="total">
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Zensoft.Website.Configuration.Helpers.PriceFormat(int.Parse(Eval("TotalItem").ToString())) %>' />
                                </span>
                                <span class="del">
                                    <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="/images/blue_delete_icon.png" AlternateText="Delete" ToolTip="Xóa sản phẩm này" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="if (confirm('Bạn thực sự muốn xóa sản phẩm này trong giỏ hàng?') == false) return false;" ></asp:ImageButton>
                                </span>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <span class="promotion">(Giảm giá <%=(Zensoft.Website.Configuration.AppConfiguration.PromotionOrder) %>% cho tất cả các đơn hàng trên website)</span>
                <h3 class="amountCart">Tạm tính:&nbsp;&nbsp;<asp:Label ID="lblGrossTotal" runat="server" /></h3>
                <h3 class="amountCart">Giảm giá:&nbsp;&nbsp;<asp:Label ID="lblPromotion" runat="server" /></h3>
                <h3 class="amountCart"><b>Thành tiền:&nbsp;&nbsp;<asp:Label ID="lblResult" runat="server" /></b></h3>
                <script type="text/javascript">GrossTotal(<%=float.Parse((Zensoft.Website.Configuration.AppConfiguration.PromotionOrder))/100 %>);</script>
                <h3 class="noteShip"><b>Quý khách lưu ý</b>: Giá trị hóa đơn trên chưa bao gồm chi phí ship hàng.</h3>
            </div>
            <div class="btnEndCart">
                <asp:LinkButton runat="server" ID="lbtnPay" ValidationGroup="EndCart" OnClick="lbtnPay_Click">Hoàn tất đơn hàng</asp:LinkButton>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlMss" CssClass="">
        <span>Chưa có sản phẩm nào trong giỏ hàng</span>
    </asp:Panel>
</asp:Content>


