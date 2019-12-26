var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];

$(document).ready(function () {
    $("#newUserForm").on("click", function (e) {
        e.preventDefault();
        var teste = "teste1";
        $.ajax({
            type: 'GET',
            data: { teste },
            url: '/Home/newUser',
            cache: false,
            success: function (data) {
                if (data.status == 200) {
                    $("#formUser").html(data.html);
                } else {
                    alert("erro");
                } 
            }
        });
    });
});