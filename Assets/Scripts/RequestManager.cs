using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
public class Usuario
{
    public int id;
    public string name;
    public int points;
    public string created_at;
}
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
        return usuarios[0];

    }
    public static async Task<Usuario> CriarUsuario(string name)
    {

        string requestUrl = $"{apiUrl}?apikey={apiKey}";
        
        string json = $" \"name\":\"{name}\", \"points\": 0 ";
        json = "{"+json+"}";

        UnityWebRequest request = UnityWebRequest.Post(requestUrl, json, "application/json");
        await request.SendWebRequest();

        return await BuscaUsuario(name);

    }
    //Criar novo usu�rio

    

}
