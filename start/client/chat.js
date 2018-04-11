let url = 'http://localhost:5000/';
let apiUrl = `${url}api/`;
let signalrUrl = `${url}messages/`;
let postUrl = `${apiUrl}values/`;

let connection = new signalR.HubConnection(signalrUrl);

connection.on('Sendback', message => {
    console.log('from signalr', message);
    $('#items').append(`<li>${message}</li>`);
});

connection.on('itemReceived', item => {
    alert(`received ${item}`);
});

connection.start().then(() => {
    console.log('got it');
});

$('#sendmessage').click(() => {
    const message = $('#message').val();
    connection.invoke('send', message);
    $('#message').val('');
});

$('#postMessage').click(() => {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: postUrl,
        data: JSON.stringify('Hello')
    });
});
