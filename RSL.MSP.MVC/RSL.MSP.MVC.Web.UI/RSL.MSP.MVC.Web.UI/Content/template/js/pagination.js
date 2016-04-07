$(function () {
    $(function () {
        $(".pagination").off("click", "a[data-page]").on("click", "a[data-page]", function (e) {
            e.preventDefault();
            $(".nowpage").val($(this).attr("data-page"));
            if (typeof paginationFunction === "function") {
                paginationFunction($(this));
            }
            e.stopPropagation();
        });
    });
});