using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonRegresar : MonoBehaviour //el script se encuntra en el boton del mismo nombre en la escena de la "Mesa de trabajo"
{
    private Button boton;

    private void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(Regresar);
    }

    private void Regresar()
    {
        string nivelAnterior = GuardarNivel.ObtenerNivelAnterior();

        SceneManager.LoadScene(nivelAnterior); //carga el nivel en el que se encontrba el jugador
    }
}
