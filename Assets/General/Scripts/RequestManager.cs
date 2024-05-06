using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

public class RequestManager : MonoBehaviour
{
    static string apiUrl = "https://udbivwcnyultcnelilpl.supabase.co/rest/v1/usuarios";
    static string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVkYml2d2NueXVsdGNuZWxpbHBsIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTIzNDcwMzMsImV4cCI6MjAyNzkyMzAzM30.sA3IglUsaastSDRPspXy_EeDo0e2cOaV1Wno_08lYE0";
    
    //Buscar um usu�rio pelo nome
    public static async Task<Usuario> BuscaUsuario(string name) 
    {

        string requestUrl = $"{apiUrl}?name=eq.{name}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

        string response = request.downloadHandler.text;
        if(response == "[]")
        {
            return null;
        }
        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
        Debug.Log($"{usuarios[0].name}");

        HudManager.instacia.LoadingTime();
        
        return usuarios[0];

    }
     //Criar novo usu�rio
    public static async Task<Usuario> CriarUsuario(string name)
    {

        string requestUrl = $"{apiUrl}?apikey={apiKey}";
        
        string json = $" \"name\":\"{name}\", \"points\": 0 ";
        json = "{"+json+"}";

        UnityWebRequest request = UnityWebRequest.Post(requestUrl, json, "application/json");
        await request.SendWebRequest();

        HudManager.instacia.LoadingTime();
        return await BuscaUsuario(name);

    }
    //Atualiza pontos buscando pelo id do usuário
    public static async void AlteraPontos(int id , int pontos)
    {
        string json = "{\"points\":"+pontos+"}";
        string requestUrl = $"{apiUrl}?id=eq.{id}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Put(requestUrl, json);
        request.SetRequestHeader("Content-Type","application/json");
        request.method ="PATCH";

        await request.SendWebRequest();

    } 
    public static async void RankUsuarios()
    {
        string requestUrl = $"{apiUrl}?points=gt.0&order=points.desc&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

         string response = request.downloadHandler.text;
        if(response == "[]")
        {
            return ;
        }
        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);

        for(int i = 0; i < usuarios.Count;i++)
        {  
               
        }
        Debug.Log(usuarios[0].name);
    }
   
    

}
