using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonClass : MonoBehaviour
{
    [SerializeField]
    public float _speed = 5;
    [SerializeField]
    public GameObject _Harpoon;
    [SerializeField]
    public GameObject _Gun;
    private bool _shooting = false;
    private bool _returning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_shooting)
        {
            _Harpoon.transform.Translate(0, 0, Time.deltaTime * _speed);
        }
        else if(_returning)
        {
            ReturnHarpoon();
        }
    }

    public void StopHarpoon()
    {
        _Harpoon.transform.Translate(0, 0, 0);
        _shooting = false;
    }

    public void ReturnHarpoon()
    {
        _Harpoon.transform.Translate(0, 0, Time.deltaTime * -_speed);
    }

    public void ShootForward()
    {

        _shooting = true;
    }


    private void OnTriggerEnter(Collider other)
    {

        _shooting = false;
        if (other.gameObject.CompareTag("HarpoonGun"))
        {
            _returning = false;
            StopHarpoon();
            return;
        }
        _returning = true;
    }


}
