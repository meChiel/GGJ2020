using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPSDestroyer : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
