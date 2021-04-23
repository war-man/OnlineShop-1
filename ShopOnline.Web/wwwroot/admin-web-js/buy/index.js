var BuyControl = function () {
    this.init = function () {
        registerEvent();
    }
    function registerEvent() {
        $('#txtBuy').off('click').on('click', function () {
            var firstname = $('#first_name').val();
            var lastname = $('#last_name').val();
            var email = $('#email_address').val();
            var adress = $('#address').val();
            var radio = $('input[type="radio"]:checked');
            var payment = radio.val();
            $.ajax({
                url: '/Cart/AddOrder',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Adress: adress,
                    Paymnet: payment
                }, success: function (res) {
                    if (res.status == 1) {
                        window.location.href ="/Cart/BuySuccess"
                    }
                }
            })
        })
       
    }
}