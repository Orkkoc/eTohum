var Index = function () {
    return {
        //main function to initiate the module
        init: function () {
            $('#submitForm').off("click").on("click", function (){                
                setBsUser();
            };

            sendMails();
        }
    }
}
//Set BsUser Method with index form data
var setBsUser = function () {
    // Gather Form Info
    var name = $('#Name').val();
    var surName = $('#SurName').val();
    var emailUser = $('#emailUser').val();
    var emailGuest = $('#emailGuest').val();

    // Prepare Controller Variable
    var bsUserDetail = {
        Name: name,
        SurName: surName,
        EmailUser: emailUser,
        EmailGuest: emailGuest,
    };
    var bsUser = JSON.stringify(bsUserDetail, null, 2);
    // Initilize Ajax
    $.ajax({
        url: '/Home/SetBsUser',
        data: { 'bsUser': bsUser },
        success: function (data) {
            if (data.Result) {
                alert('İşlem Başarılı');


            } else {

                if (data.ErrorType == window.LoginOff) {
                    UserLogOut(data.ErrorMessage);
                }
            }
        },
        error: function (data) {

        },
        dataType: 'json'
    });
}

var sendMails = function () {
    //initialize Sending Emails with definite intervals.
}