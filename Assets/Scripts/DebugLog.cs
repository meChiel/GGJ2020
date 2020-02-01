using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLog : MonoBehaviour
{
    public static DebugLog Instance;
    bool inMenu;
    Text logText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        var lt = DebugUIBuilder.instance.AddLabel("Debug");
        logText = lt.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }

    public void Log(string msg)
    {
        logText.text = msg;
    }

    public void AddToLog(string msg)
    {
        logText.text = logText.text + msg;
    }
}
