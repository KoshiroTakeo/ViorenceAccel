//============================================================
// あの移動処理
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
// 20220811:加減速追加、fRadiusと減速率が変更できるようにしたい
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class HoverMover 
    {
        // 必要なもの
        public float fRadius = 0.2f; // 加速開始距離
        public float fbrakepower = 2f;  // ブレーキ強度
        public float fstopmagnitude = 1f;

        float fnowspeed;
        
        public void HeadInclinationMove(CharacterController _character ,Vector3 _anchor, Vector3 _initirizepos, float _speed)
        {
            Vector3 setDirection = new Vector3(_anchor.x - _initirizepos.x, 0, _anchor.z - _initirizepos.z);
            float fsetSpeed = _speed - fRadius;

            // 停止範囲外に出たとき走り出す
            if (Calcurate(setDirection.x, setDirection.z) > fRadius)
            {               
                // 加速段階
                if(fsetSpeed >= fnowspeed)
                {
                    Debug.Log("加速");
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

        // 汎用性高いはずだから分けたい（そのうち）
        public float Calcurate(float _x, float _y)
        {
            float radius;

            radius = (_x * _x) + (_y * _y);

            return Mathf.Sqrt(radius);
        }
    }
}
