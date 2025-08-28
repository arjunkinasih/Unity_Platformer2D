using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, shootpoint.position, transform.rotation);
        }
    }
}
