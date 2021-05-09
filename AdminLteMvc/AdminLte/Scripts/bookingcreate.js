$(function () {
    //$("#bookingno").chosen();
    $("#authorizedtrucker").chosen();
    $("#issuedby").chosen();
    $("#cvno").chosen();

});

$("#atwyear").css("display", "none");
$("#atwbkid").css("display", "none");
$("#transSelect").css("display", "none");
$("#bkno").css("display", "none");
$("#cvnos").css("display", "none");
$("#shippers").css("display", "none");

$(document).ready(function () {
    $('#issuedate').on("change", function () {
        var tt = document.getElementById('issuedate').value;

        var today = new Date(tt);
        var dd = today.getDate() + 2;
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }

        today = yyyy + '-' + mm + '-' + dd;
        document.getElementById("expirydate").value = today;

        var yearInput = yyyy.toString()

        $.ajax({
            url: '../../../ATW/GetIDSFromYear',
            type: 'GET',
            data: { yearInput: yearInput },
            contentType: "application/json",
            success: function (ids) {
                console.log("I'M HERE");
                console.log(ids);
                var docFormatted = 'ATW-' + yearInput + '-' + ids;
                document.getElementById("atwno").value = docFormatted;
                document.getElementById("atwyear").value = yearInput;
                document.getElementById("atwbkid").value = ids;
                document.getElementById("bkno").value = yearInput + '-' + ids;
            },
        });
    });

    //$('#bookingno').on("change", function () {
    //    var bookingNum = document.getElementById('bookingno').value;
    //    //alert(bookingNum);

    //    var bknumber = bookingNum.toString();

    //    $.ajax({
    //        url: '../../../ATW/GetATWTrnDetails',
    //        type: 'get',
    //        data: { bknumber: bknumber },
    //        contenttype: "application/json",
    //        success: function (company) {
    //            console.log(company);
    //            $("table tbody").empty();
    //            for (var i = 0; i < company.trndetail.length; i++) {
    //                var markup = "<tr><td><input type='checkbox' id='trnchoices' name='trnsction' value='" + company.trndetail[i].transactionNo + "'></td><td>"
    //                    + company.trndetail[i].transactionNo + "</td><td>"
    //                    + company.trndetail[i].serviceType + "</td><td>"
    //                    + company.cname + "</td><td>"
    //                    + company.trndetail[i].origin + "</td><td>"
    //                    + company.trndetail[i].destination + "</td><td>"
    //                    + company.trndetail[i].consignee + "</td></tr>";
    //                $("table tbody").append(markup);
    //            }
    //            function checkTrns() {
    //                var len = $("input[name='trnsction']:checked").length;
    //                if (len > 2) { $.notify("Maximum of 2 CV's only.", "error");}
    //            }

    //            $("input:checkbox").on("change", function () {
    //                checkTrns();
    //            });
    //        },
    //    });

    //})



    $('#submit').click(function () {
        var isAllValid = true;
        var d1 = new Date($('#issuedate').val());
        var d2 = new Date($('#expirydate').val());
        if (d2 < d1) {
            $.notify("Expiry date must not be before with the issued date.", "error");
            isAllValid = false;
        }

        var transactionList = $('#transSelect').val().split(',');
        if (transactionList.length > 2) {
            $.notify("Maximum of 2 CV's only.", "error");
            isAllValid = false;
        }
        if ($('#transSelect').val() == '') {
            $.notify("Please select at least 1 CV to withdraw.", "error");
            isAllValid = false;
        }

        //if ($("input:checkbox:checked").length < 1) {
        //    $.notify("Must select at least 1 CV to proceed.", "error");
        //    isAllValid = false;
        //}
        //else if ($("input:checkbox:checked").length > 2) {
        //    $.notify("Maximum of 2 CV's allowed.", "error");
        //    isAllValid = false;}
        //else {
        //    var trnArray = [];
        //    $("table tbody").find('input[name="trnsction"]').each(function () {
        //        if ($(this).is(":checked")) {
        //            trnArray.push($(this).val());
        //        }
        //    });
        //    console.log(trnArray);
        //    var trns = trnArray.join();
        //    document.getElementById("transSelect").value = trns;
        //}


        //var bk = $('#bookingno').find(":selected").val();
        //var convan = $('#cvno').find(":selected").val();
        var at = $('#authorizedtrucker').find(":selected").val();
        var ab = $('#issuedby').find(":selected").val();

        if ($('#issuedate').val().trim() == '') {
            $.notify("Issue Date is required.", "error");
            isAllValid = false;
        }

        if ($('#atwno').val().trim() == '') {
            $.notify("ATW No is required.", "error");
            isAllValid = false;
        }

        //if (bk === '0' || $('#bookingno').val().trim() == '') {
        //    $.notify("Booking No is required.", "error");
        //    isAllValid = false;
        //}

        //if (convan === '0') {
        //    $.notify("ConVan No is required.", "error");
        //    isAllValid = false;
        //}

        if (at === '0' || $('#authorizedtrucker').val().trim() == '') {
            $.notify("Authorized Trucker is required.", "error");
            isAllValid = false;
        }

        if (ab === '0' || $('#issuedby').val().trim() == '') {
            $.notify("ATW Issued By is required.", "error");
            isAllValid = false;
        }

        if ($('#expirydate').val().trim() == '') {
            $.notify("Expiry Date is required.", "error");
            isAllValid = false;
        }

        if ($('#authorizeddriver').val().trim() == '') {
            $.notify("Authorized Driver is required.", "error");
            isAllValid = false;
        }

        if ($('#plateno').val().trim() == '') {
            $.notify("Truck Plate No. is required.", "error");
            isAllValid = false;
        }

        //if ($('#remarks').val().trim() == '') {
        //    $.notify("Remarks is required.", "error");
        //    isAllValid = false;
        //}

        var transactionnos = $('#transSelect').val().split(',');
        var CVS = $('#cvnos').val().split(',');
        var SHIPPERS = $('#shippers').val().split(',');
        trn1 = transactionnos[0];
        trn2 = transactionnos[1];
        cvno1 = CVS[0];
        cvno2 = CVS[1];
        ship1 = SHIPPERS[0];
        ship2 = SHIPPERS[1];

        if (isAllValid) {


            var dataHdr = {
                bkNo: $('#bkno').val(),
                atwBkNo: $('#atwno').val(),
                iDate: $('#issuedate').val(),
                eDate: $('#expirydate').val(),
                transactionno1: trn1,
                convanno1: cvno1,
                shipperno1: ship1,
                transactionno2: trn2,
                convanno2: cvno2,
                shipperno2: ship2,
                issuedBy: $('#issuedby').val(),
                cvno: $('#cvno').val(),
                aDriver: $('#authorizeddriver').val(),
                aTrucker: $('#authorizedtrucker').val(),
                plateNo: $('#plateno').val(),
                remarks: $('#remarks').val(),
                atwYear: $('#atwyear').val(),
                atwBkID: $('#atwbkid').val(),
                trns: $('#transSelect').val(),
                atwStatus: "Active"
            }

            console.log(dataHdr);

            $.ajax({
                type: 'POST',
                url: '../../../ATW/SaveHdr',
                data: JSON.stringify(dataHdr),
                contentType: 'application/json',
                success: function (dataHdr) {
                    if (dataHdr.status) {
                        console.log(dataHdr);
                        $.notify("Operation successfully posted.", "success");
                        var r = confirm("Would like to add another ATW?");
                        if (r == true) {
                            var url = '@Url.Action("Create", "ATW")';
                            window.location.href = url;
                        } else {
                            var url = '@Url.Action("Index", "ATW")';
                            window.location.href = url;
                        }
                    }
                    else {
                        $.notify("Operation failed to post.", "error");
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }
    });//end

});