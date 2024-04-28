using UnityEngine;

public class Hand : MonoBehaviour
{
    private WeaponService _weaponService;
    private NewControls inputActions;



    private void OnEnable()
    {
        _weaponService = ServiceLocator.Instance.Get<WeaponService>();

        inputActions = new NewControls();
        inputActions.Enable();

        inputActions.Player.FirstWeapon.performed += OnFirstWeaponPerformed;
        inputActions.Player.SecondWeapon.performed += OnSecondWeaponPerformed;
        inputActions.Player.ThirdWeapon.performed += OnThirdWeaponPerformed;
    }

    private void OnDisable()
    {
        inputActions.Disable();

        inputActions.Player.FirstWeapon.performed -= OnFirstWeaponPerformed;
        inputActions.Player.SecondWeapon.performed -= OnSecondWeaponPerformed;
        inputActions.Player.ThirdWeapon.performed -= OnThirdWeaponPerformed;
    }

    private void OnThirdWeaponPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Equip(2);
    }

    private void OnSecondWeaponPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Equip(1);
    }

    private void OnFirstWeaponPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Equip(0);
    }
    private void Equip(int index)
    {
        _weaponService.Use(index);

        _weaponService.CurrentWeapon.transform.parent = transform;
        _weaponService.CurrentWeapon.transform.localPosition = Vector3.zero;
    }
}
