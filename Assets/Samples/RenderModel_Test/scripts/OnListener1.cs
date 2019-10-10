using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;
using UnityEngine.UI;

public class OnListener1 : MonoBehaviour {
    //private static string LOG_TAG = "OnListener1";

    void OnEnable()
    {

#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            return;
        }
#endif

        WaveVR_Utils.Event.Listen(WaveVR_Utils.Event.DS_ASSETS_NOT_FOUND, onAssetNotFound);
    }

    void OnDisable()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            return;
        }
#endif
        WaveVR_Utils.Event.Remove(WaveVR_Utils.Event.DS_ASSETS_NOT_FOUND, onAssetNotFound);
    }

    // Use this for initialization
    void Start () {
		GameObject.Find("Asset").GetComponent<Text>().text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void onAssetNotFound(params object[] args)
    {
        //WVR_DeviceType eventType = (WVR_DeviceType)args[0];
        GameObject.Find("Asset").GetComponent<Text>().text = "Controller model asset is not found in DS.";
    }
}
