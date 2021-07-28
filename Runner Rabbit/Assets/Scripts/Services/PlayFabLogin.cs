using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    [Header("User Info")]
    [SerializeField] private string UserEmail;
    [SerializeField] private string UserPassword;
    [SerializeField] private string UserConfirmPassword;
    [SerializeField] private string username;

    [Space(10)]
    [Header("Status Bools")]
    bool MobileIDLogin = false;
    [SerializeField] bool ChangeAccount = false;
    [SerializeField] bool RememberMe;
    bool CompleatlyLoggedIn;
    bool SkippedLoggin;
    


    [Space(10)]
    [Header("Support Scripts References")]
    [SerializeField] LanguageManagerLogin myLanguageManagerLogin;
    [SerializeField] PlayfabLoginUI myPlayfabLoginUI;
   


    [Space(10)]
    [Header("Debug errors")]
    [SerializeField] TextMeshProUGUI SignInStatus;
    [SerializeField] TextMeshProUGUI EmailRetrieved;
    [SerializeField] TextMeshProUGUI DataRetrievalStatus;
    [SerializeField] TextMeshProUGUI ErrorReport;
    [SerializeField] TextMeshProUGUI DeviceIdentifier;



    #region Login
    
    public void Start()
    {
        InitializePlayfab();

    }

    private void InitializePlayfab()
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
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            Debug.Log("User has stored email");
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
#if UNITY_EDITOR
            else
            {
                var requestEditor = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = false };
                PlayFabClientAPI.LoginWithIOSDeviceID(requestEditor, OnLoginMobileSuccess, OnLoginMobileFailure);
            }   
#endif
        }


        //Debugs
        DeviceIdentifier.text = ReturnMobileID();
    }

    #region SuccessMethods
    private void OnLoginSuccess(LoginResult result)
    {

        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        else
        {
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }

        LinkMobileID();
        Debug.Log("Login success");
        DisableLoginPanel();
    }

    private void OnLoginMobileSuccess(LoginResult result)
    {
        SignInStatus.text = "success";
        //Debug.Log("Congratulations, you made your first successful Mobile API call!");
        MobileIDLogin = true;

        string LoginPlayfabID = result.PlayFabId;
        var GetAccountInfoRequest = new GetAccountInfoRequest { PlayFabId = LoginPlayfabID };
        PlayFabClientAPI.GetAccountInfo(GetAccountInfoRequest, OnGetInfoSuccess, OnGetUserInfoFailure);

    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        else
        {
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        LinkMobileID();


        Debug.Log("Congratulations, you made your first successful API call!");
        DisableLoginPanel();
    }
    private void OnAddRegisterSuccess(AddUsernamePasswordResult result)
    {
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        else
        {
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }

        Debug.Log("Congratulations, you made your first successful API call!");
        DisableLoginPanel();
    }
    private void OnChangeAccountRegisterSuccess(RegisterPlayFabUserResult result)
    {
        if (RememberMe)
        {
            PlayerPrefs.SetString("EMAIL", UserEmail);
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        else
        {
            PlayerPrefs.SetString("PASSWORD", UserPassword);
        }
        UnlinkMobileID();
        LinkMobileID();


        Debug.Log("Created new account and relinked Device");
        DisableLoginPanel();
    }


    private void OnGetInfoSuccess(GetAccountInfoResult result)
    {
        DataRetrievalStatus.text = "success";
        string email = result.AccountInfo.PrivateInfo.Email;
        string StoredUsername = result.AccountInfo.Username;



        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(StoredUsername))
        {
            //DeviceAccountWithEmail
       
            EmailRetrieved.text = "Email: " + email;
            username = StoredUsername;
            UserEmail = email;

            AsignUsername(username);
            ShowContinueAsPanel();
            DisableRecoverableDataAskPanel();

        }
        else
        {
            //DeviceAccountWithNoEmail
            EmailRetrieved.text = "No Email";
        }

    }


    #endregion SuccessMethods

    #region Failure Methods
    private void OnLoginFailure(PlayFabError error)
    {
        switch (error.Error)
        {
            case PlayFabErrorCode.InvalidEmailAddress:
            case PlayFabErrorCode.InvalidPassword:
            case PlayFabErrorCode.InvalidEmailOrPassword:
                DisplaySigninError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.InvalidUser));
                break;
            default:
                DisplaySigninError(error.GenerateErrorReport());
                break;
        }
        Debug.LogWarning("Something went wrong the login");      
    }
    private void OnLoginMobileFailure(PlayFabError error)
    {
        SignInStatus.text = "Falure";
        ErrorReport.text = error.GenerateErrorReport();

        if (SkippedLoggin)
        {
            DisableLoginPanel();
        }

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
                DisplayRegisterError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.EmailTaken));
                break;
            case PlayFabErrorCode.UsernameNotAvailable:
                DisplayRegisterError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.UsernameTaken));

                break;
            case PlayFabErrorCode.InvalidEmailAddress:
            case PlayFabErrorCode.InvalidPassword:
            case PlayFabErrorCode.InvalidEmailOrPassword:
                DisplayRegisterError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.InvalidUser));
                break;
            default:
                DisplayRegisterError(error.GenerateErrorReport());
                break;
        }


    }

    private void OnGetUserInfoFailure(PlayFabError error)
    {
        DataRetrievalStatus.text = "Failure";
        EmailRetrieved.text = "Get User info Failed";
    }

    #endregion Failure Methods

    #region GetMethods
    public void GetUserEmail(string emailIn)
    {
        UserEmail = emailIn;
    }
    public void GetUserPassword(string passwordIn)
    {
        UserPassword = passwordIn;
    }
    public void GetUserConfirmPassword(string ConfirmpasswordIn)
    {
        UserConfirmPassword = ConfirmpasswordIn;
    }

    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
    }

    #endregion GetMethods

    #region OnClick Methods
    public void OnClickSignIn()
    {
        if (ChangeAccount)
        {
            UnlinkMobileID();
            PlayFabClientAPI.ForgetAllCredentials();
            var loginWithPlayfabRequest = new LoginWithPlayFabRequest { Username = username, Password = UserPassword };
            PlayFabClientAPI.LoginWithPlayFab(loginWithPlayfabRequest, OnLoginSuccess, OnLoginFailure);
        }
        else
        {
            if (MobileIDLogin)
            {
                UnlinkMobileID();
                PlayFabClientAPI.ForgetAllCredentials();
                var loginWithPlayfabRequest = new LoginWithPlayFabRequest { Username = username, Password = UserPassword };
                PlayFabClientAPI.LoginWithPlayFab(loginWithPlayfabRequest, OnLoginSuccess, OnLoginFailure);
            }
            else
            {
                var loginWithPlayfabRequest = new LoginWithPlayFabRequest { Username = username, Password = UserPassword };
                PlayFabClientAPI.LoginWithPlayFab(loginWithPlayfabRequest, OnLoginSuccess, OnLoginFailure);
            }
        }
    }

    public void OnClickRegister()
    {
        if (ChangeAccount)
        {
            if (UserPassword == UserConfirmPassword)
            {
                UnlinkMobileID();
                PlayFabClientAPI.ForgetAllCredentials();
                var registerRequest = new RegisterPlayFabUserRequest { Email = UserEmail, Password = UserPassword, Username = username };
                PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnChangeAccountRegisterSuccess, OnRegisterFailure);
                LinkMobileID();
            }
            else
            {
                DisplayRegisterError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.PasswordUnmatch));
            }
        }
        else
        {
            if (UserPassword == UserConfirmPassword)
            {
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
            else
            {
                DisplayRegisterError(myLanguageManagerLogin.GetErrorMessageTrnalation(GameStats.stats.LanguageSelect, LanguageManagerLogin.ErrorType.PasswordUnmatch));
            }
        }
    }
    public void OnClickPlay()
    {
        Debug.Log("Login Skipped");
        SkippedLoggin = true;
        if (MobileIDLogin)
        {
            if (RememberMe)
            {
                PlayerPrefs.SetString("EMAIL", UserEmail);
            }
            DisableLoginPanel();
        }
        else
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
#if UNITY_EDITOR
            var requestEditor = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = true };
            PlayFabClientAPI.LoginWithIOSDeviceID(requestEditor, OnLoginMobileSuccess, OnLoginMobileFailure);
#endif

        }


    }

    #endregion OnClick Methods

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
        else
        {
            var unlinkIOSRequest = new UnlinkIOSDeviceIDRequest { DeviceId = ReturnMobileID() };
            PlayFabClientAPI.UnlinkIOSDeviceID(unlinkIOSRequest, OnIOSUnlinkSuccess, OnMobileUnlinkError);
        }

    }
    private void OnAndroidUnlinkSuccess(UnlinkAndroidDeviceIDResult result)
    {
        Debug.Log("Android Unlinked");
    }
    private void OnIOSUnlinkSuccess(UnlinkIOSDeviceIDResult result)
    {
        Debug.Log("IOS Unlinked");
    }

    private void OnMobileUnlinkError(PlayFabError error)
    {

        Debug.Log("Unlinked Error");
        Debug.Log("Error: " + error.GenerateErrorReport());
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
        else
        {
            var linkIOSRequest = new LinkIOSDeviceIDRequest { DeviceId = ReturnMobileID() };
            PlayFabClientAPI.LinkIOSDeviceID(linkIOSRequest, OnLinkIOSDeviceSuccess, OnMobileLinkError);
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

    }

    #endregion

    public void ToogleRememberMe(bool rememberMe)
    {
        RememberMe = rememberMe;
    }

    public static string ReturnMobileID()
    {
        string DeviceID = SystemInfo.deviceUniqueIdentifier;

        return DeviceID;
    }

    public void SetChangeAccount()
    {
        ChangeAccount = true;
        username = null;
        UserEmail = null;
        UserPassword = null;
        UserConfirmPassword = null;
    }

    public void ClearInfo()
    {
        username = null;
        UserEmail = null;
        UserPassword = null;
        UserConfirmPassword = null;
    }

    

    #endregion Login

    #region UIActions

    // Display Panels
    private void DisableLoginPanel()
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.UIAction(PlayfabLoginUI.UiActions.DisableLoginPanel);
           
            
            InitializeStats();
              
        }
     
    }
    private void ShowContinueAsPanel()
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.UIAction(PlayfabLoginUI.UiActions.ShowContinueAsPanel);
        }
    }
    private void DisableRecoverableDataAskPanel()
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.UIAction(PlayfabLoginUI.UiActions.DisableRecoverableDataAskPanel);
        }
    }
    private void AsignUsername(string usernameToAsign)
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.UIAction(PlayfabLoginUI.UiActions.AsignContinueAsUsername, usernameToAsign);
        }
    }

    // Display Error

    private void DisplayRegisterError(string errorToDisplay)
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.DisplayError(PlayfabLoginUI.DisplayErrors.RegisterError, errorToDisplay);
        }
    }

    private void DisplaySigninError(string errorToDisplay)
    {
        if (myPlayfabLoginUI != null)
        {
            myPlayfabLoginUI.DisplayError(PlayfabLoginUI.DisplayErrors.SignInError, errorToDisplay);
        }
    }

    #endregion UIActions


    public void InitializeStats()
    {
      
       GameStats.stats.LoadCloudSaveData();
            
    }



}
