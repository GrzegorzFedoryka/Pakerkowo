$(document).ready(function () {
    $("#loginForm").submit(function (e) {
        e.preventDefault();

        var data = JSON.stringify($(loginForm).serializeArray().reduce(function (obj, item) {
            obj[item.name] = item.value;
            return obj;
        }, {}
        ));

        console.log(data);

        $.ajax({
            url: '/Home/Login',
            type: "POST",
            contentType: 'application/json',
            data: data,

            success: function (result) {
                alert("Zostałeś pomyślnie zalogowany! :)");
                $("#resultDiv").append(result);
            },
            error: function (xhr, resp, text) {
                $("#resultDiv").append("Logowanie nie powiodło się. :(");
                console.log(xhr, resp, text);
            }
        })
    });
});