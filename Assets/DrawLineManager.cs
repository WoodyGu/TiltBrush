using System.Collections;
using UnityEngine;
using wvr;
using UnityEngine.UI;


public class DrawLineManager : MonoBehaviour
{
    private LineRenderer currLine;
    private int numClicks = 0;

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;


    void Update()
    {
        if (WaveVR_Controller.Input(curFocusControllerType).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Touchpad) ||
                WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Digital_Trigger) ||
                WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger))
        {
            GameObject go = new GameObject();
            currLine = go.AddComponent<LineRenderer>();
            currLine.startWidth = .1f;
            currLine.endWidth = .1f;
            numClicks = 0;
        }
        else if (WaveVR_Controller.Input(curFocusControllerType).GetPress(WVR_InputId.WVR_InputId_Alias1_Trigger))
        {
            currLine.positionCount = numClicks + 1;
            var locationOfRight = this.transform.position;
            currLine.SetPosition(numClicks, locationOfRight);
            if (locationOfRight == null)
            {
                Debug.LogError("WTF!");
            }
            else
            {
                Debug.LogError(locationOfRight.ToString());
            }
            numClicks++;
        }
    }
}