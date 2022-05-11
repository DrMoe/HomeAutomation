"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/eventHub").build();

connection.on("DeviceEvent", function (device, value) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${device} says ${value}`;
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});