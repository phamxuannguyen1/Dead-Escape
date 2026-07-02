using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public static bool _isCarrying = false;
    public static GameObject _currentItem;

    public static void PickItem(GameObject item)
    {
        _isCarrying = true;
        _currentItem = item;
    }

    public static void DropItem()
    {
        _isCarrying = false;
        _currentItem = null;
    }
}