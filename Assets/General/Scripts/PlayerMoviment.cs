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
        Animator.SetBool("Walk", walk);

        Vector3 movimento = new Vector3(inputHorizontal, 0f, inputVertical);
        movimento *= velocidade * Time.deltaTime;

        transform.Translate(movimento);

        // Rotação
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Relacionar o movimento com a direção da câmera
        Vector3 desiredDirection = forward * inputVertical + right * inputHorizontal;

        if (desiredDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }
    }
}