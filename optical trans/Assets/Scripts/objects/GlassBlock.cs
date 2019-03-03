using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlock : MonoBehaviour
{
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
            StartCoroutine(LightStart());

    }
    void OnTriggerStay2D(Collider2D other)
    {
        //if (other.GetComponent<Collider2D>().isTrigger == false) 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            //StopCoroutine(LightStart());
            StopAllCoroutines();
            StartCoroutine(LightEnd());
        }
    }

    IEnumerator LightStart()
    {
        if (light.intensity < 90)
        {
            for (int i = (int)light.intensity + 20; i <= 90; i += 20)
            {
                if(light.intensity + 20 <= 90)
                    light.intensity = i;

                yield return new WaitForSeconds(0.001f);
            }
        }
        yield break;
    }

    IEnumerator LightEnd()
    {
        if (light.intensity > 30)
        {
            for (int i = (int)light.intensity; i >= 30; i--)
            {
                if(light.intensity - 1 >= 30)
                    light.intensity = i;

                yield return new WaitForSeconds(0.001f);
            }
        }

        yield break;
    }
}
