//var getUrl = window.location;
//var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];

//$(document).ready(function () {
//    $("#newUserForm").on("click", function (e) {
//        e.preventDefault();
//        var teste = "teste1";
//        $.ajax({
//            type: 'GET',
//            data: { teste },
//            url: '/Home/newUser',
//            cache: false,
//            success: function (data) {
//                if (data.status == 200) {
//                    $("#formUser").html(data.html);
//                } else {
//                    alert("erro");
//                } 
//            }
//        });
//    });
//});

$(".navButton.button1").mouseenter(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(10deg)',
        '-ms - transform:': 'rotate(10deg)',
        'transform': 'rotate(10deg)',
        'transition': '.4s'
    });

});
$(".navButton.button1").mouseleave(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(0deg)',
        '-ms - transform:': 'rotate(0deg)',
        'transform': 'rotate(0deg)'
    });

});

$(".navButton.button2").mouseenter(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(20deg)',
        '-ms - transform:': 'rotate(20deg)',
        'transform': 'rotate(20deg)',
        'transition': '.4s'
    });

});
$(".navButton.button2").mouseleave(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(0deg)',
        '-ms - transform:': 'rotate(0deg)',
        'transform': 'rotate(0deg)'
    });

});

$(".navButton.button3").mouseenter(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(10deg)',
        '-ms - transform:': 'rotate(10deg)',
        'transform': 'rotate(10deg)',
        'transition': '.4s'
    });

});
$(".navButton.button3").mouseleave(function () {
    var navButton = $(this).parent();
    $(navButton).find("i").css({
        '-webkit - transform': 'rotate(0deg)',
        '-ms - transform:': 'rotate(0deg)',
        'transform': 'rotate(0deg)'
    });

});


//    .mouseleave(function () {
//    $(this).css("background", "00F").css("border-radius", "0px");
//});