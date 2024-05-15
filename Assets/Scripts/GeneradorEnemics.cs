using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    public GameObject _prefabEnemic;
    void Start()
    {
        InvokeRepeating("GeneraEnemic", 1, 2);
    }

    private void GeneraEnemic(){
        GameObject enemic = Instantiate(_prefabEnemic);
        enemic.transform.position = transform.position;
    }

    void Update()
    {
        
    }
}
