//package com.example.repeatcall;

using Android.app.Application;
using Android.OS;
using Android.support.v7.app.AppCompatActivity;

//import timber.log.Timber;
[assembly: Dependency(typeof(PhoneCall_Droid))]
public class App : Application {

    //@Override
    public void onCreate() {
        super.onCreate();
        // Log
        Timber.plant(new Timber.DebugTree());
    }
}
