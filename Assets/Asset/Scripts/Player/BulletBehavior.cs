using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed, damage, destroytime;

    void Awake()
    {
        Destroy(gameObject, destroytime);//kode untuk otomatis destroy peluru beberapa detik kemudian
    }
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);//speed peluru 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))//jika peluru kena enemy maka destroy peluru
        {
            collision.transform.parent.GetComponent<EnemyHealth>().takedamage(damage);//memanggil script EnemyHealth
            Destroy(gameObject);
        }
        else if (collision.CompareTag("enviroment"))//jika peluru kena enviroment maka destroy peluru
        {
            Destroy(gameObject);
        }
    }
}
