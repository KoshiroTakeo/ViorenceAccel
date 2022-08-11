//============================================================
// ���̈ړ�����
//======================================================================
// �J������
// 20220729:�p������̂��ߍč\�z
// 20220811:�������ǉ��AfRadius�ƌ��������ύX�ł���悤�ɂ�����
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class HoverMover 
    {
        // �K�v�Ȃ���
        public float fRadius = 0.2f; // �����J�n����
        public float fbrakepower = 2f;  // �u���[�L���x
        public float fstopmagnitude = 1f;

        float fnowspeed;
        
        public void HeadInclinationMove(CharacterController _character ,Vector3 _anchor, Vector3 _initirizepos, float _speed)
        {
            Vector3 setDirection = new Vector3(_anchor.x - _initirizepos.x, 0, _anchor.z - _initirizepos.z);
            float fsetSpeed = _speed - fRadius;

            // ��~�͈͊O�ɏo���Ƃ�����o��
            if (Calcurate(setDirection.x, setDirection.z) > fRadius)
            {               
                // �����i�K
                if(fsetSpeed >= fnowspeed)
                {
                    Debug.Log("����");
                    _character.Move(setDirection * Time.fixedDeltaTime * (fnowspeed += fsetSpeed / 20));
                }
                else
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * fsetSpeed);
                }
            }
            else
            {
                Debug.Log("gennsoku ");
                fnowspeed = 0;
                if (_character.velocity.magnitude > fstopmagnitude)
                {
                    _character.Move(setDirection * Time.fixedDeltaTime * (fsetSpeed / (_speed / 20)));
                }
                
            }

            
        }

        // �ėp�������͂������番�������i���̂����j
        public float Calcurate(float _x, float _y)
        {
            float radius;

            radius = (_x * _x) + (_y * _y);

            return Mathf.Sqrt(radius);
        }
    }
}