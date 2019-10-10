using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(Text))]
public class Resource_Test1Handle : MonoBehaviour
{

    public string displayText = "";
    public Text _text;
    private static string LOG_TAG = "Resource_Test1Handle";
    private WaveVR_Resource rw = null;
    private string _country = "TW";
    private string _lang = "zh";

    // Use this for initialization
    void Start()
    {
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
    void Update()
    {

    }

    public void getCountryandLanguage()
    {
        //Log.d(LOG_TAG, "getCountryandLanguage " + rw.getSystemCountry() + " \nLanguage : " + rw.getSystemLanguage());
        displayText = "location country : " + rw.getSystemCountry() + " \nLanguage : " + rw.getSystemLanguage();
        _text.text = displayText;
    }

    public void press_homekey()
    {
        //Log.d(LOG_TAG, "press_homekey " + rw.getStringByLanguage("HomeKey", _lang, _country));
        displayText = rw.getString("HomeKey");
        _text.text = displayText;
    }

    public void press_appkey()
    {
        //Log.d(LOG_TAG, "press_appkey " + rw.getStringByLanguage("AppKey", _lang, _country));
        displayText = rw.getString("AppKey");
        _text.text = displayText;
    }

    public void press_triggerkey()
    {
        //Log.d(LOG_TAG, "press_triggerkey " + rw.getStringByLanguage("TriggerKey", _lang, _country));
        displayText = rw.getString("TriggerKey");
        _text.text = displayText;
    }

    public void press_touchpad()
    {
        //Log.d(LOG_TAG, "press_touchpad " + rw.getStringByLanguage("TouchPad", _lang, _country));
        displayText = rw.getString("TouchPad");
        _text.text = displayText;
    }

    public void press_volumekey()
    {
        //Log.d(LOG_TAG, "press_volumekey " + rw.getStringByLanguage("VolumeKey", _lang, _country));
        displayText = rw.getString("VolumeKey");
        _text.text = displayText;
    }

    public void press_digitalTrigger()
    {
        //Log.d(LOG_TAG, "press_DigitalTrigger " + rw.getStringByLanguage("DigitalTriggerKey", _lang, _country));
        displayText = rw.getString("DigitalTriggerKey");
        _text.text = displayText;
    }

    public void selectTW()
    {
        _country = "TW";
        _lang = "zh";
        rw.setPreferredLanguage(_lang, _country);
        displayText = "zh_TWsetPreferredLanguageSuccess";
        _text.text = displayText;
        //Log.d(LOG_TAG, "selectTW " +_country + " \nLanguage : " + _lang);
    }

    public void selectCN()
    {
        _country = "CN";
        _lang = "zh";
        rw.setPreferredLanguage(_lang, _country);
        displayText = "zh_CNsetPreferredLanguageSuccess";
        _text.text = displayText;
        //Log.d(LOG_TAG, "selectCN " + _country + " \nLanguage : " + _lang);
    }

    public void selectEN()
    {
        _country = "US";
        _lang = "en";
        rw.setPreferredLanguage(_lang, _country);
        displayText = "eng_USsetPreferredLanguageSuccess";
        _text.text = displayText;
        //Log.d(LOG_TAG, "selectEN " + _country + " \nLanguage : " + _lang);
    }

    public void useSystemLanguage()
    {
        _country = rw.getSystemCountry();
        _lang = rw.getSystemLanguage();
        rw.setPreferredLanguage(_lang, _country);
        displayText = "Set Current Language Success";
        _text.text = displayText;
        //Log.d(LOG_TAG, "useSystemLanguage " + rw.getSystemCountry() + " \nLanguage : " + rw.getSystemLanguage());
    }
}
