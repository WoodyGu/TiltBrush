// "WaveVR SDK 
// © 2017 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the WaveVR SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using wvr;
using WaveVR_Log;

[RequireComponent(typeof(Text))]
public class Battery_Info : MonoBehaviour {
    //private static string LOG_TAG = "Battery_Info";
    private Text textField;
    string battery_info = "";
    private float _deviceBatteryStatus;
    private float _leftControllerBatteryStatus;
    private float _rightControllerBatteryStatus;
    private string _leftControllerBatteryStatus_str;
    private string _rightControllerBatteryStatus_str;

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            return;
        }
#endif

        StartCoroutine(deviceBatteryInfo());
    }


    // Update is called once per frame
    void Update () {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            return;
        }
#endif
    }

    IEnumerator deviceBatteryInfo()
    {

        textField = GetComponent<Text>();

        while (true)
        {
            _deviceBatteryStatus = Interop.WVR_GetDeviceBatteryPercentage(WVR_DeviceType.WVR_DeviceType_HMD);
            _leftControllerBatteryStatus = Interop.WVR_GetDeviceBatteryPercentage(WVR_DeviceType.WVR_DeviceType_Controller_Left);
            _rightControllerBatteryStatus = Interop.WVR_GetDeviceBatteryPercentage(WVR_DeviceType.WVR_DeviceType_Controller_Right);

            if (_leftControllerBatteryStatus == -1)
                _leftControllerBatteryStatus_str = "not available";
            else
                _leftControllerBatteryStatus_str = _leftControllerBatteryStatus.ToString();

            if (_rightControllerBatteryStatus == -1)
                _rightControllerBatteryStatus_str = "not available";
            else
                _rightControllerBatteryStatus_str = _rightControllerBatteryStatus.ToString();

            //Log.d(LOG_TAG, "Start, _deviceBatteryStatus = " + _deviceBatteryStatus + "_leftControllerBatteryStatus = " + _leftControllerBatteryStatus + "_rightControllerBattery = " + _rightControllerBatteryStatus);
            battery_info = "\nHMD Battery : " + _deviceBatteryStatus + "\nNonDominant Controller Battery : " + _leftControllerBatteryStatus_str + "\nDominant Controller Battery : " + _rightControllerBatteryStatus_str;

            textField.text = battery_info;

            yield return new WaitForSeconds(2f); // delay 2 secs
        }
    }
}
