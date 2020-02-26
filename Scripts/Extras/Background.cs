using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] int numeroBg;
    [SerializeField] float velocidadScrollX;
    [SerializeField] float distanciaSpawnRight;
    [SerializeField] float distanciaSpawnLeft;
    [SerializeField] float distanciaDestruccionRight;
    [SerializeField] float distanciaDestruccionLeft;
    [SerializeField] GameObject player;
    [SerializeField] GameObject camera;
    [SerializeField] string nombreBgBase, nombreBgRight, nombreBgLeft;

    private Transform cameraTransform;
    private Rigidbody2D playerRb;
    private float x, y, factorX, difX, posicionX, posicionY;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        cameraTransform = camera.GetComponent<Transform>();
        posicionX = cameraTransform.position.x;
        posicionY = cameraTransform.position.y;
    }

    private void Update()
    {
        if (playerRb != null)
        {
            x = posicionX - cameraTransform.position.x;
            y = posicionY - cameraTransform.position.y;

            if (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0)
            {
                if (Mathf.Abs(x) > 0)
                {
                    factorX = x * velocidadScrollX;
                }
                else
                {
                    factorX = 0;
                }

                transform.Translate(new Vector2(factorX, 0));
            }

            difX = cameraTransform.position.x - transform.position.x;

            if (difX > distanciaSpawnRight && GameObject.Find(nombreBgRight) == null)
            {
                GameObject go = Instantiate(gameObject, new Vector2(transform.position.x + 63.8f, transform.position.y), transform.rotation, transform.parent);
                go.name = nombreBgRight;
                go.GetComponent<Background>().EstablecrBg(numeroBg + 1, nombreBgBase);
            }
            else if (difX < -distanciaSpawnLeft && GameObject.Find(nombreBgLeft) == null)
            {
                GameObject go = Instantiate(gameObject, new Vector2(transform.position.x - 63.8f, transform.position.y), transform.rotation, transform.parent);
                go.name = nombreBgLeft;
                go.GetComponent<Background>().EstablecrBg(numeroBg - 1, nombreBgBase);
            }

            if (difX > distanciaDestruccionRight || difX < -distanciaDestruccionLeft)
            {
                Destroy(gameObject);
            }
        }

        transform.position = new Vector2(transform.position.x, cameraTransform.position.y);
        posicionX = cameraTransform.position.x;
        posicionY = cameraTransform.position.y;
    }

    public void EstablecrBg(int numeroBgNuevo, string nombreBgBaseNuevo)
    {
        numeroBg = numeroBgNuevo;
        nombreBgBase = nombreBgBaseNuevo;

        if (numeroBg == 0)
        {
            nombreBgRight = nombreBgBase + "1";
            nombreBgLeft = nombreBgBase + "-1";
        }
        else if (numeroBg == 1)
        {
            nombreBgRight = nombreBgBase + (numeroBg + 1);
            nombreBgLeft = nombreBgBase;
        }
        else if (numeroBg == -1)
        {
            nombreBgRight = nombreBgBase;
            nombreBgLeft = nombreBgBase + (numeroBg - 1);
        }
        else
        {
            nombreBgRight = nombreBgBase + (numeroBg + 1);
            nombreBgLeft = nombreBgBase + (numeroBg - 1);
        }
    }
}
