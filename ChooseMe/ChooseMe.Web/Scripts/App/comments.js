(function(){
    $("#comment").on("click", (function () {
        $("#hidden-comments").toggle().get(0).scrollIntoView();
    }));

    $("#comments").bind("DOMSubtreeModified", (function () {
        $("#comment-input").val(' ')
    }));
}());