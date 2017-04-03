//
// Animate On Scroll
//
AOS.init({
    duration: 1200,
})

//
// Set menu selection active
//
//$(".sf-menu a").on("click", function () {
//    $(".sf-menu").find(".active").removeClass("active");
//    $(this).parent().addClass("active");
//});
//
// Initilise SuperFish Menu
//
//jQuery(document).ready(function () {
//    jQuery('ul.sf-menu').superfish({
//        pathClass: 'current'
//    });
//});
//
// Smooth Scrolling
//
$('a[href^="#"]').on('click', function (event) {
    var target = $(this.getAttribute('href'));
    if (target.length) {
        event.preventDefault();
        $('html, body').stop().animate({
            scrollTop: target.offset().top - 110
        }, 1000);
    }
});
//
// Change header styling
//
$(document).ready(function () {
    var urlPathName = window.location.pathname;
    // if length is < 2 must be the home page
    $('#header').addClass('homepage-header-background-start');
    if (urlPathName.length < 2) {
        var scroll_start = 0;
        var startchange = $('#startchange');
        var offset = startchange.offset();
        $(document).scroll(function () {
            scroll_start = $(this).scrollTop();
            if (scroll_start + 230 > offset.top) {
                $('#header').addClass('homepage-header-background-scroll');
                $('#header').removeClass('homepage-header-background-start');
                $('#header').removeClass('otherpages-header-background');
            } else {
                $('#header').addClass('homepage-header-background-start');
                $('#header').removeClass('homepage-header-background-scroll');
                $('#header').removeClass('otherpages-header-background');
            }
        }
        )
    }
    else {
        $('#header').addClass('otherpages-header-background');
        $('#header').removeClass('homepage-header-background-start');
        $('#header').removeClass('homepage-header-background-scroll');
    }
});
//
// Change browser tab title when user moves off Adcreo tab 
//

$(function () {
    // Get page title
    var pageTitle = $("title").text();

    // Change page title on blur
    $(window).blur(function () {
        $("title").text("Call us now for a chat...");
    });

    // Change page title back on focus
    $(window).focus(function () {
        $("title").text(pageTitle);
    });
});

