using UnityEngine;

public class EfectoCaricatura : MonoBehaviour
{
    public float intensidad = 0.1f; // Qué tanto se estira
    public float velocidad = 4f;   // Qué tan rápido respira

    private Vector3 escalaInicial;

    void Start()
    {
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        // Calculamos el estiramiento (solo positivo para que no se encoja hacia abajo)
        float estiramiento = Mathf.Sin(Time.time * velocidad) * intensidad;

        // Aplicamos el cambio: aumenta en Y (altura) y disminuye un pelín en X (ancho)
        // Esto hace que se vea más natural: si se estira, se pone flaco.
        transform.localScale = new Vector3(
            escalaInicial.x - (estiramiento * 0.5f), 
            escalaInicial.y + estiramiento, 
            escalaInicial.z
        );
    }
}