using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MendapatkanKoin : MonoBehaviour
{


    public int jmlhCoin;
    public TextMeshProUGUI ui_coin;
    public AudioSource sfx;
    public AudioClip sound_sfx;

    private void Start()
    {
        ui_coin.text = jmlhCoin.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            sfx.PlayOneShot(sound_sfx);
            jmlhCoin = jmlhCoin + 1;
            ui_coin.text = jmlhCoin.ToString();
            Destroy(other.gameObject);


            PemunculanKoin.instance.Tunggu(1);


        }


        // Lakukan sesuatu ketika objek masuk ke dalam collider
    }



}
