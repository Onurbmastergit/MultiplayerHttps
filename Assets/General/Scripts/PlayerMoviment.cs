using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoviment : MonoBehaviour
{
    public float velocidade = 5;
    bool walk;
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        walk = inputHorizontal != 0 || inputVertical != 0;
        Animator.SetBool("Walk" , walk);

        Vector3 movimento = new Vector3(inputHorizontal,0f, inputVertical);
        movimento *= velocidade * Time.deltaTime;

        
        transform.Translate(movimento);
    }
}
