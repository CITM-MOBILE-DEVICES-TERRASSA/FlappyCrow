using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TubeController : MonoBehaviour
{

    private float speed = 4.0f;
    private float lifeTime = 4.0f;
    private float contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);


        contador += Time.deltaTime;
        if(contador >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
