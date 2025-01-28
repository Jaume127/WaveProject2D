using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Configuration")]
    [SerializeField] float speed = 10;
    [SerializeField] float limitX;

    
    void Update()
    {
        //Movimiento
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //Limitador de pantalla
        if (transform.position.x >= limitX) gameObject.SetActive(false);
    }
}
