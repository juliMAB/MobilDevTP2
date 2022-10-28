package com.pomelovolador.native_plugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

public class AlertClass {
    private static final String LOGTAG = "UnityAndroidPlugin=>";
    private static Activity unityActivity;
    AlertDialog.Builder builder;

    public static void receiveUnityActivity(Activity tActivity){
        unityActivity = tActivity;
    }

    public void CreateAlert(){
        builder = new AlertDialog.Builder(unityActivity);
        builder.setMessage("Set your intro message.");
        builder.setCancelable(true);
        builder.setPositiveButton(
                "Yes",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        Log.v(LOGTAG, "Clicked from plugin - Yes");
                        dialogInterface.cancel();
                    }
                }
        );
        builder.setNegativeButton(
                "No",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        Log.v(LOGTAG, "Clicked from plugin - No");
                        dialogInterface.cancel();
                    }
                }
        );
    }

    public  void ShowAlert(){
        AlertDialog alert = builder.create();
        alert.show();
    }
}
