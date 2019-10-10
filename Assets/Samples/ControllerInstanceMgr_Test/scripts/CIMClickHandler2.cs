using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class CIMClickHandler2 : MonoBehaviour {

    public void LoadScene1()
    {
#if UNITY_EDITOR
        Debug.Log("ControllerInstanceMgrTest load scene 1");
#endif
        Log.d("ControllerInstanceMgrTest", "ControllerInstanceMgrTest load scene 1");

        SceneManager.LoadScene("ControllerInstanceSence_test1");
    }
}
