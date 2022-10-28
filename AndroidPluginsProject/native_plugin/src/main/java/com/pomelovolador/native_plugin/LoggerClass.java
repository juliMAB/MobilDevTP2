package com.pomelovolador.native_plugin;

import android.app.Activity;
import android.util.Log;


public class LoggerClass {

    private static final String LOGTAG = "UnityAndroidPlugin=>";

    public  static  final LoggerClass _instance = new LoggerClass();

    public  static  LoggerClass GetInstance(){
        return _instance;
    }

    public  void SendLog(String msg){
        Log.d( LOGTAG, msg);
    }

}
