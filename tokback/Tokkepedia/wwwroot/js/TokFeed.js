
var renderCount = 0;
var isComment = false;
var activityId = '';
var unsaved = false;

var getWindowOptions = function () {
    var width = 500;
    var height = 350;
    var left = (window.innerWidth / 2) - (width / 2);
    var top = (window.innerHeight / 2) - (height / 2);

    return [
        'resizable,scrollbars,status',
        'height=' + height,
        'width=' + width,
        'left=' + left,
        'top=' + top,
    ].join();
};

function GetInitData(filter = '', type = 0, isComment = false, withCard = false) {
    var SelectGroupOptions = {};
    SelectGroupOptions.url = filter.length > 0 ? "/Tok/InitializeTokData?filter=" + filter + "&type=" + type + "&withCardView=" + withCard : "/Tok/InitializeTokData?type=" + type + "&withCardView=" + withCard;
    SelectGroupOptions.type = "GET";
    SelectGroupOptions.async = true;
    SelectGroupOptions.success = function (htmlData) {
        $("#Token").val(htmlData.token);

        if (withCard) {
            $("#tokCardContainer").html(htmlData.cardHtml);
            $("#cards").removeClass("active");
            $("#cards").css("visibility", "");
        }
        $("#tokContainer").html(htmlData.defaultTokHtml);
        $("#tokListContainer").html(htmlData.tokListHtml);
    };
    SelectGroupOptions.error = function () {
        if (withCard) $(".cardContainerProgress").show();
        $("#containerProgress").hide();
    };
    SelectGroupOptions.beforeSend = function () {
        if (withCard) $(".cardContainerProgress").show();
        $("#containerProgress").show();
    };
    SelectGroupOptions.complete = function () {
        if (withCard) $(".cardContainerProgress").hide();
        $("#containerProgress").hide();
        $('.social-buttons').each(function () {
            var btnShare = $(this).find(".btnShare");
            FB.XFBML.parse(this);
            var obj = {
                method: 'feed',
                link: btnShare.attr("data-href"),
                picture: btnShare.attr("data-pic"),
                name: btnShare.attr("data-title"),
                description: btnShare.attr("data-desc")
            };
            $(".btnShare").click(function () {
                FB.ui(obj, function (response) { console.log(response); });
            });
        });

        $("#twitter-button").click(function (e) {
            e.preventDefault();
            var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
            win.opener = null; // 2
        });
        // Twitter Renderer
        $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });

        $(".tok-tile").click(function (e) {
            OpenDialog(this);
        });

        $(".tok-tile a").on('click', function (ev) {
            ev.stopImmediatePropagation();
        });

        // Bootstrap Tooltip
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
            $('[data-toggle="modal"][title]').tooltip();
        })
    };
    $.ajax(SelectGroupOptions);
}

function GetInitRawData(filter = '', type = 0) {
    var SelectGroupOptions = {};
    SelectGroupOptions.url = "/Tok/InitializeRawTokData?filter=" + filter + "&type=" + type;
    SelectGroupOptions.type = "GET";
    SelectGroupOptions.async = true;
    SelectGroupOptions.success = function (data) {
        $("#Token").val(data.token);
        var toks = data.allToks;
        //console.log(toks);
        $("#tokTileContainer").html("");
        for (var i = 0; i < toks.length; i++) {
            //console.log(JSON.stringify(toks[i]));
            (function (x) {
                $.ajax({
                    url: "/Tok/RenderTokViews",
                    type: "POST",
                    data: JSON.stringify(toks[x]),
                    datatype: "html",
                    contentType: "application/json",
                    async: true,
                    cache: false,
                    success: function (res) {
                        // Make the tab active and invisible to render the view 
                        // and implement the flipping to its visible parent container.
                        if (!$("#cards").hasClass("active")) {
                            $("#cards").css("display", "block");
                            $("#cards").css("visibility", "hidden");
                        }

                        $("#tokTileContainer").append(res.tileHtml);
                        $("#cardContainer").append(res.cardHtml);
                        $("#listContainer").append(res.tokHtml);

                        // Hide the tab after rendering
                        if (!$("#cards").hasClass("active")) {
                            $("#cards").css("display", "");
                            $("#cards").css("visibility", "");
                        }
                    },
                    error: function () {
                        // Error here..
                    },
                    complete: function () {
                        $(".tok-tile").click(function (e) {
                            OpenDialog(this);
                        });

                        $(".tok-tile a").on('click', function (ev) {
                            ev.stopImmediatePropagation();
                        });

                        // Facebook Renderer
                        $(".tokTile_" + toks[x].id).find('.social-buttons').each(function () {
                            var btnShare = $(this).find(".btnShare");
                            FB.XFBML.parse(this);
                            var obj = {
                                method: 'feed',
                                link: btnShare.attr("data-href"),
                                picture: btnShare.attr("data-pic"),
                                name: btnShare.attr("data-title"),
                                description: btnShare.attr("data-desc")
                            };
                            $(".btnShare").click(function () {
                                FB.ui(obj, function (response) { console.log(response); });
                            });
                        });

                        $("#twitter-button").click(function (e) {
                            e.preventDefault();
                            var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
                            win.opener = null; // 2
                        });
                        // Twitter Renderer
                        $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });
                    }
                });
            })(i);

            if (i >= toks.length - 1) {
                $("#containerProgress").hide();
                $(".cardContainerProgress").hide();
            }
        }

        if (toks.length <= 0) {
            $("#containerProgress").hide();
            $(".cardContainerProgress").hide();
        }
    };
    SelectGroupOptions.error = function () {
        $("#containerProgress").hide();
        $(".cardContainerProgress").hide();
    };
    SelectGroupOptions.beforeSend = function () {
        $("#containerProgress").show();
        $(".cardContainerProgress").show();
    };
    SelectGroupOptions.complete = function () {
        $("#cards").removeClass("active");
        $("#cards").css("visibility", "");

        // Facebook Renderer
        $('.social-buttons').each(function () {
            var btnShare = $(this).find(".btnShare");
            FB.XFBML.parse(this);
            var obj = {
                method: 'feed',
                link: btnShare.attr("data-href"),
                picture: btnShare.attr("data-pic"),
                name: btnShare.attr("data-title"),
                description: btnShare.attr("data-desc")
            };
            $(".btnShare").click(function () {
                FB.ui(obj, function (response) { console.log(response); });
            });
        });

        $("#twitter-button").click(function (e) {
            e.preventDefault();
            var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
            win.opener = null; // 2
        });
        // Twitter Renderer
        $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });

        // Bootstrap Tooltip
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
            $('[data-toggle="modal"][title]').tooltip();
        })

        setTimeout(function () {
            $(".dropdown-menu > .social-buttons > .fb-share-button > span", ".dropdown-menu > .social-buttons > .fb-share-button > span > iframe").css("width", "73px");
            $(".dropdown-menu > .social-buttons > .fb-share-button > span", ".dropdown-menu > .social-buttons > .fb-share-button > span > iframe").css("height", "28px");
        }, 1500);
    };
    $.ajax(SelectGroupOptions);
}

function InitializeCommentData(filter = '', container) {
    var SelectGroupOptions = {};

    SelectGroupOptions.url = "/Reaction/InitializeComments?filter=" + filter;
    SelectGroupOptions.type = "GET";
    SelectGroupOptions.async = true;
    SelectGroupOptions.success = function (htmlData) {
        $(container).html(htmlData);
    };
    SelectGroupOptions.error = function () {
        $(container).parent().find("#containerProgress").hide();
    };
    SelectGroupOptions.beforeSend = function () {
        $(container).parent().find("#containerProgress").show();
    };
    SelectGroupOptions.complete = function () {
        $(container).parent().find("#containerProgress").hide();
    };
    $.ajax(SelectGroupOptions);
}

function GetComments(container) {
    var SelectGroupOptions = {};
    SelectGroupOptions.url = "/Reaction/LoadComments?activityId=" + activityId + "&token=" + $("#Token").val();
    SelectGroupOptions.type = "GET";
    SelectGroupOptions.async = true;
    SelectGroupOptions.success = function (htmlData) {
        if (htmlData.token.length > 0) {
            if (typeof container !== "undefined") {
                $(container).find("#Token").val(htmlData.token);
                $(container).find("#TokFeed").append(htmlData.comments);
            }
            else {
                $("#Token").val(htmlData.token); // Set new Token
                $("#TokFeed").append(htmlData.comments); // Append Comments
            }
        }
    };
    SelectGroupOptions.error = function () {
        if (typeof container !== "undefined") {
            $(container).find("#progress").hide();
        }
        else {
            $("#progress").hide();
        }
    };
    SelectGroupOptions.beforeSend = function () {
        if (typeof container !== "undefined") {
            $(container).find("#progress").show();
        }
        else {
            $("#progress").show();
        }
    };
    SelectGroupOptions.complete = function () {
        if (typeof container !== "undefined") {
            $(container).find("#progress").hide();
        }
        else {
            $("#progress").hide();
        }
    };
    $.ajax(SelectGroupOptions);
}

function SendReaction(btn, rmsg = '') {
    var id = $(btn).attr("data-tokid");
    var catId = $(btn).attr("data-categoryId");
    var typeId = $(btn).attr("data-tokTypeId");
    var type = $(btn).attr("data-type");
    var actId = $(btn).attr("data-activityId");
    var ownerId = $(btn).attr("data-itemUser");
    var cnt = parseInt($(btn).find("span.reactionlbl").text());

    var ReactionOptions = {};
    ReactionOptions.url = "/Reaction/React";
    ReactionOptions.type = "POST";
    ReactionOptions.data = JSON.stringify({
        label: "reaction",
        activity_id: actId,
        kind: type,
        ReactionKind: type,
        owner_id: ownerId,
        category_id: catId,
        tok_type_id: typeId,
        IsActive: $(btn).hasClass("active"),
        text: rmsg,
        item_id: id
    });
    ReactionOptions.datatype = "html";
    ReactionOptions.contentType = "application/json";
    ReactionOptions.beforeSend = function (e) {
        $(btn).find("i.reactionbtn").addClass("hide");
        $(btn).find("span.reactionlbl").addClass("hide");
        $(btn).find(".loading").removeClass("hide");
    };
    ReactionOptions.success = function (Result) {
        //
        console.log("Done!");
        if ($(btn).hasClass("active")) {
            $(btn).removeClass("active");
            if (cnt > 0) {
                cnt -= 1;
                $(btn).find("span.reactionlbl").text(cnt);
            }
        }
        else {
            $(btn).addClass("active");
            cnt += 1;
            $(btn).find("span.reactionlbl").text(cnt);
        }
    };
    ReactionOptions.error = function () {
        alert("An error occured, please try again or contact an admin.");
    };
    ReactionOptions.complete = function () {
        $(btn).find("i.reactionbtn").removeClass("hide");
        $(btn).find("span.reactionlbl").removeClass("hide");
        $(btn).find(".loading").addClass("hide");
    };
    $.ajax(ReactionOptions);
}

function ShowReply(btn) {
    var parent = $(btn).parent().parent().parent().parent().parent();
    var replySection = parent.find(".replySection");
    var isShown = $(replySection).attr("data-isshown");
    if (isShown == 0) {
        $(replySection).attr("data-isshown", 1);
        $(replySection).css("display", "");
    }
    else {
        $(replySection).attr("data-isshown", 0);
        $(replySection).css("display", "none");
    }
}

function ViewReplies(btn) {
    var parent = $(btn).parent();
    var isShown = $(btn).attr("data-isshown");
    var cnt = $(btn).attr("data-cnter");
    if (isShown == 0) {
        $(btn).attr("data-isshown", 1);
        $(parent).find(".reply").css("display", "");
        $(btn).find("h6").text("Hide Replies");
    }
    else {
        $(btn).attr("data-isshown", 0);
        $(parent).find(".reply").css("display", "none");
        $(btn).find("h6").text("View " + cnt + " Replies");
    }
}

function RemoveImage(editTokContainer) {
    var imgc = $(editTokContainer).find(".img-container");
    var imgv = $(editTokContainer).find("input.txtImage");
    imgc.hide();
    imgv.val('');
    imgc.find("img.cropped").attr('src','');
}

function noPreview(parent) {
    $(parent).find(".img-container").hide();
}

function BrowseFile(btn) {
    var maxsize = 5000 * 1024; // 500 KB

    $('#max-size').html((maxsize / 1024).toFixed(2));

    $(btn).change(function () {
        var file = this.files[0];
        var match = ["image/jpeg", "image/png", "image/jpg"];

        if (!((file.type == match[0]) || (file.type == match[1]) || (file.type == match[2]))) {
            noPreview($(btn).parent().parent());

            swal("Invalid image format.","Allowed formats: JPG, JPEG, PNG.","error");

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
            $(parent).find(".img-container").show();
            $(parent).find(".img-container > img.cropped").attr('src', e.target.result);
            $(parent).find("input.txtImage").val(e.target.result);
        }
        reader.readAsDataURL(this.files[0]);
    });
}

function Replicate(btn) {
    console.log("sulod bro");
    var id = $(btn).attr("data-tokid");
    console.log(id);
    //var id = $(this).attr('id').replace("replicate-", "").replace("-button", "");
    var idSection = "#" + id + "-section";
    var tokVal = "#tok-" + id;

    var idCategory = "#" + id + "-replicatecategory";
    var category = $(idCategory).val();
    var tok = JSON.parse($(tokVal).val());
    tok.category = category;
    var tokString = JSON.stringify(tok);

    var SelectGroupOptions = {};
    SelectGroupOptions.url = "/Tok/Replicate";
    SelectGroupOptions.type = "POST";
    SelectGroupOptions.data = JSON.stringify({ group: tokString });
    SelectGroupOptions.datatype = "json";
    SelectGroupOptions.contentType = "application/json";

    SelectGroupOptions.success = function (GetSubtypes) {
        $("#GetSubtypes").val(JSON.stringify(GetSubtypes));

        $(idSection).css('opacity', 0);
        $(idSection)
            .css('opacity', 0)
            .slideUp(250)
            .animate(
                { opacity: 0 },
                { opacity: 0 },
                { queue: false, duration: 'fast' }
            );

        $(idSection).empty();
        $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Tok replicated.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    SelectGroupOptions.error = function () {

        $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Tok could not be replicated.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    $.ajax(SelectGroupOptions);
}

function SaveEdit(btn) {
    var id = $(btn).attr('data-tokid');
    var idSection = "#" + id + "-section";
    var idCategory = "#" + id + "-editcategory";
    var category = $(idCategory).val();
    var tokVal = "#tok-" + id;
    var tok = JSON.parse($(tokVal).val());

    if (category.length > 0 && category.length <= 50) {
        tok.category = category;
    }

    //Primary and Secondary fields
    var idPrimary = "#" + id + "-editprimary";
    var primary = $(idPrimary).val();
    if (primary.length > 0) {
        tok.primary_text = primary;
    }

    if (tok.is_detail_based) {
        var details = [];
        for (var i = 0; i < 5; ++i) {
            var idDetail = "#" + id + "-editdetail" + (i + 1);
            var detail = $(idDetail).val();
            details.push(detail);
        }
        tok.details = details;
    }
    else {
        var idSecondary = "#" + id + "-editsecondary";
        var secondary = $(idSecondary).val();
        if (secondary.length > 0) {
            tok.secondary_text = secondary;
        }
    }

    //English Translations
    if (tok.isEnglish === 'false') {

        var idLanguage = "#" + id + "-editlanguage";
        var language = $(idLanguage).val();
        if (language.length > 0) {
            tok.language = language;
        }

        var idEnglishPrimary = "#" + id + "-editenglishprimary";
        var englishprimary = $(idEnglishPrimary).val();
        if (englishprimary.length > 0) {
            tok.english_primary_text = englishprimary;
        }
        tok.english_primary_text = englishprimary;

        if (tok.is_detail_based) {
            var englishdetails = [];
            for (var i = 0; i < 5; ++i) {
                var idEnglishDetail = "#" + id + "-editenglishdetail" + (i + 1);
                var englishdetail = $(idEnglishDetail).val();
                englishdetails.push(englishdetail);
            }
            tok.english_details = englishdetails;

        }
        else {
            var idEnglishSecondary = "#" + id + "-editenglishsecondary";
            var englishsecondary = $(idEnglishSecondary).val();
            if (englishsecondary.length > 0) {
                tok.english_secondary_text = englishsecondary;
            }
        }
    }

    //Required fields
    var required_fields = [];
    var required_field_values = [];
    var requiredCount = parseInt($('#requiredfieldcount').val());


    for (var i = 0; i < requiredCount; ++i) {
        var idRequired = "#" + id + "-editrequired" + (i + 1);
        var required = $(idRequired).val();
        required_field_values.push(required);

        var idRequiredName = "#" + id + "-editrequiredname" + (i + 1);
        var requiredname = $(idRequiredName).val();
        required_fields.push(requiredname);
    }
    tok.required_fields = required_fields;
    tok.required_field_values = required_field_values;


    //Optional fields
    var optional_fields = [];
    var optional_field_values = [];
    var optionalCount = parseInt($('#optionalfieldcount').val());

    //alert(requiredCount.toString());
    for (var j = 0; j < optionalCount; ++j) {
        idRequired = "#" + id + "-editoptional" + (j + 1);
        var optional = $(idRequired).val();
        optional_field_values.push(optional);

        var idRequiredNam = "#" + id + "-editoptionalname" + (j + 1);
        var optionalname = $(idRequiredNam).val();
        optional_fields.push(optionalname);
    }
    tok.optional_fields = optional_fields;
    tok.optional_field_values = optional_field_values;



    var tokString = JSON.stringify(tok);
    
    //Send edit request
    var SelectGroupOptions = {};
    SelectGroupOptions.url = "/Tok/Edit";
    SelectGroupOptions.type = "POST";
    SelectGroupOptions.data = JSON.stringify({ group: tokString }); //group: $("#SelectGroup").val()
    SelectGroupOptions.datatype = "json";
    SelectGroupOptions.contentType = "application/json";
    SelectGroupOptions.beforeSend = function () {
        $(this).attr("disabled", true);
        $('body').append("<div class='fadeIn parrotLoad' style='position: fixed; right: 50%; top: 50%; z-index: 99; opacity: 0; animation: fadeInLeft_firstHalf 1.2s linear .2s; animation-fill-mode: both;'><img src='/images/parrot.gif' style='width: 100px; height: 100px;' /></div>");
    };
    SelectGroupOptions.complete = function () {
        $(".parrotLoad").css("animation", "fadeInLeft_secondHalf 1.2s linear 2s");
        $(".parrotLoad").css("animation-fill-mode", "both");
    };
    SelectGroupOptions.success = function (GetSubtypes) {
        $("#GetSubtypes").val(JSON.stringify(GetSubtypes));

        $(idSection).css('opacity', 0);
        $(idSection)
            .css('opacity', 0)
            .slideUp(250)
            .animate(
                { opacity: 0 },
                { queue: false, duration: 'fast' }
            );

        $(idSection).empty();
        $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Tok edited.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    SelectGroupOptions.error = function () {

        $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Tok could not be edited.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    $.ajax(SelectGroupOptions);
}

function DeleteTok(btn) {
    var id = $(btn).attr('data-tokid');
    var idSection = "#" + id + "-section";
    
    var SelectGroupOptions = {};
    SelectGroupOptions.url = "/Tok/Delete";
    SelectGroupOptions.type = "POST";
    SelectGroupOptions.data = JSON.stringify({ group: id }); //group: $("#SelectGroup").val()
    SelectGroupOptions.datatype = "json";
    SelectGroupOptions.contentType = "application/json";
    //alert(SelectGroupOptions.data.toString());

    SelectGroupOptions.success = function (GetSubtypes) {
        //$("#GetSubtypes").val(JSON.stringify(GetSubtypes));

        $(idSection).css('opacity', 0);
        $(idSection)
            .css('opacity', 0)
            .slideUp(250)
            .animate(
                { opacity: 0 },
                { queue: false, duration: 'fast' }
            );

        $(idSection).empty();
        $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Tok deleted.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    SelectGroupOptions.error = function () {

        $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Tok could not be deleted.</div>');
        $(idSection)
            .css('opacity', 1)
            .slideDown(500)
            .animate(
                { opacity: 1 },
                { queue: true, duration: 'fast' }
            );

    };
    $.ajax(SelectGroupOptions);
}

$(document).ready(function () {

    $(window).data('ajaxready', true).scroll(function (e) {
        if ($(window).data('ajaxready') === false) return;
        if ($(window).scrollTop() + 5 >= $(document).height() - $(window).height()) {
            //console.log("Scrolling...");
            if (!$(".tokProgress").is(":visible")) {
                if (isComment) {
                    GetComments();
                }
                else {
                    //Only load more if there is a token
                    if ($("#Token").val()) {
                        GetMoreData();
                    }
                }
            }
        }
    });

    function GetData(withCard = false) {
        var functionName = $("#LoadMoreFunction").val();
        $("#IsLoadMore").val('yes');

        var runAlready = false;
        var SelectGroupOptions = {};
        SelectGroupOptions.url = "/Tok/" + functionName;
        SelectGroupOptions.type = "POST";
        SelectGroupOptions.data = JSON.stringify({
            group: $("#Token").val(),
            comment: $("#ValSearchText").val(),
            order: $("#searchorder").val(),
            country: $("#CountryFilter").val(),
            category: $("#TxtCategory").val(),
            toktype: $("#TokTypeFilter").val(),
            toktypeid: $("#TokTypeIdFilter").val(),
            tokgroup: $("#TokGroupFilter").val(),
            userid: $("#UserIdFilter").val(),
            isLoadMore: $("#IsLoadMore").val(),
            loadCount: renderCount / 2
        });
        SelectGroupOptions.datatype = "json";
        SelectGroupOptions.contentType = "application/json";
        SelectGroupOptions.success = function (GetData) {

            $("#Token").val(GetData.token);
            //alert(GetData.token);
            //alert($("#Token").val());

            if (!runAlready && GetData.results.length > 0) {
                
                renderCount += 1;

                if (!$("#cards").hasClass("active")) {
                    $("#cards").css("display", "block");
                    $("#cards").css("visibility", "hidden");
                }

                var RenderTokOptions = {};
                RenderTokOptions.url = "/Tok/RenderTok";
                RenderTokOptions.type = "POST";
                RenderTokOptions.data = JSON.stringify({ group: JSON.stringify(GetData.results), isCard: withCard });
                RenderTokOptions.datatype = "json";
                RenderTokOptions.contentType = "application/json";
                RenderTokOptions.success = function (TokData) {
                    //console.log(TokData);
                    if (withCard) {
                        $(".TokCardFeed").append(TokData.cardHtml);
                        if (!$("#cards").hasClass("active")) {
                            $("#cards").css("display", "");
                            $("#cards").css("visibility", "");
                        }
                    }

                    $("#TokFeed").append(TokData.tokHtml);
                    $("#tokTileContainer").append(TokData.tileHtml);


                    $('.social-buttons').each(function () {
                        var btnShare = $(this).find(".btnShare");
                        FB.XFBML.parse(this);
                        var obj = {
                            method: 'feed',
                            link: btnShare.attr("data-href"),
                            picture: btnShare.attr("data-pic"),
                            name: btnShare.attr("data-title"),
                            description: btnShare.attr("data-desc")
                        };
                        $(".btnShare").click(function () {
                            FB.ui(obj, function (response) { console.log(response); });
                        });
                    });

                    $("#twitter-button").click(function (e) {
                        e.preventDefault();
                        var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
                        win.opener = null; // 2
                    });
                    // Twitter Renderer
                    $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });
                };
                RenderTokOptions.error = function () {

                };
                RenderTokOptions.complete = function () {
                    $(".tok-tile").click(function (e) {
                        OpenDialog(this);
                    });

                    $(".tok-tile a").on('click', function (ev) {
                        ev.stopImmediatePropagation();
                    });

                    // Bootstrap Tooltip
                    $(function () {
                        $('[data-toggle="tooltip"]').tooltip();
                        $('[data-toggle="modal"][title]').tooltip();
                    })
                };
                $.ajax(RenderTokOptions);

                if (withCard)
                    $(".cardMoreProgress").fadeOut('slow');

                $(".tokProgress").fadeOut('slow');

                runAlready = true;
            }
            else {
                if (withCard)
                    $(".cardMoreProgress").fadeOut('fast');

                $(".tokProgress").fadeOut('fast');
            }

        };
        SelectGroupOptions.error = function () {
            if (withCard)
                $(".cardMoreProgress").show();

            $(".tokProgress").hide();
        };
        SelectGroupOptions.beforeSend = function () {
            if (withCard)
                $(".cardMoreProgress").show();

            $(".tokProgress").show();
        };
        SelectGroupOptions.complete = function () {
        };
        $.ajax(SelectGroupOptions);

    }

    // New
    function GetMoreData() {
        var functionName = $("#LoadMoreFunction").val();
        $("#IsLoadMore").val('yes');

        var runAlready = false;
        var SelectGroupOptions = {};
        SelectGroupOptions.url = "/Tok/" + functionName;
        SelectGroupOptions.type = "POST";
        SelectGroupOptions.data = JSON.stringify({
            group: $("#Token").val(),
            comment: $("#ValSearchText").val(),
            order: $("#searchorder").val(),
            country: $("#CountryFilter").val(),
            category: $("#TxtCategory").val(),
            toktype: $("#TokTypeFilter").val(),
            toktypeid: $("#TokTypeIdFilter").val(),
            tokgroup: $("#TokGroupFilter").val(),
            userid: $("#UserIdFilter").val(),
            isLoadMore: $("#IsLoadMore").val(),
            loadCount: renderCount / 2
        });
        SelectGroupOptions.datatype = "json";
        SelectGroupOptions.contentType = "application/json";
        SelectGroupOptions.success = function (GetData) {
            if (!runAlready && GetData.results.length > 0) {
                $("#Token").val(GetData.token);
                renderCount += 1;

                var toks = GetData.results;
                for (var i = 0; i < toks.length; i++) {
                    //console.log(JSON.stringify(toks[i]));
                    (function (x) {
                        $.ajax({
                            url: "/Tok/RenderTokViews",
                            type: "POST",
                            data: JSON.stringify(toks[x]),
                            datatype: "html",
                            contentType: "application/json",
                            async: true,
                            cache: false,
                            success: function (res) {
                                // Make the tab active and invisible to render the view 
                                // and implement the flipping to its visible parent container.
                                if (!$("#cards").hasClass("active")) {
                                    $("#cards").css("display", "block");
                                    $("#cards").css("visibility", "hidden");
                                }

                                $("#tokTileContainer").append(res.tileHtml);
                                $("#cardContainer").append(res.cardHtml);
                                $("#listContainer").append(res.tokHtml);

                                // Hide the tab after rendering
                                if (!$("#cards").hasClass("active")) {
                                    $("#cards").css("display", "");
                                    $("#cards").css("visibility", "");
                                }
                            },
                            error: function () {
                                // Error here..
                            },
                            complete: function () {
                                $(".tok-tile").click(function (e) {
                                    OpenDialog(this);
                                });

                                $(".tok-tile a").on('click', function (ev) {
                                    ev.stopImmediatePropagation();
                                });

                                // Facebook Renderer
                                $(".tokTile_" + toks[x].id).find('.social-buttons').each(function () {
                                    var btnShare = $(this).find(".btnShare");
                                    FB.XFBML.parse(this);
                                    var obj = {
                                        method: 'feed',
                                        link: btnShare.attr("data-href"),
                                        picture: btnShare.attr("data-pic"),
                                        name: btnShare.attr("data-title"),
                                        description: btnShare.attr("data-desc")
                                    };
                                    $(".btnShare").click(function () {
                                        FB.ui(obj, function (response) { console.log(response); });
                                    });
                                });

                                $("#twitter-button").click(function (e) {
                                    e.preventDefault();
                                    var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
                                    win.opener = null; // 2
                                });
                                // Twitter Renderer
                                $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });
                            }
                        });
                    })(i);

                    if (i >= toks.length - 1) {
                        $("#containerProgress").hide();
                        $(".cardContainerProgress").hide();
                    }
                }

                if (toks.length <= 0) {
                    $("#containerProgress").hide();
                    $(".cardContainerProgress").hide();
                }

                 $(".cardMoreProgress").fadeOut('slow');
                $(".tokProgress").fadeOut('slow');

                runAlready = true;
            }
            else {
                $(".cardMoreProgress").fadeOut('fast');
                $(".tokProgress").fadeOut('fast');
            }

        };
        SelectGroupOptions.error = function () {
            $(".cardMoreProgress").show();
            $(".tokProgress").hide();
        };
        SelectGroupOptions.beforeSend = function () {
            $(".cardMoreProgress").show();
            $(".tokProgress").show();
        };
        SelectGroupOptions.complete = function () {
        };
        $.ajax(SelectGroupOptions);

    }

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
        var tokVal = "#tok-" + id;
        //alert($(tokVal).val());//
        var tok = JSON.parse($(tokVal).val());
        var tokString = JSON.stringify(tok);

        //Set Id
        var SetId = $("#selectedset-" + id).val();
        var setname = $("#" + id + "-setname").val();

        var ReactionOptions = {};
        ReactionOptions.url = "/Tok/AddTokToSet";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({ group: tokString, comment: id, data3: setname }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Select existing set
    $("#TokFeed").on("click", ".tokviewitem .addtosetmodal .addtosetdialog .addtosetcontent .addtosetbody .addtosetsetssection .addtosetlistgroup .addtoexistingset", function (event) { // .addtosetcontent .addtosetform .addtosetbtngroup .addtosetbtn
        //Set id
        var id = $(this).attr('name').replace("setlist-", "");
        var SetValId = "selectedset-" + id;

        //Get Tok Id
        var TokId = $(this).attr('id').replace("setlist-" + id + "-", "");

        //Set selected set id
        var selectedSetId = "#selectedset-" + TokId;
        $(selectedSetId).val(id);

        //Hide "Create new set section"
        $("#" + TokId + "-newsetsection").hide();

        //Enable button
        var idBtn = "addtoset-" + TokId + "-button";
        $("#" + idBtn).prop("disabled", false);

        //if ($(this).hasClass('active')) {
        //    $("#" + idBtn).prop("disabled", true);
        //}
        //else {
        //    $("#" + idBtn).prop("disabled", false);
        //}
    });


    //Accurate button
    $("#TokFeed").on("click", ".tokviewitem .accuratemodal .accuratedialog .accuratecontent .accuratebtngroup .accuratebtn", function (event) { // .accuratecontent .accurateform .accuratebtngroup .accuratebtn
        var id = $(this).attr('id').replace("accurate-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;
        var primaryText = $("#primarytext-" + id).val();

        var idText = "#" + id + "-accuratetext";
        var text = $(idText).val();
        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/Accurate";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({ group: id, comment: text, detailtext: primaryText }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Inaccurate button
    $("#TokFeed").on("click", ".tokviewitem .inaccuratedetailmodal .inaccuratedetaildialog .inaccuratedetailcontent .inaccuratedetailbtngroup .inaccuratedetailbtn", function (event) { // .inaccuratedetailcontent .inaccuratedetailform .inaccuratedetailbtngroup .inaccuratedetailbtn
        var id = $(this).attr('id').replace("inaccuratedetail-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;
        var primaryText = $("#primarytext-" + id).val();

        var idText = "#" + id + "-inaccuratedetailtext";
        var text = $(idText).val();
        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/Inaccurate";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({ group: id, comment: text, detailtext: primaryText }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Comment button
    $("#TokFeed").on("click", ".tokviewitem .commentmodal .commentdialog .commentcontent .commentbtngroup .commentbtn", function (event) { // .commentcontent .commentform .commentbtngroup .commentbtn
        var id = $(this).attr('id').replace("comment-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;
        var primaryText = $("#primarytext-" + id).val();

        var idText = "#" + id + "-commenttext";
        var text = $(idText).val();

        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/Comment";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({ group: id, comment: text, detailtext: primaryText }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });



    //Accurate detail button
    $("#TokFeed").on("click", ".tokviewitem .accuratedetailmodal .accuratedetaildialog .accuratedetailcontent .accuratedetailbtngroup .accuratedetailbtn", function (event) { // .accuratedetailcontent .accuratedetailform .accuratedetailbtngroup .accuratedetailbtn
        var id = $(this).attr('id').replace("accuratedetail-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;

        var idText = "#" + id + "-accuratedetailtext";
        var text = $(idText).val();
        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/AccurateDetail";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({
            group: id,
            comment: text,
            data3: $('#selecteddetail-' + id).val(),
            detailtext: $('#selecteddetailtext-' + id).val()
        }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Inaccurate detail button
    $("#TokFeed").on("click", ".tokviewitem .inaccuratedetailmodal .inaccuratedetaildialog .inaccuratedetailcontent .inaccuratedetailbtngroup .inaccuratedetailbtn", function (event) { // .inaccuratedetailcontent .inaccuratedetailform .inaccuratedetailbtngroup .inaccuratedetailbtn
        var id = $(this).attr('id').replace("inaccuratedetail-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;

        var idText = "#" + id + "-inaccuratedetailtext";
        var text = $(idText).val();
        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/InaccurateDetail";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({
            group: id, 
            comment: text,
            data3: $('#selecteddetail-' + id).val(),
            detailtext: $('#selecteddetailtext-' + id).val()
        }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });

    //Comment detail button
    $("#TokFeed").on("click", ".tokviewitem .commentdetailmodal .commentdetaildialog .commentdetailcontent .commentdetailbtngroup .commentdetailbtn", function (event) { // .commentdetailcontent .commentdetailform .commentdetailbtngroup .commentdetailbtn
        var id = $(this).attr('id').replace("commentdetail-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;

        var idText = "#" + id + "-commentdetailtext";
        var text = $(idText).val();

        var ReactionOptions = {};
        ReactionOptions.url = "/Reaction/CommentDetail";
        ReactionOptions.type = "POST";
        ReactionOptions.data = JSON.stringify({
            group: id,
            comment: text,
            data3: $('#selecteddetail-' + id).val(),
            detailtext: $('#selecteddetailtext-' + id).val()
        }); //group: $("#Reaction").val()
        ReactionOptions.datatype = "json";
        ReactionOptions.contentType = "application/json";
        //alert(ReactionOptions.data.toString());

        ReactionOptions.success = function (Data) {

        };
        ReactionOptions.error = function () {

        };
        $.ajax(ReactionOptions);
    });


    //Report button
    $("#TokFeed").on("click", ".tokviewitem .reportmodal .reportdialog .reportcontent .reportbtngroup .reportbtn", function (event) { // .reportcontent .reportform .reportbtngroup .reportbtn


        var id = $(this).attr('id').replace("report-", "").replace("-button", "");
        var idSection = "#" + id + "-section";
        var tokVal = "#tok-" + id;

        var idCategory = "#" + id + "-reportcategory";
        var tok = JSON.parse($(tokVal).val());
        var tokString = JSON.stringify(tok);

        var SelectGroupOptions = {};
        SelectGroupOptions.url = "/Tok/ReportTok";
        SelectGroupOptions.type = "POST";
        SelectGroupOptions.data = JSON.stringify({ group: tokString, comment: $(idCategory).val() }); //group: $("#SelectGroup").val()
        SelectGroupOptions.datatype = "json";
        SelectGroupOptions.contentType = "application/json";
        //alert(SelectGroupOptions.data.toString());

        SelectGroupOptions.success = function (GetSubtypes) {
            $("#GetSubtypes").val(JSON.stringify(GetSubtypes));

            $(idSection).css('opacity', 0);
            $(idSection)
                .css('opacity', 0)
                .slideUp(250)
                .animate(
                    { opacity: 0 },
                    { opacity: 0 },
                    { queue: false, duration: 'fast' }
                );

            $(idSection).empty();
            $(idSection).append('<div class="alert alert-success alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Success!</strong> Tok reported.</div>');
            $(idSection)
                .css('opacity', 1)
                .slideDown(500)
                .animate(
                    { opacity: 1 },
                    { queue: true, duration: 'fast' }
                );

        };
        SelectGroupOptions.error = function () {

            $(idSection).prepend('<div class="alert alert-danger alert-dismissible fade show"><a href="javascript:void(0)" class="close" data-dismiss="alert">&times;</a><strong>Error </strong> Tok could not be reported.</div>');
            $(idSection)
                .css('opacity', 1)
                .slideDown(500)
                .animate(
                    { opacity: 1 },
                    { queue: true, duration: 'fast' }
                );

        };
        $.ajax(SelectGroupOptions);
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

    //Inaccurate text required
    $("#TokFeed").on("input", ".tokviewitem .inaccuratedetailmodal .inaccuratedetaildialog .inaccuratedetailcontent .inaccuratedetailbody .inaccuratedetailform .inaccuratedetailtext", function (event) { // .inaccuratedetailcontent .inaccuratedetailform .inaccuratedetailbtngroup .inaccuratedetailbtn
        var id = $(this).attr('id').replace("-inaccuratedetailtext", "");
        var idBtn = "#inaccuratedetail-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Comment text required
    $("#TokFeed").on("input", ".tokviewitem .commentmodal .commentdialog .commentcontent .commentbody .commentform .commenttext", function (event) { // .commentcontent .commentform .commentbtngroup .commentbtn
        var id = $(this).attr('id').replace("-commenttext", "");
        var idBtn = "#comment-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });



    //Inaccurate text required
    $("#TokFeed").on("input", ".tokviewitem .inaccuratedetaildetailmodal .inaccuratedetaildetaildialog .inaccuratedetaildetailcontent .inaccuratedetaildetailbody .inaccuratedetaildetailform .inaccuratedetaildetailtext", function (event) { // .inaccuratedetaildetailcontent .inaccuratedetaildetailform .inaccuratedetaildetailbtngroup .inaccuratedetaildetailbtn
        var id = $(this).attr('id').replace("-inaccuratedetaildetailtext", "");
        var idBtn = "#inaccuratedetaildetail-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Comment text required
    $("#TokFeed").on("input", ".tokviewitem .commentdetailmodal .commentdetaildialog .commentdetailcontent .commentdetailbody .commentdetailform .commentdetailtext", function (event) { // .commentdetailcontent .commentdetailform .commentdetailbtngroup .commentdetailbtn
        var id = $(this).attr('id').replace("-commentdetailtext", "");
        var idBtn = "#commentdetail-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Report reason required
    $("#TokFeed").on("input", ".tokviewitem .reportmodal .reportdialog .reportcontent .reportbody .reportform .reportcategory", function (event) { // .reportcontent .reportform .reportbtngroup .reportbtn
        var id = $(this).attr('id').replace("-reportcategory", "");
        var idBtn = "#report-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Replicate category required
    $("#TokFeed").on("input", ".tokviewitem .replicatemodal .replicatedialog .replicatecontent .replicatebody .replicateform .replicatecategory", function (event) { // .replicatecontent .replicateform .replicatebtngroup .replicatebtn
        var id = $(this).attr('id').replace("-replicatecategory", "");
        var idBtn = "#replicate-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Edit category required
    $("#TokFeed").on("input", ".tokviewitem .editmodal .editdialog .editcontent .editbody .editform .editcategory", function (event) {
        var id = $(this).attr('id').replace("-editcategory", "");
        var idBtn = "#edit-" + id + "-button";

        if ($(this).val().length <= 0) {
            $(idBtn).prop("disabled", true);
        }
        else {
            $(idBtn).prop("disabled", false);
        }
    });

    //Translations
    $("#TokFeed").on("click", ".tokviewitem .editmodal .editdialog .editcontent .editbody .edittranslation", function (event) {
        var id = $(this).attr('id');
        var idSection = "#" + id + "ection";

        if ($(idSection).is(":visible")) {
            $(idSection).hide();
            $(this).text('Show English Translations');
        }
        else {
            $(idSection).show();
            $(this).text('Hide English Translations');
        }

    });

    //Optional fields
    $("#TokFeed").on("click", ".tokviewitem .editmodal .editdialog .editcontent .editbody .editoptional", function (event) {
        var id = $(this).attr('id');
        var idSection = "#" + id + "ection";

        if ($(idSection).is(":visible")) {
            $(idSection).hide();
            $(this).text('Show Optional Fields');
        }
        else {
            $(idSection).show();
            $(this).text('Hide Optional Fields');
        }

    });

    //Create new set
    $("#TokFeed").on("click", ".tokviewitem .addtosetmodal .addtosetdialog .addtosetcontent .addtosetbody .addtosetcreatenewset", function (event) {
        //alert('dss');
        var id = $(this).attr('id').replace('createnewset-', '');
        var idSetsSection = "#" + id + "-setssection";
        var idNewSetSection = "#" + id + "-newsetsection";
        //alert(idNewSetSection);

        //Let program know a new set is being created
        $("#selectedset-" + id).val("new");

        //Enable button
        var idBtn = "addtoset-" + id + "-button";
        $("#" + idBtn).prop("disabled", false);


        if (!$(this).hasClass("active")) {
            if (!$(idNewSetSection).is(":visible")) {
                //$(idSetsSection).hide();
                $(idNewSetSection).show();
            }
            else {
                //$(idSetsSection).show();
                $(idNewSetSection).hide();
            }
        }
    });
    
    //Dislike button click
    $("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .dislikebtn",
        function (event) {
            var id = $(this).attr('id').replace("btndislike-", "").replace("lbldislike-", "").replace("dislike-", "");
            var primaryText = $("#primarytext-" + id).val();

            var ReactionOptions = {};
            ReactionOptions.url = "/Reaction/Dislike";
            ReactionOptions.type = "POST";
            ReactionOptions.data = JSON.stringify({ group: id, detailtext: primaryText }); //group: $("#Reaction").val()
            ReactionOptions.datatype = "json";
            ReactionOptions.contentType = "application/json";

            ReactionOptions.success = function (Result) {
                $("#lbllike-" + id).text(Result[0]);
                $("#lbldislike-" + id).text(Result[1]);
                $("#lblcheck-" + id).text(Result[2]);
                $("#lblx-" + id).text(Result[3]);
                $("#lblcomment-" + id).text(Result[4]);
            };
            ReactionOptions.error = function () {
                alert("An error occured, please try again or contact an admin.");
            };
            $.ajax(ReactionOptions);


            //var id = $(this).attr('id').replace("btndislike-", "").replace("lbldislike-", "").replace("dislike-", "");
            //$("#btndislike-" + id).toggleClass("blue144");
            //$("#lbldislike-" + id).toggleClass("blue144");
        }
    );


    //Check detail button click
    $("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .checkbtn",
        function (event) {
            var idPrefix = 'check' + $(this).attr('name') + '-';
            var id = $(this).attr('id').replace(idPrefix, "");
            $('#selecteddetail-' + id).val($(this).attr('name'));
            $('#selecteddetailtext-' + id).val($('#detailtext' + $(this).attr('name') + '-' + id).val());
            //alert($('#selecteddetail-' + id).val());
        }
    );

    //x detail button click
    $("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .xbtn",
        function (event) {
            var idPrefix = 'x' + $(this).attr('name') + '-';
            var id = $(this).attr('id').replace(idPrefix, "");
            $('#selecteddetail-' + id).val($(this).attr('name'));
            $('#selecteddetailtext-' + id).val($('#detailtext' + $(this).attr('name') + '-' + id).val());
            //alert($('#selecteddetail-' + id).val());
        }
    );

    //Comment button click
    $("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .msgbtn",
        function (event) {
            var idPrefix = 'msg' + $(this).attr('name') + '-';
            var id = $(this).attr('id').replace(idPrefix, "");
            $('#selecteddetail-' + id).val($(this).attr('name'));
            $('#selecteddetailtext-' + id).val($('#detailtext' + $(this).attr('name') + '-' + id).val());
            //alert($('#selecteddetail-' + id).val());
        }
    );

    //Check detail button click
    //$("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .checkbtn",
    //    function (event) {
    //        var id = $(this).attr('id').replace("btncheck-", "").replace("lblcheck-", "").replace("check-", "");
    //        alert(id);
    //        $("#btncheck-" + id).toggleClass("green144");
    //        $("#lblcheck-" + id).toggleClass("green144");
    //    }
    //);

    //x button click
    //$("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .xbtn",
    //    function (event) {
    //        var id = $(this).attr('id').replace("btnx-", "").replace("lblx-", "").replace("x-", "");
    //        alert(id);
    //        $("#btnx-" + id).toggleClass("orange144");
    //        $("#lblx-" + id).toggleClass("orange144");
    //    }
    //);

    //Comment button click
    //$("#TokFeed").on("click", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .commentbtn",
    //    function (event) {
    //        var id = $(this).attr('id').replace("btncomment-", "").replace("lblcomment-", "");
    //        alert(id);
    //        $("#btncomment-" + id).toggleClass("lightblue144");
    //        $("#lblcomment-" + id).toggleClass("lightblue144");
    //    }
    //);

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .likebtn", function (event) {
        var id = $(this).attr('id').replace("like-", "");

        $("#btnlike-" + id).toggleClass("red144");
        $("#lbllike-" + id).toggleClass("red144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .likebtn", function (event) {
        var id = $(this).attr('id').replace("like-", "");

        $("#btnlike-" + id).toggleClass("red144");
        $("#lbllike-" + id).toggleClass("red144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .dislikebtn", function (event) {
        var id = $(this).attr('id').replace("dislike-", "");

        $("#btndislike-" + id).toggleClass("blue144");
        $("#lbldislike-" + id).toggleClass("blue144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .dislikebtn", function (event) {
        var id = $(this).attr('id').replace("dislike-", "");

        $("#btndislike-" + id).toggleClass("blue144");
        $("#lbldislike-" + id).toggleClass("blue144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .checkbtn", function (event) {
        var id = $(this).attr('id').replace("check-", "");

        $("#btncheck-" + id).toggleClass("green144");
        $("#lblcheck-" + id).toggleClass("green144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .checkbtn", function (event) {
        var id = $(this).attr('id').replace("check-", "");

        $("#btncheck-" + id).toggleClass("green144");
        $("#lblcheck-" + id).toggleClass("green144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .xbtn", function (event) {
        var id = $(this).attr('id').replace("x-", "");

        $("#btnx-" + id).toggleClass("orange144");
        $("#lblx-" + id).toggleClass("orange144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .xbtn", function (event) {
        var id = $(this).attr('id').replace("x-", "");

        $("#btnx-" + id).toggleClass("orange144");
        $("#lblx-" + id).toggleClass("orange144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .msgbtn", function (event) {
        var id = $(this).attr('id').replace("msg-", "");

        $("#btncomment-" + id).toggleClass("lightblue144");
        $("#lblcomment-" + id).toggleClass("lightblue144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactioncard .reactioncontainer .msgbtn", function (event) {
        var id = $(this).attr('id').replace("msg-", "");

        $("#btncomment-" + id).toggleClass("lightblue144");
        $("#lblcomment-" + id).toggleClass("lightblue144");
    });


    //Detail Reactions
    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .checkbtn", function (event) {
        $(this).toggleClass("green144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .checkbtn", function (event) {
        $(this).toggleClass("green144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .xbtn", function (event) {
        $(this).toggleClass("orange144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .xbtn", function (event) {
        $(this).toggleClass("orange144");
    });

    $("#TokFeed").on("mouseenter", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .msgbtn", function (event) {
        $(this).toggleClass("lightblue144");
    });

    $("#TokFeed").on("mouseleave", ".tokviewitem .tokviewsection .tokviewrow .tokviewcol .reactiondetail .msgbtn", function (event) {
        $(this).toggleClass("lightblue144");
    });



    //editoptional

});

