using UnityEngine;

public class GameManagerRaces : MonoBehaviour
{
    public static GameManagerRaces instance;
    public int inimigosMortos = 0;
    public int inimigosNecessarios = 5;
    public GameObject bossPrefab;
    public Transform bossSpawn;
    public GeradorInimigosRaces geradorInimigos; // arraste no Inspector

    private bool bossInvocado = false;
    private bool bossMorto = false;




    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("TimeScale resetado!");
    }
    void Awake() {
        instance = this;
    }

    public void InimigoMorto() {
        if (bossMorto) return; // se o boss já morreu, ignora

        inimigosMortos++;

        // Só invoca o boss uma vez
        if (!bossInvocado && inimigosMortos >= inimigosNecessarios) {
            InvocarBoss();
        }
    }

    void InvocarBoss()
    {
        bossInvocado = true;
        Debug.Log("Boss apareceu!");

        if (geradorInimigos == null)
        {
            Debug.LogError("? ERRO: geradorInimigos NÃO está atribuído no inspector!");
        }
        else
        {
            Debug.Log("?? Parando spawn agora!");
            geradorInimigos.PararSpawn();
        }

        Instantiate(bossPrefab, bossSpawn.position, Quaternion.identity);
    }



    // Chame este método quando o boss morrer
    public void BossMorreu() {
        bossMorto = true;
        bossInvocado = false;
        Debug.Log("Boss derrotado!");
    }


}
