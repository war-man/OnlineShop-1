var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();
connection.start().catch(err => console.error(err.toString()));
connection.on("ReceiveMessage", (message) => {
    console.log(message);
    var template = $('#table-template-publicMessage').html();
    var ren = '';
    ren = Mustache.render(template, {
        Name: message.userName,
        Decripstion:message.deCripstion
    })
    var totalAnnounce = parseInt($('.txtTotal').text()) + 1;
    $('.txtTotal').text(totalAnnounce);
    $('#anount').prepend(ren);
});


