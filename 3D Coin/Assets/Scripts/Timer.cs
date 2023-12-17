using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public bool hapus = false;
    public float waktuTotal = 60.0f;  // Waktu total dalam detik
    private float waktuSisa;  // Waktu yang tersisa
    public TextMeshProUGUI textTimer;


    // Referensi teks untuk menampilkan timer

    void Start()
    {
        waktuSisa = waktuTotal;
        StartCoroutine(HitungMundur());

    }

    IEnumerator HitungMundur()
    {
        while (waktuSisa > 0)
        {
            TampilkanWaktu();
            yield return new WaitForSeconds(1.0f);
            waktuSisa--;
        }

        // Eksekusi ketika waktu habis
        TampilkanWaktu();
        Debug.Log("Waktu sudah habis!");
        PemunculanKoin.instance.cor = 0;
        hapus = true;
        hancurkan("coin");


    }

    public void hancurkan(string coin)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(coin);

        // Iterasi melalui setiap objek dan menghancurkannya
        foreach (GameObject obj in objectsWithTag)
        {
            // Menghancurkan objek
            Destroy(obj);

            // atau menggunakan DestroyImmediate(obj) untuk menghancurkan objek segera
        }
    }

    void TampilkanWaktu()
    {
        // Menampilkan waktu di UI atau melakukan sesuatu dengan nilai waktu
        if (textTimer != null)
        {
            textTimer.text = "Waktu: " + waktuSisa.ToString();
        }
    }
}
