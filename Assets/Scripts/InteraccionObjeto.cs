using UnityEngine;
using TMPro;

public class InteraccionObjeto : MonoBehaviour
{
    public GameObject indicadorX;
    public GameObject cuadroDialogo;
    public string mensaje;
    public TextMeshProUGUI textoUI;

    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.X))
        {
            GameObject jugador = GameObject.FindWithTag("Player");

            if (!cuadroDialogo.activeSelf)
            {
                // CONGELAR
                if (jugador != null) 
                {
                    var scriptMov = jugador.GetComponent<MovimientoJugador>();
                    if(scriptMov != null) scriptMov.enabled = false;
                }

                textoUI.text = mensaje;
                cuadroDialogo.SetActive(true);
                indicadorX.SetActive(false);
            }
            else
            {
                // Cerramos el diálogo primero
                cuadroDialogo.SetActive(false);
                indicadorX.SetActive(true);

                if (gameObject.name == "Malote") 
                {
                    // CAMBIO CLAVE: Buscamos la pelea incluso si el objeto está desactivado
                    LogicaPelea pelea = Resources.FindObjectsOfTypeAll<LogicaPelea>()[0];
                    
                    if (pelea != null) 
                    {
                        pelea.IniciarPelea();
                    }
                    else 
                    {
                        Debug.LogError("No se encontró el script LogicaPelea en la escena. ¡Asegúrate de que el panel tenga el script!");
                    }
                }
                else 
                {
                    // DESCONGELAR (Solo para NPCs normales)
                    if (jugador != null) 
                    {
                        var scriptMov = jugador.GetComponent<MovimientoJugador>();
                        if(scriptMov != null) scriptMov.enabled = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            indicadorX.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            indicadorX.SetActive(false);
            cuadroDialogo.SetActive(false);
        }
    }
}