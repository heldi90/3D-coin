using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetLoader : MonoBehaviour
{
    public AssetReference assetReference;

    void Start()
    {
        LoadAssetAtZero();
    }

    private void LoadAssetAtZero()
    {
        // Vector3.zero akan menempatkan objek di x:0, y:0, z:0
        Addressables.InstantiateAsync(assetReference, Vector3.zero, Quaternion.identity).Completed += (handle) => 
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Objek berhasil muncul di Hierarchy pada posisi (0,0,0)");
            }
            else
            {
                Debug.LogError("Gagal memuat objek. Pastikan AssetReference sudah diisi di Inspector!");
            }
        };
    }
}