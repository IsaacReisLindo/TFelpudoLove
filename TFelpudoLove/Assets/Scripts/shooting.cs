using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;



    void Update()
    {
       
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;

            ;
        }
    }
}