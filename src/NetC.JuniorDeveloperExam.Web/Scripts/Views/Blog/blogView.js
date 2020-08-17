
$(function () {

    $(".blogReplyForm").hide();


    $("#postComment").validate({

        rules: {
            EmailAddress:
            {
                required: true,
                rangelength: [2, 255],
                email: true
            },
            Name:
            {
                required: true,
                rangelength: [2, 200]
            },
            Message:
            {
                required: true,
                rangelength: [2, 1000]
            }
        }
    });

    $('.blogReply').click(function () {
        console.log("!");
        $(this).next(".blogReplyForm").toggle();
         
    });

});