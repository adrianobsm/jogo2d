using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject gameHud;
    public GameObject gameMenu;

    public GameObject playerPlaceholder;

    public GameObject currentPlayer;

    public Text playerLifesText;
    
    public GameObject carne;
    private int lifes;

    public AudioSource Derrota;

	public AudioSource Triunfo;

	public AudioSource newLife;

    // Start is called before the first frame update
    void Start() {
        if (PassarValor.lifes!=0){
            lifes=PassarValor.lifes;
        } else{
            lifes=10;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void AddLife(int value, int tipo) {
        lifes += value;

        playerLifesText.text = "Vidas: " + lifes;

        if (lifes == 0) {
            SceneManager.LoadScene("Level01");
        } else {
            if (tipo == 1){
                Destroy(currentPlayer);
                currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
            } else {
                carne.SetActive(false);
            }
        }
    }

    
    public void NewGame() {
        gameMenu.SetActive(false);
        gameHud.SetActive(true);
        
        lifes=10;
        currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
    }

    public void Continue() {
        carne.SetActive(true);
        gameMenu.SetActive(false);
        gameHud.SetActive(true);
        playerLifesText.text = "Vidas: " + lifes;
        currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
    }

    public void Continue2() {
        gameMenu.SetActive(false);
        gameHud.SetActive(true);
        playerLifesText.text = "Vidas: " + lifes;
        currentPlayer = Instantiate(playerPrefab, playerPlaceholder.transform.position, Quaternion.identity);
    }

    public void MudarFase(string fase){
        SceneManager.LoadScene(fase);
        PassarValor.lifes=lifes;
    }
    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
