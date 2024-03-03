$(document).ready(function () {

    $("#btnSubmit").click(function (e) {
        debugger;
        var valData = $("#formLogin").serialize();
        $.ajax({
            url: "/Accounts/Login",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            type: "POST",
            contentType: "application /x-www-form-urlencoded;charset=utf-8",
            dataType: "JSON",
            data: valData,
            success: function (data) {
                console.log(data)
                window.location = "/Students/Index";
            },
            error: function (error) {
                alert(error)
            }
        });
    });
})