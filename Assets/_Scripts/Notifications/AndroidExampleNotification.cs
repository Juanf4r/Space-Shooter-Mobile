using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using System;

public class AndroidExampleNotification : MonoBehaviour
{
    [SerializeField] private int notificationId;
    [SerializeField] private string channelIdExample;

    private void Start()
    {
        //Debug.Log(DateTime.Now.ToString());
    }

#if UNITY_ANDROID

    public void NotificationExample(DateTime timeToFire)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = channelIdExample,
            Name = "Example Name",
            Description = "This is just an Example",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            //Esto es lo que aparecera en la notificacion
            Title = "Where are you?",
            Text = "Come back and Play",
            SmallIcon = "default", //Default si ya tenemos icon en Player Settings
            LargeIcon = "default", //Default si ya tenemos icon en Player Settings
            FireTime = timeToFire
        };

        //AndroidNotificationCenter.SendNotification(notification, channelIdExample);
        AndroidNotificationCenter.SendNotificationWithExplicitID(notification, channelIdExample, notificationId);
    }

    private void OnApplicationFocus(bool focus)
    {
        if(focus == false)
        {
            DateTime whenToFire = DateTime.Now.AddSeconds(12);
            NotificationExample(whenToFire);
        }
        else
        {
            //AndroidNotificationCenter.CancelAllScheduledNotifications();
            AndroidNotificationCenter.CancelScheduledNotification(notificationId);
        }
    }
#endif
}
