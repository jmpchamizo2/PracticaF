using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPruebaEspada : MonoBehaviour {

    [SerializeField] GameObject espada;
    [SerializeField] GameObject espadaPrefab;
    [SerializeField] float radioX = -0.15f;
    [SerializeField] float radioZ = -1.5f;
    [SerializeField] float velocidad = 0.18f;
    [SerializeField] Transform lanzamiento;


    float theta;
    GameObject instancia;
    private void Start() {
        
    }

    void FixedUpdate () {
        if(instancia != null) {
            instancia.transform.Translate(new Vector3((radioX * Mathf.Cos(theta)), 0, radioZ * Mathf.Sin(theta)), Space.World);
            instancia.transform.rotation = espada.transform.rotation;
            AumentarTheta();
        }
        
	}

    private void AumentarTheta() {
        theta += velocidad;
        theta = Mathf.Max(theta, 180);

    }

    private void ComenzarAnimacion() {
        espada.SetActive(false);
        theta = 0;;
        instancia = Instantiate(espadaPrefab, espada.transform.position, espada.transform.rotation);
    }

    private void FinalizarAnimacion() {
        espada.SetActive(true);
        Destroy(instancia.gameObject);
        
    }

}
