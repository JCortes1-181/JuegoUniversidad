using UnityEngine;

public class AnimacionFlotante : MonoBehaviour
{
    public float amplitud = 0.2f; // Qué tan arriba y abajo llega
    public float velocidad = 3f;  // Qué tan rápido se mueve

    private Vector3 posicionInicial;

    void Start()
    {
        // Guardamos dónde empezó el perro para que no se vaya volando
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
        // Calculamos la nueva posición usando el tiempo y una onda Seno
        float nuevoY = Mathf.Sin(Time.time * velocidad) * amplitud;

        // Aplicamos el movimiento solo al eje Y
        transform.localPosition = posicionInicial + new Vector3(0, nuevoY, 0);
    }
}