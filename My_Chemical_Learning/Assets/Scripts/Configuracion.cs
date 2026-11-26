using UnityEngine;

public class Configuracion : MonoBehaviour //sirve para establecer las configs de android como oculatar la barra de notiificaciones
{
    private void Awake()
    {
        Screen.fullScreen = true; //ocualta la barra de noti

        Application.targetFrameRate = 60;//establece el framerate
    }
}
