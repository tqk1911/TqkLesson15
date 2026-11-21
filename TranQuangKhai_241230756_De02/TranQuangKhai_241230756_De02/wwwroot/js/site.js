$(function () {
    $(".menu").on("click", ".loai-link", function (e) {
        e.preventDefault();
        $(".menu li").removeClass("active");
        $(this).parent().addClass("active");
        $("#main-content").load("/Home/LocTheoLoai?maLoai=" + $(this).data("id"));
    });
});