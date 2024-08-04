$(document).ready(function (){
    var connectionChat = new signalR.HubConnectionBuilder()
        .withUrl("/hub/chatbot")
        .build();

    connectionChat.on("connectToChat", (value) => {
        console.log(`Write user id: ${value}`);
        $("circle").each(function () {
            console.log($(this).attr("title"))
            if (value.includes($(this).attr("title"))){
                $(this).css('fill', 'green')
            }
        })
        
    })


    connectionChat.start().then(GetConnectedUser, Rejected)

    function GetConnectedUser() {
        connectionChat.send("GetConnectedUsers");
    }

    function Rejected(err) {
        console.log(err)
    }


   



})