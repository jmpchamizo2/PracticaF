using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPrueba2Script : MonoBehaviour {

    [SerializeField] GameObject espada;
    [SerializeField] GameObject espadaMovimiento;
    [SerializeField] float radioX;
    [SerializeField] float radioZ;
    //[SerializeField] float velocidad;
    const float TIEMPOENTREMETODOS = 0.56f;
    float factorVelocidadDeCambio = 1 / TIEMPOENTREMETODOS;
    GameObject instancia;
    Vector3 posicionInicial;
    Quaternion rotacionInicial;
    float theta;
    float tiempoTotal;
    int count;



    private void FixedUpdate() {
        MovimientoHorizontalDerecho();
    }


    private void AumentarTheta() {

        if (theta > 180) {
            count++;
            print(count);
            theta = 0;
        } else {
            theta += factorVelocidadDeCambio * Time.deltaTime * 180;
        }
    }

    private void LanzarEspadaHorizontalDerecha() {
        theta = 0.0001f;
        tiempoTotal = 0;
        CopiarTransformInicial();
        espada.SetActive(false);
        espadaMovimiento.SetActive(true);

    }

    private void CopiarTransformInicial() {
        posicionInicial = espada.transform.position;
        rotacionInicial = espada.transform.rotation;
        espadaMovimiento.transform.position = posicionInicial;
        espadaMovimiento.transform.rotation = rotacionInicial;
        //print("Rotation Inicial: " + rotacionInicial.eulerAngles);
        //print("Position Inicial: " + posicionInicial);
    }

    private void MovimientoHorizontalDerecho() {
  
        if (espadaMovimiento.activeSelf) {
           tiempoTotal += Time.deltaTime;
            espadaMovimiento.transform.position = new Vector3(
                posicionInicial.x + (radioX / 2 * Mathf.Cos(theta)) - radioX / 2,
                posicionInicial.y,
                posicionInicial.z + (radioZ * Mathf.Sin(theta)));
            espadaMovimiento.transform.rotation = rotacionInicial;
            AumentarTheta();
        }
    }

    private void RecogerEspadaHorizontalDerecha() {
        espada.SetActive(true);
        //print("Rotation Final: " + espada.transform.rotation.eulerAngles);
        //print("Position Final: " + espada.transform.position);
        print("Tiempo total: " + tiempoTotal);
        espadaMovimiento.SetActive(false);

    }


}
