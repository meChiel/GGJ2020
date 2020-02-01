using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubSpin : MonoBehaviour
{
    float xRot;
   // float yRot;
   // float zRot;

    //float xLoc;
    public float yLoc;
    //float zLoc;

    float yLocStart;
    float timePassed;

    /*public float maxHeight;
    public float minHeight;
    */
    public float rotationSpeed;
    float versnellingY = 9.81f;
    public float throwPower;
    public float throwAngle = Mathf.PI / 2;


    bool rising;
    // Start is called before the first frame update
    void Start()
    {

        yLocStart = this.transform.localPosition.y;
        float flyTime = (2 * throwPower * Mathf.Sin(throwAngle)) / versnellingY;
        rotationSpeed = 360 / flyTime;
        xRot = 180 - rotationSpeed;
        timePassed = 0;

    }

    // Update is called once per frame
    void Update()
    {  
        xRot = (xRot + rotationSpeed * Time.deltaTime) % 360;
        this.transform.localRotation = Quaternion.Euler(xRot, this.transform.localRotation.y, this.transform.localRotation.z);
        float yDispl = throwPower * timePassed * Mathf.Sin(throwAngle) -( 0.5f * versnellingY * Mathf.Pow(timePassed, 2f));
        Debug.Log(yDispl);
        yLoc = yLocStart + yDispl;

        if (yLoc < yLocStart)
        {
            timePassed = 0;
        }
        else
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, yLoc, transform.localPosition.z);
            timePassed += Time.deltaTime;
        }
    }
}
