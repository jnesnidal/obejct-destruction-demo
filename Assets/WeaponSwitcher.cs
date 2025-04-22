using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private int currentWeaponIndex = 0;
    private Transform[] weapons;

    void Start()
    {
        // Cache weapon children
        weapons = new Transform[transform.childCount];
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = transform.GetChild(i);
        }

        SelectWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // Number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            SelectWeapon(currentWeaponIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length > 1)
        {
            currentWeaponIndex = 1;
            SelectWeapon(currentWeaponIndex);
        }

        // Mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }
        else if (scroll < 0f)
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
            SelectWeapon(currentWeaponIndex);
        }
    }

    void SelectWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }
    }
}

