using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //movement
    public float movespeed;
    public bool IsFacingRight;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    //checker
    public Transform groundchecker;
    public float groundcheckerRadius;
    public LayerMask whatisground;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////

    public Transform healtbarHUD;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movespeed * Time.deltaTime); //kode otomatis jalan kekanan
        if (!Thereisground()) // kode apakah didepan tidak ada jalan
        {
            if (IsFacingRight)
            {
                healtbarHUD.localEulerAngles = Vector2.zero;//kode untuk putar balik ke kiri(healtbarUI)
                transform.eulerAngles = Vector2.up * 180; //kode untuk putar balik ke kiri
                IsFacingRight = false;
            }
            else
            {
                healtbarHUD.localEulerAngles = Vector2.up * 180;// kode jika dia awalnya hadap kiri, maka akan langsung hadap kanan(healtbarUI)
                transform.eulerAngles = Vector2.zero;// kode jika dia awalnya hadap kiri, maka akan langsung hadap kanan
                IsFacingRight = true;
            }
        }
    }

    bool Thereisground() //kode untuk memeriksa apakah didepan masih ada jalan atau tidak?
    {
        return Physics2D.OverlapCircle(groundchecker.position, groundcheckerRadius, whatisground);
    }

     void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundchecker.position, groundcheckerRadius);//dengan ini kita bisa melihat lingkaranya, agar presisi saat menempatkanya
    }
}
