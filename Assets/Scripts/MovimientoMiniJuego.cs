using UnityEngine;

public class MovimientoMiniJuego : MonoBehaviour
{
    public float velocidad = 300f;
    public float limiteX = 180f; // El ancho de tu cajita

    void Update()
    {
        // Movimiento simple con flechas o A/D
        float mover = Input.GetAxis("Horizontal");
        
        // Calculamos la nueva posición
        Vector2 nuevaPos = transform.localPosition;
        nuevaPos.x += mover * velocidad * Time.deltaTime;

        // Limitar para que no se salga de la cajita negra
        nuevaPos.x = Mathf.Clamp(nuevaPos.x, -limiteX, limiteX);

        transform.localPosition = nuevaPos;
    }
}