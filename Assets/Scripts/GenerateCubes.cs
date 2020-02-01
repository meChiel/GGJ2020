using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    bool cube;
    //public GameObject camera;
    public GameObject myPrefab;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        cube = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) && cube)
        {
            cube = false;
            DebugLog.Instance.Log("Button pressed");
            //Vector3 locationController = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            //Vector3 locationParent = new Vector3(0,0.7f,0) + controller.transform.position;
            Vector3 location = transform.position;
            Instantiate(myPrefab, location, Quaternion.identity);
            DebugLog.Instance.AddToLog("Generate Cube ");
            DebugLog.Instance.AddToLog("location is: " + location);
            //Instantiate(myPrefab, new Vector3(0.1f,0.2f, 0.2f), Quaternion.identity);
        }
        else if (!OVRInput.Get(OVRInput.Button.One)) cube = true;
    }
}
