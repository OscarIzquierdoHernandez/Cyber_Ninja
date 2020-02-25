﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Slider volumenSlider;
    [SerializeField] Text VolumenTexto;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = PlayerPrefs.GetInt(UIConfigManager.SONIDO, 1) == 1 ? true : false;
        audioSource.volume = PlayerPrefs.GetFloat(UIConfigManager.VOLUMEN, 1);
    }

    public void CambiarVolumen()
    {
        audioSource.volume = volumenSlider.value;
        VolumenTexto.text = ("Volume " + ((int)(volumenSlider.value * 100)) + "%");
    }
}
