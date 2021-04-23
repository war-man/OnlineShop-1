var LanguageControl = function () {
    this.init = function () {
        RegisterEvent();
    }
    function RegisterEvent() {
        $('#ddlListLanguage').on('change', function () {
            var Id = $(this).val();
            $.ajax({
                url: '/Admin/Home/Index',
                type: 'Post',
                dataType: 'Json',
                data: {
                    LanguageId: Id
                }, success: function (res) {
                    if (res.status == true) {

                    }
                }
            })
        })
    }
    
}