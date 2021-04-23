var ChatControl = function () {
    this.init = function () {
        loadData();
    }
    function RegisterEvent() {

    }
    
    function loadData() {
        $.ajax({
            url: '/Chat/GetAllChat',
            type: 'Get',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listchat = res.data;
                    var render = '';
                    $.each(listchat, function (i, item) {
                        render += '<li>' + item.userName + ' said ' + item.content + '+'+item.dateCreated+'</li>';
                    })
                    $('#messagesList').html(render);
                }
            }
        })
    }
    
}