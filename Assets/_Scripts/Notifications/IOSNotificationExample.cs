using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class IOSNotificationExample : MonoBehaviour
{
    [SerializeField] private string notificationID = "Example One";

#if UNITY_IOS
    public void NotificationExample()
    {
        iOSNotification notification = new iOSNotification()
        {
            Identifier = notificationID,
            Title = "Example Title",
            Subtitle = "WHere are you?",
            Body = "Come back and play!",
            ShowInForeground = false,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new System.TimeSpan(0,0,0,10), //Esto esta en Dias, Horas, Minutos y Segundos
                Repeats = false
            }
        };
        iOSNotificationCenter.ScheduleNotification(notification);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            NotificationExample();
        }
        else
        {
            iOSNotificationCenter.RemoveScheduledNotification(notificationID);
        }
    }
#endif
}
