$(document).ready(function () {
    $("#currenViewCounter").text("10");
    var connectionUserCount = new signalR.HubConnectionBuilder()
        .withUrl("/hub/userhub")
        .build();

    connectionUserCount.on("updateTotalView", (value) => {
        $("#totalViewCounter").text(value);
    })

    connectionUserCount.on("updateCurrentUser", (value) => {
        console.log("updated")
        $("#currenViewCounter").text(value);
    })

    function newWindowLoadedOnClient() {
        connectionUserCount.send("JoinPage")
    }
    function fullfill() {
        console.log("We did it");
        newWindowLoadedOnClient();
    }

    function rejected() {
        console.log("error")
    }
    connectionUserCount.start().then(fullfill, rejected);
});


    