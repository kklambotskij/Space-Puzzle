using UnityEngine;

public class Hint : MonoBehaviour
{
    public float count;
    public static Hint Instance { get; private set; } // static singleton
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        GetHint(PlayerPrefs.GetFloat("money", 0));
    }
    public void GetHint(float hintGet)
    {
        count += hintGet;
        PlayerPrefs.SetFloat("money", count);
    }
    public bool SpendMoney(int moneySpend)
    {
        if (count >= moneySpend)
        {
            GetHint(-moneySpend);
            return true;
        }
        else
            return false;
    }
}