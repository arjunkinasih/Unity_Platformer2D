using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    float maxhealth;
    public Image healthUI;

    void Start()
    {
        maxhealth = health;
    }

    public void takedamage(float damage)
    {
        healthUI.fillAmount = health / maxhealth;//kode untuk mengurangi UI health enemy dengan lebih presisi
        health -= damage;// mengurangi nyawa enemy setiap kena peluru
        if (health <= 0)//jika enemy darahnya 0 maka destroy enemy
        {
            Destroy(gameObject);
        }
    }
}
