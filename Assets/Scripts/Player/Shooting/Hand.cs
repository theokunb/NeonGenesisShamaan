using UnityEngine;

public class Hand : MonoBehaviour
{
    private void Start()
    {
        var weaponService = ServiceLocator.Instance.Get<WeaponService>();

        weaponService.Use(0);

        weaponService.CurrentWeapon.transform.parent = transform;
        weaponService.CurrentWeapon.transform.localPosition = Vector3.zero;
    }
}
