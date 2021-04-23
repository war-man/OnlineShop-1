var CartControl = function () {
    var cateObj = {
        colors: [],
        sizes:[]
    }
    this.init = function () {
        loadListColor();
        loadListSize();
        loadData();
        registerEvent();
    }
    
    function registerEvent() {
        $('#txtCheckProceed').off('click').on('click', function () {
            window.location.href="/Cart/Checked"
        })
        
        $('body').on('click', '.txtplush', function () {
            var listId = $(this).data('id');
            $.ajax({
                url: '/Cart/AddCartUpdate',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Value: JSON.stringify(listId)
                }, success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index"
                    }
                }
            })
        })
        $('body').on('click', '.txtmin', function () {
            var listId = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveCartUpdate',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Value: JSON.stringify(listId)
                }, success: function (res) {
                    if (res.status == true) {
                        window.location.href="/Cart/Index"
                    }
                }
            })
        })
        $('body').on('click', '.txtDelete', function () {
            var items = $(this).closest('tr');
            var ren = [];
            ren.push({
                ProductId: $(this).data('id'),
                ColorId: items.find('td select.txtddlColor').first().val(),
                SizeId: items.find('td select.txtddlSize').first().val(),
            });
            $.ajax({
                url: '/Cart/DeleteCart',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Value: JSON.stringify(ren)
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Xóa thành công');
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        })
        $('.updatecarrtproduct').off('click').on('click', function () {
            var ren = [];
            $.each($('#txtListCart tr'), function (i, item) {
                ren.push({
                    ProductId: $(this).data('id'),
                    ColorId: $(item).find('td select.txtddlColor').first().val(),
                    SizeId: $(item).find('td select.txtddlSize').first().val(),
                    LastColorId: $(item).find('td input.txtLastColorId').first().val(),
                    LastSizeId: $(item).find('td input.txtLastSizeId').first().val(),
                });

            });
            $.ajax({
                url: '/Cart/UpdateCart',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Value: JSON.stringify(ren)
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Cập nhập thành công');
                        window.location.href = "/Cart/Index"
                    }
                }
            })
        })
       
        $('.continue-shopping').off('click').on('click', function () {
            window.location.href="/Home/Index"
        })
         $('.btn-cart').off('click').on('click', function () {
            var ProductId = $(this).data('id');
            var ColorId = $('#txtSelectListColor').val();
            var SizeId = $('#txtSelectListSize').val();
            var Quantity = $('#qty').val();
            $.ajax({
                url: '/Cart/AddCart',
                type: 'Post',
                dataType: 'Json',
                data: {
                    productId: ProductId,
                    colorId: ColorId,
                    sizeId: SizeId,
                    quantity: Quantity
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Thêm vào giỏ hàng thành công');
                        window.location.href="/Cart/Index"
                    }
                }
            })
        })
    }
    function loadData() {
        $.ajax({
            url: '/Cart/GetAllCart',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var list = res.data;
                    var listcart = list.items;
                    var ren = '';
                    var template = $('#table-template-listcart').html();
                    $.each(listcart, function (i, item) {
                        ren += Mustache.render(template, {
                            Id: item.productViewModel.id,
                            PathImage: item.productViewModel.pathImage,
                            Decripstion: item.productViewModel.decripstion,
                            LastColorId: item.colorId,
                            LastSizeId: item.sizeId,
                            Color: getddlProductColor(item.colorId),
                            Size: getddlProductSize(item.sizeId),
                            LastPrice: item.lastPrice,
                            Quantity: item.quantity,
                        })
                    })
                    $('#txtListCart').html(ren);
                }
            }
        })
    }
    function loadListColor() {
        $.ajax({
            url: '/Admin/Product/GetListProductColor',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listcolor = res.data;
                    cateObj.colors = listcolor;
                }
            }
        })
    }
    function loadListSize() {
        $.ajax({
            url: '/Admin/Product/GetListProductSize',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listsizes = res.data;
                    cateObj.sizes = listsizes;
                }
            }
        })
    }
    function getddlProductColor(id) {
        var ren = '<select class="txtddlColor">';
        if (id > 0) {
            $.each(cateObj.colors, function (i, item) {
                if (item.id === id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
            $.each(cateObj.colors, function (i, item) {
                if (item.id !== id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
        }
        else {
            $.each(cateObj.colors, function (i, item) {
                ren += '<option value="' + item.id + '">' + item.name + '</option>'
            })
        }
        ren += '</select>';
        return ren;
    }
    function getddlProductSize(id) {
        var ren = '<select class="txtddlSize">';
        if (id > 0) {
            $.each(cateObj.sizes, function (i, item) {
                if (item.id === id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }

            })
            $.each(cateObj.sizes, function (i, item) {
                if (item.id !== id) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
                }
            })
        }
        else {
            $.each(cateObj.sizes, function (i, item) {
                    ren += '<option value="' + item.id + '">' + item.name + '</option>'
              
            })
        }
       
        ren += '</select>';
        return ren;
    }
}