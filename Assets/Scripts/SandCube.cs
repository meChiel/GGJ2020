using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCube : OVRGrabbable
{
    public bool hasNotBeenGrabbed = true;
    public ParticleSystem explosion;
    private void Update()
    {
        if (transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            hasNotBeenGrabbed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag == "ground" || collision.gameObject.tag == "sandblock") && hasNotBeenGrabbed)
        {
            destroyCube();
        }
    }

    void destroyCube()
    {
        Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

}
