// Write your JavaScript code.
$(document).ready(function () { 
    $("#TokGroup").val('');
    $("#TokType").val('');

    $("#txtLanguage").prop('required', false);
    $("#txtEnglishPrimary").prop('required', false);
    $("#txtEnglishSecondary").prop('required', false);
    $("#txtEnglishDetail1").prop('required', false);
    $("#txtEnglishDetail2").prop('required', false);
    $("#txtEnglishDetail3").prop('required', false);

    //Hide section
    $("#DetailsSection").hide();
    $("#EnglishDetailsSection").hide();
    $("#EnglishSection").hide();
    $("#LanguageSection").hide();

    //Disable until Tok Type selected
    DisableTextFields();

    //$("#TokTypeExam").hide();
    $("#BtnSubmit").prop("disabled", true);
    $("#OptionalFieldHeader").hide();

    $("#SelectType").prop("disabled", true);
    $("#SelectGroup").change(function () {
        

        if ($("#SelectGroup").val() != 'Choose') {

            var SelectGroupOptions = {};
            SelectGroupOptions.url = "/Tok/GetSubtypes";
            SelectGroupOptions.type = "POST";
            SelectGroupOptions.data = JSON.stringify({ group: $("#SelectGroup").val() }); //group: $("#SelectGroup").val()
            SelectGroupOptions.datatype = "json";
            SelectGroupOptions.contentType = "application/json";
            //alert(SelectGroupOptions.data.toString());

            SelectGroupOptions.success = function (GetSubtypes) {
                $("#GetSubtypes").val(JSON.stringify(GetSubtypes));

                //Disable until Tok Type selected
                DisableTextFields();

                //---Character limits------------
                var primaryLimit = GetSubtypes.primary_char_limit;
                var secondaryLimit = GetSubtypes.secondary_char_limit;

                $("#PrimaryLimit").val(primaryLimit);
                $("#SecondaryLimit").val(secondaryLimit);

                $("#txtPrimary").attr('maxlength', primaryLimit);
                $("#txtSecondary").attr('maxlength', secondaryLimit);

                for (var i = 1; i <= 10; i++) {
                    $("#txtDetail" + i).attr('maxlength', secondaryLimit);
                    $("#txtEnglishDetail" + i).attr('maxlength', secondaryLimit);
                }

                $("#txtEnglishPrimary").attr('maxlength', primaryLimit);
                $("#txtEnglishSecondary").attr('maxlength', secondaryLimit);
                
                var requiredfields = GetSubtypes.required_fields;
                //--------------------------------

                //Group Info
                $("#TokGroupName").text(GetSubtypes.tok_group);
                $("#TokGroupDesc").text(GetSubtypes.description);

                $(".txtTokGroup_Preview").html(GetSubtypes.tok_group);

                //
                if ($("#TokGroupDesc").text() == '') {
                    $("#TokGroupDesc").text('Please select a Tok Group');
                    $("#TokGroupTokstar").animate({ marginTop: '0em' }, 200);
                }
                else {
                    //$("#TokGroupTokstar").animate({ marginTop: '1.5em' }, 200);
                }

                //Type Info
                $("#TokTypeName").text('Tok Type');
                $("#TokTypeDesc").text('');
                $("#TokTypeExam").text('');
                //$("#TokTypeExam").hide();//no need to hide


                $("#SelectType").empty();
                $("#SelectType").append("<option value=\"Choose\">Choose...</option>");

                for (var i = 0; i < GetSubtypes.tok_types.length; ++i) {
                    var typeVal = "desc1" + GetSubtypes.descriptions[i] + "desc2" + "exam1" + GetSubtypes.examples[i] + "exam2"; 
                    //var typeValJson = JSON.stringify(typeVal);
                    $("#SelectType").append("<option value=\"" + typeVal + "\">" + GetSubtypes.tok_types[i] + "</option>");
                }
                $("#SelectType").prop("disabled", false);

                //Detail Based Switch
                if (GetSubtypes.is_detail_based == true) {
                    $("#DetailBased").val(true);
                    $("#DetailsSection").show();
                    $("#SecondaryFieldSection").hide();

                    $("#EnglishDetailsSection").show();
                    $("#EnglishSecondaryFieldSection").hide();
                }
                else {
                    $("#DetailBased").val(false);
                    $("#DetailsSection").hide();
                    $("#SecondaryFieldSection").show();

                    $("#EnglishDetailsSection").hide();
                    $("#EnglishSecondaryFieldSection").show();
                }

                //Field Names
                $("#lblPrimaryNum").text("");
                $("#TokGroup").val($("#SelectGroup").find(":selected").text());
                //$("#TokType").val($("#SelectType").find(":selected").text());
                $("#TokType").val('');
                $("#PrimaryFieldLabel").text(GetSubtypes.primary_field_name);
                $("#SecondaryFieldLabel").text(GetSubtypes.secondary_field_name);
                $("#btnAddMoreDetail").text("+ Add " + GetSubtypes.secondary_field_name);
                $("#PrimaryFieldName").val(GetSubtypes.primary_field_name);
                $("#SecondaryFieldName").val(GetSubtypes.secondary_field_name);

                $("#EnglishPrimaryFieldLabel").text(GetSubtypes.primary_field_name + " - English Translation");
                $("#EnglishSecondaryFieldLabel").text(GetSubtypes.secondary_field_name + " - English Translation");

                //Detail Names
                for (var i = 1; i <= 10; i++) {
                    $("#Detail" + i).text(GetSubtypes.secondary_field_name + " " + i);
                    $("#txtDetail" + i).text("");
                    $("#divDetail" + i).find(".btnRemoveDetail").attr("title", "Remove " + GetSubtypes.secondary_field_name);
                    $("#divDetail" + i).find(".btnRemoveDetail").attr("data-original-title", "Remove " + GetSubtypes.secondary_field_name);

                    $("#EnglishDetail" + i).text(GetSubtypes.secondary_field_name + " " + i + "- English Translation");
                    $("#txtEnglishDetail" + i).text("");

                    if (i > 3) {
                        $("#divDetail" + i).addClass("hide");
                        $("#divEnglishDetail" + i).addClass("hide");
                    }
                }

                $("#OptionalFieldHeader").show();
                $("#OptionalFieldsSection").empty();

                $("#OptionalFieldsSection").append('<h4 class="mb-3">Optional Fields</h4>');
                for (var j = 0; j < GetSubtypes.optional_fields.length; ++j) {
                    //Append hiddens to store optional field names
                    $("#OptionalFieldsSection").append('<input name="Tok.optional_fields[' + j + ']" id="OptionalFields[' + j + ']" type="hidden" value="' + GetSubtypes.optional_fields[j] + '">');

                    //Append all optional fields
                    $("#OptionalFieldsSection").append(
                        ('<div class="mb-3">' +
                            '<label id="' + GetSubtypes.optional_fields[j] + '">' + GetSubtypes.optional_fields[j] + ' <span class="text-muted">(' + GetSubtypes.optional_limits[j] +' characters max)</span></label>' +
                            '<input name="Tok.OptionalFieldValues[' + j + ']" class="form-control text-box single-line optionalfield" id="Tok_OptionalFieldValues[' + j + ']" type="text" value="" maxlength="' + GetSubtypes.optional_limits[j] + '">' +
                            '<h6 id="lblOptionalField' + j + '"></h6>' +
                            '<div class="invalid-feedback">Please enter a valid value.</div>' +
                            '</div>')
                    );
                }

                $("#RequiredFieldsSection").empty();
                $("#RequiredFieldCount").val(GetSubtypes.required_fields.length);


                if (GetSubtypes.required_fields.length > 0) {

                    $("#RequiredPrompt").hide();
                    $("#RequiredFieldsSection").show();

                    $("#RequiredFieldsSection").empty();

                    for (var j = 0; j < GetSubtypes.required_fields.length; ++j) {
                        //Append hiddens to store required field names
                        $("#RequiredFieldsSection").append('<input name="Tok.required_fields[' + j + ']" id="RequiredFields[' + j + ']" type="hidden" value="' + GetSubtypes.required_fields[j] + '">');

                        //Append all required fields
                        $("#RequiredFieldsSection").append(
                            ('<div class="mb-3">' +
                                '<label id="' + GetSubtypes.required_fields[j] + '">' + GetSubtypes.required_fields[j] + '</label>' +
                                '<input name="Tok.RequiredFieldValues[' + j + ']" class="form-control text-box single-line" id="Tok_RequiredFieldValues[' + j + ']" type="text" value="" maxlength="100" required>' +
                                '<div class="invalid-feedback">Please enter a valid value.</div>' +
                                '</div>')
                        );
                    }

                }//emnd required length
                else {
                    $("#RequiredPrompt").hide();
                    $("#RequiredFieldsSection").hide();

                }

                

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
        $(".txtTokType_Preview").html(selectedType);
        $("#txtPrimary").prop("disabled", false);
        //$("#BtnSubmit").prop("disabled", false);

        $("#txtLanguage").prop("disabled", false);
        $("#txtEnglishPrimary").prop("disabled", false);
        

        //Detail Based Switch
        if ($("#DetailBased").val() == "true") {
            $("#txtSecondary").prop("disabled", true);
            $("#txtEnglishSecondary").prop("disabled", true);

            $("#txtDetail1").prop("disabled", false);
            $("#txtDetail2").prop("disabled", false);
            $("#txtDetail3").prop("disabled", false);
            $("#txtDetail4").prop("disabled", false);
            $("#txtDetail5").prop("disabled", false);

            $("#txtEnglishDetail1").prop("disabled", false);
            $("#txtEnglishDetail2").prop("disabled", false);
            $("#txtEnglishDetail3").prop("disabled", false);
            $("#txtEnglishDetail4").prop("disabled", false);
            $("#txtEnglishDetail5").prop("disabled", false);
        }
        else {
            $("#txtSecondary").prop("disabled", false);
            $("#txtEnglishSecondary").prop("disabled", false);

            $("#txtDetail1").prop("disabled", true);
            $("#txtDetail2").prop("disabled", true);
            $("#txtDetail3").prop("disabled", true);
            $("#txtDetail4").prop("disabled", true);
            $("#txtDetail5").prop("disabled", true);

            $("#txtEnglishDetail1").prop("disabled", true);
            $("#txtEnglishDetail2").prop("disabled", true);
            $("#txtEnglishDetail3").prop("disabled", true);
            $("#txtEnglishDetail4").prop("disabled", true);
            $("#txtEnglishDetail5").prop("disabled", true);
        }

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

    });   //On Change Type

    function DisableTextFields() {
        $("#txtLanguage").prop("disabled", true);

        $("#txtPrimary").prop("disabled", true);
        $("#txtSecondary").prop("disabled", true);
        $("#txtDetail1").prop("disabled", true);
        $("#txtDetail2").prop("disabled", true);
        $("#txtDetail3").prop("disabled", true);
        $("#txtDetail4").prop("disabled", true);
        $("#txtDetail5").prop("disabled", true);

        $("#txtEnglishPrimary").prop("disabled", true);
        $("#txtEnglishSecondary").prop("disabled", true);
        $("#txtEnglishDetail1").prop("disabled", true);
        $("#txtEnglishDetail2").prop("disabled", true);
        $("#txtEnglishDetail3").prop("disabled", true);
        $("#txtEnglishDetail4").prop("disabled", true);
        $("#txtEnglishDetail5").prop("disabled", true);

        $("#BtnSubmit").prop("disabled", true);
    }


    $("#BtnExam").on('click', function () {
        if ($("#TokTypeExam").is(":visible")) {
            $("#TokTypeExam").hide();
        }
        else {
            $("#TokTypeExam").show();
        }
    });



    $("#txtCategory").on('input', function () {
        $('#lblCategoryNum').text((50 - $("#txtCategory").val().length));
        if ($("#txtCategory").val().length == 0) {
            $('#lblCategoryNum').text('');
        }

        $(".txtCategory_Preview").html($("#txtCategory").val()); 
        if ($("#txtSecondary").val().length == 0) {
            $("#tokCardItem .txtCategory_Preview").removeClass("hide");
            $(".txtSecondaryField_Preview").addClass("hide");
        }
        else {
            if (!$("#tokCardItem .txtCategory_Preview").hasClass("hide")) { $("#tokCardItem .txtCategory_Preview").addClass("hide"); }
            $(".txtSecondaryField_Preview").removeClass("hide");
        }
        enableSubmitButton();
    });

    $("#txtLanguage").on('input', function () {
        $('#lblLanguage').text((25 - $("#txtLanguage").val().length));
        if ($("#txtLanguage").val().length == 0) {
            $('#lblLanguage').text('');
        }

        enableSubmitButton();
    });

    $("#chkEnglish").on('click', function () {


        if ($("#ChkEnglish").is(':checked')) {
            $("#EnglishSection").hide();

            $("#txtLanguage").prop('required', false);
            $("#txtEnglishPrimary").prop('required', false);
            $("#txtEnglishSecondary").prop('required', false);
            $("#txtEnglishDetail1").prop('required', false);
            $("#txtEnglishDetail2").prop('required', false);
            $("#txtEnglishDetail3").prop('required', false);

            $("#LanguageSection").hide();
            //$("#LanguageSection").prop("disabled", true);
            $("#txtLanguage").text("English");
        }
        else {
            $("#EnglishSection").show();

            $("#txtLanguage").prop('required', true);
            $("#txtEnglishPrimary").prop('required', true);
            $("#txtEnglishSecondary").prop('required', true);
            $("#txtEnglishDetail1").prop('required', true);
            $("#txtEnglishDetail2").prop('required', true);
            $("#txtEnglishDetail3").prop('required', true);

            $("#LanguageSection").show();
            //$("#LanguageSection").prop("disabled", false);
            $("#txtLanguage").text('');
        }
        enableSubmitButton();
        //$("#txtEnglishPrimary").removeAttr('required');
        //$("#txtEnglishSecondary").removeAttr('required');
        //$("#txtEnglishDetail1").removeAttr('required');
        //$("#txtEnglishDetail2").removeAttr('required');
        //$("#txtEnglishDetail3").removeAttr('required');
        //$("#txtEnglishDetail4").removeAttr('required');
        //$("#txtEnglishDetail5").removeAttr('required');
    });

    $("#txtPrimary").on('input', function () {
        var max = $("#PrimaryLimit").val();
        $('#lblPrimaryNum').text((max - $("#txtPrimary").val().length));


        if ($("#txtPrimary").val().length == 0) {
            $('#lblPrimaryNum').text('');
        }

        $(".txtBodyContent_Preview").html($("#txtPrimary").val());
        if ($("#txtPrimary").val().length >= 100) {
            $(".txtBodyContent_CardPreview").html($("#txtPrimary").val());
            $(".txtBodyContent_CardPreview").css("font-size", "16px");
        }
        else {
            $(".txtBodyContent_CardPreview").html($("#txtPrimary").val());
        }
        enableSubmitButton();
    });

    $("#txtSecondary").on('input', function () {
        var max = $("#SecondaryLimit").val();
        $('#lblSecondaryNum').text((max - $("#txtSecondary").val().length));

        if ($("#txtSecondary").val().length == 0) {
            $('#lblSecondaryNum').text('');
        }

        $(".txtSecondaryField_Preview").text($("#txtSecondary").val());
        enableSubmitButton();
    });

    $("#txtDetail1,#txtDetail2,#txtDetail3,#txtDetail4,#txtDetail5,#txtDetail6,#txtDetail7,#txtDetail8,#txtDetail9,#txtDetail10")
    .on('input', function () {
        var max = $("#SecondaryLimit").val();
        var lblCounterName = "#" + $(this).attr("id").replace("txt", "lbl") + "Num";
        console.log(lblCounterName);    
        $(lblCounterName).text((max - $(this).val().length));

        if ($(this).val().length == 0) {
            $(lblCounterName).text('');
        }

        enableSubmitButton();
    });

    //$("#txtDetail2").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblDetail2Num').text((max - $("#txtDetail2").val().length));

    //    if ($("#txtDetail2").val().length == 0) {
    //        $('#lblDetail2Num').text('');
    //    }

    //    enableSubmitButton();
    //});

    //$("#txtDetail3").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblDetail3Num').text((max - $("#txtDetail3").val().length));

    //    if ($("#txtDetail3").val().length == 0) {
    //        $('#lblDetail3Num').text('');
    //    }

    //    enableSubmitButton();
    //});

    //$("#txtDetail4").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblDetail4Num').text((max - $("#txtDetail4").val().length));

    //    if ($("#txtDetail4").val().length == 0) {
    //        $('#lblDetail4Num').text('');
    //    }
    //});

    //$("#txtDetail5").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblDetail5Num').text((max - $("#txtDetail5").val().length));

    //    if ($("#txtDetail5").val().length == 0) {
    //        $('#lblDetail5Num').text('');
    //    }
    //});

    //ENGLISH FIELD COUNTERS
    $("#txtEnglishPrimary").on('input', function () {
        var max = $("#PrimaryLimit").val();
        $('#lblEnglishPrimaryNum').text((max - $("#txtEnglishPrimary").val().length));


        if ($("#txtEnglishPrimary").val().length == 0) {
            $('#lblEnglishPrimaryNum').text('');
        }

        enableSubmitButton();
    });

    $("#txtEnglishSecondary").on('input', function () {
        var max = $("#SecondaryLimit").val();
        $('#lblEnglishSecondaryNum').text((max - $("#txtEnglishSecondary").val().length));

        if ($("#txtEnglishSecondary").val().length == 0) {
            $('#lblEnglishSecondaryNum').text('');
        }

        enableSubmitButton();
    });

    $("#txtEnglishDetail1,#txtEnglishDetail2,#txtEnglishDetail3,#txtEnglishDetail4,#txtEnglishDetail5,#txtEnglishDetail6,#txtEnglishDetail7,#txtEnglishDetail8,#txtEnglishDetail9,#txtEnglishDetail10")
    .on('input', function () {
        var max = $("#SecondaryLimit").val();
        var lblCounterName = "#" + $(this).attr("id").replace("txt", "lbl") + "Num";
        console.log(lblCounterName);    
        $(lblCounterName).text((max - $(this).val().length));

        if ($(this).val().length == 0) {
            $(lblCounterName).text('');
        }

        enableSubmitButton();
    });

    //$("#txtEnglishDetail2").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblEnglishDetail2Num').text((max - $("#txtEnglishDetail2").val().length));

    //    if ($("#txtEnglishDetail2").val().length == 0) {
    //        $('#lblEnglishDetail2Num').text('');
    //    }

    //    enableSubmitButton();
    //});

    //$("#txtEnglishDetail3").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblEnglishDetail3Num').text((max - $("#txtEnglishDetail3").val().length));

    //    if ($("#txtEnglishDetail3").val().length == 0) {
    //        $('#lblEnglishDetail3Num').text('');
    //    }

    //    enableSubmitButton();
    //});

    //$("#txtEnglishDetail4").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblEnglishDetail4Num').text((max - $("#txtEnglishDetail4").val().length));

    //    if ($("#txtEnglishDetail4").val().length == 0) {
    //        $('#lblEnglishDetail4Num').text('');
    //    }
    //});

    //$("#txtEnglishDetail5").on('input', function () {
    //    var max = $("#SecondaryLimit").val();
    //    $('#lblEnglishDetail5Num').text((max - $("#txtEnglishDetail5").val().length));

    //    if ($("#txtEnglishDetail5").val().length == 0) {
    //        $('#lblEnglishDetail5Num').text('');
    //    }
    //});

    $("#txtNotes").on('input', function () {
        var max = 2000;
        $('#lblNotesNum').text((max - $("#txtNotes").val().length));

        if ($("#txtNotes").val().length == 0) {
            $('#lblNotesNum').text('');
        }
    });

    $(".overcontent1").hide();
    $(".overcontent2").hide();
    $(".overcontent3").hide();
    $(".overcontent4").hide();
    $(".overparrot").hide();
    
    $("#BtnSubmit").on("click", //$("#BtnSubmit") .overtext
        function (event) {
            // Properties for validation
            var cat = $("#txtCategory").val();
            var type = $("#SelectType > option:selected").text();
            var field1 = $("#txtPrimary").val();
            var field2 = $("#txtSecondary").val();

            console.log($("#Base64Image").val());

            // Validate inputs
            if (compareStr(cat, type)) {
                var feedback = $("#txtCategory").parent().find(".invalid-feedback");
                feedback.css("display", "block");
                feedback.text("Category must not be the same with Tok Type.");
                return;
            }

            // Primary Field
            if (compareStr(field1, cat)) {
                var title = $("#txtPrimary").parent().find("#PrimaryFieldLabel").text();
                var feedback = $("#txtPrimary").parent().find(".invalid-feedback");
                feedback.css("display", "block");
                feedback.text(title + " must not contain a category.");
                return;
            }

            // Details
            if ($("#DetailBased").val() === "true") {
                var found = false;
                $("#DetailsSection").each(function () {
                    var val = $(this).find("input").val();
                    if (compareStr(val, cat)) {
                        var feedback = $(this).find(".invalid-feedback");
                        feedback.css("display", "block");
                        feedback.text("Detail must not contain a category.");
                        found = true;
                    }
                });
                if (found) return; // Return if there's an invalid input
            }
            else {
                // Secondary Field
                if (compareStr(field2, cat)) {
                    var title = $("#txtSecondary").parent().find("#SecondaryFieldLabel").text();
                    var feedback = $("#txtSecondary").parent().find(".invalid-feedback");
                    feedback.css("display", "block");
                    feedback.text(title + " must not contain a category.");
                    return;
                }
            }


            // If it goes here, the inputs are valid.
            // Validated and Submit Tok
            $("#frmAddTok").submit();
        }
    );

    function compareStr(str = "", toCompareStr = "") {
        return str.length > 0 && toCompareStr.length > 0 ? (str.toLowerCase().indexOf(toCompareStr.toLowerCase()) >= 0) : false;
    }

    function enableSubmitButton() {
        if ($("#TokGroup").val() !== '' && $("#TokType").val() !== '' && $("#txtCategory").val().length > 0 && $("#txtPrimary").val().length > 0) {
            //if detail
            var detailed = false;
            var preLanguageVerified = false;
            if ($("#DetailBased").val() === "true") { detailed = true; }
            else { detailed = false; }



            if (detailed) { //3 details
                if ($("#txtDetail1").val().length > 0 && $("#txtDetail2").val().length > 0 && $("#txtDetail3").val().length > 0) {
                    $("#BtnSubmit").prop("disabled", false);
                    preLanguageVerified = true;
                }
                else { $("#BtnSubmit").prop("disabled", true); }
            }
            else {  //Secondary
                if ($("#txtSecondary").val().length > 0) { $("#BtnSubmit").prop("disabled", false); preLanguageVerified = true; }
                else { $("#BtnSubmit").prop("disabled", true); }
            }

            var isEnglish = $("#ChkEnglish").is(':checked');

            if (!isEnglish && preLanguageVerified) {

                if ($("#txtLanguage").val().length > 0 && $("#txtEnglishPrimary").val().length > 0) {

                    if (detailed) { //3 details
                        if ($("#txtEnglishDetail1").val().length > 0 && $("#txtEnglishDetail2").val().length > 0 && $("#txtEnglishDetail3").val().length > 0) {
                            $("#BtnSubmit").prop("disabled", false);
                        }
                        else { $("#BtnSubmit").prop("disabled", true); }
                    }
                    else {  //Secondary
                        if ($("#txtEnglishSecondary").val().length > 0) { $("#BtnSubmit").prop("disabled", false); }
                        else { $("#BtnSubmit").prop("disabled", true); }
                    }

                }
                else { $("#BtnSubmit").prop("disabled", true); }
            }
            else if (isEnglish && preLanguageVerified) {
                $("#BtnSubmit").prop("disabled", false);
            }
            else { $("#BtnSubmit").prop("disabled", true); }
        }
        else {
            $("#BtnSubmit").prop("disabled", true);
        }
    }

    




    //-----IMAGE UPLOAD CODE----
    /*jslint browser: true, white: true, eqeq: true, plusplus: true, sloppy: true, vars: true*/
    /*global $, console, alert, FormData, FileReader*/


    function noPreview() {
        $('#image-preview-div').css("display", "none");
        $('#preview-img').attr('src', '');
        $('upload-button').attr('disabled', '');
    }

    function selectImage(e) {
        $('#file').css("color", "green");
        $('#image-preview-div').css("display", "block");
        $("#Base64Image").val(e.target.result);
        $("#Base64Image").prop("value", e.target.result);
        $("#Base64Image").attr("value", e.target.result);
        $('#preview-img').attr('src', e.target.result);
        $('#preview-img').css('max-width', '550px');
        $('#txtTokTileImage_Preview').attr('src', e.target.result);
        $('#txtTokCardImage_Preview img').attr('src', e.target.result);
        $('#txtTokCardImage_Preview').removeClass("hide");
        $('#tokTileNormal_Preview').hide();
        $('#tokTilewithImage_Preview').show();
    }

    $(document).ready(function (e) {
        $("#txtLanguage").prop('required', false);
        $("#txtEnglishPrimary").prop('required', false);
        $("#txtEnglishSecondary").prop('required', false);
        $("#txtEnglishDetail1").prop('required', false);
        $("#txtEnglishDetail2").prop('required', false);
        $("#txtEnglishDetail3").prop('required', false);

        var maxsize = 5000 * 1024; // 500 KB

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

                $('#message').html('<div class=\"alert alert-danger\" role=\"alert\">The size of image you are attempting to upload is ' + (file.size / 1024).toFixed(2) + ' KB, maximum size allowed is ' + (maxsize / 1024).toFixed(0) + ' KB</div>');

                return false;
            }

            $('#upload-button').removeAttr("disabled");

            var reader = new FileReader();
            reader.onload = selectImage;
            reader.readAsDataURL(this.files[0]);

        });

    });


    



});//Document ready

