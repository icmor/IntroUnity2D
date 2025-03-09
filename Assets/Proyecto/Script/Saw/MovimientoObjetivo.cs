using System;
using System.Collections;
using UnityEngine;

public class MovimientoObjetivo : MonoBehaviour
{
    // componentes
    Rigidbody2D rb;
    Animator animator;
    
    // trayectoria
    Vector2 posicionInicial;    
    [SerializeField, Tooltip("Posicion donde se va a mover la sierra")]
    Vector2 posicionFinal;
    Vector2 vectorDireccion;   //  La direccion donde se mueve la sierra
    bool direccion; //  Valor que nos dice a que direccion debe moverse el objeto
    [Header("Movimiento"), SerializeField, Tooltip("Duracion del movimiento en una direccion")]
    float tiempo = 1;
    
    // cadenas
    [Header("Cadena"), SerializeField, Tooltip("Prefab del eslabón de la cadena")]
    GameObject chainLinkPrefab;
    [SerializeField, Tooltip("Número de eslabones entre la posición inicial y final")]
    int cadenasIntermedias;

    // corutinas 
    Coroutine coroutine;

    private void Start()
    {
        // componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // movimiento
        posicionInicial = transform.position;
        // posicionFinal =  posicionInicial + new Vector2(1.5f, 0);
        vectorDireccion = posicionFinal - posicionInicial;
        coroutine = StartCoroutine(nameof(CambiarDireccion));
        
        // animaciones
        animator.SetBool("Off", false);

        // cadena
        GenerarCadena();
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

    private void GenerarCadena()
    {
        int totalCadenas = cadenasIntermedias + 2;

        for (int i = 0; i < totalCadenas; i++)
        {
            float t = (float)i / (totalCadenas - 1);
            Vector2 posicionCadena = Vector2.Lerp(posicionInicial, posicionFinal, t);
            GameObject cadena = Instantiate(chainLinkPrefab, posicionCadena, Quaternion.identity);
            cadena.transform.parent = transform.parent;
        }
    }
}