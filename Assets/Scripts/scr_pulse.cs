using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pulse : MonoBehaviour
{
    float scaleRate = 0.0005f;
    float minScale = 0.05f;
    float maxScale = 0.3f;

    public void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
    }

    public void main()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }

    void Update()
    {
        main();

    }
}
