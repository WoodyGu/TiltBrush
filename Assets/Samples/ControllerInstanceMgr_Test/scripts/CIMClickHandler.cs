using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class CIMClickHandler : MonoBehaviour {
    public void LoadScene2()
    {
#if UNITY_EDITOR
        Debug.Log("ControllerInstanceMgrTest load scene 2");
#endif
        Log.d("ControllerInstanceMgrTest", "ControllerInstanceMgrTest load scene 2");

        SceneManager.LoadScene("ControllerInstanceSence_test2");
    }
}
