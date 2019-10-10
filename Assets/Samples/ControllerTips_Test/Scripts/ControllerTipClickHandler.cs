using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class ControllerTipClickHandler : MonoBehaviour {

    public void LoadScene2()
    {
#if UNITY_EDITOR
        Debug.Log("Controller Tips test load scene 2");
#endif
        Log.d("ControllerTipsTest", "Controller Tips test load scene 2");

        SceneManager.LoadScene("ControllerTips_Test2");
    }
}
