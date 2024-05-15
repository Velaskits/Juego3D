using UnityEngine;

public class Moneda : MonoBehaviour
{
    private float velocidad = 6f;
    private float tiempoVida = 6f;
    private float tiempoCambioDireccion = 2f;
    private Vector3 direccion;
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();

        CambiarDireccionAleatoria();
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
        tiempoCambioDireccion -= Time.deltaTime;
        if (tiempoCambioDireccion <= 0f)
        {
            CambiarDireccionAleatoria();
            tiempoCambioDireccion = 2f;
        }
    }

    void OnCollisionEnter(Collision objecteTocat)
    {
        if (objecteTocat.gameObject.name == "Jugador")
        {
            if (gameController != null)
            {
                gameController.IncrementarMonedesTocades();
            }
            Destroy(gameObject);
        }
    }

    void CambiarDireccionAleatoria()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        direccion = new Vector3(x, y, 0f).normalized;
    }
}
