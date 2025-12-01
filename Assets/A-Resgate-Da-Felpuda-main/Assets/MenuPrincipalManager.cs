using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string NomeCenaJogo;
    [SerializeField] private GameObject painelControles;
    [SerializeField] private GameObject painelMenuPrincipal;
    public void Jogar() {
        SceneManager.LoadScene(NomeCenaJogo);
    }

    public void Controles() {
        painelMenuPrincipal.SetActive(false);
        painelControles.SetActive(true);
    }
    public void VoltarMenu() {
        painelMenuPrincipal.SetActive(true);
         painelControles.SetActive(false);
    }  
}
