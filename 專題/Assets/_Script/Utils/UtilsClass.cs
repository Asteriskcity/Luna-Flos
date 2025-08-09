using UnityEngine;

namespace Guagua.Utils
{
    public class UtilsClass
    {

        //隨機方向
        public static Vector2 GetRandomDirection()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }


        //兩個向量的差，回傳一個向量
        public static Vector3 GetVectorDistance(Vector3 targetA, Vector3 targetB)
        {
            return targetA - targetB;
        }
    }
}
