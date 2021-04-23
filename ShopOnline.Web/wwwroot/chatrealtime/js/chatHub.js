var connection = new signalR.HubConnectionBuilder().withUrl("/hubUser").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ConnectRecievemessage", function (user, message) {
    var ren = '';
    ren = '<li>' + user + ' said ' + message + '</li>';
    $('#messagesList').append(ren);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

$('#sendButton').off('click').on('click', function () {
    var user = $('#userInput').val();
    var message = $('#messageInput').val();
    $.ajax({
        url: '/Chat/CreateChat',
        type: 'Post',
        dataType: 'Json',
        data: {
            UserName: user,
            Content: message
        }, success: function (res) {
            if (res.status == true) {
                
            }
        }
    })
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
   
})

