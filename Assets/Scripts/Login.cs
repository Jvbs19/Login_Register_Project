using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    [SerializeField] InputField User;
    [SerializeField] InputField Senha;

    [SerializeField] Button Mandar;
    
    [SerializeField]  Text ErrorBox;

    public void ChamaLogar()
    {
        StartCoroutine(Logar(User.text, Senha.text));
    }
    IEnumerator Logar(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                ErrorBox.text = "" + www.error;
                User.text = "";
                Senha.text = "";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                ErrorBox.text = "" +www.downloadHandler.text;
                User.text = "";
                Senha.text = "";
            }
        }
    }
    public void VerificarInputs()
    {
        Mandar.interactable = (User.text.Length >= 4 && Senha.text.Length >= 6);
    }
}
