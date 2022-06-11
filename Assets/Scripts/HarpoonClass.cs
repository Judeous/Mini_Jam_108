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
    public bool _hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (_hit == true)
        {
            ReturnHarpoon();
        }

        else if (_hit == false)
        {
            StopHaproon();
        }

    }

    public void StopHaproon()
    {
        _Harpoon.transform.Translate(0, 0, 0);
    }

    public void ReturnHarpoon()
    {
        _Harpoon.transform.Translate(0, 0, Time.deltaTime * -_speed);
        //_Harpoon.transform.parent = _Gun.transform;
    }

        public void ShootForward()
    {
        _Harpoon.transform.Translate(0, 0, Time.deltaTime * _speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Return"))
        {
            _hit = true;
        }

        if (other.gameObject.CompareTag("HarpoonGun"))
        {
            _hit = false;

        }
    }





}
