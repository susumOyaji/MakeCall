//package com.example.repeatcall;
using System;
using System.IO;

using Android.Annotation;//.SuppressLint;
using Android.App;//.Activity;
using Android.Content;//.Context;
//using Android.Content.Intent;
using Android.OS;//.Bundle;
using Android.Telecom;//.Call;
using Android.Views;//.View;
using Android.Widget;//.Button;
//using Android.Widget;.TextView;

using Java.Util.Concurrent;//.TimeUnit;

//using io.reactivex.disposables.CompositeDisposable;
//using io.reactivex.disposables.Disposable;
using System.Reactive.Disposables;
using Xamarin.Forms;
using MakeCall.Droid;
using ReactiveUI;
using Java.Lang;

[assembly:Dependency(typeof(PhoneCall_Droid))]
namespace MakeCall.Droid { 
	public class CallActivity
    {

        private CompositeDisposable disposables = new CompositeDisposable();
        private string number;
        private Button answer, hangup;
        private TextView callInfo;

    
        public void onCreate(Bundle savedInstanceState) {
        //super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_call);

        //answer = findViewById(R.id.answer);
        //hangup = findViewById(R.id.hangup);
        //callInfo = findViewById(R.id.callInfo);

        number = getIntent().getData().getSchemeSpecificPart();
    }

    //@SuppressLint("CheckResult")
    //@Override
    public void onStart() {
       // super.onStart();

        answer.setOnClickListener(v -> OngoingCall.answer());

        hangup.setOnClickListener(v -> OngoingCall.hangup());

        // Subscribe to state change -> call updateUi when change
        new OngoingCall();
        Disposable disposable = OngoingCall.state.Subscribe(this:updateUi);
        disposables.Add(disposable);

        // Subscribe to state change (only when disconnected) -> call finish to close phone call
        new OngoingCall();
        Disposable disposable2 = OngoingCall.state
                .filter(state -> state == Call.STATE_DISCONNECTED)
                .delay(1, TimeUnit.SECONDS)
                .firstElement()
                .subscribe(this::finish);

        disposables.Add(disposable2);
    }

    // Call to Activity finish
    void finish(Integer state){
        finish();
    }

    // Set the UI for the call
    //@SuppressLint("SetTextI18n")
    public void updateUi(Integer state) {
        // Set callInfo text by the state
        callInfo.SetText(CallStateString.asString(state).toLowerCase()+"\n"+"\n"+number);

        if (state == Call.STATE_RINGING)
            answer.setVisibility(View.VISIBLE);
        else
            answer.setVisibility(View.GONE);

        if (state == Call.STATE_DIALING || state == Call.STATE_RINGING || state == Call.STATE_ACTIVE)
            hangup.setVisibility(View.VISIBLE);
        else
            hangup.setVisibility(View.GONE);
    }


    @Override
    public void onStop() {
        super.onStop();
        disposables.clear();
    }

    //@SuppressLint("NewApi")
    public static void start(Context context, Call call) {
        context.StartActivity(new Intent(context, CallActivity.class)
                .setFlags(Intent.FLAG_ACTIVITY_NEW_TASK)
                .setData(call.getDetails().getHandle()));
    }

}
}