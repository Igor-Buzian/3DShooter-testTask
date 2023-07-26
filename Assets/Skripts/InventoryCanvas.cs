using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvas : MonoBehaviour
{
    [SerializeField] private GameObject firstWeapon;
    [SerializeField] private GameObject secondWeapon;
    [SerializeField] private GameObject[] weaponPlayer;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Text Fps;
    private Weapon[] WeaponCode;


    private void Start()
    {
        // Получаем компоненты Weapon из дочерних объектов
        WeaponCode = new Weapon[weaponPlayer.Length];
        for (int i = 0; i < weaponPlayer.Length; i++)
        {
            WeaponCode[i] = weaponPlayer[i].GetComponent<Weapon>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            WeaponCode[0].enabled = false;
            WeaponCode[1].enabled = false;
            Panel.SetActive(true);
            Time.timeScale = 0f;
            Fps.gameObject.SetActive(false);
        }
    }

    public void FirstWeapon()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        WeaponCode[0].enabled = true;
        firstWeapon.SetActive(true);
        secondWeapon.SetActive(false);
        Panel.SetActive(false);
        Fps.gameObject.SetActive(true);
    }

    public void SecondWeapon()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        WeaponCode[1].enabled = true;
        firstWeapon.SetActive(false);
        secondWeapon.SetActive(true);
        Panel.SetActive(false);
        Fps.gameObject.SetActive(true);
    }
}
