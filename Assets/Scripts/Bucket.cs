using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public Transform cubePrefab;
    bool buttonDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1)
        {
            if (!buttonDown && transform.Find("BucketFull").gameObject.activeSelf)
            {
                buttonDown = true;
                Transform cube = Instantiate(cubePrefab, this.transform.position, Quaternion.identity);
                // cube.gameObject.GetComponent<SandCube>().hasNotBeenGrabbed = false;
                transform.Find("BucketEmpty").gameObject.SetActive(true);
                transform.Find("BucketFull").gameObject.SetActive(false);
            }
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 0)
        {
            buttonDown = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "sandblock")
        {
            if (collision.gameObject.GetComponent<SandCube>().hasNotBeenGrabbed)
            {
                Destroy(collision.gameObject);
                transform.Find("BucketEmpty").gameObject.SetActive(false);
                transform.Find("BucketFull").gameObject.SetActive(true);
            }

        }
    }
}
