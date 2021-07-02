using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    private string UserEmail;
    private string UserPassword;
    private string username;
    bool MobileIDLogin = false;

    public GameObject loginPanel;


    [SerializeField] LanguageManagerLogin myLanguageManagerLogin;
    [SerializeField] bool RememberMe;

    [Space(10)]
    [Header("Error Strings")]

    public GameObject registerErrorObject;
    TextMeshProUGUI registerErrorTM;
    string registerErrorText;
    [Space(5)]
    public GameObject SigninErrorObject;
    TextMeshProUGUI SigninErrorTM;
    string SigninErrorText;

    [Header("Debug errors")]
    [SerializeField] TextMeshProUGUI DebugMobileLogin;
    [SerializeField] TextMeshProUGUI DebugLinkMobileLogin;
    [SerializeField] TextMeshProUGUI DebugRegister;
    [SerializeField] TextMeshProUGUI DebugSignIn;

    string DebugMobileText;
    string DebugLinkMobileText;
    string DebugRegisterText;
    string debugSignInText;



    public void Start()
    {
        MobileIDLogin = false;
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "BD954";
        }
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            UserEmail = PlayerPrefs.GetString("EMAIL");
            UserPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = UserEmail, Password = UserPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
        else
        {

            if (Application.platform == RuntimePlatform.Android)
            {
                var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(), CreateAccount = false };
                PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginMobileSuccess, OnLoginMobileFailure);
            }
#if UNITY_IOS
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                var requestIOS = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = false };
                PlayFabClientAPI.LoginWithIOSDeviceID(requestIOS, OnLoginMobileSuccess, OnLoginMobileFailure);

            }
#endif
        }

        // get dependencies
        registerErrorTM = registerErrorObject.GetComponent<TextMeshProUGUI>();
        SigninErrorTM = SigninErrorObject.GetComponent<TextMeshProUGUI>();
        registerErrorObject.SetActive(false);
        SigninErrorObject.SetActive(false);

    }

    private void Update()
    {
        if(DebugMobileLogin != null)
        {
            DebugMobileLogin.text = DebugMobileText;
        }
       if(DebugLinkMobileLogin != null)
        {
            DebugLinkMobileLogin.text = DebugLinkMobileText;
        }
       if(DebugRegister != null)
        {
            DebugRegister.text = DebugRegisterText;
        }
       if(DebugSignIn != null)
        {
            DebugSignIn.text = debugSignInText;
        }

    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }


        loginPanel.SetActive(false);
    }

    private void OnLoginMobileSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful Mobile API call!");
        MobileIDLogin = true;
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        LinkMobileID();


        Debug.Log("Congratulations, you made your first successful API call!");
        loginPanel.SetActive(false);
    }
    private void OnLoginFailure(PlayFabError error)
    {
        switch (error.Error)
        {
            case PlayFabErrorCode.InvalidEmailAddress:
            case PlayFabErrorCode.InvalidPassword:
            case PlayFabErrorCode.InvalidEmailOrPassword:
                SigninErrorText = myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.InvalidUser);
                SigninErrorTM.text = SigninErrorText;
                SigninErrorObject.SetActive(true);
                break;
            default:
                registerErrorText = error.GenerateErrorReport();
                registerErrorTM.text = registerErrorText;
                registerErrorObject.SetActive(true);
                break;
        }

        debugSignInText = error.GenerateErrorReport();
        //Debug.LogWarning("Something went wrong with your first API call.  :(");
        //Debug.LogError("Here's some debug information:");
        //Debug.LogError(error.GenerateErrorReport());  
    }
    private void OnLoginMobileFailure(PlayFabError error)
    {
        Debug.LogWarning(error.GenerateErrorReport());
        //Debug.LogError("Here's some debug information:");
        //Debug.LogError(error.GenerateErrorReport());

    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        switch (error.Error)
        {
            case PlayFabErrorCode.EmailAddressNotAvailable:
                registerErrorText = myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.EmailTaken);
                registerErrorTM.text = registerErrorText;
                registerErrorObject.SetActive(true);
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                registerErrorText = myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.UsernameTaken);
                registerErrorTM.text = registerErrorText;
                registerErrorObject.SetActive(true);
                break;
            case PlayFabErrorCode.InvalidEmailAddress:
            case PlayFabErrorCode.InvalidPassword:
            case PlayFabErrorCode.InvalidEmailOrPassword:
           
                registerErrorText = myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.InvalidUser);
                registerErrorTM.text = registerErrorText;
                registerErrorObject.SetActive(true);
                break;
            default:
                registerErrorText = error.GenerateErrorReport();
                registerErrorTM.text = registerErrorText;
                registerErrorObject.SetActive(true);
                break;
        }

        DebugRegisterText = error.GenerateErrorReport();
    }


    public void GetUserEmail(string emailIn)
    {
        UserEmail = emailIn;
    }
    public void GetUserPassword(string passwordIn)
    {
        UserPassword = passwordIn;
    }

    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
    }

    public void ToogleRememberMe(bool rememberMe)
    {
        RememberMe = rememberMe;
    }

    public void OnClickSignIn()
    {

        var request = new LoginWithEmailAddressRequest { Email = UserEmail, Password = UserPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }

    public void OnClickRegister()
    {
        //var registerRequest = new RegisterPlayFabUserRequest { Email = UserEmail, Password = UserPassword, Username = username };
        //PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);

        if (MobileIDLogin)
        {
            var registerAddRequest = new AddUsernamePasswordRequest { Email = UserEmail, Password = UserPassword, Username = username };
            PlayFabClientAPI.AddUsernamePassword(registerAddRequest, OnAddRegisterSuccess, OnRegisterFailure);
        }
        else
        {
            var registerRequest = new RegisterPlayFabUserRequest { Email = UserEmail, Password = UserPassword, Username = username };
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
        }

    }

    private void OnAddRegisterSuccess(AddUsernamePasswordResult result)
    {
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        Debug.Log("Congratulations, you made your first successful API call!");
        loginPanel.SetActive(false);
    }

    public static string ReturnMobileID()
    {
        string DeviceID = SystemInfo.deviceUniqueIdentifier;
        return DeviceID;
    }

    #region Unlink Device ID
    private void UnlinkMobileID()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            var unlinkIOSRequest = new UnlinkIOSDeviceIDRequest { DeviceId = ReturnMobileID() };
            PlayFabClientAPI.UnlinkIOSDeviceID(unlinkIOSRequest, OnIOSUnlinkSuccess, OnMobileUnlinkError);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            var unlinkAndroidRequest = new UnlinkAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID() };
            PlayFabClientAPI.UnlinkAndroidDeviceID(unlinkAndroidRequest, OnAndroidUnlinkSuccess, OnMobileUnlinkError);
        }

    }
    private void OnAndroidUnlinkSuccess(UnlinkAndroidDeviceIDResult result)
    {

    }
    private void OnIOSUnlinkSuccess(UnlinkIOSDeviceIDResult result)
    {

    }

    private void OnMobileUnlinkError(PlayFabError error)
    {
        
    }
    #endregion
    #region Link Device ID
    private void LinkMobileID()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            var linkIOSRequest = new LinkIOSDeviceIDRequest { DeviceId = ReturnMobileID() };
            PlayFabClientAPI.LinkIOSDeviceID(linkIOSRequest, OnLinkIOSDeviceSuccess, OnMobileLinkError);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            var linkAndroidRequest = new LinkAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID() };
            PlayFabClientAPI.LinkAndroidDeviceID(linkAndroidRequest, OnLinkAndroidDeviceSuccess, OnMobileLinkError);
        }
    }

    private void OnLinkIOSDeviceSuccess(LinkIOSDeviceIDResult result)
    {

    }
    private void OnLinkAndroidDeviceSuccess(LinkAndroidDeviceIDResult result)
    {

    }
    private void OnMobileLinkError(PlayFabError error)
    {
        DebugLinkMobileText = error.GenerateErrorReport();
    }

    #endregion


    public void OnCLickPlay()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(), CreateAccount = true };
            PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginMobileSuccess, OnLoginMobileFailure);
        }
#if UNITY_IOS
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            var requestIOS = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = true };
            PlayFabClientAPI.LoginWithIOSDeviceID(requestIOS, OnLoginMobileSuccess, OnLoginMobileFailure);

        }
#endif

    }


}
