function ApplyFlipCard() {
    $(".custom-card").flip({
        axis: 'y',
        trigger: 'click'
    });
}

function ApplyMagnificPopup() {
    //Image popup
    $('.img-container').magnificPopup({ //.image-popup-no-margins
        delegate: '.image-popup-no-margins',
        type: 'image',
        closeOnContentClick: true,
        closeBtnInside: false,
        fixedContentPos: true,
        mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
        image: {
            verticalFit: true
        },
        zoom: {
            enabled: true,
            duration: 300 // don't foget to change the duration also in CSS
        }
    });
}

function ReportSelection(rdo, txt) {
    var checked = $(rdo).is(":checked");
    var parent = $(rdo).parent().parent();

    $(".radio").find(".txtMoreOption").addClass("hide");
    $(txt).attr("value","");

    if (checked) {
        var opts = parent.find(".txtMoreOption");
        opts.removeClass("hide");
        if (opts.length == 0) {
            $(txt).attr("value", $(rdo).val());
        }
    }
    else {
        parent.find(".txtMoreOption").addClass("hide");
    }
}

function SelectedOption(opt, txt) {
    $(txt).attr("value", $(opt).find(":selected").val());
}

function ReportTok(msg = "") {
    if (msg.length > 0) {
        $.ajax({
            url: "/Report/ReportTok",
            type: "POST",
            data: { message: msg },
            dataType: "json",
            async: true,
            success: function (e) {
                //$(modal).modal('toggle'); // Close Modal
                if (e.resultEnum == 1) {
                    swal("Success!", e.resultMessage, "success")
                }
            },
            error: function () {
                // Error here..
            }
        });
    }
}

function InputValidation(e, btn) {
    if ($(e).val().length > 0) {
        $(btn).removeAttr("disabled");
        unsaved = true;
    }
    else {
        $(btn).attr("disabled", true);
    }
}

function FlexFont() {
    var txts = document.getElementsByClassName("flexFont");
    for (var i = 0; i < txts.length; i++) {
        var parent = $(txts[i]).parent();
        var relFontsize = parent[0].offsetWidth * 0.05;
        txts[i].style.fontSize = relFontsize + 'px';
    }
};

function OpenDialog(container) {
    $("body").addClass("full-dialog-open");
    $(container).parent().find(".full-dialog").css("display", "block");
    $(container).parent().find(".full-dialog").addClass("show");
    activityId = $(container).parent().find(".txtActivityId").val();
    //console.log(activityId);
    InitializeCommentData(activityId, $(container).parent().find(".commentContainer"));
}

function CloseDialog(container) {
    $("body").removeClass("full-dialog-open");
    $(container).parent().parent().css("display", "");
    $(container).parent().parent().removeClass("show");
}

window.onresize = function (event) {
    FlexFont();
};