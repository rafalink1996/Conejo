using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.iOS;

public class KeychainTest : MonoBehaviour
{
    public TextMeshProUGUI DevicIDText;
    public TextMeshProUGUI KeychainIDText;
    public TextMeshProUGUI VendorIDText;
    public TextMeshProUGUI AdvertisingIDText;
    // Start is called before the first frame update

    private void Start()
    {
        DevicIDText.text = SystemInfo.deviceUniqueIdentifier;
        VendorIDText.text = Device.vendorIdentifier;
        AdvertisingIDText.text = Device.advertisingIdentifier;
    }
    public void SaveKeychain()
    {
        string DeviceID = SystemInfo.deviceUniqueIdentifier;
        KeyChain.BindSetKeyChainUser("0", DeviceID);
        Debug.Log("SaveUUID: [" + DeviceID + "]");
    }

    public void loadKeyChain()
    {
        string KeychainID = KeyChain.BindGetKeyChainUser();
        if (string.IsNullOrEmpty(KeychainID))
        {
            KeychainIDText.text = KeychainID;
            Debug.Log("LoadUUID: [" + KeychainID + "]");
        }
        else
        {
            KeychainIDText.text = "No keychain Save";
        }
    }
}
