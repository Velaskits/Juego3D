using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button boton;
    public Text marcadorText;
    public Text escudosText;
    public Text puntosJugador;
    public GameObject panel;
    public GameObject monedaPrefab;
    public GameObject enemigoPrefab;
    public Transform[] puntosGeneracion;
    private int monedesTocades = 0;
    private int enemicsTocats = 0;
    private int escutsJugador = 0;
    private int puntos_jugador = 0;
    private bool juegoEnCurso = false;
    private bool juegoPausado = false;

    void Start()
    {
        IniciarJuego();
    }

    void IniciarJuego()
    {
        monedesTocades = 0;
        enemicsTocats = 0;
        escutsJugador = 0;
        puntos_jugador = 0;
        ActualizarMarcador();
        juegoEnCurso = true;
        InvokeRepeating("GenerarMoneda", 1, 2);
        panel.SetActive(false);
    }

    void FinalizarJuego()
    {
        botonPulsado();
        juegoPausado = true;
        CancelInvoke("GenerarMoneda");
        PausarJuego();
        PuntosJugador();
        juegoEnCurso = false;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Moneda"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemic"))
        {
            Destroy(obj);
        }
    }

    void GenerarMoneda()
    {
        int indicePunto = Random.Range(0, puntosGeneracion.Length);
        Vector3 posicionGeneracion = puntosGeneracion[indicePunto].position;
        Instantiate(monedaPrefab, posicionGeneracion, Quaternion.identity);
    }

    public void IncrementarMonedesTocades()
    {
        monedesTocades++;
        escutsJugador++;
        puntos_jugador++;
        ActualizarMarcador();
    }

    public void botonPulsado(){
        if(boton != null){
            boton.onClick.AddListener(ReanudarJuego);
        }
    }

    public void IncrementarEnemicsTocats()
    {
        enemicsTocats++;
        escutsJugador--;
        ActualizarMarcador();

        if (escutsJugador < 0)
        {
            FinalizarJuego(); 
        }
    }


    void ActualizarMarcador()
    {
        if (marcadorText != null)
        {
            marcadorText.text = "Monedas tocadas: " + monedesTocades + "\nEnemigos tocados: " + enemicsTocats;
        }

        if (escudosText != null)
        {
            escudosText.text = "Escudos jugador: " + escutsJugador;
        }
    }

    void PuntosJugador(){
        if (puntosJugador != null)
        {
            puntosJugador.text = "Puntos Obtenidos: " + puntos_jugador;
        }
    }

    public void FinalizarJuegoExterno()
    {
        FinalizarJuego();
    }

    void PausarJuego()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; 
        juegoPausado = true;
    }

    void ReanudarJuego()
    {
        Time.timeScale = 1f; 
        juegoPausado = false;
        IniciarJuego();
    }
}
