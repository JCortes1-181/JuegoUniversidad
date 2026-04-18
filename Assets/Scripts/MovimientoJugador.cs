using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    // Esta es la velocidad. Puedes cambiarla desde Unity después.
    public float velocidad = 5f; 
    
    // Aquí guardaremos el cuerpo del malvavisco
    private Rigidbody2D rb; 
    // Aquí guardaremos hacia dónde queremos ir
    private Vector2 direccion; 

    void Start()
    {
        // Al empezar, el código busca el componente Rigidbody2D que pusimos antes
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detecta si presionas W, A, S, D o las flechas
        float moverX = Input.GetAxisRaw("Horizontal"); 
        float moverY = Input.GetAxisRaw("Vertical"); 

        direccion = new Vector2(moverX, moverY).normalized;
    }

    void FixedUpdate()
    {
        // Mueve el cuerpo del malvavisco físicamente
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
    }
}