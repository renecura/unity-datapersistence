using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField playerNameInput; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame(){

        if(playerNameInput.text == ""){
            Debug.Log("Ingresar nombre!");
            return;
        }

        PlayerManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }
}
