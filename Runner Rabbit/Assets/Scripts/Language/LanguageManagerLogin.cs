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
    public TextMeshProUGUI RegisterUsername, RegisterEmail, RegisterPassword;
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
        RegisterLoginButton.text = Language_Login[languageID];
        alreadyHaveAnAccountText.text = Language_AlreadyHaveAnAccount[languageID];
        SignInButton.text = Language_SignIn[languageID];

        SignInTitle.text = Language_SignIn[languageID];
        SignInUsername.text = Language_Username[languageID];
        SignInPassword.text = Language_Password[languageID];
        SignInLoginButton.text = Language_Login[languageID];
        dontHaveAnAccountText.text = Language_DontHaveAnAccount[languageID];
        RegisterButton.text = Language_Register[languageID];
    }

    public enum ErrorType
    {
        InvalidUser,
        EmailTaken,
        UsernameTaken
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
        }
        else
        {
            ErrorTranslation = "";
        }
        return ErrorTranslation;
    }
}
