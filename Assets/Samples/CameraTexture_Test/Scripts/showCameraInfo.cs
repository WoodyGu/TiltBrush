using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
public class showCameraInfo : MonoBehaviour {

    private static string LOG_TAG = "CameraTextureInfo";

   // private CameraTextureSample cameraInfoObj;
    private Text textField;
    private bool cameraStarted = false;
    private bool isShow = false;
    string obj = "";

    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        if (Application.isEditor) return;
#endif
        textField = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update () {
#if UNITY_EDITOR
        if (Application.isEditor) return;
#endif
        setCameraStarted();
        if (isShow == true)
        {
            if (cameraStarted == true)
            {
                obj = "Camera image fomat : " + WaveVR_CameraTexture.instance.GetCameraImageFormat() + "\n" + "Camera image type : "
                + WaveVR_CameraTexture.instance.GetCameraImageType() + "\n" + "Camera image width : " + WaveVR_CameraTexture.instance.GetCameraImageWidth() + "\n" +
                "Camera image height : " + WaveVR_CameraTexture.instance.GetCameraImageHeight();
                textField.text = obj;
            }
            else
            {
                textField.text = "Camera is not started.";
            }
        }
    }

    public void ShowInfo()
    {
        if (!isShow)
        {
            //Log.d(LOG_TAG, " ShowInfo" + cameraStarted.ToString());
            if (cameraStarted == true)
            {
                string obj = "Camera image fomat : " + WaveVR_CameraTexture.instance.GetCameraImageFormat() + "\n" + "Camera image type : "
                + WaveVR_CameraTexture.instance.GetCameraImageType() + "\n" + "Camera imege width : " + WaveVR_CameraTexture.instance.GetCameraImageWidth() + "\n" +
                "Camera imege height : " + WaveVR_CameraTexture.instance.GetCameraImageHeight();
                Log.d(LOG_TAG, " ShowInfo" + obj);
                textField.text = obj;
            }
            else
            {
                textField.text = "Camera is not started.";
            }
            isShow = true;
        }
        else
        {
            isShow = false;
            textField.text = "";
        }

    }

    private void setCameraStarted()
    {
        cameraStarted = WaveVR_CameraTexture.instance.isStarted;
        //Log.d(LOG_TAG, "setCameraStarted " + cameraStarted.ToString());
    }
}
