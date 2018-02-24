
function FormatMoney(n) {
    return n.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
}

$(document).ready(function intGross() {
    $("[id*=rptCart]input[type=text][id*=txtQty]").numeric(
        { decimal: false, negative: false },
        function () {
            alert("Số lượng hàng không phù hợp.");
            this.value = "";
            this.focus();
        });

    $("[id*=rptCart]input[type=text][id*=txtQty]").keyup(function (e) {
        var price = $(this).closest('li').find("[id*=lblPrice]").text().split('.').join('');
        price.replace("đ", "");
        var quantity = $(e.target).closest('li').find("input[type=text][id*=txtQty]").val();

        if (quantity > 20) {
            alert("Số lượng hàng lớn quý khách vui lòng liên hệ trực tiếp với chúng tôi. Xin cảm ơn!");
            this.focus();
            return;
        }
        if (quantity < 1) {
            return false;
        }

        var total = parseFloat(quantity) * parseFloat(price);
        $(e.target).closest('li').find("[id*=lblTotal]").text(FormatMoney(parseFloat(total)) + " đ");

        GrossTotal();
    });

    $("[id*=txtCusName]").keyup(function (e) {
        var cusName = $(e.target).closest('li').find("[id*=txtCusName]").val();
        $("[id*=lblCusName]").text(cusName);
    });

    $("[id*=txtCusMobile]").keyup(function (e) {
        var cusMobile = $(e.target).closest('li').find("[id*=txtCusMobile]").val();
        $("[id*=lblCusMobile]").text(cusMobile);
    });

    $("[id*=txtCusEmail]").keyup(function (e) {
        var cusEmail = $(e.target).closest('li').find("[id*=txtCusEmail]").val();
        $("[id*=lblCusEmail]").text(cusEmail);
    });

    $("[id*=txtCusAddress]").keyup(function (e) {
        var cusAddress = $(e.target).closest('li').find("[id*=txtCusAddress]").val();
        $("[id*=lblCusAddress]").text(cusAddress);
    });

    $('#editInfoShip').click(function (e) {
        $('input[type=text][id*=_shipName]').text($(e.target).closest('li').find('[id*=lblCusName]').val());
        $('input[type=text][id*=_shipMobile]').text($(e.target).closest('li').find('[id*=lblCusMobile]').val());
        $('input[type=text][id*=_shipEmail]').text($(e.target).closest('li').find('[id*=lblCusEmail]').val());
        $('input[type=text][id*=_shipAddress]').text($(e.target).closest('li').find('[id*=lblCusAddress]').val());
    });

    $('#submit').click(function () {
        alert('submitting');
        $('#formfield').submit();
    });
});

var gross;
var promotion;
var result;

function GrossTotal(sale) {
    gross = 0;
    $("[id*=rptCart][id*=lblTotal]").each(function (index, item) {
        $(item).text().replace("đ", "");
        gross = gross + parseFloat($(item).text().split('.').join(''));
        promotion = gross * sale;
        result = gross - promotion;
    });

    $("[id*=lblGrossTotal]").text(FormatMoney(parseFloat(gross)) + " đ");
    $("[id*=lblPromotion]").text("-" + FormatMoney(parseFloat(promotion)) + " đ");
    $("[id*=lblResult]").text(FormatMoney(parseFloat(result)) + " đ");
}

intGross();