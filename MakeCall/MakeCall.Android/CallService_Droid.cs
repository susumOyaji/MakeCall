//package com.example.repeatcall;
using System;

using Android.Telecom;
using Android.Widget;

using Xamarin.Forms;

using MakeCall.Droid;

[assembly: Dependency(typeof(PhoneCall_Droid))]
public class CallService : InCallService {
    //@Override
    public void onCallAdded(Call call) {
        new OngoingCall().SetCall(call);
        Toast.MakeText(this, "class to CallService", ToastLength.Short).Show();
        CallActivity.start(this, call);
    }

    //@Override
    public void onCallRemoved(Call call) {
        new OngoingCall().SetCall(null);
    }
}
