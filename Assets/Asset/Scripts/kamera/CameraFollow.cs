using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerpos;
    public Vector3 offset;
    public float cameraspeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerpos.position + offset, cameraspeed * Time.deltaTime);
        //kode ini membuat movement kamera berjalan linear //...+ offset berfungsi sebagai agar kamera tidak diposisi(Z=0) jadi harus diubah jadi -10
    }
}
