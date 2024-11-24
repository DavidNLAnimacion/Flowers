using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public float fuerzaDisparo = 10f; // Fuerza de disparo
    public float anguloTiro = 45f;    // �ngulo de lanzamiento en grados

    void Update()
    {
        // Detectar si se hace clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            DispararProyectil();
        }
    }

    void DispararProyectil()
    {
        // Instanciar el proyectil en la posici�n del objeto que contiene el script
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

        // Calcular la direcci�n del disparo bas�ndose en el �ngulo
        float radianes = anguloTiro * Mathf.Deg2Rad; // Convertir �ngulo a radianes
        float fuerzaX = fuerzaDisparo * Mathf.Cos(radianes); // Componente horizontal
        float fuerzaY = fuerzaDisparo * Mathf.Sin(radianes); // Componente vertical

        // Aplicar una fuerza al proyectil utilizando el Rigidbody
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Aplicamos la velocidad al proyectil en la direcci�n de la par�bola
            rb.velocity = new Vector2(fuerzaX, fuerzaY);
        }
        else
        {
            Debug.LogWarning("El proyectil no tiene un Rigidbody2D.");
        }
    }
}