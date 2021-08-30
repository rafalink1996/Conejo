using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerLogin : MonoBehaviour
{
    [Header("Login Ask Texts")]
    public TextMeshProUGUI PlayButton;
    public TextMeshProUGUI SignInWithEmailButton;

    [Space(10)]
    [Header("Remember me and skip")]
    public TextMeshProUGUI RememberMe;
    public TextMeshProUGUI SkipButton;

    [Space(10)]
    [Header("Register Texts")]
    public TextMeshProUGUI RegisterTitle;
    public TextMeshProUGUI RegisterUsername, RegisterEmail, RegisterPassword, RegisterConfirmPassword;
    public TextMeshProUGUI ShowPasswordToggle;
    public TextMeshProUGUI RegisterLoginButton;
    public TextMeshProUGUI alreadyHaveAnAccountText;
    public TextMeshProUGUI SignInButton;

    [Space(10)]
    [Header("SignIn Texts")]
    public TextMeshProUGUI SignInTitle;
    public TextMeshProUGUI SignInUsername, SignInPassword;
    public TextMeshProUGUI SignInLoginButton;
    public TextMeshProUGUI dontHaveAnAccountText;
    public TextMeshProUGUI RegisterButton;

    [Space(10)]
    [Header("Continue As")]
    public TextMeshProUGUI ContinueAsTitle;
    public TextMeshProUGUI ContinueButton;
    public TextMeshProUGUI LoginWithDifferentAccountButton;
    public TextMeshProUGUI ContinueAsRememberMe;

    [Space(10)]
    [Header("No Sign In Disclaimer")]
    public TextMeshProUGUI DisclaimerTitle;
    public TextMeshProUGUI DisclaimerDescription, disclaimerplaybutton, disclaimerBackButton;

    [Space(10)]
    [Header("Options forget login data")]
    public TextMeshProUGUI forgetTitle;
    public TextMeshProUGUI forgetdescription, forgetButton, keepButton, ForgetInitialButton;



    // language variables

    string[] Language_play = new string[]
    {
        "Play",
        "Jugar",
        "frances"// Todo
    };
    string[] Language_SignInWithEmail = new string[]
    {
        "Sign in with email",
        "iniciar sesion con correo electrónico",
        "frances"// Todo
    };
    string[] Language_RememberMe = new string[]
    {
        "Remember Me",
        "Recuérdame",
        "frances"// Todo
    };
    string[] Language_Skip = new string[]
    {
        "Skip",
        "Saltar",
        "frances"// Todo
    };
    string[] Language_Register = new string[]
    {
        "Register",
        "Registrarse",
        "frances"// Todo
    };
    string[] Language_Username = new string[]
    {
        "Username",
        "Usuario",
        "frances"// Todo
    };
    string[] Language_Email = new string[]
    {
        "Email",
        "Correo electrónico",
        "frances"// Todo
    };
    string[] Language_Password = new string[]
   {
        "Password",
        "Contraseña",
        "frances"// Todo
   };
    string[] Language_ConfirmPassword = new string[]
{
        "Confirm Password",
        "Confirmar Contraseña",
        "frances"// Todo
};
    string[] Language_ShowPassword = new string[]
{
        "Show Password",
        "Mostrar Contraseña",
        "frances"// Todo
};
    string[] Language_Login = new string[]
   {
        "Login",
        "Iniciar Sesión",
        "frances"// Todo
   };
    string[] Language_AlreadyHaveAnAccount = new string[]
   {
        "Already Have an account?",
        "¿Ya tienes una Cuenta?",
        "frances"// Todo
   };
    string[] Language_SignIn = new string[]
  {
        "Sign In",
        "Iniciar Sesión",
        "frances"// Todo
  };
    string[] Language_DontHaveAnAccount = new string[]
  {
        "Dont have an account?",
        "¿No tienes una cuenta?",
        "frances"// Todo
  };
    string[] Language_InvalidUsernameOrPasswordError = new string[]
 {
        "Invalid Username or password",
        "El usuario o la contraseña no son validos",
        "frances"// Todo
 };
    string[] Language_EmailTakenError = new string[]
 {
        "Email already taken",
        "Este correo ya está en uso",
        "frances"// Todo
 };
    string[] Language_UsernameTakenError = new string[]
{
        "Username already taken",
        "Nombre de usario no disponible",
        "frances"// Todo
};
    string[] Language_PasswordUnmatchError = new string[]
{
        "Passwords don't match",
        "Las contraseñas no coinciden",
        "frances"// Todo
};
    string[] Language_dataNotSaved = new string[]
{
        "data will not be saved in the cloud. if you uninstall de game,progress will be lost",
        "los datos no se guardarán en la nube. si desinstalas el juego, se perderá el progreso. ",
        "frances"// Todo
};
    string[] Language_SureToContinue = new string[]
{
        "Are you sure you want to continue?",
        "¿Seguro que quieres continuar? ",
        "frances"// Todo
};
    string[] Language_BackToSignIn = new string[]
{
        "Back To Sign In",
        "Volver a iniciar sesión",
        "frances"// Todo
};
    string[] Language_ForgetTitle = new string[]
{
        "Forget account details",
        "Olvidar detalles de cuenta",
        "frances"// Todo
};
    string[] Language_ForgetDescription = new string[]
{
        "This will forget locally saved account data. you will have to manually login next time you open the game.",
        "Esto olvidará la informacion guardada de la cuenta. Tendrás que iniciar sesion manualmente la siguiente vez que abras el juego. ",
        "frances"// Todo
};
    string[] Language_ForgetButton = new string[]
{
        "Forget",
        "Olvidar",
        "frances"// Todo
};
    string[] Language_KeepButton = new string[]
{
        "Keep",
        "Mantener",
        "frances"// Todo
};
    string[] Language_ForgetInitialButton = new string[]
{
        "Forget account data",
        "Olvidar datos de cuenta",
        "frances"// Todo
};
    string[] Language_CheckAccountData_no = new string[]
{
        "No Data",
        "No hay datos",
        "frances"// Todo
};
    string[] Language_CheckAccountData_yes = new string[]
{
        "Saved data as: ",
        "Guardados detas como: ",
        "frances"// Todo
};
    string[] Language_ContinueAsTitle = new string[]
    {
        "Continue As",
        "Continuar Como",
        "Frances" // Todo
    };
    string[] Language_ContinueButton = new string[]
   {
        "Continue",
        "Continuar",
        "Frances" // Todo
   };
       string[] Language_LoginWithdiffernetAccount = new string[]
   {
        "Login with diferent account",
        "Iniciar sesion con una cuenta diferente",
        "Frances" // Todo
   };
    string[] Language_AccountNotFound = new string[]
  {
        "Account not Found",
        "Cuenta no encontrada",
        "Frances" // Todo
  };
    string[] Language_SignInError = new string[]
  {
        "Sign in Error",
        "Error de inicio se sesión",
        "Frances" // Todo
  };
    string[] Language_RegisterError = new string[]
  {
        "Register Error",
        "Error de registro",
        "Frances" // Todo
  };



    // Start is called before the first frame update
    void Start()
    {
        if (GameStats.stats.languageselected)
        {
            UpdateLanguage(GameStats.stats.LanguageSelect);
        }
        else
        {
            UpdateLanguage(0);
        }

    }

    public void UpdateLanguage(int languageID)
    {
        PlayButton.text = Language_play[languageID];
        SignInWithEmailButton.text = Language_SignInWithEmail[languageID];

        RememberMe.text = Language_RememberMe[languageID];
        SkipButton.text = Language_Skip[languageID];

        RegisterTitle.text = Language_Register[languageID];
        RegisterUsername.text = Language_Username[languageID];
        RegisterEmail.text = Language_Email[languageID];
        RegisterPassword.text = Language_Password[languageID];
        RegisterConfirmPassword.text = Language_ConfirmPassword[languageID];
        ShowPasswordToggle.text = Language_ShowPassword[languageID];
        RegisterLoginButton.text = Language_Login[languageID];
        alreadyHaveAnAccountText.text = Language_AlreadyHaveAnAccount[languageID];
        SignInButton.text = Language_SignIn[languageID];

        SignInTitle.text = Language_SignIn[languageID];
        SignInUsername.text = Language_Username[languageID];
        SignInPassword.text = Language_Password[languageID];
        SignInLoginButton.text = Language_Login[languageID];
        dontHaveAnAccountText.text = Language_DontHaveAnAccount[languageID];
        RegisterButton.text = Language_Register[languageID];


        ContinueAsTitle.text = Language_ContinueAsTitle[languageID];
        ContinueButton.text = Language_ContinueButton[languageID];
        LoginWithDifferentAccountButton.text = Language_LoginWithdiffernetAccount[languageID];
        ContinueAsRememberMe.text = Language_RememberMe[languageID];
        

        DisclaimerTitle.text = Language_dataNotSaved[languageID];
        DisclaimerDescription.text = Language_SureToContinue[languageID];
        disclaimerplaybutton.text = Language_play[languageID];
        disclaimerBackButton.text = Language_BackToSignIn[languageID];


        forgetTitle.text = Language_ForgetTitle[languageID];
        forgetdescription.text = Language_ForgetDescription[languageID];
        forgetButton.text = Language_ForgetButton[languageID];
        keepButton.text = Language_KeepButton[languageID];
        ForgetInitialButton.text = Language_ForgetInitialButton[languageID];

    }

    public enum ErrorType
    {
        InvalidUser,
        EmailTaken,
        UsernameTaken,
        PasswordUnmatch,
        AccountNotFound,
        LoginError,
        RegisterError


    };

    public string GetErrorMessageTrnalation(int LanguageID, ErrorType errorType)
    {
        string ErrorTranslation;
        if (errorType == ErrorType.InvalidUser)
        {
            ErrorTranslation = Language_InvalidUsernameOrPasswordError[LanguageID];
        }
        else if (errorType == ErrorType.EmailTaken)
        {
            ErrorTranslation = Language_EmailTakenError[LanguageID];
        }
        else if (errorType == ErrorType.UsernameTaken)
        {
            ErrorTranslation = Language_UsernameTakenError[LanguageID];
        }else if(errorType == ErrorType.PasswordUnmatch)
        {
            ErrorTranslation = Language_PasswordUnmatchError[LanguageID];
        }
        else if (errorType == ErrorType.AccountNotFound)
        {
            ErrorTranslation = Language_AccountNotFound[LanguageID];
        }
        else if (errorType == ErrorType.LoginError)
        {
            ErrorTranslation = Language_SignInError[LanguageID];
        }
        else if (errorType == ErrorType.RegisterError)
        {
            ErrorTranslation = Language_RegisterError[LanguageID];
        }
        else
        {
            ErrorTranslation = "";
        }
        return ErrorTranslation;
    }

    public string GetAccountDataCheck(bool savedData, int languageID)
    {
        string ReturnString;
        if (savedData)
        {
            ReturnString = Language_CheckAccountData_yes[languageID];
        }
        else
        {
            ReturnString = Language_CheckAccountData_no[languageID];
        }
        return ReturnString;
    }
}
