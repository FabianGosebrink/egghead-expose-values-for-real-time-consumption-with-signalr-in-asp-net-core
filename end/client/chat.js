let url = 'https://localhost:5001/';
let apiUrl = `${url}api/`;
let signalrUrl = `${url}messages/`;
let postUrl = `${apiUrl}weatherforecast/`;

let connection = new signalR.HubConnectionBuilder()
  .withUrl(signalrUrl)
  .configureLogging(signalR.LogLevel.Information)
  .build();

connection.on('Sendback', message => {
  console.log('from signalr', message);
  $('#items').append(`<li>${message}</li>`);
});

connection.on('itemReceived', item => {
  alert(`received ${item}`);
});

connection.start().then(() => {
  console.log('connection established');
});

$('#sendmessage').click(() => {
  const message = $('#message').val();
  connection.invoke('sendmessage', message);
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
