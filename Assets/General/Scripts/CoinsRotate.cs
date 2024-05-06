using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotate : MonoBehaviour
{
    public int coinValue = 1;
    void Update()
    {
        transform.Rotate(0, 0 , 50* Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.usuarioLogado.points++;
            HudManager.instacia.AlteraPontosNaTela(GameManager.usuarioLogado.points);
            RequestManager.AlteraPontos(GameManager.usuarioLogado.id,GameManager.usuarioLogado.points);
            Destroy(gameObject);

        }
    }
}
