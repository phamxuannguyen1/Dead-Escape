using UnityEngine;

public class DoorOpen2 : MonoBehaviour
{
    [SerializeField] private float _thedistance;
    [SerializeField] private GameObject _ActionDisplay;
    [SerializeField] private GameObject _ActionText;
    [SerializeField] private GameObject _TheDoor;
    [SerializeField] private AudioSource _Sound;

    void Update()
    {
        _thedistance = ActionCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (_thedistance <= 3)
        {
            if (_ActionDisplay) _ActionDisplay.SetActive(true);
            if (_ActionText) _ActionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<BoxCollider>().enabled = false;

                if (_ActionDisplay) _ActionDisplay.SetActive(false);
                if (_ActionText) _ActionText.SetActive(false);

                _TheDoor.GetComponent<Animation>().Play("DoorOpen02");

                if (_Sound) _Sound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        if (_ActionDisplay) _ActionDisplay.SetActive(false);
        if (_ActionText) _ActionText.SetActive(false);
    }
}