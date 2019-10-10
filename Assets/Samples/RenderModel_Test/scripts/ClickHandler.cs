using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using WaveVR_Log;

public class ClickHandler : MonoBehaviour {
    public void LoadScene2()
    {
#if UNITY_EDITOR
        Debug.Log("Render model load scene 2");
#endif
        Log.d("RenderModelTest", "Render model load scene 2");

        SceneManager.LoadScene("RenderModel_scene2");
    }
}
