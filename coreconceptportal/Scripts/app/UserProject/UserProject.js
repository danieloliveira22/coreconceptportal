var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];


$('#drag').draggable(function () {

    alert("");
});





$("#projectsList").on('change', function () {

    var id = $(this).val();

    console.log(id);

 
        $.ajax({
            type: 'GET',
            data: { ProjectId : id },
            url: 'UserProject/getUsersProjectAsso',
            cache: false,
            success: function (data) {
                //var userId = JSON.parse(data);
               
              
                data = JSON.parse(data);
                console.log(data);




                //$.each(data, function (i, obj) {

                //    utilizadoresId.push(obj.usersId);
                //})
                //var index = 0;
                //$.each(data, function () {
                //    idsUser.push(data[index].userId);
                //    index++;
                //})

              
                //var idsUser = [];
             

                //console.log(idsUser);
                //$.ajax({
                //    type: 'GET',
                //    data: { data: userId },
                //    url: 'UserProject/getUsersbyId',
                //    cache: false,
                //    success: function (data) {
                //        userNames = JSON.parse(data);
                //    }
                //})


                //$.each(json, function () {
                //    $.each(this, function (name, value) {
                //        console.log(name + '=' + value);
                //    });

                //});
            
            }
        });



});