
$(document).ready(function () {
    debugger;
        $("#btnUpload").click(function () {
            $.ajax({
                type: "POST", 
                url: "/LoanApplication/upload",
                data: {
                    armyNo: $("#armyNo").val(),
                    ltype: $("#ltype").val()
                },
                success: function (data) {
                    $("#result").html(data);
                }
            });
        });

    $("#btnDownload").click(function () {
        $.ajax({
            type: "POST",
            url: "/LoanApplication/download",
            data: {
                armyNo: $("#armyNo").val(),
                ltype: $("#ltype").val()
            },
            success: function (data) {
                $("#result").html(data);
            }
        });
        });

    $("#btnStatus").click(function () {
        $.ajax({
            type: "POST",
            url: "/LoanApplication/status",
            data: {
                armyNo: $("#armyNo").val(),
                ltype: $("#ltype").val()
            },
            success: function (data) {
                $("#result").html(data);
            }
        });
        });
    });

