using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform[] backgrounds;     // Array de los fondos
    public float[] parallaxSpeeds;      // Velocidad de movimiento de cada fondo
    public float repositionDistance;    // Distancia en X para reposicionar los fondos
    public float repositionX;           // Posici�n X espec�fica a la que se mover�n los fondos cuando recorran la distancia

    private float[] distancesMoved;     // Distancia recorrida acumulada para cada fondo

    void Start()
    {
        // Inicializar el array que guardar� la distancia recorrida para cada fondo
        distancesMoved = new float[backgrounds.Length];
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Mover el fondo hacia la izquierda seg�n su velocidad
            backgrounds[i].position += Vector3.left * parallaxSpeeds[i] * Time.deltaTime;

            // Calcular la distancia que ha recorrido cada fondo
            distancesMoved[i] += parallaxSpeeds[i] * Time.deltaTime;

            // Si la distancia recorrida supera el l�mite establecido, reposicionar el fondo
            if (distancesMoved[i] >= repositionDistance)
            {
                RepositionBackground(i);
            }
        }
    }

    // M�todo para reposicionar el fondo a la posici�n X espec�fica y reiniciar la distancia acumulada
    void RepositionBackground(int index)
    {
        // Cambiar la posici�n X del fondo a la especificada en repositionX
        backgrounds[index].position = new Vector3(repositionX, backgrounds[index].position.y, backgrounds[index].position.z);

        // Reiniciar la distancia recorrida acumulada para ese fondo
        distancesMoved[index] = 0f;
    }
}