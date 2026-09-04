using UnityEngine;

public class Saltar : MonoBehaviour, IMover //el script se encuentra en el boton de saltar (hud del jugador)
{ 
    private float fuerza = 8.5f;

    public void Mover(Rigidbody2D rb)
    {
        LayerMask piso = LayerMask.GetMask("Piso"); //el nombre del Layer en que se encuntran las plataformas del mapa

        RaycastHit2D golpe = Physics2D.Raycast(rb.position, Vector2.down, 1.5f, piso); //lanza un raycast hacia el piso
        
        Debug.DrawRay(rb.position, Vector2.down * 1.5f, Color.red); //si no está tocando el piso, no puede saltar
        
        if (!golpe) return;
        
        rb.linearVelocity = new Vector2( rb.linearVelocity.x, fuerza );
    }
}
