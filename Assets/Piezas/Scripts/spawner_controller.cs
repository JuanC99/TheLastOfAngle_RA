using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_controller : MonoBehaviour
{

    public GameObject pieza;
    private List<Vector3> listaPosicionesGeneradas;
    [SerializeField]
    int numeroDePiezasAGenerar = 10;
    [SerializeField]
    float distanciaMinimaAlVehiculo = 5;
    [SerializeField]
    float distanciaMinimaEntrePiezas = 5;
    [SerializeField]
    GameObject vehiculo;
    [SerializeField]
    Vector3 posInicialVehiculo;
    [SerializeField]
    float radio = 10;
    [SerializeField]
    GameObject terreno;
    float bordeX = 0f;
    float bordeZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //obtenemos la posicion inicial del vehiculo
        posInicialVehiculo = vehiculo.transform.position;
        //obtenemos los bordes
        MeshRenderer mr = terreno.GetComponent<MeshRenderer>();
        bordeX = mr.bounds.size.x;
        bordeZ = mr.bounds.size.z;
        //Debug.Log("Borde X : " + bordeX);
        //Debug.Log("Borde Z : " + bordeZ);

        //instanciamos la lista que guardar� las posiciones donde hay objetos
        listaPosicionesGeneradas = new List<Vector3>();

        //llamamos al metodo para generar las piezas
        Instantiate(pieza, new Vector3(posInicialVehiculo.x + 5, posInicialVehiculo.y, posInicialVehiculo.z  + 5), Quaternion.identity);
        // generarPiezas(1 , 1, 1, mr.bounds.center, radio);
    }

    public void generarPiezas(int numeroAGenerar, float distanciaMinimaAlVehiculo, float distanciaMinimaEntrePiezas, Vector3 origen, float radioMaximo)
    {
        int contadorPiezasGeneradas = 0;
        while (contadorPiezasGeneradas < numeroAGenerar)//comprobamos si ya se han generado todas
        {
            Vector3 randomPosition = origen + Random.insideUnitSphere * radioMaximo;//creamos una coordenada random
            randomPosition.y = 0;



            if (contadorPiezasGeneradas != 0)//comprobamos que no sea la primera
            {
                bool estaLejosDeOtrasPiezas = true;
                foreach (Vector3 pos in listaPosicionesGeneradas)//recorremos la lista de posiciones
                {
                    if (Vector3.Distance(pos, randomPosition) < distanciaMinimaEntrePiezas)//si no esta a la distancia minima de otras piezas no se genera
                    {
                        estaLejosDeOtrasPiezas = false;
                    }
                }
                if (estaLejosDeOtrasPiezas && Vector3.Distance(posInicialVehiculo, randomPosition) > distanciaMinimaAlVehiculo && Mathf.Abs(randomPosition.x) < bordeX && Mathf.Abs(randomPosition.z) < bordeZ)
                {
                    //si pasa todas las comprobaciones se a�ade
                    Instantiate(pieza, randomPosition, Quaternion.identity);
                    contadorPiezasGeneradas++;
                    listaPosicionesGeneradas.Add(randomPosition);
                }

            }
            else
            {
                //si es la primera
                //comprobamos si esta a la distancia minima del vehiculo y si esta dentro del plano
                if (Vector3.Distance(posInicialVehiculo, randomPosition) > distanciaMinimaAlVehiculo && Mathf.Abs(randomPosition.x) < bordeX && Mathf.Abs(randomPosition.z) < bordeZ)
                {
                    Instantiate(pieza, randomPosition, Quaternion.identity);
                    contadorPiezasGeneradas++;
                    listaPosicionesGeneradas.Add(randomPosition);
                }

            }



        }

    }
}
