using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNpcs : MonoBehaviour
{
    [SerializeField] private AudioClip hablarSonido;
    public float velMov, velRot;

    public float tiempoReaccion = 0.8f; 
    int movimiento;
    bool espera, camina, gira;

    private void Start()
    {
        accion();
    }
    private void Update()
    {
        if (espera)
        {
            GetComponent<Animator>().SetBool("Activo", false);
        }
        if (camina)
        {
            GetComponent<Animator>().SetBool("Activo", true);
            transform.position += (transform.forward * velMov * Time.deltaTime);
        }
        if (gira)
        {
            transform.Rotate(Vector3.up * velRot * Time.deltaTime);
        }
    }

    void accion()
    {
        movimiento = Random.Range(1, 4);
        if (movimiento == 1)
        {
            camina = true;
            espera = false;
        }
        if (movimiento == 2)
        {
            espera = true;
            camina = false;
        }
        if (movimiento == 3)
        {
            gira = true;
            StartCoroutine(tiempoGiro());
        }

        //Invocamos la accion y el tiempo en el que se repite todo el ciclo en donde se ejecuta constantemente.
        Invoke("accion", tiempoReaccion);
    }

    //Evitar que gire y gire.
    IEnumerator tiempoGiro()
    {
        yield return new WaitForSeconds(2);
        gira = false;
    }

    private void OnTriggerEnter(Collider other)
    {
    

        if (other.tag == "Player")
        {
            AudioManager.Instance.PlaySound(hablarSonido);
        }

    }

}
