using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

public class SaveData
{
    public static void PostDataToFirebase(){
        User user = new User();

        RestClient.Put("https://iec-test-68513.firebaseio.com/" + SystemInfo.deviceUniqueIdentifier +  ".json", user);
    }
}

public class User{
    public int fishCone;
    public int premium;

    public User(){
        fishCone = PlayerData.instance.coins;
        premium = PlayerData.instance.premium;
    }
}

