using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField getUsername;

    private void Start()
    {
        getUsername.placeholder.GetComponent<TMP_Text>().text = "Enter Username...";
    }

    public void StartButtonClicked()
    {
        GameManager.Instance.username = getUsername.text;
        SceneManager.LoadScene(1);
    }
}
