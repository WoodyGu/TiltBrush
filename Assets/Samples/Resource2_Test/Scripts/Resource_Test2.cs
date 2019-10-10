using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Resource_Test2 : MonoBehaviour {
    public string displayText = "";
    public Text _text;
    private static string LOG_TAG = "Resource_Test2";
    private WaveVR_Resource rw = null;
    // Use this for initialization
    void Start () {
        _text = GetComponent<Text>();
        Log.d(LOG_TAG, "start()");
#if UNITY_EDITOR
        if (Application.isEditor)
        {
            Debug.Log("Resource_Test1Handle can't run on editor!");
            return;
        }
#endif
        rw = WaveVR_Resource.instance;
    }

    // Update is called once per frame
	void Update () {

	}

    public void btnHomeEn() {
        //Log.d(LOG_TAG, "btnHomeEn " + rw.getStringByLanguage("HomeKey", "en", "US"));
        displayText = rw.getStringByLanguage("HomeKey", "en", "US");
        _text.text = displayText;
    }

    public void btnAppEn() {
        //Log.d(LOG_TAG, "btnAppEn " + rw.getStringByLanguage("AppKey", "en", "US"));
        displayText = rw.getStringByLanguage("AppKey", "en", "US");
        _text.text = displayText;
    }

    public void btnTriggerEn() {
        //Log.d(LOG_TAG, "btnTriggerEn " + rw.getStringByLanguage("TriggerKey", "en", "US"));
        displayText = rw.getStringByLanguage("TriggerKey", "en", "US");
        _text.text = displayText;
    }

    public void btnTouchEn() {
        //Log.d(LOG_TAG, "btnTouchEn " + rw.getStringByLanguage("TouchPad", "en", "US"));
        displayText = rw.getStringByLanguage("TouchPad", "en", "US");
        _text.text = displayText;
    }

    public void btnVolumeEn() {
        //Log.d(LOG_TAG, "btnVolumeEn " + rw.getStringByLanguage("VolumeKey", "en", "US"));
        displayText = rw.getStringByLanguage("VolumeKey", "en", "US");
        _text.text = displayText;
    }

    public void btnDigitalEn() {
        //Log.d(LOG_TAG, "btnDigitalEn " + rw.getStringByLanguage("DigitalTriggerKey", "en", "US"));
        displayText = rw.getStringByLanguage("DigitalTriggerKey", "en", "US");
        _text.text = displayText;
    }

    public void btnHomeCN()
    {
        //Log.d(LOG_TAG, "btnHomeCN " + rw.getStringByLanguage("HomeKey", "zh", "CN"));
        displayText = rw.getStringByLanguage("HomeKey", "zh", "CN");
        _text.text = displayText;
    }

    public void btnAppCN()
    {
        //Log.d(LOG_TAG, "btnAppCN " + rw.getStringByLanguage("AppKey", "zh", "CN"));
        displayText = rw.getStringByLanguage("AppKey", "zh", "CN");
        _text.text = displayText;
    }

    public void btnTriggerCN()
    {
        //Log.d(LOG_TAG, "btnTriggerCN " + rw.getStringByLanguage("TriggerKey", "zh", "CN"));
        displayText = rw.getStringByLanguage("TriggerKey", "zh", "CN");
        _text.text = displayText;
    }

    public void btnTouchCN()
    {
        //Log.d(LOG_TAG, "btnTouchCN " + rw.getStringByLanguage("TouchPad", "zh", "CN"));
        displayText = rw.getStringByLanguage("TouchPad", "zh", "CN");
        _text.text = displayText;
    }

    public void btnVolumeCN()
    {
        //Log.d(LOG_TAG, "btnVolumeCN " + rw.getStringByLanguage("VolumeKey", "zh", "CN"));
        displayText = rw.getStringByLanguage("VolumeKey", "zh", "CN");
        _text.text = displayText;
    }

    public void btnDigitalCN()
    {
        //Log.d(LOG_TAG, "btnDigitalCN " + rw.getStringByLanguage("DigitalTriggerKey", "zh", "CN"));
        displayText = rw.getStringByLanguage("DigitalTriggerKey", "zh", "CN");
        _text.text = displayText;
    }

    public void btnHomeTW()
    {
        //Log.d(LOG_TAG, "btnHomeTW " + rw.getStringByLanguage("HomeKey", "zh", "TW"));
        displayText = rw.getStringByLanguage("HomeKey", "zh", "TW");
        _text.text = displayText;
    }

    public void btnAppTW()
    {
        //Log.d(LOG_TAG, "btnAppTW " + rw.getStringByLanguage("AppKey", "zh", "TW"));
        displayText = rw.getStringByLanguage("AppKey", "zh", "TW");
        _text.text = displayText;
    }

    public void btnTriggerTW()
    {
        //Log.d(LOG_TAG, "btnTriggerTW " + rw.getStringByLanguage("TriggerKey", "zh", "TW"));
        displayText = rw.getStringByLanguage("TriggerKey", "zh", "TW");
        _text.text = displayText;
    }

    public void btnTouchTW()
    {
        //Log.d(LOG_TAG, "btnTouchTW " + rw.getStringByLanguage("TouchPad", "zh", "TW"));
        displayText = rw.getStringByLanguage("TouchPad", "zh", "TW");
        _text.text = displayText;
    }

    public void btnVolumeTW()
    {
        //Log.d(LOG_TAG, "btnVolumeTW " + rw.getStringByLanguage("VolumeKey", "zh", "TW"));
        displayText = rw.getStringByLanguage("VolumeKey", "zh", "TW");
        _text.text = displayText;
    }

    public void btnDigitalTW()
    {
        //Log.d(LOG_TAG, "btnDigitalTW " + rw.getStringByLanguage("DigitalTriggerKey", "zh", "TW"));
        displayText = rw.getStringByLanguage("DigitalTriggerKey", "zh", "TW");
        _text.text = displayText;
    }
}
