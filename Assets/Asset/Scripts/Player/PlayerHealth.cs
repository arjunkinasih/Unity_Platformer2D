using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject[] healthUI;

    void takedamage()
    {
        health--;
        if (health <= 0)//kode untuk mengurangi nyawa saat player bersentuhan dengan enemy
        {
            health = 0;//kode jika healt 0 maka loadscene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//kode untuk mengulang dari awal jika player mati
        }
        healthUI[health].SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            takedamage();// trigger akan memeriksa apkah player bersentuhan dengan enemy jika iya maka take damage akan dipanggil 
        }
        else if (collision.CompareTag("spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
