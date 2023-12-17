using UnityEngine;
using System.Collections;
public class PemunculanKoin : MonoBehaviour
{
    public static PemunculanKoin instance; //singleton unity




    Timer timer;


    public int cor;
    public GameObject koinPrefab;

    public GameObject[] sumbu_x;
    public GameObject[] sumbu_z;




    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public float posY;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (cor <= 0 && timer.hapus == true)
        {
            timer.hancurkan("coin");
        }
    }

    void Start()
    {

        timer = GetComponent<Timer>();



        minX = sumbu(sumbu_x[0]);
        maxX = sumbu(sumbu_x[1]);

        minZ = sumbu(sumbu_z[0]);
        maxZ = sumbu(sumbu_z[1]);

        // MunculkanKoin();
    }



    float sumbu(GameObject xz)
    {
        float pos = 0f;  // Inisialisasi variabel pos di luar blok if

        if (xz == sumbu_x[0] || xz == sumbu_x[1])
        {
            pos = xz.transform.position.x;
        }
        else if (xz == sumbu_z[0] || xz == sumbu_z[1])
        {
            pos = xz.transform.position.z;
        }

        return pos;
    }

    public void MunculkanKoin()
    {
        cor = cor - 1;
        // Menentukan posisi acak untuk koin
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // Mengatur posisi Y sesuai dengan variabel posY
        Vector3 posisiAcak = new Vector3(randomX, posY, randomZ);

        // Membuat instance koin di posisi acak
        Instantiate(koinPrefab, posisiAcak, Quaternion.identity);
    }

    public void Tunggu(int nilai)
    {
        cor = cor + nilai;

        StartCoroutine(TungguDanEksekusi());
    }

    public IEnumerator TungguDanEksekusi()
    {

        for (int i = 0; i < cor; i++)
        {
            // Menunggu selama 10 detik
            yield return new WaitForSeconds(10f);

            // Kode yang akan dieksekusi setelah menunggu 10 detik
            Debug.Log("Waktu telah berlalu, kode dieksekusi!");
            MunculkanKoin();
        }


        // Setelah selesai, reset status menunggu

    }
}