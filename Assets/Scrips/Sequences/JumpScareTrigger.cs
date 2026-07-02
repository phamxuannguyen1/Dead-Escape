using System.Collections;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public AudioSource _doorBang;
    public AudioSource _jumpScareSound;
    public GameObject _thezoombie;
    public GameObject _theDoor;
    public GameObject _Torch;

    private void OnTriggerEnter()
    {
        
            GetComponent<BoxCollider>().enabled = false;
            _theDoor.GetComponent<Animation>().Play("DoorOpen02");
            _doorBang.Play();
            _jumpScareSound.Play();

            StartCoroutine(ActivateJumpScare());
        
    }

    IEnumerator ActivateJumpScare()
    {
        yield return new WaitForSeconds(1.5f);
        _thezoombie.SetActive(false);
        _Torch.SetActive(false);
        yield return new WaitForSeconds(5f);
        _Torch.SetActive(true);

    }

}
