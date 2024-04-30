using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TMP_InputField inputNome;

    public async void BotaoEntrar()
    {

        HudManager.instacia.LoadingTime();

        Usuario usuario = await RequestManager.BuscaUsuario(inputNome.text);
        if(usuario == null)
        {
            usuario = await RequestManager.CriarUsuario(inputNome.text);
        }
        
        //Player já esta logado
        HudManager.instacia.DisableHud();
        PlayerSpawner.instacia.SpawnPlayer();
        GameObject.FindWithTag("Spawn").GetComponent<SpawnColetavel>().SpawnarMoeda();
       
        


    }
}