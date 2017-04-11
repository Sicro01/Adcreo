//
// Animate On Scroll
//
AOS.init({
    duration: 1200,
})
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
// //$('#header').addClass('homepage-header-background-start');
// if length is < 2 must be the home page
$(document).ready(function () {
    var urlPathName = window.location.pathname;
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
// Draw a box slowly around the home page tagline
//

//$(document).ready(function () {
//    window.setTimeout(function () {
//        $("#startchange").addClass("flex-item-tagline-border-top", 1000, "easeOutBounce");
//        $("#startchange").addClass("flex-item-tagline-border-right", 1000, "easeOutBounce");
//        $("#startchange").addClass("flex-item-tagline-border-bottom", 1000, "easeOutBounce");
//        $("#startchange").addClass("flex-item-tagline-border-left", 1000, "easeOutBounce");

//    }, 500);
//});

//$(document).ready(function () {
//    window.setTimeout(function () {
//        $("#startchange").addClass("flex-item-tagline-border-top", 500, "easeInElastic");
//        $("#startchange").addClass("flex-item-tagline-border-bottom", 1000, "easeOutBounce");
//        $("#startchange").addClass("flex-item-tagline-border-left", 1500, "easeOutBounce");
//        $("#startchange").addClass("flex-item-tagline-border-right", 2000, "easeOutBounce");
//    }, 2000);   
//});

//$(document).ready(function () {
//    window.setTimeout(function () {
//        $("#startchange").addClass("flex-item-tagline-border-top");
//        $("#startchange").addClass("flex-item-tagline-border-bottom");
//        $("#startchange").addClass("flex-item-tagline-border-left");
//        $("#startchange").addClass("flex-item-tagline-border-right");
//    }, 3000);
//});

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

