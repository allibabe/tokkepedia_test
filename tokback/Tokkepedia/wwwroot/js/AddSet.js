//-----IMAGE UPLOAD CODE----
/*jslint browser: true, white: true, eqeq: true, plusplus: true, sloppy: true, vars: true*/
/*global $, console, alert, FormData, FileReader*/

var uploadCrop;

function noPreview() {
    $('#image-preview-div').css("display", "none");
    //$('#preview-img').attr('src', '');
    $('upload-button').attr('disabled', '');
}

function selectImage(e) {
    $('#resizer').addClass('ready');
    uploadCrop.croppie('bind', {
        url: e.target.result
    }).then(function () {
        //console.log('jQuery bind complete');
    });
    $('#file').css("color", "green");
    $('#image-preview-div').css("display", "block");
    //$('#preview-img').attr('src', e.target.result);
    //$('#preview-img').css('max-width', '550px');
}

function enableSubmitButton() {
    if ($("#TokGroup").val() !== '' && $("#TokType").val() !== '' && $("#txtName").val().length > 0) {
        $("#BtnSubmit").prop("disabled", false);
    }
    else {
        $("#BtnSubmit").prop("disabled", true);
    }
}

$(document).ready(function (e) {

    $("#BtnSubmit").prop("disabled", true);
    var maxsize = 500 * 1024; // 500 KB

    uploadCrop = $('#resizer').croppie({
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

    $("#BtnSubmit").click(function () {
        uploadCrop.croppie('result', {
            type: 'canvas',
            size: 'viewport'
        }).then(function (resp) {
            $("#Base64Image").val(resp);
        });

        setTimeout(function () {
            $("#frmAddSet").submit();
        }, 1000);
    });

    $('#max-size').html((maxsize / 1024).toFixed(2));

    $('#pic').change(function () {

        $('#message').empty();

        var file = this.files[0];
        var match = ["image/jpeg", "image/png", "image/jpg"];

        if (!((file.type == match[0]) || (file.type == match[1]) || (file.type == match[2]))) {
            noPreview();

            $('#message').html('<div class="alert alert-warning" role="alert">Invalid image format. Allowed formats: JPG, JPEG, PNG.</div>');

            return false;
        }

        if (file.size > maxsize) {
            noPreview();

            $('#message').html('<div class=\"alert alert-danger\" role=\"alert\">The size of image you are attempting to upload is ' + (file.size / 1024).toFixed(2) + ' KB, maximum size allowed is ' + (maxsize / 1024).toFixed(2) + ' KB</div>');

            return false;
        }

        $('#upload-button').removeAttr("disabled");

        var reader = new FileReader();
        reader.onload = selectImage;
        reader.readAsDataURL(this.files[0]);

    });

    $("#txtName").on('input', function () {
        enableSubmitButton();
    });

    //Tok Type code
    $("#SelectType").prop("disabled", true);
    $("#SelectGroup").change(function () {


        if ($("#SelectGroup").val() !== 'Choose') {

            var SelectGroupOptions = {};
            SelectGroupOptions.url = "/Tok/GetSubtypes";
            SelectGroupOptions.type = "POST";
            SelectGroupOptions.data = JSON.stringify({ group: $("#SelectGroup").val() }); //group: $("#SelectGroup").val()
            SelectGroupOptions.datatype = "json";
            SelectGroupOptions.contentType = "application/json";
            //alert(SelectGroupOptions.data.toString());

            SelectGroupOptions.success = function (GetSubtypes) {
                $("#GetSubtypes").val(JSON.stringify(GetSubtypes));


                var requiredfields = GetSubtypes.required_fields;
                //--------------------------------

                //Group Info
                $("#TokGroupName").text(GetSubtypes.tok_group);
                $("#TokGroupDesc").text(GetSubtypes.description);

                //
                if ($("#TokGroupDesc").text() === '') {
                    $("#TokGroupDesc").text('Please select a Tok Group');
                    $("#TokGroupTokstar").animate({ marginTop: '0em' }, 200);
                }
                else {
                    $("#TokGroupTokstar").animate({ marginTop: '1.5em' }, 200);
                }

                //Type Info
                $("#TokTypeName").text('Tok Type');
                $("#TokTypeDesc").text('');
                $("#TokTypeExam").text('');


                $("#SelectType").empty();
                $("#SelectType").append("<option value=\"Choose\">Choose...</option>");
                for (var i = 0; i < GetSubtypes.tok_types.length; ++i) {
                    var typeVal = "desc1" + GetSubtypes.descriptions[i] + "desc2" + "exam1" + GetSubtypes.examples[i] + "exam2";
                    //var typeValJson = JSON.stringify(typeVal);
                    $("#SelectType").append("<option value=\"" + typeVal + "\">" + GetSubtypes.tok_types[i] + "</option>");
                }
                $("#SelectType").prop("disabled", false);

                //Field Names
                $("#TokGroup").val($("#SelectGroup").find(":selected").text());
                //$("#TokType").val($("#SelectType").find(":selected").text());
                $("#TokType").val('');



            };
            SelectGroupOptions.error = function () { alert("Please select a Tok Group."); };
            $.ajax(SelectGroupOptions);
        }
        else {
            $("#SelectType").empty();
            $("#SelectType").prop("disabled", true);
        }


    }); //On Change Group

    $("#SelectType").change(function () {
        var selectedType = $("#SelectType").find(":selected").text();
        $("#TokType").val(selectedType);
        
        var ft = $("#SelectType").val();
        //alert(ft);
        var tf = "-desc1---desc2-";
        var desc1 = "desc1";
        var desc2 = "desc2";
        var exam1 = "exam1";
        var exam2 = "exam2";

        var subStr = ft.match(desc1 + "(.*)" + desc2);
        var example = ft.match(exam1 + "(.*)" + exam2);
        //alert(subStr[1]);

        //Type Info
        $("#TokTypeName").text(selectedType);
        $("#TokTypeDesc").text(subStr[1]);
        $("#TokTypeExam").text('Example: ' + example[1]);
        enableSubmitButton();

    });   //On Change Type

});