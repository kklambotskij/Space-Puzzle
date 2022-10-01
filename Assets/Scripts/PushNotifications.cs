using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class PushNotifications : MonoBehaviour
{
    private void Awake()
    {
        CreateNotificationsChannel();
    }
    public void CreateNotificationsChannel()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }
    public void CreateNotifications()
    {
        var notification = new AndroidNotification();
        notification.Title = "Скидки на шубы";
        notification.Text = "несколько увроней не пройдено, вернись в игру и пройди";
        notification.FireTime = System.DateTime.Now.AddDays(1);
        notification.LargeIcon = "large_icon";
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
