using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Firebase.Firestore;

public class EnteranceVeriableCollecter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI emailField = null;
    [SerializeField]
    private TextMeshProUGUI passwordField = null;
    [SerializeField]
    private TextMeshProUGUI passwordAuthocationField = null;
    [SerializeField]
    private TextMeshProUGUI userNameField = null;

    [SerializeField]
    private TextMeshProUGUI emailField_0 = null;
    [SerializeField]
    private TextMeshProUGUI passwordField_0 = null;

    [SerializeField]
    private TextMeshProUGUI inAppUserName = null;
    [SerializeField]
    private GameObject inAppObject = null;

    [SerializeField]
    private GameObject errorObject = null;
    [SerializeField]
    private TextMeshProUGUI errorText = null;

    [SerializeField]
    private GameObject errorObject_0 = null;
    [SerializeField]
    private TextMeshProUGUI errorText_0 = null;

    [SerializeField]
    private GameObject firstSceneOfEnteranceObject = null;

    [SerializeField]
    private GameObject logInPageObject = null;
    [SerializeField]
    private GameObject signUpPageObject = null;

    [SerializeField]
    private Toggle rememberMeCheckBoxSignUp = null;
    [SerializeField]
    private Toggle rememberMeCheckBoxLogIn = null;

    [SerializeField]
    private TMP_Text forgotPasswordField = null;

    [SerializeField]
    private GameObject forgotPasswordSuccedObject = null;
    [SerializeField]
    private GameObject forgotPasswordObject = null;

    [SerializeField]
    private GameObject errorObject_1 = null;
    [SerializeField]
    private TextMeshProUGUI errorText_1 = null;

    [SerializeField]
    private GameObject sixthSceneGameObject = null;
    
    [SerializeField]
    private TextMeshProUGUI addDoctorNameSurnameField = null;
    [SerializeField]
    private TextMeshProUGUI addDoctorHospitalField = null;
    [SerializeField]
    private TextMeshProUGUI addDoctorBranchField = null;

    [SerializeField]
    private TextMeshProUGUI doctorNameSurnameField = null;
    [SerializeField]
    private TextMeshProUGUI doctorHospitalField = null;
    [SerializeField]
    private TextMeshProUGUI doctorBranchField = null;
    [SerializeField]
    private GameObject doctorElementObject = null;
    [SerializeField]
    private GameObject addDoctorObject = null;

    private bool signInControl_0 = false;
    private bool signInControl_1 = false;
    private bool signInControl_2 = false;

    public string userPassword = null;
    public string userEmail = null;
    public string userName = null;

    private string[] verifyControlEmails;
    private string[] verifyControlStatus;
    private bool isEmailVerified = false;
    private bool signUpControl = false;
    private bool verifyControl = false;

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    FirebaseFirestore db;

    private Task<QuerySnapshot> _storageSnapshot;
    void Awake() => _storageSnapshot = FirebaseFirestore.DefaultInstance.Collection("VerifyStat").GetSnapshotAsync();

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(requestCurl("http://185.243.181.144/emailVerification/control/?gmail=ozdemirasafemir@gmail.com"));
        //StartCoroutine(webPostt("http://185.243.181.144/?gmail=ozdemirasafemir@gmail.com"));
        /*UnityWebRequest r = UnityWebRequest.Head("http://185.243.181.144/?gmail=aei.tubitak@gmail.com");
        r.GetRequestHeader();*/
        //StartCoroutine(waitt());
        //StartCoroutine(merhaba());
        //Firebase.Firebaseapp.Create();
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance;
                InitializeFirebase();
                db = FirebaseFirestore.DefaultInstance; 
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
        //print(PlayerPrefs.GetInt("RememberMeDecision"));
        //SignInUser("ozdemirasafemir@gmail.com", "asafasaf");
        //StartCoroutine(GetPaintingsAndPois());
    }

    public string emailFormatter(string target) {
        string result = "";
        for(int i = 0; i < target.Length - 1; i++) {
            result += target[i];
        }
        return result;
    }

    public IEnumerator GetPaintingsAndPois()
    {
        _storageSnapshot = FirebaseFirestore.DefaultInstance.Collection("VerifyStat").GetSnapshotAsync();
        int length = 0;
        _storageSnapshot.ContinueWithOnMainThread(task =>
        {
            var collection = task.Result;
            if (collection.Count == 0) {
                Debug.LogError("There are no paintings available in the collection 'Paintings'.");
            }
            length = collection.Count;
            //Debug.Log("Found " + collection.Count + " paintings!");
            verifyControlEmails = new string[collection.Count];
            verifyControlStatus = new string[collection.Count];
            int counter = 0;
            foreach (var verifyData in collection.Documents)
            {
                //string titleVerify = "Email";
                /*Debug.Log(verifyData.ToDictionary()["Email"]);
                Debug.Log(verifyData.ToDictionary()["Status"]);*/
                verifyControlEmails[counter] = verifyData.ToDictionary()["Email"].ToString();
                verifyControlStatus[counter] = verifyData.ToDictionary()["Status"].ToString();
                counter++;
            }
        });
        yield return new WaitUntil(() => verifyControlEmails.Length == length && length != 0);
        //print(verifyControlEmails[1]);
        int emailIndex = -1;
        for(int i = 0; i < verifyControlEmails.Length; i++) {
            //print(verifyControlEmails[i].Equals((string)user.Email.ToString()));
            if(verifyControlEmails[i].Equals(emailFormatter(user.Email.ToString()))) {
                emailIndex = i;
            }
        }
        if(emailIndex != -1) {
            //print(verifyControlEmails[emailIndex] + " rgfdhfg " + user.Email.ToString());
            if(verifyControlStatus[emailIndex].Equals("True")) {
                PlayerPrefs.SetInt(user.Email + "_verified", 1);
                isEmailVerified = true;
                signUpControl = false;
                sixthSceneGameObject.SetActive(false);
                print("olduuuu");
            }
        }
        /*for(int i = 0; i < verifyControlEmails.Length; i++) {
            print(verifyControlEmails[i] + " = " + emailFormatter(user.Email.ToString()));
            print(verifyControlEmails[i].Length + " = " + emailFormatter(user.Email.ToString()).Length);
            print(verifyControlEmails[i].Equals(emailFormatter(user.Email.ToString())));
            print(emailIndex + " = " + i);
            print(verifyControlStatus[i]);
            print(verifyControlStatus[i].Equals("True"));
            print("---------------------------------------------------------------------------------------");
        }*/
    }

    IEnumerator verificationScreen() {
        StartCoroutine(GetPaintingsAndPois());
        yield return new WaitUntil(() => isEmailVerified);
        sixthSceneGameObject.SetActive(false);
        signUpControl = false;
    }

    public void verifyOnClick() {
        StartCoroutine(GetPaintingsAndPois());
    }

    // Update is called once per frame
    void Update()
    {
        if(signInControl_0) {
            if(!signInControl_1) {
                print(PlayerPrefs.GetInt("RememberMeDecision"));
                print(user.DisplayName);
                if(PlayerPrefs.GetInt("RememberMeDecision") == 1) {
                    signInControl_1 = true;
                    inAppUserName.text = user.DisplayName;
                    inAppObject.SetActive(true);
                    firstSceneOfEnteranceObject.SetActive(false);
                }
                else if(!signInControl_2 && PlayerPrefs.GetInt("RememberMeDecision") == 0) {
                    signInControl_1 = true;
                    signUpPageObject.SetActive(false);
                    logInPageObject.SetActive(false);
                    auth.SignOut();
                    inAppObject.SetActive(false);
                    firstSceneOfEnteranceObject.SetActive(true);
                }
            }
        }
        if(signUpControl) {
            if(!verifyControl) {
                string targetUrl = "http://185.243.181.144/emailVerification/?gmail=" + emailFormatter(user.Email) + "&code=null#";
                print(targetUrl);
                Application.OpenURL(targetUrl);
                verifyControl = true;
            }
            StartCoroutine(verificationScreen());
        }
    }

    public void addDoctorOnClick() {
        if(!string.IsNullOrEmpty(addDoctorNameSurnameField.text) && !string.IsNullOrEmpty(addDoctorBranchField.text) && !string.IsNullOrEmpty(addDoctorHospitalField.text)) {
            doctorElementObject.SetActive(true);
            doctorNameSurnameField.text = addDoctorNameSurnameField.text;
            doctorBranchField.text = addDoctorBranchField.text;
            doctorHospitalField.text = addDoctorHospitalField.text;
            addDoctorObject.SetActive(false);
            //StartCoroutine(sendValueToMySql());
        }
    }

    IEnumerator sendValueToMySql()
    {
        string webDoctorNameSurnameText = "";
        for(int i = 0; i < addDoctorNameSurnameField.text.Length - 1; i++) {
            webDoctorNameSurnameText += addDoctorNameSurnameField.text[i];
        }
        string webUserDisplayNameText = "";
        for(int i = 0; i < user.DisplayName.Length - 1; i++) {
            webUserDisplayNameText += user.DisplayName[i];
        }
        print("http://185.243.181.144/appInsertValue.php?doctors=" + webDoctorNameSurnameText + "|" + webUserDisplayNameText);
        string tUrl = "http://185.243.181.144/appInsertValue.php?doctors=" + webDoctorNameSurnameText + "|" + webUserDisplayNameText;
        UnityWebRequest hs_get = UnityWebRequest.Get(tUrl);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log(hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            print(dataText);
        }
    }

    public void signUpOnClick() {
        if(passwordField.text == passwordAuthocationField.text && !string.IsNullOrEmpty(emailField.text) && !string.IsNullOrEmpty(passwordField.text) && !string.IsNullOrEmpty(userNameField.text) && !string.IsNullOrEmpty(userNameField.text)) {
            userEmail = emailField.text;
            userPassword = passwordField.text;
            userName = userNameField.text;
            //inAppUserName.text = (string)userNameField.text;
            CreateUser(emailField.text, passwordField.text, userNameField.text);
            sixthSceneGameObject.SetActive(true);
            signUpControl = true;
        }
    }

    public void logInOnClick() {
        if(!string.IsNullOrEmpty(emailField_0.text) && !string.IsNullOrEmpty(passwordField_0.text)) {
            userEmail = emailField_0.text;
            userPassword = passwordField_0.text;
            SignInUser(userEmail, userPassword);
        }
    }

    public void logOutOnClick() {
        signUpPageObject.SetActive(false);
        logInPageObject.SetActive(false);
        firstSceneOfEnteranceObject.SetActive(true);
        inAppObject.SetActive(false);
        auth.SignOut();
    }

    public void passwordResetOnClick() {
        print("http://185.243.181.144/?gmail=" + forgotPasswordField.text);
        string targetUrl = "http://185.243.181.144/?gmail=" + forgotPasswordField.text + "#";
        Application.OpenURL(targetUrl);
        forgotPasswordSuccedObject.SetActive(true);
        forgotPasswordObject.SetActive(false);
    }

    void CreateUser(string email, string password, string UserName) {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach(Exception exception in task.Exception.Flatten().InnerExceptions) {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage(GetErrorMessage(errorCode), errorObject_0, errorText_0);
                    }
                }
                
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;

            inAppUserName.text = UserName;
            PlayerPrefs.SetInt("RememberMeDecision", rememberMeCheckBoxSignUp.isOn ? 1 : 0);
            inAppObject.SetActive(true);
            signUpPageObject.SetActive(false);
            print("a");
            signInControl_2 = true;

            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);

            UpdateUserProfile(UserName);
        });
    }

    public void SignInUser(string email, string password) {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach(Exception exception in task.Exception.Flatten().InnerExceptions) {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage(GetErrorMessage(errorCode), errorObject, errorText);
                    }
                }

                return;
            }

            Firebase.Auth.AuthResult result = task.Result;

            inAppUserName.text = user.DisplayName;
            
            inAppObject.SetActive(true);
            logInPageObject.SetActive(false);
            PlayerPrefs.SetInt("RememberMeDecision", rememberMeCheckBoxLogIn.isOn ? 1 : 0);
            signInControl_2 = true;

            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }

    void InitializeFirebase() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null
                && auth.CurrentUser.IsValid();
            if (!signedIn && user != null) {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn) {
                
                    Debug.Log("Signed in " + user.UserId);
                    /*displayName = user.DisplayName ?? "";
                    emailAddress = user.Email ?? "";
                    photoUrl = user.PhotoUrl ?? "";*/
                    signInControl_0 = true;
            }
        }
    }

    void OnDestroy() {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    void UpdateUserProfile(string UserName) {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null) {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = UserName,
                PhotoUrl = new System.Uri("https://dummyimage.com/150x150/000/fff"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled) {  
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
            });
        }
    }

    private static string GetErrorMessage(AuthError errorCode) {
        var message = "";
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Farkli Kimlik Bilgilerine Sahipsiniz";
                break;
            case AuthError.MissingPassword:
                message = "Sifre Gerekli";
                break;
            case AuthError.WeakPassword:
                message = "Sifre Zayif";
                break;
            case AuthError.WrongPassword:
                message = "Sifre Yanlis";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Bu E-postaya Sahip Bir Hesap Zaten Mebcut";
                break;
            case AuthError.InvalidEmail:
                message = "Gecersiz E-posta";
                break;
            case AuthError.MissingEmail:
                message = "E-posta Gerekli";
                break;
            default:
                message = "Bir Hata Olustu";
                break;
        }
        return message;
    }

    void showNotificationMessage(string errorMessage, GameObject object_, TextMeshProUGUI text) {
        text.text = errorMessage;
        object_.SetActive(true);
    }

    public void forgotPassword(string forgotPasswordEmail) {
        string emailAddress = forgotPasswordEmail;
        print(user.Email);
        if (user != null) {
        auth.SendPasswordResetEmailAsync(emailAddress).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) {
            Debug.LogError("SendPasswordResetEmailAsync was canceled.");
            return;
            }
            if (task.IsFaulted) {
            Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
            return;
            }

            Debug.Log("Password reset email sent successfully.");
        });
        }
        /*print(user == null);
        user.SendPasswordResetEmailAsync(forgotPasswordEmail).ContinueWithOnMainThread(task => {
            if(task.IsCanceled) {
                Debug.LogError("SendPasswordResetEmailAsync was canceled");
                return;
            }
            if(task.IsFaulted) {
                Debug.LogError("SendPasswordResetEmailAsync was faulted" + task.Exception);
                foreach(Exception exception in task.Exception.Flatten().InnerExceptions) {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showNotificationMessage(GetErrorMessage(errorCode), errorObject_1, errorText_1);
                    }
                }
                return;
            }
            forgotPasswordSuccedObject.SetActive(true);
            forgotPasswordObject.SetActive(false);
        });*/
    }

    public void forgotPasswordOnClick() {
        if(string.IsNullOrEmpty(forgotPasswordField.text)) {
            showNotificationMessage("Lütfen Email'inizi Giriniz !", errorObject_1, errorText_1);
            return;
        }
        forgotPassword(forgotPasswordField.text);
    }
}
