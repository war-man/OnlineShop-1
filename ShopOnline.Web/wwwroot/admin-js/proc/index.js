var ProcControl = new function () {
    this.init = function () {
        RegisterEvent();
    }
    function RegisterEvent() {
        $.ajax({
            url:'/'
        })
    }
}