$(document).ready(function () {
    //phonestart(8001);

    var ws_servers = 'wss://49.248.16.102/voitekk/wss',
    uri = 'sip:@49.248.16.102:5060',
    agent_id = $('#MainContainer_txtagentid').val();
    console.toString(agent_id);
    phonestart(agent_id, ws_servers, uri);
});
var callData = "";
function callStart() {

    var phoneNumber = $('#MainContainer_txtCallingNumber').val(),
            agentId = $('#MainContainer_txtuserid').val(),
            agentName = $('#MainContainer_txtagentname').val(),
            customerid = $('#MainContainer_txtconid').val(),
            campaign_id = $('#MainContainer_txtcampaignid').val(),
            agent_id = $('#MainContainer_txtagentid').val()
    campaign_name = $('#MainContainer_txtcampaignname').val();


    var form_data = {
        agentExtn: agent_id,
        agentId: agentId,
        agentName: agentName,
        customerNumber: phoneNumber,
        customerId: customerid,
        leadsetId: 1,
        leadsetName: "default",
        campaignId: 1,
        campaignName: "TestCampaign",
        processId: 1,
        processName: "TestProcess"
    }
    $.post("https://49.248.16.102/voitekk/callingApis/click2CallExtn", form_data, function (message) {
        console.log(message);
        try {
            updateStream();

        }
        catch (e) {
            console.log("Update Stream Not Found");
        }


        //$("#MainContainer_callstarttime").val(Date.now() / 1000);
        var callstarttime = new Date();
        var timestamp = callstarttime.toTimeString();

        $.gritter.add({
            title: 'Call Connected',
            text: 'Call has been successfully Connected to ' + phoneNumber,
            class_name: 'gritter-success'
        });
        //                  var msg = JSON.parse(message);
        //                  console.log(msg);
        $("#MainContainer_customerPhone").val(message.Time);
    });
}

function callEnd(callLegInfo) {
    console.log(callLegInfo);
    $("#callEndBtn").hide();
    $("#callStartBtn").show();
    $("#callhold").hide();
    var phoneNumber = $('#MainContainer_txtCallingNumber').val(),
          callLegInfo = callLegInfo.replace(/;/g, ',');
    var callData = JSON.parse(callLegInfo);
    console.log(callData);
    $("#MainContainer_customerPhone").val(callData.info[0].customerPhone);
    $("#MainContainer_customerId").val(callData.info[1].customerId);
    $("#MainContainer_leadsetId").val(callData.info[2].leadsetId);
    $("#MainContainer_leadsetName").val(callData.info[3].leadsetName);
    $("#MainContainer_campaignId").val(callData.info[4].campaignId);
    $("#MainContainer_campaignName").val(callData.info[5].campaignName);
    $("#MainContainer_processId").val(callData.info[6].processId);
    $("#MainContainer_processName").val(callData.info[7].processName);
    $("#MainContainer_agentId").val(callData.info[8].agentId);
    $("#MainContainer_crUd").val(callData.info[9].crUd);
    $("#MainContainer_rfUd").val("https://49.248.16.102/dumprecords/" + callData.info[10].rfUd + ".mp3");
    $("#MainContainer_legType").val(callData.info[11].legType);
    $("#MainContainer_snUd").val(callData.info[12].snUd);
    $("#MainContainer_otUd").val(callData.info[13].otUd);
    $("#MainContainer_atEn").val(callData.info[14].atEn);
    $("#MainContainer_txSt").val(callData.info[15].txSt);
    $("#MainContainer_moc").val(callData.info[16].moc);
    var callEndtime = new Date();
    var timestampEnd = callEndtime.toTimeString();
    $("#MainContainer_callendtime").val(timestampEnd);

    //$("#MainContainer_callendtime").val(parseInt(Date.now()/1000));
    //$().toastmessage('Call Ended', "Call Ended.....");

    $.gritter.add({
        title: 'Call Ended',
        text: 'Call Ended to ' + phoneNumber,
        class_name: 'gritter-error'
    });

    $("#callEndBtn").hide();
    $("#callStartBtn").show();
    $("#callhold").hide();
    $("#callunhold").hide();

}

function userRegistered() {
    //    $("#MainContainer_divsipregistered").show();
    //    $("#MainContainer_divsipunregistered").hide();

    $.gritter.add({
        title: 'SIP Registered',
        text: 'System is ready for Call',
        class_name: 'gritter-success'
    });



}

function userUnregistered() {
    //    $("#MainContainer_divsipregistered").hide();
    //    $("#MainContainer_divsipunregistered").show();

    $.gritter.add({
        title: 'SIP UnRegistered',
        text: 'Please check connectivity, post which the system will be ready for Call',
        class_name: 'gritter-error'
    });
}

function userDisconnect() {
    //    $("#MainContainer_divsipregistered").hide();
    //    $("#MainContainer_divsipunregistered").show();

    $("#MainContainer_lblsipunregistered").text("Call Disconnected due to network issue");
    $.gritter.add({
        title: 'Disconnected',
        text: 'Network Issue as been identified',
        class_name: 'gritter-error'
    });
}


function WebSocketConnect() {
    $.gritter.add({
        title: 'Web Socket Connected',
        text: 'Intialization Suucessfully Completed',
        class_name: 'gritter-success'
    });
}
function userRegisterationFailed() {
    $.gritter.add({
        title: 'User Registration Failed',
        text: 'Please Contact Administrator as your registration has been failed.',
        class_name: 'gritter-error'
    });

}
function callAddStream() {

}
function callConfirmed(callLegInfo) {

    var phoneNumber = $('#MainContainer_txtCallingNumber').val(),
            agentId = $('#MainContainer_txtuserid').val(),
            agentName = $('#MainContainer_txtagentname').val(),
            customerid = $('#MainContainer_txtconid').val(),
            campaign_id = $('#MainContainer_txtcampaignid').val(),
            campaign_name = $('#MainContainer_txtcampaignname').val();
    $.gritter.add({
        title: 'Call Confirmed',
        text: 'Calling In process to ' + phoneNumber,
        class_name: 'gritter-success'
    });
    callstartbtn();
    callLegInfo = callLegInfo.replace(/;/g, ',');
    console.log(callLegInfo);
    callData = JSON.parse(callLegInfo);
    console.log(callData);
    $("#MainContainer_callstarttime").val(timestamp);
    $("#MainContainer_customerPhone").val(callData.info[0].customerPhone);
    $("#MainContainer_customerId").val(callData.info[1].customerId);
    $("#MainContainer_leadsetId").val(callData.info[2].leadsetId);
    $("#MainContainer_leadsetName").val(callData.info[3].leadsetName);
    $("#MainContainer_campaignId").val(callData.info[4].campaignId);
    $("#MainContainer_campaignName").val(callData.info[5].campaignName);
    $("#MainContainer_processId").val(callData.info[6].processId);
    $("#MainContainer_processName").val(callData.info[7].processName);
    $("#MainContainer_agentId").val(callData.info[8].agentId);
    $("#MainContainer_crUd").val(callData.info[9].crUd);
    $("#MainContainer_rfUd1").val(callData.info[10].rfUd);
    $("#MainContainer_legType").val(callData.info[11].legType);
    $("#MainContainer_snUd").val(callData.info[12].snUd);
    $("#MainContainer_otUd").val(callData.info[13].otUd);
    $("#MainContainer_atEn").val(callData.info[14].atEn);
    $("#MainContainer_txSt").val(callData.info[15].txSt);
    $("#MainContainer_moc").val(callData.info[16].moc);

}

function callFailed() {
    var phoneNumber = $('#MainContainer_txtCallingNumber').val(),
            agentId = $('#MainContainer_txtuserid').val(),
            agentName = $('#MainContainer_txtagentname').val(),
            customerid = $('#MainContainer_txtconid').val(),
            campaign_id = $('#MainContainer_txtcampaignid').val(),
            campaign_name = $('#MainContainer_txtcampaignname').val();
    $.gritter.add({
        title: 'Call Failed',
        text: 'Call Failed to ' + phoneNumber,
        class_name: 'gritter-error'
    });

}

function holdCall() {
    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").hide();
    $("#callunhold").show();



    var form_data = { "rfUd": callData.info[9].crUd,
        "crUd": callData.info[10].rfUd,
        "atEn": callData.info[14].atEn,
        "crNr": callData.info[0].customerPhone
    }
    $.post("https://49.248.16.102/voitekk/callingApis/hold", form_data,
            function (message) {
                console.log(message);
                $("#callhold").hide();
                holdbtn();
            }).error(function (data) {
                console.log("Hold call error");
                console.log(data);
            });
}

function unholdCall() {
    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").show();
    $("#callunhold").hide();


    var form_data = {
        "atEn": callData.info[14].atEn,
        "atEnTy": "dynamic",
        "atId": callData.info[8].agentId,
        "atNm": $('#MainContainer_txtagentname').val(),
        "moc": callData.info[16].moc,
        "crNr": callData.info[0].customerPhone,
        "crId": $('#MainContainer_txtconid').val(),
        "cnId": callData.info[4].campaignId,
        "cnNm": callData.info[5].campaignName,
        "prId": callData.info[6].processId,
        "prNm": callData.info[7].processName,
        "rfUd": callData.info[10].rfUd,
        "crUd": callData.info[9].crUd
    }
    $.post("https://49.248.16.102/voitekk/callingApis/unhold", form_data, function (message) {
        console.log(message);
        unholdbtn();
    }).error(function (data) {
        console.log("Unhold call error");
        console.log(data);
    });

    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").show();
    $("#callunhold").hide();
}

function holdbtn() {
    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").hide();
    $("#callunhold").show();
    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").hide();
        $("#callunhold").show();
    }, 1000);

    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").hide();
        $("#callunhold").show();
    }, 2000);

    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").hide();
        $("#callunhold").show();
    }, 3000);
}

function unholdbtn() {
    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").show();
    $("#callunhold").hide();
    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").show();
        $("#callunhold").hide();
    }, 1000);
    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").show();
        $("#callunhold").hide();
    }, 2000);
    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").show();
        $("#callunhold").hide();
    }, 3000);


}

function callstartbtn() {
    $("#callEndBtn").show();
    $("#callStartBtn").hide();
    $("#callhold").show();
    setTimeout(function () {
        $("#callEndBtn").show();
        $("#callStartBtn").hide();
        $("#callhold").show();
    }, 1000);
    
}