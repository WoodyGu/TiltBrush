using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class ClickHandler2 : MonoBehaviour {

    public void LoadScene1()
    {
#if UNITY_EDITOR
        Debug.Log("Render model load scene 1");
#endif
        Log.d("RenderModelTest", "Render model load scene 1");

        SceneManager.LoadScene("RenderModel_test");
    }
}
