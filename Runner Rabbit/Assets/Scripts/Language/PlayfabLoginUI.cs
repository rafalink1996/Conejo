using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayfabLoginUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject loginPanel;
    public GameObject ContinueAsPanel;
    public GameObject recoverableDataAskObject;

    [Space(10)]
    [Header("Player Info")]
    public TextMeshProUGUI ContinueUsername;

    [Space(10)]
    [Header("Passwords Toogle")]
    [SerializeField] TMP_InputField passwordInputField;
    [SerializeField] TMP_InputField confirmPasswordInputField;
    [SerializeField] TMP_InputField passwordSigninInputField;


    [Space(10)]
    [Header("Error Strings")]

    public GameObject registerErrorObject;
    TextMeshProUGUI registerErrorTM;
   
    [Space(5)]
    public GameObject SigninErrorObject;
    TextMeshProUGUI SigninErrorTM;
    

    [Space(10)]
    [Header("Debug errors")]
    [SerializeField] TextMeshProUGUI SignInStatus;
    [SerializeField] TextMeshProUGUI EmailRetrieved;
    [SerializeField] TextMeshProUGUI DataRetrievalStatus;
    [SerializeField] TextMeshProUGUI ErrorReport;
    [SerializeField] TextMeshProUGUI DeviceIdentifier;


    private void Awake()
    {
        if(registerErrorObject != null)
        {
            registerErrorTM = registerErrorObject.GetComponent<TextMeshProUGUI>();
            registerErrorObject.SetActive(false);
        }
        if(registerErrorObject != null)
        {
            SigninErrorTM = SigninErrorObject.GetComponent<TextMeshProUGUI>();
            SigninErrorObject.SetActive(false);
        }
        
        
    }

    #region Toogle Passwords
    public void OnToggleShowPassword(bool show)
    {
        if (show)
        {

            passwordInputField.contentType = TMP_InputField.ContentType.Standard;
            confirmPasswordInputField.contentType = TMP_InputField.ContentType.Standard;

        }
        else
        {

            passwordInputField.contentType = TMP_InputField.ContentType.Password;
            confirmPasswordInputField.contentType = TMP_InputField.ContentType.Password;
        }
        passwordInputField.ForceLabelUpdate();
        confirmPasswordInputField.ForceLabelUpdate();
    }

    public void OnToggleShowPasswordSignIn(bool show)
    {
        if (show)
        {
            passwordSigninInputField.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordSigninInputField.contentType = TMP_InputField.ContentType.Password;
        }
        passwordSigninInputField.ForceLabelUpdate();
    }

    #endregion Toogle Passwords

    #region UIFunctions
    public enum UiActions
    {
        DisableLoginPanel,
        DisableRecoverableDataAskPanel,
        ShowContinueAsPanel,
        AsignContinueAsUsername,
        ShowRegisterError,
        ShowSignInError
    }
    public void UIAction(UiActions action, string username = null)
    {
        switch (action)
        {
            case UiActions.DisableLoginPanel:
                if(loginPanel != null)
                {
                    loginPanel.SetActive(false);
                }
                break;

            case UiActions.DisableRecoverableDataAskPanel:
                if(recoverableDataAskObject != null)
                {
                    recoverableDataAskObject.SetActive(false);
                }    
                break;

            case UiActions.ShowContinueAsPanel:
                if (ContinueAsPanel != null)
                {
                    ContinueAsPanel.SetActive(true);
                }
                break;

            case UiActions.AsignContinueAsUsername:
               
                if(username != null && ContinueUsername != null)
                {
                    ContinueUsername.text = username;
                }
                break;

            case UiActions.ShowRegisterError:
                if(registerErrorObject != null)
                {
                    registerErrorObject.SetActive(true);
                }
                break;
            case UiActions.ShowSignInError:
                if(SigninErrorObject != null)
                {
                    SigninErrorObject.SetActive(true);
                }
                break;
        }
    }

    public enum DisplayErrors
    {
        RegisterError,
        SignInError

    }
    public void DisplayError(DisplayErrors error, string ErrorText)
    {
        switch (error)
        {
            case DisplayErrors.RegisterError:
                if(registerErrorTM != null)
                {
                    registerErrorTM.text = ErrorText;
                }
                UIAction(UiActions.ShowRegisterError);
                break;
            case DisplayErrors.SignInError:
                if(SigninErrorTM != null)
                {
                    SigninErrorTM.text = ErrorText;
                }
                UIAction(UiActions.ShowSignInError);
                break;
        }
    }
        #endregion UIFunctions
    }
