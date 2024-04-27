using UnityEngine;

public class CameraFollow : BaseMonoBeh, IService
{
    [SerializeField] private float _speed;

    private Room _currentRoom;

    public void LookAt(Room room)
    {
        _currentRoom = room;
    }

    private void Update()
    {
        if (_currentRoom == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentRoom.transform.position.x,
            _currentRoom.transform.position.y, transform.position.z), _speed * Time.deltaTime);
    }
}
