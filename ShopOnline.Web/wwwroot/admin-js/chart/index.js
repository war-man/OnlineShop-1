var ChartControl = function () {
    this.init = function () {
        loadData();
    }
    function registerEvent() {

    }
    function loadData() {
        $.ajax({
            url: '/Admin/Chart/StoreChart',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var list = res.data;
                    var ren = '';
                    var template = $('#table-template').html();
                    $.each(list, function (i, item) {
                        ren += Mustache.render(template, {
                            Time: item.date,
                            Revent: item.revent,
                            Profit: item.profit
                        });
                        
                    })
                    $('#txtbody').html(ren);
                }
            }
        })
    }
}