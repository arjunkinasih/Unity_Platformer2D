using UnityEngine;

public class goalManager : MonoBehaviour
{
    public static goalManager singelton; //untuk memanggil variable/fungsion yang public dari goalmanager
    public int holywaterNeeded;
    public int holywaterCollected;
    public bool canEnter;

    void Awake()
    {
        singelton = this;
    }
    public void collectHolywater()
    {
        holywaterCollected++;
        if (holywaterCollected >= holywaterNeeded)
        {
            canEnter = true;
        }    
    }
}
