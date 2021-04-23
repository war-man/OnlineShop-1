var UserControl = function () {
    this.init = function () {
        loadData();
        registerEvent();
    }
    var images = [];
    function registerEvent() {
        $("#btnSaveImages").off('click').on('click', function () {
            var imageList = [];
            $.each($('#image-list').find('img'), function (i, item) {
                imageList.push($(this).data('path'));
            });
            $.ajax({
                url: '/Admin/ImageUser/CreateImageUser',
                data: {
                    UserName: $('#hidId').val(),
                    Images: images
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#modal-image-manage').modal('hide');
                    $('#image-list').html('');
                    loadData();
                    loadImages();
                }
            });
        });
        $("#fileImage").on('change', function () {
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
                    images.push(path);
                    $('#image-list').append('<div class="col-md-3"><img width="100"  data-path="' + path + '" src="' + path + '"><a class="txtdeleteListImage">DeleteImage</a></div>');
                },

            });
        });
        $('body').on('click', '.btn-images', function () {
            var that = $(this).data('id');
            $('#hidId').val(that);
            loadImages();
            $('#modal-image-manage').modal('show');
        });
        $('#txt-search-keyword').on('keyup', function () {
            var value = $(this).val();
            $('#tbl-content tr').filter(function () {
                $(this).toggle($(this).text().indexOf(value) > -1)
            });
        })
        $('body').on('click', '.btn-delete', function () {
            var username = $(this).data('id');
            $.ajax({
                url: '/Admin/User/DeleteUserByUserName',
                type: 'Post',
                dataType: 'Json',
                data: {
                    UserName: username
                }, success: function (res) {
                    if (res.status == true) {
                        alert('Delete is successfull');
                        window.location.href='/Admin/User/Index'
                    }
                }
            })
        })
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtFullName: { required: true },
                txtUserName: { required: true },
                txtPassword: {
                    required: true,
                    minlength: 6
                },
                txtConfirmPassword: {
                    equalTo: "#txtPassword"
                },
                txtEmail: {
                    required: true,
                    email: true
                }
            }
        });
        $('#btn-create').off('click').on('click', function () {
            loadListRole();
            $('#modal-add-edit').modal('show');
            $('#btnSave').on('click', function (e) {
                if ($('#frmMaintainance').valid()) {
                    e.preventDefault();
                    var userName = $('#txtUserName').val();
                    var password = $('#txtPassword').val();
                    var email = $('#txtEmail').val();
                    var phoneNumber = $('#txtPhoneNumber').val();
                    var roles = [];
                    $.each($('#listrole tr'), function (i, item) {
                        if ($(item).find('input.txtCheckrole').first().prop('checked') == true) {
                            roles.push({
                                Name: $(item).find('input.txtCheckrole').first().val()
                            })
                        }
                    })
                    $.ajax({
                        url: '/Admin/User/Register',
                        type: 'Post',
                        dataType: 'Json',
                        data: {
                            UserName: userName,
                            Password: password,
                            PhoneNumber: phoneNumber,
                            Email: email,
                            Value: JSON.stringify(roles)
                        }, success: function (res) {
                            if (res.status == true) {
                               
                                $('#modal-add-edit').modal('hide');
                                loadData();
                                
                            }
                        }

                    })
                }
                return false;
            });
        })
        $('body').on('click', '.btn-edit', function () {
            var id = $(this).data('id');
            $('#hidId').val(id);
            var username = $(this).data('id');
            loadlistRoleUpdate();
            loadUserByName(username);
            $('#modaledit').modal('show');
            $('#btnSaveUpdate').off('click').on('click', function () {
                var usernow = $('#txtUserNameUpdate').val();
                var email = $('#txtEmailUpdate').val();
                var phone = $('#txtPhoneNumberUpdate').val();
                var ren = [];
                $.each($('#listroleupdate tr'), function (i, item) {
                    ren.push({
                        Name: $(item).find('input.txtCheckroleUpdate').val()
                    })
                })
                $.ajax({
                    url: '/Admin/User/UpdateUser',
                    type: 'Post',
                    dataType: 'Json',
                    data: {
                        UserLast: username,
                        UserNow: usernow,
                        Email: email,
                        PhoneNumber: phone,
                        Value: JSON.stringify(ren)
                    }, success: function (res) {
                        if (res.status == true) {
                            alert('Update Is successfull');
                            window.loca.href="/Admin/User/Index"
                        }
                    }
                })
            })

        })
    }
    function loadImages() {

        $.ajax({
            url: '/Admin/ImageUser/GetListProductImageByUserName',
            data: {
                UserName: $('#hidId').val()
            },
            type: 'Post',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var listproductImage = res.data;
                    var render = '';
                    $.each(listproductImage, function (i, item) {
                        render += '<div class="col-md-3"><img width="100" src="' + item.pathImage + '"><br/><a class="btn-delete-image" data-id="' + item.id + '">Xóa</a></div>'
                    });
                    $('#image-list').html(render);
                }
            }
        });
    }
    
    function loadUserByName(userName) {
        $.ajax({
            url: '/Admin/User/GetListRoleOfUserByUserName',
            type: 'Post',
            dataType: 'Json',
            data: {
                UserName: userName
            },
            success: function (res) {
                if (res.status == true) {
                    var user = res.data1;
                    var roleofUser = res.data;
                    $('#txtUserNameUpdate').val(user.userName);
                    $('#txtEmailUpdate').val(user.email);
                    $('#txtPhoneNumberUpdate').val(user.phoneNumber);
                    $.each($('#listroleupdate tr'), function (i, item) {
                        var name = $(item).find('input.txtCheckroleUpdate').first().val();
                        $.each(roleofUser, function (j, jtem) {
                            var nameTest = jtem;
                            if (jtem === name) {
                                $(item).find('input.txtCheckroleUpdate').prop('checked', true)
                            }
                        })
                    })
                }
            }
        })
    }
    function loadlistRoleUpdate() {
        $.ajax({
            url: '/Admin/Role/GetAllRole',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listrole = res.data;
                    var template = $('#role-template-update').html();
                    var ren = '';
                    $.each(listrole, function (i, item) {
                        ren += Mustache.render(template, {
                            Name: item.name,
                            Checked: ''
                        })
                        $('#listroleupdate').html(ren);
                    })
                }
            }
        })
    }
    function loadData(isPageChanged) {
        $('#ddlshowpage').on('change', function () {
            tedu.configs.pageSize = $(this).val();
            tedu.configs.pageIndex = 1;
            loadData(true);
        });
        $.ajax({
            url: '/Admin/User/GetAllUserPaging',
            type: 'Post',
            dataType: 'Json',
            data: {
                keyword: $('#txtKeyword').val(),
                pageIndex: tedu.configs.pageIndex,
                pageSize: tedu.configs.pageSize
            },
            success: function (response) {
                var listUser = response.items;
                var ren = '';
                var template = $('#table-template').html();
                $.each(listUser, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        UserName: item.userName,
                        PhoneNumber: item.phoneNumber,
                        Email: item.email
                    })
                })
                $('#tbl-content').html(ren);
                wrapPaging(response.totalRecords, function () {
                    loadData();
                }, isPageChanged);
            }
        })
    }
    function loadListRole() {
        $.ajax({
            url: '/Admin/Role/GetAllRole',
            type: 'Post',
            dataType: 'Json',
            success: function (res) {
                if (res.status == true) {
                    var listrole = res.data;
                    var template = $('#role-template').html();
                    var ren = '';
                    $.each(listrole, function (i, item) {
                        ren += Mustache.render(template, {
                            Name: item.name,
                            Checked: ''
                        })
                        $('#listrole').html(ren);
                    })
                }
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