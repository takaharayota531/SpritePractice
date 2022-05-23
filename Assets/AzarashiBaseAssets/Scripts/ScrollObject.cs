using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
   [SerializeField] private float speed=1.0f;
    [SerializeField] private float m_StartPosition;
    [SerializeField] private float m_EndPosition;

   /// <summary>
   /// 毎フレーム毎に呼ばれる処理
   /// </summary>
    private void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if(transform.position.x<=m_EndPosition) ScrollEnd();

    }
    /// <summary>
    /// スクロールが最終地点まで来たか確かめるための処理
    /// </summary>
    private void ScrollEnd(){

        float diff = transform.position.x - m_EndPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = m_StartPosition + diff;
        transform.position = restartPosition;
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }

}
