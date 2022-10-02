using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] CoinCollect coinCollect;
    [SerializeField] RectTransform winCanvas;
    [SerializeField] Animator winCanvasAnimator;
    [SerializeField] Animator notNowAnimator;
    [SerializeField] Text cheerText;
    [SerializeField] Text moneyCount;
    [SerializeField] Text moneyX1Text;
    [SerializeField] Text moneyX3Text;

    private bool disabled;
    private bool complete;
    private int moneyX1;
    private int moneyX3;
    public void Show(int count)
    {
        UniAndroidVibration.Vibrate(500);


        moneyCount.text = Money.Instance.count.ToString();
        cheerText.text = UI.Instance.GetCongratulation();
        moneyX1 = count;
        moneyX3 = moneyX1 * 3;
        moneyX1Text.text = $"+{moneyX1}";
        moneyX3Text.text = $"+{moneyX3}";

        disabled = false;
        winCanvasAnimator.SetTrigger("Show");
        notNowAnimator.SetTrigger("Show");
    }

    public void Hide()
    {
        winCanvasAnimator.SetTrigger("Hide");
    }

    public void GetX1()
    {
        if (!disabled)
        {
            disabled = true;
            complete = false;
            coinCollect.StartCoinMove(moneyX1, 
                () =>
            {
                OnCoinCollected();
            }, 
                () =>
            {
                Hide();
            });
        }
    }
    public void GetX3()
    {
        if (!disabled)
        {
            disabled = true;
            complete = false;
            Ads.Instance.ShowRewardedVideo("X3");
#warning remove after event implementation
            RewardedVideoFinished();
        }
    }

    public void RewardedVideoFinished()
    {
        coinCollect.StartCoinMove(moneyX3, 
            () =>
        {
            OnCoinCollected();
        }, 
            () =>
        {
            Hide();
        });
    }

    private void OnCoinCollected()
    {
        Money.Instance.GetMoney(1);
        moneyCount.text = Money.Instance.count.ToString();
        if (!complete)
        {
            complete = true;
        }
    }
    private void Complete()
    {
        notNowAnimator.SetTrigger("Hide");
        FieldController.Instance.Complete();
    }
}
