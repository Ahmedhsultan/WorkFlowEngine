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

                GetRequests(outhUserName)
                GetTasks(outhUserName)
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
    $(`#drop`).on('click', `#Card`, function () {
        let parent = $(this);
        jQuery.ajax({
            url: 'api/GenerateGUID',
            success: function (newGUID) {
                $('#propertiestool').removeAttr('hidden');
                let guid = newGUID;
                let form = $('#propertiestool').children(`#Form`).val();
                let outhuser = $('#propertiestool').children(`#OuthUser`).val();
                parent.children('.card-body').children('#Guid').text(`${guid}`);
                parent.children('.card-body').children('#OuthUserName').text(`${outhuser}`);
                parent.children('.card-body').children('#FormName').text(`${form}`);
            }
        });
    });                        //ok

    //Save Digram
    $('#Save').click(function () {
        let htmlProcessCard = $("#drop").find("#Card");

        let processList = [];

        $.each(htmlProcessCard, function (i, value) {
            let guid = htmlProcessCard[i].children[1].children[0].textContent;
            let nextguid = "00000000-0000-0000-0000-000000000000";
            if (i < (htmlProcessCard.length-1))
                nextguid = htmlProcessCard[i+1].children[1].children[0].textContent;
            let OuthUserName = htmlProcessCard[i].children[1].children[1].textContent;
            let FormName = htmlProcessCard[i].children[1].children[2].textContent;

            let process = { processId: guid, form: FormName, usersOthenticated: [OuthUserName], nextProcessIdNo1: nextguid };
            processList.push(process);
        });

        $.ajax({
            type: "Post",
            url: 'api/Process/CreateDigram',
            headers: {
                'Content-Type': 'application/json',
            },
            data: JSON.stringify({
                userName: outhUserName,
                digramName: 'accc',
                adminUserName: [outhUserName],
                initiateUserName: [outhUserName],
                ProcessList: processList
            }),
            success: function (response) {
                console.log(response);
            }
        });
    });                     //ok

    
});

//Functions-------------------------------------------------------------------------------------------------------------------------------------------
//Get Requests
function GetRequests(userName) {
    jQuery.ajax({
        url: 'api/Requests/GetAvilableRequests',
        data: { "userName": userName },
        success: function (respose1) {
            for (var i = 0; i < respose1.length; i++) {
                $("#Requests").append(`<button class=" btn btn-lg btn-primary" type="button" id="request${i}">Start Requests</button>`);

                //Start Request
                let startProcessGUID = respose1[i]["startProcessesId"]
                $(`#Requests`).on('click', `#request${i}`, function () {
                    $.ajax({
                        type: "Post",
                        url: 'api/Tasks/CreateTasks',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        data: JSON.stringify({
                            userName: userName,
                            PreviusProcessGUID: startProcessGUID
                        }),
                        success: function (response) {

                        }
                    });
                })
            }
        }
    });
}
//Get Tasks
function GetTasks(userName) {
    jQuery.ajax({
        url: 'api/Tasks/GetAvilableTasks',
        data: { "userName": userName },
        success: function (respose1) {
            for (var i = 0; i < respose1.length; i++) {
                $("#Tasks").append(`<button class=" btn btn-lg btn-primary" type="button" id="Tasks${i}">Approve Task</button>`);

                //Submit Task
                let taskId = respose1[i]["taskId"]
                $(`#Tasks`).on('click', `#Tasks${i}`, function () {
                    $.ajax({
                        type: "Post",
                        url: 'api/Tasks/SubmitTasks',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        data: JSON.stringify({
                            taskGUID: taskId
                        }),
                        success: function (response) {

                        }
                    });
                })
            }
        }
    });
}