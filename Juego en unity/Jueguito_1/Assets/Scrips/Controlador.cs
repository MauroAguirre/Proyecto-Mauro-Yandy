using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public void CambiarEscena(string escena)
    {
        print("Cambiando a escena: "+ escena);
        SceneManager.LoadScene(escena);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
