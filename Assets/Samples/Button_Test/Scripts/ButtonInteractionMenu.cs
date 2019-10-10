// "WaveVR SDK
// © 2017 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the WaveVR SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using WaveVR_Log;
using wvr;
using System.Collections.Generic;

[RequireComponent(typeof(Toggle))]
public class ButtonInteractionMenu : MonoBehaviour, IPointerDownHandler
{
    private const string LOG_TAG = "ButtonInteractionMenu";
    private void PrintDebugLog(string msg)
    {
        Log.d (LOG_TAG, this.DeviceType + " " + msg, true);
    }

    public WaveVR_Controller.EDeviceType DeviceType = WaveVR_Controller.EDeviceType.Dominant;
    private Toggle mToggle;
    private static List<WaveVR_ButtonList.EButtons> headButtonList = new List<WaveVR_ButtonList.EButtons>();
    private static List<WaveVR_ButtonList.EButtons> dominantButtonList = new List<WaveVR_ButtonList.EButtons>();
    private static List<WaveVR_ButtonList.EButtons> noDomintButtonList = new List<WaveVR_ButtonList.EButtons>();

    void Start()
    {
        if (!headButtonList.Contains (WaveVR_ButtonList.EButtons.HMDEnter))
            headButtonList.Add (WaveVR_ButtonList.EButtons.HMDEnter);
        // Always enable Touchpad
        if (!dominantButtonList.Contains(WaveVR_ButtonList.EButtons.Touchpad))
            dominantButtonList.Add (WaveVR_ButtonList.EButtons.Touchpad);
        if (!noDomintButtonList.Contains(WaveVR_ButtonList.EButtons.Touchpad))
            noDomintButtonList.Add (WaveVR_ButtonList.EButtons.Touchpad);

        mToggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (WaveVR_ButtonList.Instance == null)
            return;

        switch (mToggle.name)
        {
        case "Toggle_Menu":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Menu);
            break;
        case "Toggle_Grip":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Grip);
            break;
        case "Toggle_DPadUp":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_DPad_Up);
            break;
        case "Toggle_DPadRight":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_DPad_Right);
            break;
        case "Toggle_DPadDown":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_DPad_Down);
            break;
        case "Toggle_DPadLeft":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_DPad_Left);
            break;
        case "Toggle_VolumeUp":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Volume_Up);
            break;
        case "Toggle_VolumeDown":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Volume_Down);
            break;
        case "Toggle_HmdEnter":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Enter);
            break;
        case "Toggle_Trigger":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Trigger);
            break;
        case "Toggle_Thumbstick":
            mToggle.isOn = WaveVR_ButtonList.Instance.IsButtonAvailable (this.DeviceType, WVR_InputId.WVR_InputId_Alias1_Thumbstick);
            break;
        default:
            break;
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if (WaveVR_ButtonList.Instance == null)
            return;

        switch (this.DeviceType)
        {
        case WaveVR_Controller.EDeviceType.Head:
            switch (gameObject.name)
            {
            case "Toggle_HmdEnter":
                if (headButtonList.Contains (WaveVR_ButtonList.EButtons.HMDEnter))
                    headButtonList.Remove (WaveVR_ButtonList.EButtons.HMDEnter);
                else
                    headButtonList.Add (WaveVR_ButtonList.EButtons.HMDEnter);
                break;
            case "Toggle_VolumeUp":
                if (headButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeUp))
                    headButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeUp);
                else
                    headButtonList.Add (WaveVR_ButtonList.EButtons.VolumeUp);
                break;
            case "Toggle_VolumeDown":
                if (headButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeDown))
                    headButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeDown);
                else
                    headButtonList.Add (WaveVR_ButtonList.EButtons.VolumeDown);
                break;
            default:
                break;
            }

            foreach (WaveVR_ButtonList.EButtons _btn in headButtonList)
                PrintDebugLog ("OnPointerDown() set up button list: " + _btn);

            WaveVR_ButtonList.Instance.SetupButtonList (this.DeviceType, headButtonList);
            break;
        case WaveVR_Controller.EDeviceType.Dominant:
            switch (gameObject.name)
            {
            case "Toggle_Menu":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.Menu))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.Menu);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.Menu);
                break;
            case "Toggle_Grip":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.Grip))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.Grip);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.Grip);
                break;
            case "Toggle_DPadUp":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.DPadUp))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.DPadUp);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.DPadUp);
                break;
            case "Toggle_DPadRight":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.DPadRight))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.DPadRight);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.DPadRight);
                break;
            case "Toggle_DPadDown":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.DPadDown))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.DPadDown);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.DPadDown);
                break;
            case "Toggle_DPadLeft":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.DPadLeft))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.DPadLeft);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.DPadLeft);
                break;
            case "Toggle_VolumeUp":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeUp))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeUp);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.VolumeUp);
                break;
            case "Toggle_VolumeDown":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeDown))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeDown);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.VolumeDown);
                break;
            case "Toggle_Trigger":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.Trigger))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.Trigger);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.Trigger);
                break;
            case "Toggle_Thumbstick":
                if (dominantButtonList.Contains (WaveVR_ButtonList.EButtons.Thumbstick))
                    dominantButtonList.Remove (WaveVR_ButtonList.EButtons.Thumbstick);
                else
                    dominantButtonList.Add (WaveVR_ButtonList.EButtons.Thumbstick);
                break;
            default:
                break;
            }

            foreach (WaveVR_ButtonList.EButtons _btn in dominantButtonList)
                PrintDebugLog ("OnPointerDown() set up button list: " + _btn);

            WaveVR_ButtonList.Instance.SetupButtonList (this.DeviceType, dominantButtonList);
            break;
        case WaveVR_Controller.EDeviceType.NonDominant:
            switch (gameObject.name)
            {
            case "Toggle_Menu":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.Menu))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.Menu);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.Menu);
                break;
            case "Toggle_Grip":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.Grip))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.Grip);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.Grip);
                break;
            case "Toggle_DPadUp":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.DPadUp))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.DPadUp);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.DPadUp);
                break;
            case "Toggle_DPadRight":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.DPadRight))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.DPadRight);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.DPadRight);
                break;
            case "Toggle_DPadDown":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.DPadDown))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.DPadDown);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.DPadDown);
                break;
            case "Toggle_DPadLeft":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.DPadLeft))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.DPadLeft);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.DPadLeft);
                break;
            case "Toggle_VolumeUp":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeUp))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeUp);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.VolumeUp);
                break;
            case "Toggle_VolumeDown":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.VolumeDown))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.VolumeDown);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.VolumeDown);
                break;
            case "Toggle_Trigger":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.Trigger))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.Trigger);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.Trigger);
                break;
            case "Toggle_Thumbstick":
                if (noDomintButtonList.Contains (WaveVR_ButtonList.EButtons.Thumbstick))
                    noDomintButtonList.Remove (WaveVR_ButtonList.EButtons.Thumbstick);
                else
                    noDomintButtonList.Add (WaveVR_ButtonList.EButtons.Thumbstick);
                break;
            default:
                break;
            }

            foreach (WaveVR_ButtonList.EButtons _btn in noDomintButtonList)
                PrintDebugLog ("OnPointerDown() set up button list: " + _btn);

            WaveVR_ButtonList.Instance.SetupButtonList (this.DeviceType, noDomintButtonList);
            break;
        }
    }
}