using UnityEngine;

public class AtaqueGolpe : MonoBehaviour //se encuentra en ol objeto con el mismo nombre en el hijo Jefe
{
    private Transform jugador;

    private MoverManoJefe manoDer;
    private MoverManoJefe manoIzq;

    private float tiempoEspera = 2f;
    private float temporizador;
    private bool turnoDerecha = true;
    private bool intercalando;

    private Vector2 objetivo;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Jugador")?.GetComponent<Transform>();

        manoDer = transform.Find("ManoDer").gameObject.GetComponent<MoverManoJefe>();
        manoIzq = transform.Find("ManoIzq").gameObject.GetComponent<MoverManoJefe>();
    }

    public void Atacar()
    {
        objetivo = jugador.position;
        intercalando = true;
    }


    private void Update()
    {
        if (!intercalando) return;

        temporizador += Time.deltaTime;

        if (temporizador < tiempoEspera) return;

        temporizador = 0f;

        (turnoDerecha ? manoDer : manoIzq).MoverHacia(objetivo);//se encarga de osilar entre la mano dereche e izquierda

        turnoDerecha = !turnoDerecha;
    }
}
