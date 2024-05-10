using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaZ = Input.GetAxisRaw("Vertical");

        Vector3 direccioIndicada = new Vector3(direccioIndicadaX, 0, direccioIndicadaZ).normalized;

        transform.position += direccioIndicada * (_vel * Time.deltaTime);
    }
}
