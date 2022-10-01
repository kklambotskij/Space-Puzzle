using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    [SerializeField] private Button claimB;
    [SerializeField] private Text currentTimeReward;
    [SerializeField] private Money money;

    private float cooldownTime = 1f;
    private bool canClaimReward;

    public static int count;

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        }
    }
#else
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif

    private DateTime ? lastClaim
    {
        get
        {            
            string data = PlayerPrefs.GetString("LastSession", null);

            if (!string.IsNullOrEmpty(data))            
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString("LastSession", value.ToString());
            else
                PlayerPrefs.DeleteKey("LastSession");
        }
    }

    void Start()
    {
        StartCoroutine(RewardStateUpdate());
    }
    public void FreeCoins()
    {
        money.GetMoney(count);
        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            count = 15;
            FieldController.Instance.shop.CloseShop();
        }
        PlayerPrefs.SetString("StartCooldown", DateTime.Now.TimeOfDay.ToString());
        Debug.Log(PlayerPrefs.GetString("StartCooldown"));
        claimB.interactable = false;
    }
    private IEnumerator RewardStateUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            UpdateReward();
        }
    }

    private void UpdateReward()
    {
        DateTime.Now.Day.ToString();
        TimeSpan startCooldown = DateTime.Now.Subtract(DateTime.Parse(PlayerPrefs.GetString("StartCooldown")));

        canClaimReward = false;

        if (PlayerPrefs.HasKey("LastSession"))
        {
            TimeSpan lastSessionTime = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            Debug.Log(lastSessionTime);
            startCooldown -= lastSessionTime;
        }
        
        TimeSpan timeSpan = DateTime.Now.TimeOfDay - startCooldown;
        Debug.Log(timeSpan);
        if (PlayerPrefs.HasKey("StartCooldown") && timeSpan.Hours >= cooldownTime)
        {
            canClaimReward = true;
        }
        UpdateRewardUI(timeSpan);
    }

    private void UpdateRewardUI(TimeSpan timeSpan)
    {
        claimB.interactable = canClaimReward;

        if (canClaimReward)
            currentTimeReward.text = "Бесплатно";
        else
        {
            string cooldown = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            currentTimeReward.text = cooldown;
        }
    }
}
