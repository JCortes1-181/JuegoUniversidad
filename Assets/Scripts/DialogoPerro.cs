using UnityEngine;
using TMPro; // Agregamos esto para que el perro pueda escribir

public class DialogoPerro : MonoBehaviour
{
    public GameObject cuadroDeTexto;
    public TextMeshProUGUI textoUI; // Nueva casilla para el texto
    public string mensajePerro;     // Nueva casilla para el mensaje del perro

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // Antes de mostrar el cuadro, el perro escribe su mensaje
            textoUI.text = mensajePerro; 
            cuadroDeTexto.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            cuadroDeTexto.SetActive(false);
        }
    }
}