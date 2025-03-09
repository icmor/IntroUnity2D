using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 posicionInicial;
    private Vector2 posicionFinal;
    // Start is called before the first frame update
    private Vector2 vectorDireccion;
    private float tiempo = 3f;
    private bool direccion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position; 
        posicionFinal = posicionInicial + new Vector2(0, 1);
        vectorDireccion = posicionFinal - posicionInicial;
        StartCoroutine(nameof(CambiarDireccion));
    }

    private void FixedUpdate() {
        rb.velocity = (direccion ? -1 : 1) * vectorDireccion / tiempo;
    } 

    IEnumerator CambiarDireccion()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            direccion = !direccion;
        }
    }
}
