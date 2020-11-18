using UnityEngine;

//Applied to main camera in player
public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public GameObject impactEffect;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            TargetDragon targetDragon = hit.transform.GetComponent<TargetDragon>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (targetDragon != null)
            {
                targetDragon.TakeDamage(damage);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
