var SlideControl = function () {
    this.init = function () {
        loadData();
        registerEvent();
    }
    function registerEvent() {
        $('#btnSelectImg').on('click', function () { // image Manager
            $('#fileInputImage').click();
        }); // Image Manager

        $("#fileInputImage").on('change', function () { // image Manager
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImage').val(path);
                    $('#txtUpadateImageTest').html('<div  class="col-md-3"><img src="' + path + '" alt="" width="100" height="100"></div>')
                },

            });
        });  
        $('#btnSave').off('click').on('click', function () {
            var id = $('#hidIdM').val();
            var name = $('#txtNameM').val();
            var decripstion = $('#txtDescM').val();
            var pathImage = $('#txtImage').val();
            $.ajax({
                url: '/Admin/Slide/CreatSlide',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id,
                    Name: name,
                    Decripstion: decripstion,
                    PathImage: pathImage
                },
                success: function (res) {
                    if (res.status == true) {
                        if (id > 0) {
                            alert('Update is successfull');
                            $('#modal-add-edit').modal('hide');
                            loadData()
                        }
                        else {
                            alert('Create is successfull');
                            $('#modal-add-edit').modal('hide');
                            loadData()
                        }
                    }
                }
            })
        })
        $('#btn-create').off('click').on('click', function () {
            $('#txtNameM').val(null);
            $('#txtDescM').val(null);
            $('#txtImage').val(null);
            $('#modal-add-edit').modal('show');
        })
        $('body').on('click', '.btn-edit', function () {
            var id = $(this).data('id');
            $('#hidIdM').val(id);
            $('#modal-add-edit').modal('show');
        })
      
    }
    function loadData() {
        $.ajax({
            type: "Post",
            url: "/Admin/Slide/GetAllSlide",
              
            dataType: "json",
            success: function (response) {
                var listslide = response.data;
                var template = $('#table-template').html();
                var ren = '';
                $.each(listslide, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        Name: item.name,
                        PathImage: '<img src="' + item.pathImage +'" alt="Girl in a jacket" width="100" height="100">' 
                    })
                })
                $('#tbl-content').html(ren);
            },
        });
    }
}