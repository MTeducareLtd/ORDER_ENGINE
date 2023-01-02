var Phone           = "",
    call            = "",
    callLegInfo     = "",
    lastheader      = "",
    moc             = "";


// var crnr      = '',
//     crid      = '',
//     ltid      = '',
//     ltnm      = '',
//     cnid      = '',
//     cnnm      = '',
//     prid      = '',
//     prnm      = '',
//     atid      = '',
//     crud      = '',
//     rfud      = '',
//     leg_type  = '',
//     atNm      = '';

// var sessionUuid         = "",
//     agentExtn           = "",
//     transferAgentExtn   = "",
//     ConfereceAgentExtn  = "";

// var callTimeInSec     = 0,
//     updateAgentTimer  = "";


// var usersip = "9010";

function phonestart(e) {

  var configuration = {
    		'ws_servers'        : 'ws://166.78.13.224:11080',
    		'uri'               : 'sip:'+agentExtn+'@166.78.13.224:5060',
    		'password'          : 'IOE@12345',
    		'register_expires'  : 30
    	};

	Phone = new JsSIP.UA(configuration);

  Phone.on('connected', function(e){

	  console.log("WS Connected");
	});
  
  Phone.on('registered', function(e){

	  console.log("SIP Registered");
  });

  Phone.on('disconnected', function(e){

    console.log("WS Disconnected");
    alert('WebSocket Disconnected');
  });

  Phone.on("unregistered",function() {
      console.log("This Phone is unregistered.");
      alert('SIP UnRegistered');
	});
  
  
  Phone.on('registrationFailed', function(e) {
    console.log("User registrationFailed");
    console.log(e);
    alert('Registeration Failed');
  });

  Phone.start();

  Phone.on('newRTCSession', function(e) {

    console.log("Phone Start");
    console.log(e);

    call        = e.data.session;
    lastheader  = call.request.headers;

  	call.answer({

      mediaConstraints: { audio: true, video:false },
      RTCConstraints: {"optional": [{'DtlsSrtpKeyAgreement': 'true'}]}
    });

		remoteView = document.getElementById('remoteView');

		call.on('started',function(e){
      // call.getLocalStreams()[0];
      // call.getRemoteStreams()[0];
	  	//Attach the streams to the views if it exists.
			if ( call.getLocalStreams().length > 0) {
  			remoteView.src=window.URL.createObjectURL(call.getLocalStreams()[0]);
			}

			if ( call.getRemoteStreams().length > 0) {
  			remoteView.src=window.URL.createObjectURL(call.getRemoteStreams()[0]);
			}
    });

    call.on('ended',function(e) {
      console.log("Call Ended.");
      alert('Call Ended');
    });

    call.on('failed',function(e) {
			console.log("Call Failed.");
		});
  }); // Phone on newRTCSession function end
}

function endcall(e) {
	try {
    call.terminate();
  }
  catch (ex) {
    // btnstop(this); 
  }
}