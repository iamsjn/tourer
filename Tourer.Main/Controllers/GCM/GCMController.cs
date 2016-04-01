using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PushSharp.Core;
using PushSharp.Google;
using Newtonsoft.Json.Linq;

namespace Tourer.Main.Controllers
{
    public class GCMController : ApiController
    {
        public IHttpActionResult SendPushNotification()
        {
            string responsMessage = string.Empty;
            // Configuration
            var config = new GcmConfiguration("275794811333", "AIzaSyCh4-tyqd3xPvYiUJjWbl7NANMOLQT2Gmg", null);

            // Create a new broker
            var gcmBroker = new GcmServiceBroker(config);

            // Wire up events
            gcmBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {
                aggregateEx.Handle(ex =>
                {
                    // See what kind of exception it was to further diagnose
                    if (ex is GcmNotificationException)
                    {
                        var notificationException = (GcmNotificationException)ex;

                        // Deal with the failed notification
                        var gcmNotification = notificationException.Notification;
                        var description = notificationException.Description;

                        responsMessage = $"GCM Notification Failed: ID={gcmNotification.MessageId}, Desc={description}";
                    }
                    else if (ex is GcmMulticastResultException)
                    {
                        var multicastException = (GcmMulticastResultException)ex;

                        foreach (var succeededNotification in multicastException.Succeeded)
                        {
                            responsMessage = $"GCM Notification Failed: ID={succeededNotification.MessageId}";
                        }

                        foreach (var failedKvp in multicastException.Failed)
                        {
                            var n = failedKvp.Key;
                            var e = failedKvp.Value;

                            responsMessage = $"GCM Notification Failed: ID={n.MessageId}, Desc={e.Message}";
                        }

                    }
                    else if (ex is DeviceSubscriptionExpiredException)
                    {
                        var expiredException = (DeviceSubscriptionExpiredException)ex;

                        var oldId = expiredException.OldSubscriptionId;
                        var newId = expiredException.NewSubscriptionId;

                        responsMessage = $"Device RegistrationId Expired: {oldId}";

                        if (!string.IsNullOrWhiteSpace(newId))
                        {
                            // If this value isn't null, our subscription changed and we should update our database
                            responsMessage = $"Device RegistrationId Changed To: {newId}";
                        }
                    }
                    else if (ex is RetryAfterException)
                    {
                        var retryException = (RetryAfterException)ex;
                        // If you get rate limited, you should stop sending messages until after the RetryAfterUtc date
                        responsMessage = $"GCM Rate Limited, don't send more until after {retryException.RetryAfterUtc}";
                    }
                    else {
                        responsMessage = "GCM Notification Failed for some unknown reason";
                    }

                    // Mark it as handled
                    return true;
                });
            };

            gcmBroker.OnNotificationSucceeded += (notification) =>
            {
                responsMessage = "GCM Notification Sent!";
            };

            // Start the broker
            gcmBroker.Start();

            // Queue a notification to send
            gcmBroker.QueueNotification(new GcmNotification
            {
                RegistrationIds = new List<string> { "eOcBgZNrsU8:APA91bEvl1cZEW4xXEqD7dJWeaE1vHWGiMCw-ZV6jkAGu68WvnmnyEXt0aFTA-EhI5utXymqhQyCAdpdD6y-jq73BLSgijUS7PxyWXTHRJr2QFCK8tGdjvVfoOBQsk7sAggvzaRIGIAV" },
                Data = JObject.Parse("{ \"somekey\" : \"somevalue\" }")
            });

            //    foreach (var regId in MY_REGISTRATION_IDS)
            //    {
            //        // Queue a notification to send
            //        gcmBroker.QueueNotification(new GcmNotification
            //        {
            //            RegistrationIds = new List<string> {
            //    regId
            //},
            //            Data = JObject.Parse("{ \"somekey\" : \"somevalue\" }")
            //        });
            //    }

            // Stop the broker, wait for it to finish   
            // This isn't done after every message, but after you're
            // done with the broker
            gcmBroker.Stop();

            return Ok(responsMessage);
        }
    }
}
