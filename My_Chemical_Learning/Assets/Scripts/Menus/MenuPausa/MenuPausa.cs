using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    //Referencia al panel del menú de pausa
    [SerializeField] private GameObject panelMenuPausa;


    private bool juegoPausado = false;


    void Update()
    {
        // Al presionar tal tecla
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }


    public void Continuar()
    {
        panelMenuPausa.SetActive(false); //Desactivamos el panel de pausa
        Time.timeScale = 1f;             //Reanudamos el tiempo d ejuego
        juegoPausado = false;
    }


    public void Pausar()
    {
        panelMenuPausa.SetActive(true);  //Activamos el panel de pausa
        Time.timeScale = 0f;             //Detenemos el tiempo de juego
        juegoPausado = true;
    }
}
