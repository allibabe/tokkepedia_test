
var selectedSet;
var selectedSetUser;
var enableMultipleSelection = false, isSetTokPage = false;
function GetSetData(filter = '', type = 0, isGameSet = false, setContainer, isWithSelection = false) {
    var loadingContainer = $(setContainer).parent().find(".progress_small")[0];
    if (typeof loadingContainer !== 'undefined') {
        var animz = bodymovin.loadAnimation({
            container: $(setContainer).parent().find(".progress_small")[0], // Required
            path: window.location.origin + '/images/anim/trail_loading.json', //baseUrl + 'images/anim/trail_loading.json', // Required
            renderer: 'svg', // Required
            loop: true, // Optional
            autoplay: true, // Optional
            name: "" // Name for future reference. Optional.
        });
    }

    var SelectGroupOptions = {};
    if (!isGameSet) {
        SelectGroupOptions.url = filter.length > 0 ? "/Set/InitializeMySets?filter=" + filter + "&type=" + type + "&withSelection=" + isWithSelection : "/Set/InitializeMySets?type=" + type;
    }
    else {
        SelectGroupOptions.url = filter.length > 0 ? "/Set/InitializeMyGameSets?filter=" + filter + "&type=" + type : "/Set/InitializeMyGameSets";
    }
    SelectGroupOptions.type = "GET";
    SelectGroupOptions.async = true;
    SelectGroupOptions.success = function (htmlData) {
        // Override if there's a set container value
        if (typeof setContainer !== "undefined") {
            //console.log(setContainer);
            $(setContainer).html(htmlData);
        }
        else { // Default
            if (!isGameSet) {
                $("#SetFeed").html(htmlData);
            }
            else {
                $("#GameSetFeed").html(htmlData);
            }
        }
    };
    SelectGroupOptions.error = function (x) {
        var y = x;
        if (typeof setContainer !== "undefined") {
            $(setContainer).parent().find(".containerProgress").hide();
        }
        else { // Default
            if (!isGameSet) {
                $("#SetFeed").parent().find(".containerProgress").hide();
            }
            else {
                $("#GameSetFeed").parent().find(".containerProgress").hide();
            }
        }
    };
    SelectGroupOptions.complete = function () {
        if (typeof setContainer !== "undefined") {
            $(setContainer).parent().find(".containerProgress").hide();
        }
        else { // Default
            if (!isGameSet) {
                $("#SetFeed").parent().find(".containerProgress").hide();
            }
            else {
                $("#GameSetFeed").parent().find(".containerProgress").hide();
            }
        }
    };
    $.ajax(SelectGroupOptions);
}

function SelectSet(btn) {
    var container = $(btn).parent().parent().parent();
    if (!enableMultipleSelection) {
        $(container).find("button").each(function () {
            $(this).removeClass("list-group-item-primary");
            $(this).removeClass("selected");
        });
    }

    $(btn).addClass("list-group-item-primary");
    if ($(btn).hasClass("selected")) {
        $(btn).removeClass("selected");
        $(btn).removeClass("list-group-item-primary");
    }
    else {
        selectedSet = $(btn).attr("data-groupid");
        selectedSetUser = $(btn).attr("data-groupiduser");
        $(btn).addClass("selected");
    }
}

function AddToSet(modal) {
    if (typeof selectedSet !== 'undefined') {
        //console.log(selectedSet);
        $.ajax({
            url: "/Tok/AddTokToSet",
            type: "POST",
            data: JSON.stringify({ group: selectedSet, userid: selectedSetUser, comment: $(modal).attr("data-tokid") }),
            dataType: "json",
            async: true,
            contentType: "application/json",
            success: function (e) {
                $(modal).modal('toggle'); // Close Modal
                window.location.reload();
            },
            error: function () {
                // Error here..
            }
        });
    }
}

function EditSet(btn) {
    var id = $(btn).attr("data-groupid");
    var idSection = "#" + id + "-setssection";
    //console.log(id);
    var idName = "#" + id + "-editsetname";
    var name = $(idName).val();
    var idDescription = "#" + id + "-editsetdescription";
    var description = $(idDescription).val();
    var setVal = "#set-" + id;
    var set = JSON.parse($(setVal).val());

    uploadCrop.croppie('result', {
        type: 'canvas',
        size: 'viewport'
    }).then(function (resp) {
        $("#txtImage-" + id).val(resp);
    });

    if (name.length > 0 && name.length <= 50) {
        set.name = name;
        set.description = description;
        set.image = $("#txtImage-"+id).val();
    }
    var itemString = JSON.stringify(set);

    var Options = {};
    Options.url = "/Set/EditSet";
    Options.type = "POST";
    Options.data = JSON.stringify({ group: itemString }); //group: $("#").val()
    Options.datatype = "json";
    Options.contentType = "application/json";

    Options.success = function (res) {
        $(idSection).css('opacity', 0);
        $(idSection)
            .css('opacity', 0)
            .slideUp(250)
            .animate(
                { opacity: 0 },
                { queue: false, duration: 'fast' }
            );

        $(idSection).empty();
        $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Set edited.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    Options.error = function () {

        $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Set could not be edited.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    $.ajax(Options);
}

function DeleteSet(btn) {
    var id = $(btn).attr("data-groupid");
    var idSection = "#" + id + "-setssection";
    //console.log(id);

    var Options = {};
    Options.url = "/Set/DeleteSet";
    Options.type = "DELETE";
    Options.data = JSON.stringify({ group: id }); //group: $("#").val()
    Options.datatype = "json";
    Options.contentType = "application/json";

    Options.success = function (res) {
        $(idSection).css('opacity', 0);
        $(idSection)
            .css('opacity', 0)
            .slideUp(250)
            .animate(
                { opacity: 0 },
                { queue: false, duration: 'fast' }
            );

        $(idSection).empty();
        $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Set deleted.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    Options.error = function () {

        $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Set could not be deleted.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    $.ajax(Options);
}

var stepAt = 0;
var setId = "";
function LoadSetTokFeeds(takeCnt = 100, skip = 0, isCard = false) {
    //console.log(stepAt);
    if (setId.length > 0) { // Make sure set id is not empty.
        if (!$("#cards").hasClass("active")) {
            $("#cards").css("display", "block");
            $("#cards").css("visibility", "hidden");
        }

        var cntr = 0, showProgress = true;
        $("#tokContainer").find(".tokViewMainContainer").each(function () {
            cntr += 1;
        });
        if (cntr < 100 & isSetTokPage) showProgress = false;

        $.ajax({
            url: "/Set/GetSetToks?setId=" + setId + "&takeCnt=" + takeCnt + "&skip=" + skip + "&isCard=" + isCard,
            type: "GET",
            async: true,
            success: function (htmlData) {
                // Load Toks
                if (skip == 0) {
                    if (isCard) {
                        $("#tokCardContainer").html(htmlData);
                        $("#cards").removeClass("active");
                        $("#cards").css("visibility", "");
                    }
                    else
                        $("#tokContainer").html(htmlData);
                }
                else {
                    if (isCard) {
                        $(".TokCardFeed").append(htmlData);
                        if (!$("#cards").hasClass("active")) {
                            $("#cards").css("display", "");
                            $("#cards").css("visibility", "");
                        }
                    }
                    else
                        $("#TokFeed").append(htmlData);
                }

                // Remove Loading Animation

                if (showProgress) {
                    $("#progress").fadeOut('slow');
                    if (isCard) $(".cardMoreProgress").fadeOut('slow');
                }
            },
            beforeSend: function (e) {
                if (showProgress) {
                    $("#progress").show();
                    if (isCard) $(".cardMoreProgress").show();
                }
            },
            error: function () {
                if (showProgress) {
                    $("#progress").show();
                    if (isCard) $(".cardMoreProgress").show();
                }
            },
            complete: function () {
                if (skip == 0) {
                    if (isCard)
                        $(".cardContainerProgress").hide();
                    else
                        $(".containerProgress").hide();
                }
            }
        });

        stepAt += isCard ? 0 : takeCnt;
    }
}

function LoadSetToksListing(selectedSetId, tokContainer, takeCnt = 100, skip = 0) {
    var loadingContainer = $(tokContainer).find(".progress_small")[0];
    if (typeof loadingContainer !== 'undefined') {
        var animz = bodymovin.loadAnimation({
            container: $(tokContainer).find(".progress_small")[0], // Required
            path: window.location.origin + '/images/anim/trail_loading.json', //baseUrl + 'images/anim/trail_loading.json', // Required
            renderer: 'svg', // Required
            loop: true, // Optional
            autoplay: true, // Optional
            name: "" // Name for future reference. Optional.
        });
    }
    
    if (selectedSetId.length > 0) { // Make sure set id is not empty.
        $.ajax({
            url: "/Set/GetSetToks?setId=" + selectedSetId + "&takeCnt=" + takeCnt + "&skip=" + skip + "&isListing=true",
            type: "GET",
            async: true,
            success: function (htmlData) {
                // Load Toks
                $(tokContainer).find(".scrollsets").append(htmlData);

                // Remove Loading Animation
                $(tokContainer).find(".containerProgress").fadeOut('slow');
            },
            beforeSend: function (e) {
                $(tokContainer).find(".containerProgress").show();
            },
            error: function () {
                $(tokContainer).find(".containerProgress").hide();
            },
            complete: function () {
                $(tokContainer).find(".containerProgress").hide();
            }
        });
    }
}

function LoadSetToksByTokType(toktypeId, token = null) {
    if (toktypeId.length > 0) { // Make tok type id is not empty.
        token = token == null ? "" : token;
        console.log(token);
        $.ajax({
            url: "/Set/GetAllToks?tokTypeId=" + toktypeId + "&token=" + encodeURIComponent(token),
            type: "GET",
            async: true,
            success: function (htmlData) {
                // Load Toks
                $("#divSelectionContainer").find(".scrollsets").append(htmlData);

                // Remove Loading Animation
                $("#divSelectionContainer").find(".containerProgress").fadeOut('slow');
            },
            beforeSend: function (e) {
                $("#divSelectionContainer").find(".containerProgress").show();
            },
            error: function () {
                $("#divSelectionContainer").find(".containerProgress").hide();
            },
            complete: function () {
                $("#divSelectionContainer").find(".containerProgress").hide();
            }
        });
    }
}

function CreateGameSet(tokContainer, setId) {
    // Validate Selections
    var minValid = 5;
    var maxValid = 10;
    var selectedToks = [];

    $(tokContainer).find("#setView > button").each(function () {
        var isSelected = $(this).hasClass("list-group-item-primary");
        if (isSelected) {
            selectedToks.push($(this).attr("data-groupid"));
        }
    });

    if (selectedToks.length == minValid || selectedToks.maxValid == maxValid) {
        // Create Game Sets
        $.ajax({
            url: "/Set/AddGameSet",
            type: "POST",
            data: JSON.stringify({ Set: { Id: setId }, TokIds: selectedToks }),
            dataType: "json",
            async: true,
            contentType: "application/json",
            success: function (res) {
                switch (res.resultEnum) {
                    case 1: // Success
                        window.location.reload();
                        break;
                    case 2: // Failed
                        swal("Error", res.resultMessage, "error")
                        break;
                }
            },
            error: function () {
                // Error here..
            }
        });
    }
    else {
        swal("Invalid", "Please select at least 5 or 10 toks.", "error")
    }
}

function RemoveToksFromList(removedToks) {
    if (typeof tokIds !== "undefined") {
        for (var i = 0; i < removedToks.length; i++) {
            $(".tokViewMainContainer").each(function () {
                var tokId = $(this).attr("data-tokid");
                // Match Tok Ids
                if (tokId == removedToks[i]) {
                    var cardContr = $("#tokCardContainer");
                    var tokContr = $("#tokContainer");

                    cardContr.remove($(this));
                    tokContr.remove($(this));
                }
            });
        }
    }
}

function RemoveImage(editContainer) {
    var imgc = $(editContainer).find(".img-container");
    var imgv = $(editContainer).find("input.txtImage");
    imgc.hide();
    imgv.val('');
    imgc.find("img.cropped").attr('src', '');
}

function noPreview(parent) {
    $(parent).find(".img-container").hide();
    $(parent).find("#image-preview-div").hide();
}

var uploadCrop;
function BrowseFile(btn) {
    var maxsize = 5000 * 1024; // 500 KB

    uploadCrop = $(btn).parent().parent().find('#resizer').croppie({
        viewport: {
            height: 200,
            width: 200,
            type: 'square'
        },
        showZoomer: true,
        enableOrientation: false,
        mouseWheelZoom: 'ctrl',
        enableExif: true
    });

    $('#max-size').html((maxsize / 1024).toFixed(2));

    $(btn).change(function () {
        var file = this.files[0];
        var match = ["image/jpeg", "image/png", "image/jpg"];

        if (!((file.type == match[0]) || (file.type == match[1]) || (file.type == match[2]))) {
            noPreview($(btn).parent().parent());

            swal("Invalid image format.", "Allowed formats: JPG, JPEG, PNG.", "error");

            return false;
        }

        if (file.size > maxsize) {
            noPreview($(btn).parent().parent());

            swal("Invalid file size.", 'The size of image you are attempting to upload is ' + (file.size / 1024).toFixed(2) + ' KB, maximum size allowed is ' + (maxsize / 1024).toFixed(0) + ' KB.', "error");
            return false;
        }

        $('#upload-button').removeAttr("disabled");

        var reader = new FileReader();
        reader.onload = function (e) {
            //console.log(e);
            var parent = $(btn).parent().parent();
            $(parent).find('#resizer').addClass('ready');
            uploadCrop.croppie('bind', {
                url: e.target.result
            }).then(function () {
                //console.log('jQuery bind complete');
                });

            $(parent).find("#image-preview-div").show();
            $(parent).find("input.txtImage").val(e.target.result);
        }
        reader.readAsDataURL(this.files[0]);
    });
}

function RemoveTokFromSet(btn) {
    var tokId = $(btn).attr("data-tokid");
    $.ajax({
        url: "/Set/RemoveTokFromSet?setId=" + setId + "&tokId=" + tokId,
        type: "DELETE",
        dataType: "json",
        async: true,
        contentType: "application/json",
        success: function (e) {
            RemoveToksFromList([tokId]);
            //$(".delete-"+tokId+"-modal").modal('toggle'); // Close Modal
            window.location.reload();
        },
        error: function () {
            // Error here..
        }
    });
}

$(document).ready(function () {
    $(window).data('ajaxready', true).scroll(function (e) {
        if ($(window).data('ajaxready') === false) return;
        if ($(window).scrollTop() >= $(document).height() - $(window).height()) {
            if (!$("#progress").is(":visible") || !$(".cardMoreProgress").is(":visible")) {
                LoadSetTokFeeds(5, stepAt);
                LoadSetTokFeeds(5, stepAt, true);
            }
        }
    });

    $('.modal').on('shown.bs.modal', function () {
        $("body").css("padding-right", '10px');
        $("nav").css("padding-right", '10px');
        $(".navbar-toggler").css("margin-right", '16px');

    });

    $('.modal').on('hidden.bs.modal', function () {
        $("body").css("padding-right", '10px');
        $("nav").css("padding-right", '10px');
        $(".navbar-toggler").css("margin-right", '16px');
    });


    //Add to Set button
    $("#TokFeed").on("click", ".tokviewitem .addtosetmodal .addtosetdialog .addtosetcontent .addtosetbtngroup .addtosetbtn", function (event) { // .addtosetcontent .addtosetform .addtosetbtngroup .addtosetbtn

        //Tok Id
        var id = $(this).attr('id').replace("addtoset-", "").replace("-button", "");
        //var idSection = "#" + id + "-section";
        //var tokVal = "#tok-" + id;
        //alert($(tokVal).val());//var tok = JSON.parse($(tokVal).val())

        //Set Id
        var SetId = $("#selectedset-" + id).val();
        var setname = $("#" + id + "-setname").val();


        var ReactionOptions = {};
        ReactionOptions.url = "/Tok/AddTokToSet";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({ group: SetId, comment: id, data3: setname }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Edit button
    $("#TokFeed").on("click", ".editsetmodal .editsetdialog .editsetcontent .editsetbtngroup .editsetbtn", function (event) { // .editsetcontent .editsetform .editsetbtngroup .editsetbtn
        
        var id = $(this).attr('id').replace("editset-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var idName = "#" + id + "-editsetname";
        var name = $(idName).val();
        var idDescription = "#" + id + "-editsetdescription";
        var description = $(idDescription).val();
        var setVal = "#set-" + id;
        var set = JSON.parse($(setVal).val());

        if (name.length > 0 && name.length <= 50) {
            set.name = name;
            set.description = description;
        }
        var itemString = JSON.stringify(set);

        //Send edit request
        var SelectGroupOptions = {};
        SelectGroupOptions.url = "/Set/EditSet";
        SelectGroupOptions.type = "POST";
        SelectGroupOptions.data = JSON.stringify({ group: itemString }); //group: $("#SelectGroup").val()
        SelectGroupOptions.datatype = "json";
        SelectGroupOptions.contentType = "application/json";
        //alert(SelectGroupOptions.data.toString());

        SelectGroupOptions.success = function (data) {
            //$("#GetSubtypes").val(JSON.stringify(data));

            $(idSection).css('opacity', 0);
            $(idSection)
                .css('opacity', 0)
                .slideUp(250)
                .animate(
                    { opacity: 0 },
                    { queue: false, duration: 'fast' }
                );

            $(idSection).empty();
            $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Set edited.</div>');
            $(idSection)
                .css('opacity', 1)
                .slideDown(500)
                .animate(
                    { opacity: 1 },
                    { queue: true, duration: 'fast' }
                );

        };
        SelectGroupOptions.error = function () {

            $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Set could not be edited.</div>');
            $(idSection)
                .css('opacity', 1)
                .slideDown(500)
                .animate(
                    { opacity: 1 },
                    { queue: true, duration: 'fast' }
                );

        };
        $.ajax(SelectGroupOptions);


        //alert(tok.secondary_text.toString());
    });

    //Modal Logic
    $("#TokFeed").on('shown.bs.modal', '.tokviewitem .modal', function () {
        $("body").css("padding-right", '10px');
        $("nav").css("padding-right", '10px');
        $(".navbar-toggler").css("margin-right", '16px');
    });
    //Modal hidden logic
    $("#TokFeed").on('hidden.bs.modal', '.tokviewitem .modal', function () {
        $("body").css("padding-right", '10px');
        $("nav").css("padding-right", '10px');
        $(".navbar-toggler").css("margin-right", '16px');
    });


});

