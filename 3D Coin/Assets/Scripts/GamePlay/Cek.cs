using UnityEngine;

public class Cek : MonoBehaviour
{
    public string[] musuh;
    // Start is called before the first frame update




    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log(other.gameObject.name);
            string nama_musuh = other.gameObject.name;
            sudahAd(nama_musuh);

        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log(other.gameObject.name);
            string nama_musuh = other.gameObject.name;
            keluar(nama_musuh);

        }
    }

    private void keluar(string nama_musuh)
    {
        for (int i = 0; i < musuh.Length; i++)
        {
            if (musuh[i] == nama_musuh)
            {
                musuh[i] = string.Empty;
            }
        }
    }

    void sudahAd(string newData)
    {


        for (int i = 0; i < musuh.Length; i++)
        {
            if (musuh[i] == string.Empty) // jika kosong
            {
                int tes = 0;
                for (int j = 0; j < musuh.Length; j++)
                {
                    if (musuh[j] == newData) // apakah ada data sudah ada di array ?
                    {
                        tes = tes + 1; // jika ada maka data tidak di add ke array
                    }
                }
                if (tes == 0) // jika 0 maka data di input ke array
                {
                    musuh[i] = newData;
                }
            }
        }
    }



}
