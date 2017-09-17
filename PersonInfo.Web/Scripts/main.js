var validateInput = function () {
    var PersonalDetails = $('#personalDetails').val();
    var errorMessage = "";
    $("#errorMessage").text("");
    if (PersonalDetails.length > 0) {
       var inputArray = PersonalDetails.split(/\n|\r/);
        if (inputArray.length > 1) {
            if (!ValidateAmount(inputArray[1])) {
                $("#errorMessage").text("Please enter a valid amount").show();
                return false;
            }
       }
        else {
            $("#errorMessage").text("Please enter all the requrired details").show();
            return false;
        }
    }
    else {
        $("#errorMessage").text("Please enter all the requrired details").show();
        return false;
    }
    return true;
}

var ValidateAmount = function (amount) {
    var exp = /^[1-9]\d*(\.\d+)?$/;
    amount.match(exp)
    if (!amount.match(exp)) {
        return false;
    }
    else {
        return true;
    }
}
