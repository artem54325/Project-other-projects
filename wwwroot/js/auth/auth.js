$('#sign-in').click(function () {
    $('#dark-bg-login-form').fadeIn();
    return false;
});

$('.close-login-form').click(function () {
    $(this).parents('#dark-bg-login-form').fadeOut();
    return false;
});
$(document).keydown(function (e) {
    if (e.keyCode === 27) {
        e.stopPropagation();
        $('#dark-bg-login-form').fadeOut();
    }
});

$('#dark-bg-login-form').click(function (e) {
    if ($(e.target).closest('#login-form').length == 0) {
        $(this).fadeOut();
    }
});

$('#registr').click(function () {
    alert('registr');
});

$('#login').click(function () {
    alert('login');
});