var RoomControl = function () {
    this.init = function () {
        RegisterEvent();
    }
    function RegisterEvent() {
        $('#txtCreateRoom').off('click').on('click', function () {
            $('#txtModalCreateRoom').modal('show');
            var id = $('#txtId').val();
            $('#txtsaveCreate').off('click').on('click', function () {
                $.ajax({
                    url: '/Chat/CreateRoom',
                    type: 'Get',
                    dataType: 'Json',
                    data: {
                        Id: id
                    }, success: function (res) {
                        if (res.status == true) {
                            alert('Create Id Room successfull')
                        }
                    }
                })
            })
        })
        $('#txtsave').off('click').on('click', function () {
            var id = $('#txtRoomInput').val();
            $.ajax({
                url: '/Chat/ConfirmRoom/' + id,
                type: 'Get',
                dataType: 'Json',
                success: function (res) {
                    if (res.status == true) {
                        
                    }
                }
            })
        })
    }
    
}