jQuery(document).ready(function ($) {
    $(".a-row").click(function () {
        window.location = $(this).data("href");
    });
});
