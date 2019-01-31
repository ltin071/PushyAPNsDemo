# PushyAPNsDemo

This is a project that demo implementation for Pushy and APNs in Xamarin.

**Pushy part**
1. Make sure you open it in VS2017 and run the android part
2. API for testing:
```
https://api.pushy.me/push?api_key=e3081ffedfb8e25731f61824909dead0ce8074253c12c4190880e365cf9d015b
Content-type application/json
{
    "to": "a898837e75b385476093ef",
        "data": {"message": "test"},
        "notification": {
        "body": "test","badge": 1,
        "sound": "ping.aiff"
        }
}
```

*Please replace "to" with /topics/news" if you want to test out topic notification

**APNs part**

1. Make sure you open it in VS2017 and run the iOS part
2. No testing can be done on APNs without PushyAPNsDemoWebAPI project, please test with that project.
