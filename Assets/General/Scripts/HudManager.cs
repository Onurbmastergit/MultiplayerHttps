using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
   public static HudManager instacia;

   public  GameObject Hud;
   public GameObject HudPlayer;
   public TextMeshProUGUI pontosTela;
   public float velocity =  5;
   
   public UnityEngine.UI.Image Timer;
   public GameObject button;
   void Awake()
   {
     instacia = this;
   }
   void Start()
   {
    pontosTela = GameObject.FindWithTag("ScreenScore").GetComponent<TextMeshProUGUI>();
   }

    public void LoadingTime()
    {
        button.SetActive(false);
        Timer.enabled = true;
        Timer.rectTransform.Rotate(0,0,velocity*Time.deltaTime); 
        Invoke("LoadingTime", 0.01f);
    }
     public void DisableHud()
    {
        HudPlayer.GetComponent<Canvas>().enabled = true;
        Hud.SetActive(false);
    }
    public void AlteraPontosNaTela(int pontos)
    {
        pontosTela.text = pontos.ToString();
    }

}
