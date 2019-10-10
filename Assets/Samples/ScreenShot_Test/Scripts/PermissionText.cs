using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
public class PermissionText : MonoBehaviour {

    private static string LOG_TAG = "StoragePermission_Test";
    private WaveVR_PermissionManager pmInstance = null;
    private Text textField;
    private bool permission_granted = false;

    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        if (Application.isEditor) return;
#endif
        Log.d(LOG_TAG, "get instance at start");
        pmInstance = WaveVR_PermissionManager.instance;
        textField = GetComponent<Text>();
        permission_granted = pmInstance.isPermissionGranted("android.permission.WRITE_EXTERNAL_STORAGE");
        if (permission_granted)
        {
            textField.text = "";
        }
        else
        {
            textField.text = "Warning : \n This APP was not granted android.permission.EXTERNAL_STORAGE yet.";
        }
    }
// Update is called once per frame
    void Update () {
#if UNITY_EDITOR
        if (Application.isEditor) return;
#endif
    }

    void OnApplicationPause(bool pauseStatus)
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
            return;
#endif
        permission_granted = pmInstance.isPermissionGranted("android.permission.WRITE_EXTERNAL_STORAGE");
        if (permission_granted)
        {
            textField.text = "";
        }
        else
        {
            textField.text = "Warning : \n This APP was not granted android.permission.EXTERNAL_STORAGE yet.";
        }
    }
}
