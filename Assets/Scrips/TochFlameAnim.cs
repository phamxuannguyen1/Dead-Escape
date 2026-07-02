using System.Collections;
using UnityEngine;

public class TochFlameAnim : MonoBehaviour
{
    public int _lightmode;
    public GameObject _flamelight;
  

    // Update is called once per frame
    void Start()
    {
        if (_lightmode == 0)
        {
            StartCoroutine(FlameAnim());
        }
        
    }
    IEnumerator FlameAnim()
    {
        _lightmode = Random.Range(1, 4);
        if (_lightmode == 1)
        {
            _flamelight.GetComponent<Animation>().Play("torchanim01");
        }
        else if (_lightmode == 2)
        {
            _flamelight.GetComponent<Animation>().Play("torchanim02");
        }
        else if (_lightmode == 3)
        {
            _flamelight.GetComponent<Animation>().Play("torchanim03");
        }
        yield return new WaitForSeconds(0.99f);

            _lightmode = 0;

    }
}
