package com.pomelovolador.native_plugin;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

public class Alert2Class {

    private static final Alert2Class ourInstance = new Alert2Class();

    private static final String LOGTAG = "CWGTech";

    public static Alert2Class getInstance() {
        return ourInstance;
    }

    public static Activity mainActivity;

    public interface AlertViewCallback {
        public void onButtonTapped(int id);
    }
    private long startTime;

    private Alert2Class() {
        Log.i(LOGTAG,"Created MyPlugin");
        startTime = System.currentTimeMillis();
    }

    public double getElapsedTime()
    {
        return (System.currentTimeMillis()-startTime)/1000.0f;
    }

    public void showAlertView(String[] strings, final AlertViewCallback callback)
    {
        if (strings.length<3)
        {
            Log.i(LOGTAG,"Error - expected at least 3 strings, got " + strings.length);
            return;
        }
        DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface,int id) {

                Log.i(LOGTAG, "Tapped: " + id);
                callback.onButtonTapped(id);
                dialogInterface.dismiss();
            }
        };

        AlertDialog alertDialog = new AlertDialog.Builder(mainActivity)
                .setTitle(strings[0])
                .setMessage(strings[1])
                .setCancelable(false)
                .create();
        alertDialog.setButton(AlertDialog.BUTTON_NEUTRAL,strings[2],myClickListener);
        if (strings.length>3)
            alertDialog.setButton(AlertDialog.BUTTON_NEGATIVE,strings[3],myClickListener);
        if (strings.length>4)
            alertDialog.setButton(AlertDialog.BUTTON_POSITIVE,strings[4],myClickListener);
        alertDialog.show();
    }
}
