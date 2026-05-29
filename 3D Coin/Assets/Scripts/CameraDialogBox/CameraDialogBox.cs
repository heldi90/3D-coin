using UnityEngine;

public class CameraDialogBox : MonoBehaviour
{
    public Transform cameraDialogBox;  // Referensi ke objek camera dialog box
    public float distanceBehind = 3f;  // Jarak di belakang pemain, dapat diubah di Inspector
    public float customYPosition = 2f;  // Posisi Y yang diatur di Inspector
    public float customRotationX = 0f;  // Rotasi X yang diatur di Inspector
    public float customRotationY = 0f;  // Rotasi Y yang diatur di Inspector

    void Update()
    {
        // Pindahkan kamera ke posisi pertama di belakang pemain
        MoveCameraBehindPlayer();
    }

    // Fungsi untuk memindahkan kamera ke posisi di belakang pemain
    void MoveCameraBehindPlayer()
    {
        // Menggunakan transform dari objek yang menjalankan skrip ini (player)
        Transform player = this.transform;

        // Hitung posisi di belakang pemain berdasarkan jarak yang diatur di Inspector
        Vector3 behindPosition = player.position - player.forward * distanceBehind;

        // Set nilai Y ke customYPosition yang sudah diatur di Inspector
        behindPosition.y = customYPosition;

        // Update posisi objek camera dialog box
        cameraDialogBox.position = behindPosition;

        // Pastikan kamera menghadap ke arah yang sama dengan pemain
        cameraDialogBox.rotation = player.rotation;

        // Terapkan rotasi tambahan sesuai dengan yang diatur di Inspector
        ApplyCustomRotation();
    }

    // Fungsi untuk mengatur rotasi objek camera dialog box
    void ApplyCustomRotation()
    {
        // Rotasi objek sesuai dengan yang diatur di Inspector
        cameraDialogBox.rotation = Quaternion.Euler(customRotationX, customRotationY, cameraDialogBox.rotation.eulerAngles.z);
    }
}
