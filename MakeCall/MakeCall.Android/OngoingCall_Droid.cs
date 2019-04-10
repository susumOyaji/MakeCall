//package com.example.repeatcall;

using Android.OS;
using Android.Telecom;
using Java.Lang;


//using io.reactivex.subjects.BehaviorSubject;
using System.Reactive.Subjects;//.BehaviorSubject;

//using timber.log.Timber;
using Xamarin.Forms;
using MakeCall.Droid;


//[assembly: Dependency(typeof(OngoingCall_Droid))]
namespace MakeCall.Droid
{ 
	public class OngoingCall
    {
        public static  BehaviorSubject<Integer> state;
        private static readonly Call.Callback callback;
        private static Call call;

   
        public BehaviorSubject<Integer> GetState() {
            return state;
        }

        public void SetCall(Call value) {
            if (call != null) {
                call.UnregisterCallback(callback);
            }

            if (value != null) {
                value.RegisterCallback(callback);
                state.OnNext(value.getState());
            }

            call = value;
        }

        // Anwser the call
        public static void Answer() {
            call.Answer(0);
        }

        // Hangup the call
        public static void Hangup() {
            call.Disconnect();
        }

        /*static {
            // Create a BehaviorSubject to subscribe
            state = BehaviorSubject<Integer>.Create();
            callback = new Call.Callback() {
                public void onStateChanged(Call call, int newState) {
                Timber.d(call.ToString());
                // Change call state
                OngoingCall.state.OnNext(newState);
            }
            };
        }*/
    }
}
