using UnityEngine;

public class GunEquip : MonoBehaviour
{
    public GameObject gun;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(!gun.activeSelf);
        }
    }
}
