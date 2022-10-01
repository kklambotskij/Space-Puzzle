using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text moneyShopText;
    [SerializeField] private Text moneyLevelText;
    public float count;

    public static Money Instance { get; private set; } // static singleton
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        GetMoney(PlayerPrefs.GetFloat("money", 0));
    }
    public void GetMoney(float moneyGet)
    {
        count += moneyGet;
        if (count < 0)
        {
            count = 0;
        }
        PlayerPrefs.SetFloat("money", count);
        moneyShopText.text = $"{count}";
        moneyLevelText.text = $"{count}";
    }
    public bool SpendMoney(int moneySpend)
    {
        if (count >= moneySpend)
        {
            GetMoney(-moneySpend);
            return true;
        }
        else
        {
            Debug.Log("не достаточно денег");
            return false;
        }    
    }
}
