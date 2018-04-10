var connection = new signalR.HubConnection('http://localhost:5000/values');
// Create a function that the hub can call to broadcast messages.
connection.on('Sendback', name => {
    console.log('from signalr', name);
});
// Start the connection.
connection.start().then(() => {
    console.log('got it');
});

$('#sendmessage').click(() => {
    const message = $('#message').val();
    connection.invoke('send', message);
});
