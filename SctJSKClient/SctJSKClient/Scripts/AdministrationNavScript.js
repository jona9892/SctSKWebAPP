$(document).ready(function () {
    $('ul.nav').find('a[href="' + location.pathname + '"]')
        .closest('li').addClass('active');
});