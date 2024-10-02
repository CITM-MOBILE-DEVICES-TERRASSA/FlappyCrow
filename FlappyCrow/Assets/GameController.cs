using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject[] tubes;
    public float generationTime = 2.0f;
    public float maxAltitude = 2.5f, minAltitude = -2.5f;

    private float contador;

    // Start is called before the first frame update
    void Start()
    {
        contador = generationTime;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if(contador > generationTime)
        {
            contador = 0;

            int randomTube = Random.Range(0, tubes.Length);
            float altitude = Random.Range(-maxAltitude, maxAltitude);

            Instantiate(tubes[randomTube], new Vector3(5, altitude, 0), Quaternion.identity);

        }
    }
}
