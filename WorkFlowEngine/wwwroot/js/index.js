$(document).ready(function () {
    let outhUserName;

    //On Register
    $('#Register').click(function () {
        let userName = $('#Register-UserName').val();
        let password = $('#Register-Password').val();
        
        $.ajax({
            type: "Post",
            url: 'api/Account/Register',
            headers: {
                'Content-Type': 'application/json',
            },
            data: JSON.stringify({
                fullName: "string",
                userName: userName,
                password: password,
                Gender:0
            }),
            success: function (response) {
                console.log(response);
            }
          });
    });                 //ok

    //On Login
    $('#Login').click(function () {
        let userName = $('#Login-UserName').val();
        let password = $('#Login-Password').val();

        $.ajax({
            type: "Post",
            url: 'api/Account/Login',
            headers: {
                'Content-Type': 'application/json',
            },
            data: JSON.stringify({
                userName: userName,
                Password: password
            }),
            success: function (response) {
                outhUserName = userName;
                $('#workFlow').removeAttr('hidden');
                console.log(response);
                //get requests
            }
        });
    });                    //ok

    //Drage Element
    $(".draggable").draggable({
        appendTo: '#drop',
        cursor: "move",
        helper: "clone",
        revert: true,
        revertDuration: 0
    });            //ok
    $(".droppable").droppable({
        tolerance: 'pointer',
        drop: function (event, ui) {
            $(this).append(ui.draggable.clone());
        },
    });

    //Edit Tast Porperties
    $(`#drop`).on('click', `#Card`,function () {
        $('#propertiestool').removeAttr('hidden');
        let guid = $('#propertiestool').children(`#Guid`).val();
        let form = $('#propertiestool').children(`#Form`).val();
        let outhuser = $('#propertiestool').children(`#OuthUser`).val();
        $(this).children('.card-body').children('#properties').text(`Guid:[${guid}],Outh UserName:[${outhuser}],Form Name:[${form}]`);
    });                        //ok

    //Save Digram
    $('#Save').click(function () {
        for (var i = 0; i < 10; i++) {

        }

        $.ajax({
            type: "Post",
            url: 'api/Process/CreateDigram',
            headers: {
                'Content-Type': 'application/json',
            },
            data: JSON.stringify({
                userName: outhUserName,
                digramName: "acc",
                outhUserName: outhUserName,
                ProcessList: {
                    processId: "",
                    form:"",
                    usersOthenticated: {
                        0:''
                    },
                    nextProcessIdNo1:""
                }
            }),
            success: function (response) {
                console.log(response);
            }
        });
    });                     //pending
});
