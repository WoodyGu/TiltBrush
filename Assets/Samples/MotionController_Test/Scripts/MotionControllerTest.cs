using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wvr;
using WaveVR_Log;

public class MotionControllerTest : MonoBehaviour
{
    private const string LOG_TAG = "MotionControllerTest";
    private void PrintDebugLog(string msg)
    {
        #if UNITY_EDITOR
        Debug.Log(LOG_TAG + " " + msg);
        #endif
        Log.d (LOG_TAG, msg);
    }

    // Use this for initialization
    void Start ()
    {
    }

    private GameObject domintController = null, noDomiController = null;
    // Update is called once per frame
    void Update ()
    {
        this.domintController = WaveVR_EventSystemControllerProvider.Instance.GetControllerModel (WaveVR_Controller.EDeviceType.Dominant);
        this.noDomiController = WaveVR_EventSystemControllerProvider.Instance.GetControllerModel (WaveVR_Controller.EDeviceType.NonDominant);
    }

    public void SimulatePose()
    {
        WaveVR_ControllerPoseTracker _cpt = null;
        if (this.domintController != null)
        {
            _cpt = this.domintController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("SimulatePose() simulate right.");
                _cpt.SimulationOption = WVR_SimulationOption.ForceSimulation;
            }
        }
        if (this.noDomiController != null)
        {
            _cpt = this.noDomiController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("SimulatePose() simulate left.");
                _cpt.SimulationOption = WVR_SimulationOption.ForceSimulation;
            }
        }
    }

    public void RealPose()
    {
        WaveVR_ControllerPoseTracker _cpt = null;
        if (this.domintController != null)
        {
            _cpt = this.domintController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("RealPose() real right.");
                _cpt.SimulationOption = WVR_SimulationOption.NoSimulation;
            }
        }
        if (this.noDomiController != null)
        {
            _cpt = this.noDomiController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("RealPose() real left.");
                _cpt.SimulationOption = WVR_SimulationOption.NoSimulation;
            }
        }
    }

    public void FollowHMD()
    {
        WaveVR_ControllerPoseTracker _cpt = null;
        if (this.domintController != null)
        {
            _cpt = this.domintController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("FollowHMD() right.");
                _cpt.FollowHead = true;
            }
        }
        if (this.noDomiController != null)
        {
            _cpt = this.noDomiController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("FollowHMD() left.");
                _cpt.FollowHead = true;
            }
        }
    }

    public void NoFollowHMD()
    {
        WaveVR_ControllerPoseTracker _cpt = null;
        if (this.domintController != null)
        {
            _cpt = this.domintController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("NoFollowHMD() right.");
                _cpt.FollowHead = false;
            }
        }
        if (this.noDomiController != null)
        {
            _cpt = this.noDomiController.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("NoFollowHMD() left.");
                _cpt.FollowHead = false;
            }
        }
    }

    public void ShowPointer()
    {
        WaveVR_ControllerPointer _cp = null;
        if (this.domintController != null)
        {
            _cp = this.domintController.GetComponentInChildren<WaveVR_ControllerPointer> ();
            if (_cp != null)
            {
                PrintDebugLog ("ShowPointer() right.");
                _cp.ShowPointer = true;
            }
        }
        if (this.noDomiController != null)
        {
            _cp = this.noDomiController.GetComponentInChildren<WaveVR_ControllerPointer> ();
            if (_cp != null)
            {
                PrintDebugLog ("ShowPointer() left.");
                _cp.ShowPointer = true;
            }
        }
    }

    public void HidePointer()
    {
        WaveVR_ControllerPointer _cp = null;
        if (this.domintController != null)
        {
            _cp = this.domintController.GetComponentInChildren<WaveVR_ControllerPointer> ();
            if (_cp != null)
            {
                PrintDebugLog ("HidePointer() right.");
                _cp.ShowPointer = false;
            }
        }
        if (this.noDomiController != null)
        {
            _cp = this.noDomiController.GetComponentInChildren<WaveVR_ControllerPointer> ();
            if (_cp != null)
            {
                PrintDebugLog ("HidePointer() left.");
                _cp.ShowPointer = false;
            }
        }
    }
    /*
    public void ChangeHand()
    {
        GameObject _go = WaveVR_EventSystemControllerProvider.Instance.GetControllerModel (WaveVR_Controller.EDeviceType.Dominant);
        if (_go != null)
        {
            WaveVR_ControllerPoseTracker _cpt = _go.GetComponent<WaveVR_ControllerPoseTracker> ();
            if (_cpt != null)
            {
                PrintDebugLog ("ChangeHand()");
                _cpt.SetCustomHand = !_cpt.SetCustomHand;
            }
        }
    }
    */
}
