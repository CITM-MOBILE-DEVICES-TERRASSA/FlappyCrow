using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject[] tubes;
    public float generationTime = 2.0f;
    public float maxAltitude = 2.5f, minAltitude = -2.5f;

    private float contador;

    public static GameController instance;

    private int puntacion = 0;
    public TextMeshProUGUI puntacionUI, puntacionUIFinal;
    public bool isCrowDead = false;

    public GameObject deadMenu;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        deadMenu.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if(contador > generationTime && !isCrowDead)
        {
            contador = 0;

            int randomTube = Random.Range(0, tubes.Length);
            float altitude = Random.Range(-maxAltitude, maxAltitude);

            Instantiate(tubes[randomTube], new Vector3(5, altitude, 0), Quaternion.identity);

        }else if (isCrowDead && contador > generationTime * 2)
        {
            ShowDeadMenu();
        }
    }

    public void AddPoint()
    {
        puntacion++;
        puntacionUI.text = puntacion.ToString(); 
    }

    private void ShowDeadMenu()
    {
        puntacionUIFinal.text = puntacionUI.text;
        deadMenu.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
