using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using wvr;
using WaveVR_Log;


public class DrawLineManager : MonoBehaviour
{
    public GameObject currentStroke = null;
    private LineRenderer currLine;
    private int numClicks = 0;

    public static Color Red = Color.red;
    public static Color Green = Color.green;
    public static Color Blue = Color.blue;
    static float small = 0.01f;
    static float med = 0.05f;
    static float large = 0.1f;

    public Color currColor = Blue;
    public float currSize = small;

    public Stack<GameObject> currObjectsStack = new Stack<GameObject>();
    public Stack<GameObject> oldObjectsStack = new Stack<GameObject>();

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    void Update()
    {
        if (WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger))
        {
            GameObject go = new GameObject();
            currLine = go.AddComponent<LineRenderer>();

            currLine.useWorldSpace = false;
            GameObject LineContainer = GameObject.Find("Lines");
            currLine.transform.parent = LineContainer.transform;
            
            currentStroke = go;
            SetColor();
            SetSize();
        
            currObjectsStack.Push(go);
            numClicks = 0;
        }
        else if (WaveVR_Controller.Input(curFocusControllerType).GetPress(WVR_InputId.WVR_InputId_Alias1_Trigger))
        {
            currLine.positionCount = numClicks + 1;
            var locationOfRight = this.transform.position;
            Debug.Log(locationOfRight);
            // locationOfRight = locationOfRight + new Vector3(0,0,0.3f);
            // Debug.Log(locationOfRight);
            currLine.SetPosition(numClicks, locationOfRight);
            numClicks++;
        }
        //non-dominant controller trigger to teleport to random location
        else if(WaveVR_Controller.Input(WaveVR_Controller.EDeviceType.NonDominant).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Grip))
        {
            teleportRandom();
        }
        else if(WaveVR_Controller.Input(WaveVR_Controller.EDeviceType.NonDominant).GetPressDown(WVR_InputId.WVR_InputId_Alias1_DPad_Left))
        {
            move();
        }
        else if(WaveVR_Controller.Input(WaveVR_Controller.EDeviceType.NonDominant).GetPressDown(WVR_InputId.WVR_InputId_Alias1_DPad_Up))
        {
            rotate();
        }
        else if(WaveVR_Controller.Input(WaveVR_Controller.EDeviceType.NonDominant).GetPressDown(WVR_InputId.WVR_InputId_Alias1_DPad_Right))
        {
            scaleUp();
        }
    }

    public void SetColor()
    {
        Debug.Log("Set Brush Color");
        if (currentStroke != null)
        {
            var mat = currentStroke.GetComponent<Renderer>().material;
            mat.color = currColor;
        }
    }

    public void SetSize()
    {
        Debug.Log("Set Brush Size");
        if (currentStroke != null)
        {
            currLine.startWidth = currSize;
            currLine.endWidth = currSize;
        }
    }

    public void SetRed()
    {
        Debug.Log("onClick to change red");
        currColor = Red;
    }

    public void SetGreen()
    {
        Debug.Log("onClick to change Green");
        currColor = Green;
    }

    public void SetBlue()
    {
        Debug.Log("onClick to change blue");
        currColor = Blue;
    }

    public void SetSmall()
    {
        Debug.Log("onClick to change small");
        currSize = small;
    }

    public void SetMed()
    {
        Debug.Log("onClick to change med");
        currSize = med;
    }

    public void SetLarge()
    {
        Debug.Log("onClick to change large");
        currSize = large;
    }

    public void OnClickUndo()
    {
        if (currObjectsStack.Count > 0)
        {
            oldObjectsStack.Push(currObjectsStack.Pop());
            oldObjectsStack.Peek().SetActive(false);
        }
    }

    public void OnClickRedo()
    {
        if (oldObjectsStack.Count > 0)
        {
            currObjectsStack.Push(oldObjectsStack.Pop());
            currObjectsStack.Peek().SetActive(true);
        }
    }

    public void OnClickClear()
    {
        foreach (GameObject g in currObjectsStack)
        {
            Destroy(g);
        }
        currObjectsStack.Clear();
        foreach (GameObject g in oldObjectsStack)
        {
            Destroy(g);
        }
        oldObjectsStack.Clear();
    }

    public void teleportRandom()
    {
        GameObject head = GameObject.Find("WaveVR");
        //GameObject controllerR = GameObject.Find("Generic_MC_R(Clone)");
        // GameObject controllerL = GameObject.Find("Generic_MC_L(Clone)");

        Vector3 headPos = head.transform.position;
        //Vector3 rightPos = controllerR.transform.position;
        // Vector3 leftPos = controllerL.transform.position;
        
        Debug.Log("Before teleport Head: "+head.transform.position);
        // Debug.Log("Before teleport ControllerR: "+controllerR.transform.position);

        Vector3 direction = UnityEngine.Random.onUnitSphere;
        direction.x = Mathf.Clamp (direction.x, 0.5f, 1f);
        direction.y = 0;
        direction.z = Mathf.Clamp (direction.z, 3f, 10f);
        float distance = 2 * UnityEngine.Random.value + 1.5f;
        Vector3 newHeadPos = direction * distance;
        
        head.transform.position = newHeadPos;
        GameObject.Find("head").transform.localPosition = newHeadPos;
        //controllerR.transform.Translate(newHeadPos-headPos);
        // controllerL.transform.position = newHeadPos + (leftPos-headPos);

        Debug.Log("After teleport Head: "+head.transform.position);
        //Debug.Log("After teleport ControllerR: "+controllerR.transform.position);
    }

    public void move()
    {
        GameObject lines = GameObject.Find("Lines");
        Debug.Log("move");
       	lines.transform.Translate(0,0,0.05f);
       	lines.transform.Rotate(0, 5, 0);
    }

    
    public void scaleUp()
    {
        GameObject lines = GameObject.Find("Lines");
        Debug.Log("scale");
        lines.transform.localScale += new Vector3(0.5f,0,0.5f);
    }

    public void rotate()
    {
        GameObject lines = GameObject.Find("Lines");
        Debug.Log("rotate");
        lines.transform.Rotate(0, 5, 0);
    }
}