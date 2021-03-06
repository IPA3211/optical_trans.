﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionOnObject : MonoBehaviour {

    float obj_scaletime;
    float warp_delaytime;

    Vector2 transPos;
    Material matrial;
    Color col;
    Light light;

    public void ChangePosition(Vector2 transPosition, Material mat, Color color, float delaytime)
    {

        transPos = transPosition;
        matrial = mat;
        col = color;
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().material = mat;
        }

        if (gameObject.GetComponent<SpriteOutline>() == null)
        {
            gameObject.AddComponent<SpriteOutline>();
        }

        if (gameObject.GetComponent<Light>() == null)
        {
            light = gameObject.AddComponent<Light>();
        }
        light.color = color;
        light.type = LightType.Point;
        light.range = 10;
        //light.lightmapBakeType = LightmapBakeType.Realtime;
        light.intensity = 50;   //빛의 강도가 제일 중요


        gameObject.GetComponent<SpriteOutline>().color = color;
        gameObject.GetComponent<SpriteOutline>().outlineSize = 1;
        obj_scaletime = gameObject.transform.localScale.x / 18f;
        StartCoroutine("myYield");
    }

    IEnumerator myYield()
    {
        Vector3 objectScale = gameObject.transform.localScale;
        for (int i = 0; i < 25; i++)
        {
            if (gameObject.transform.localScale.x - 0.05f > 0)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - obj_scaletime, gameObject.transform.localScale.y - obj_scaletime, gameObject.transform.localScale.z);
                light.intensity += 3;
            }
            else
                break;
            yield return new WaitForSeconds(0.0005f);
        }
        //gameObject.SetActive(false);

        float WTime = Time.realtimeSinceStartup + warp_delaytime;

        while (Time.realtimeSinceStartup < WTime)
        {
            yield return 0;
        }
        gameObject.transform.position = transPos;
        //gameObject.SetActive(true);

        for (int i = 0; i < 25; i++)
        {
            if (gameObject.transform.localScale.x + 0.05f < objectScale.x)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + obj_scaletime, gameObject.transform.localScale.y + obj_scaletime, gameObject.transform.localScale.z);
                light.intensity -= 3.5f;
            }
            else
                break;
            yield return new WaitForSeconds(0.0005f);
        }

        gameObject.transform.localScale = objectScale;
        gameObject.GetComponent<SpriteOutline>().outlineSize = 0;
        Destroy(light);
    }
}
