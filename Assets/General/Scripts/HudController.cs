using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TMP_InputField inputNome;
    public RequestManager requestManager;

    void Start()
    {
    requestManager = GameObject.FindWithTag("Network").GetComponent<RequestManager>();
    }
    public async void BotaoEntrar()
    {
        HudManager.instacia.LoadingTime();

        Usuario usuario = await RequestManager.BuscaUsuario(inputNome.text);
        if(usuario == null)
        {
            usuario = await RequestManager.CriarUsuario(inputNome.text);
        }
        
        ToastNotification.Show("Olá, "+usuario.name+", bem-vindo de volta!");
        
        GameManager.usuarioLogado = usuario;
        requestManager.RankUsuarios();
        HudManager.instacia.AlteraPontosNaTela(GameManager.usuarioLogado.points);
        HudManager.instacia.DisableHud();
        PlayerSpawner.instacia.SpawnPlayer();
        GameObject.FindWithTag("Spawn").GetComponent<SpawnColetavel>().SpawnarMoeda();    
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            BotaoEntrar();
        }
    }
    
}
