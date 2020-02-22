$(function () {
    var getUrl = window.location;
    var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];

    
   
    $('#projectsList').select2({
        tags: true
    });

  
    $("#projectsList").on('change', function () {

        var id = $(this).val();

        console.log(id);

        $.ajax({
            type: 'GET',
            data: { ProjectId: id },
            url: 'UserProject/usersAssociated',
            cache: false,
            success: function (data) {

                console.log(data.userAssociatedViewModel);

                //utilizar o metodo do javascript "html" para intrepertar o html 
                $("#usersdiv").html(data.html);

                var assoUsersId = [];
                var nonAssoUsersId = [];
                $("#assoUsers ul li").each(function (index) {

                    assoUsersId.push($(this).val());

                });

                $("#notAssoUsers ul li").each(function (index) {

                    nonAssoUsersId.push($(this).val());

                });
                console.log("Associados: " + assoUsersId);
                console.log("Nao Associados: " + nonAssoUsersId);


                $("#saveUsers").click(function () {

                    var assoUsersIdsAfter = [];
                    var nonAssoUsersIdAfter = [];

                    $("#assoUsers ul li").each(function (index) {
                        assoUsersIdsAfter.push($(this).val());
                    });

                    $("#notAssoUsers ul li").each(function (index) {
                        nonAssoUsersIdAfter.push($(this).val());
                    });

                    console.log("Associados: " + assoUsersIdsAfter);
                    console.log("Nao Associados: " + nonAssoUsersIdAfter);

                    var projectId = $("#projectsList").val();

                    var assoUsersIdFinal = assoUsersIdsAfter.filter(function (item) {
                        return !assoUsersId.includes(item);
                    });

                    var nonAssoUsersIdFinal = nonAssoUsersIdAfter.filter(function (item) {
                        return !nonAssoUsersId.includes(item);
                    });

                    console.log("Utilizadores para adicionar: " + assoUsersIdFinal);
                    console.log("Utilizadores para remover: " + nonAssoUsersIdFinal);
                    $.ajax({
                        type: 'POST',
                        data: {
                            'assoUsersIdFinal': assoUsersIdFinal,
                            'nonAssoUsersIdFinal': nonAssoUsersIdFinal,
                            'ProjectId': projectId,
                        },
                        url: '/UserProject/saveUsersAsso',
                        cache: false,
                        success: function (data) {


                                Swal.fire({
                                    position: 'center',
                                    type: 'success',
                                    title: 'Funcionários adicionados com sucesso!',
                                    showConfirmButton: false,
                                    timer: 1500
                                })
                            
                        }

                    });
                    //var idsAssociated = $("#assoUsers ul li").val();

                    //console.log("OHHH CARLAHO " + idsAssociated);

                });


                //if (data.status == 200) {
                //    $("#formUser").html(data.html);
                //} else {
                //    alert("erro");
                //} 

            }


        });



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
    });





});


