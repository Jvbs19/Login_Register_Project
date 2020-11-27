using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Registrar : MonoBehaviour
{
   
    [SerializeField] InputField User;
    [SerializeField] InputField Senha;
   
    [SerializeField] Button Mandar;

    [SerializeField]  Text ErrorBox;

    public void ChamaRegistro()
    {
        StartCoroutine(Registro(User.text, Senha.text));
    }
    IEnumerator Registro(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity/Registrar.php", form))
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
                ErrorBox.text = "" +www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
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
