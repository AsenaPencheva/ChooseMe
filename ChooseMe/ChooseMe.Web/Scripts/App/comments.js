(function(){
    $("#comment").on("click", (function () {
        $("#hidden-comments").toggle().get(0).scrollIntoView();
    }));
}());