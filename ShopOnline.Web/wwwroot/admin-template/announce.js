var Annnounce = function () {
    this.init = function () {
        LoadData();
        RegisterEvent();
    }
    function LoadData() {
        $.ajax({
            url: '/Annoucement/GetAllAnn',
            type: 'Get',
            dataType: 'Json',
            success: function (response) {
                var listUser = response;
                var render = '';
                var templates = $('#table-template-publicMessage').html();
                $.each(listUser, function (i, item) {
                    render += Mustache.render(templates, {
                        Id: item.id,
                        Name: item.userName,
                        Decripstion: item.deCripstion
                    })
                })
                $('#anount').html(render);
            }
        })
    }
    function RegisterEvent() {
        $('body').on('click','.btnDeleteAnn', function () {
            var id = $(this).data('id');
            $.ajax({
                url: '/Annoucement/DeleteAnn',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id
                }, success: function (res) {
                    if (res.status == true) {
                        LoadData();
                    }
                }
            })
        })
        $('#txtDeleteAllAnn').off('click').on('click', function () {
            $.ajax({
                url: '/Annoucement/DeleteAllAnn',
                type: 'Post',
                dataType: 'Json',
                success: function (res) {
                    if (res.status == true) {
                        LoadData();
                    }
                }
            })
        })
    }
  
}