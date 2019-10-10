using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class ControllerTipClickHandler2 : MonoBehaviour {

    public void LoadScene1()
    {
#if UNITY_EDITOR
        Debug.Log("Controller Tips test load scene 1");
#endif
        Log.d("ControllerTipsTest", "Controller Tips test load scene 1");

        SceneManager.LoadScene("ControllerTips_Test");
    }
}
