let password = $('#password'), confirm_password = $('#confirm_password');

$(document).ready(() => {
    $('#password, #confirm_password').on('keyup', function () {
        checkPassword();
    });
});

function checkPassword() {

    if (password.val() == confirm_password.val()) {
        disableRegisterButton(false);
    }
    else {
        disableRegisterButton(true);
    }
}

function disableRegisterButton(value) {
    let button = $('#register_button');

    if (value) {
        button.attr('disabled', 'disabled');
    }
    else {
        button.removeAttr('disabled');
    }
}