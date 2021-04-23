var PageControl = function () {
    this.init = function () {
        loadData();
        RegisterEvent();
    }
    function FindPageById(id) {
        $.ajax({
            url: '/Admin/Page/FindPageById',
            type: 'Post',
            dataType: 'Json',
            data: {
                Id: id
            }, success: function (res) {
                if (res.status == true) {
                    var page = res.data;
                    $('#txtAlias').val(page.alias);
                    $('#txtDescM').val(page.decripstion);
                }
            }
        })
    }
    function RegisterEvent() {
        $('#txt-search-keyword').on('keyup', function () {
            var key = $('#txt-search-keyword').val();
            $('#tbl-content tr').filter(function () {
                $(this).toggle($(this).text().indexOf(key) > -1)
            });
        })
        $('#btn-create').off('click').on('click', function () {
            $('#modal-add-edit').modal('show');
            $('#btnSave').off('click').on('click', function () {
                var alias = $('#txtAlias').val();
                var desc = $('#txtDescM').val();
                $.ajax({
                    url: '/Admin/Page/CreatPage',
                    type: 'Post',
                    dataType: 'Json',
                    data: {
                        Alias: alias,
                        Decripstion: desc
                    }, success: function (res) {
                        alert('CreatSuccessfull');
                        loadData();
                        $('#modal-add-edit').modal('hide');
                    }
                })
            })
        })
        $('body').on('click', '.btn-edit', function () {
            var id = $(this).data('id');
            $('#modal-add-edit').modal('show');
            FindPageById(id);
            $('#btnSave').off('click').on('click', function () {
              var alias=  $('#txtAlias').val();
              var desc =  $('#txtDescM').val();
                $.ajax({
                    url: '/Admin/Page/CreatPage',
                    type: 'Post',
                    dataType: 'Json',
                    data: {
                        Id: id,
                        Alias: alias,
                        Decripstion: desc
                    }, success: function (res) {
                        alert('Updatesuccessfull');
                        loadData();
                        $('#modal-add-edit').modal('hide');
                    }
                })
            })
        })
        $('body').on('click', '.btn-delete', function () {
            var id = $(this).data('id');
            $.ajax({
                url: '/Admin/Page/DeletePage',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id
                }, success: function (res) {
                    alert('DeleteSuccess');
                    loadData();
                }
            })
        })
    }
    function loadData(isPageChanged) {
        $('#ddlshowpage').on('change', function () {
            tedu.configs.pageSize = $(this).val();
            tedu.configs.pageIndex = 1;
            loadData(true);
        });
        $.ajax({
            url: '/Admin/Page/GetAllPaging',
            type: 'Post',
            dataType: 'Json',
            data: {
                keyword: $('#txtKeyword').val(),
                pageIndex: tedu.configs.pageIndex,
                pageSize: tedu.configs.pageSize
            },
            success: function (response) {
                var listpage = response.items;
                var ren = '';
                var template = $('#table-template').html();
                $.each(listpage, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        Alias: item.alias,
                        Decripstion: item.decripstion
                    })
                })
                $('#tbl-content').html(ren);
                wrapPaging(response.totalRecords, function () {
                    loadData();
                }, isPageChanged);
            }
        })
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / tedu.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                tedu.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

}