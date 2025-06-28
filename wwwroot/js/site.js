$(document).ready(function () { 
    var token = $('input[name="__RequestVerificationToken"]').val();

    $.ajaxSetup({
        headers: {
            'RequestVerificationToken': token
        }
    });
});