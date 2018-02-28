using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public float reloadTime = 0;
    public int bulletAmount = 0;

    public GameObject bullet;
    public GameObject ShootPoint = null;

	// Use this for initialization
	void Start () {
        StartCoroutine("Shoot");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(reloadTime);
        int alreadyShoot = 0;
        while (alreadyShoot < bulletAmount)
        {
            Instantiate(bullet, ShootPoint.transform.position, Quaternion.Euler(180 + transform.eulerAngles.y, 0, 0));
			CannonSoundManager.instance.PlayCannonShootSound ();
            yield return new WaitForSeconds(0.5f);
            alreadyShoot++;
        }

        StartCoroutine("Shoot");

    }
}
