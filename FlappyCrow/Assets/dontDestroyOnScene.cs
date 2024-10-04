using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnScene : MonoBehaviour
{
    // Start is called before the first frame update

    private static dontDestroyOnScene instance;


    private void Awake()
    {
        // Verificar si ya existe una instancia de este objeto.
        if (instance != null && instance != this)
        {
            // Si existe otra instancia, destruir este objeto.
            Destroy(gameObject);
        }
        else
        {
            // Si no existe otra instancia, asignar esta como la instancia única.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
