using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemic : MonoBehaviour
{
    private float _vel;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("No se encontró el GameController en la escena.");
        }
        _vel = 4f;
        Invoke("DestruirEnemic", 4);
    }

    private void DestruirEnemic (){
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 posJugador = GameObject.Find("Jugador").transform.position;

        Vector3 direccioCapAJugador = (posJugador - transform.position).normalized;

        transform.position += direccioCapAJugador * (_vel * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision objecteTocat){
        if(objecteTocat.gameObject.name == "Jugador"){
            Destroy(gameObject);
            gameController.IncrementarEnemicsTocats();
        }
    }

}
