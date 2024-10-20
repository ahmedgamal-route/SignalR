
document.addEventListener('DOMContentLoaded', function () {
 
    var notifyMessage = document.getElementById("notificationdiv");



    var proxyConnection = new signalR.HubConnectionBuilder()
        .withUrl("/notifyHub")
        .build();

    proxyConnection.start()
        .then(() => {
            console.log("Connection started");

        })
        .catch(err => console.error("Connection error: ", err));



    proxyConnection.on("ReceiveNotification", function (message) {
        notifyMessage.innerHTML = `<strong> ${message} </strong>`;
    })



});