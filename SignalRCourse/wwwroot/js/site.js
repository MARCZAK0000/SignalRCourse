$(document).ready(function (){
    var connectionCreateNotification = new signalR.HubConnectionBuilder()
        .withUrl("/hub/notification")
        .build();


    //Hooks to HubMethods
    connectionCreateNotification.on("SendNotification", (value) => {
        
        $("#notification-count").text(value.length);
    })

    connectionCreateNotification.on("InitNotification", (value) => {
        $("#notification-count").text(value.length);
    })


    //Send Methods
    function SendInfoAboutNotification(userID) {
        connectionCreateNotification.send("CreateNotification", userID)
    }

    function GetNotifications() {
        connectionCreateNotification.send("GetNotifications")
    }


    //Create Connection
    connectionCreateNotification.start()

    //Create Notification 
    $(document).on("click", "#createNotificationSubmit", function () {
        var title = $("#createNotificationName").val()
        var userId = $("#createNotificationSelect").val()
        var desc = $("#createNotificationDesc").val()

        const body = {
            accountID: userId,
            name: title,
            description: desc
        }
        $.ajax({
            url: "https://localhost:7031/api/notification",
            method: "POST",
            contentType: "application/json",
            dataType: "text",
            data: JSON.stringify(body),
            success(res) {
                console.log(res)
                SendInfoAboutNotification(userId)
            },

            error(err) {
                console.log(err)
            }
        })
    })


    //SignIn and init notification 
    $(document).on("click", "#loginSubmit", function () {


        const body = {
            login: $("#loginUserNameInput").val(),
            password: $("#loginPasswordInput").val()
        }
        $.ajax({
            url: "https://localhost:7031/account/signin",
            method: "POST",
            contentType: "application/json",
            dataType: "text",
            data: JSON.stringify(body),
            success(res) {
                console.log(res)
                GetNotifications();
            },

            error(err) {
                console.log(err)
            }
        })
    })

});