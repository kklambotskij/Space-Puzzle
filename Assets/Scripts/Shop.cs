using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [SerializeField] private Money money;
    [SerializeField] private GameObject shopScreen;
    [SerializeField] private Animator shopTutorial;
    [SerializeField] private FieldController fieldController;
    [SerializeField] private GameObject fieldFigure;
    [SerializeField] private Text[] priceSkins;
    [SerializeField] private Image[] imageSkin;
    [SerializeField] private CoinCollect coinCollect;
    [SerializeField] private Color colorSkinBought;
    [SerializeField] private Color colorSkinChosen;

    private bool[] isSoldSkin = new bool[5];

    public virtual void OpenShop()
    {
        shopScreen.gameObject.SetActive(true);
        fieldFigure.SetActive(false);
        if (!PlayerPrefs.HasKey("Tutorial"))
            shopTutorial.gameObject.SetActive(true);
            shopTutorial.SetTrigger("Start");
    }

    public void CloseShop()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
            shopTutorial.SetTrigger("Stop");
            shopTutorial.gameObject.SetActive(false);
            UI.Instance.helpButton.GetComponent<Animator>().SetTrigger("Pop");
        shopScreen.gameObject.SetActive(false);
        fieldFigure.SetActive(true);
    }

    public void BuyOneHundredCoints()
    {
        coinCollect.StartCoinMove(10, 
            () =>
        {
            Money.Instance.GetMoney(5);
        }, 
            () =>
        {

        });
    }
    public void BuyThreeHundredCoints()
    {
        money.GetMoney(300);
    }
    public void BuyFiveHundredCoints()
    {
        money.GetMoney(500);
    }
    public void BuyOneThousandCoints()
    {
        money.GetMoney(1000);
    }
    public void BuyTwoThousandCoints()
    {
        money.GetMoney(2000);
    }
    public void BuyFiveThousandCoints()
    {
        money.GetMoney(5000);
    }
    public void BuySkinOneHundred()
    {
        if (!isSoldSkin[0])
        {
            BuySkin(100, 0);
            isSoldSkin[0] = true;            
        }
        else
        {
            BuySkin(0,0);
        }
    }
    public void BuySkinTwoHundred()
    {
        if (!isSoldSkin[1])
        {
            BuySkin(200, 1);
            isSoldSkin[1] = true;
        }
        else
        {
            BuySkin(0, 1);
        }
    }
    public void BuySkinThreeHundred()
    {
        if (!isSoldSkin[2])
        {
            BuySkin(300, 2);
            isSoldSkin[2] = true;
        }
        else
        {
            BuySkin(0, 2);
        }
    }
    public void BuySkinFourHundred()
    {
        if (!isSoldSkin[3])
        {
            BuySkin(400, 3);
            isSoldSkin[3] = true;
        }
        else
        {
            BuySkin(0, 3);
        }
    }
    public void BuySkinFiveHundred()
    {
        if (!isSoldSkin[4])
        {
            BuySkin(500, 4);
            isSoldSkin[4] = true;
        }
        else
        {
            BuySkin(0, 4);
        }
    }
    public void WatchAd()
    {
        Ads.Instance.ShowRewardedVideo("ShopAds");
    }
    public void ResetMoney()
    {
        Money.Instance.GetMoney(-999999);
        PlayerPrefs.DeleteKey("StartCooldown");
        PlayerPrefs.DeleteKey("LastSession");
    }
    private void BuySkin(int price, int numSkin)
    {
        if (Money.Instance.SpendMoney(price) && price != 0)
        {            
            fieldController.SwapFigureCells(numSkin);
            PlayerPrefs.SetInt("skin", numSkin);
            SwapColorSkin(numSkin);
        }
        else if(Money.Instance.SpendMoney(price) && price == 0)
        {
            fieldController.SwapFigureCells(numSkin);
            SwapColorSkin(numSkin);
        }
    }

    private void SwapColorSkin(int numSkin)
    {
        for (int i = 0; i < imageSkin.Length; i++)
        {
            if (isSoldSkin[i])
            {
                imageSkin[i].color = colorSkinBought;
                priceSkins[i].text = "Куплен";
            }
        }
        imageSkin[numSkin].color = colorSkinChosen;
        priceSkins[numSkin].text = "Выбран";
    }
}
