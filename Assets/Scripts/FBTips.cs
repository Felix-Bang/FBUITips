//  Felix-Bang：FBTips
//　　 へ　　　　　／|
//　　/＼7　　　 ∠＿/
//　 /　│　　 ／　／
//　│　Z ＿,＜　／　　 /`ヽ
//　│　　　　　ヽ　　 /　　〉
//　 Y　　　　　`　 /　　/
//　ｲ●　､　●　　⊂⊃〈　　/
//　()　 へ　　　　|　＼〈
//　　>ｰ ､_　 ィ　 │ ／／
//　 / へ　　 /　ﾉ＜| ＼＼
//　 ヽ_ﾉ　　(_／　 │／／
//　　7　　　　　　　|／
//　　＞―r￣￣`ｰ―＿
// Describe：提示管理
// Createtime：2018/10/25

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class FBTips : MonoBehaviour
	{
        #region 字段
        private static FBTips f_instance; 
 
        [SerializeField]
        private FBTipItem[] f_tips;
        private FBToolType f_type_enum;
        private string f_cachedes_str;
        private string f_cachedspname_str;
        private Texture2D f_cached_tex2D;
        
        private FBTipItem f_current_tip;
        private bool f_isshow_b = false;
        private float f_speed_f=2f;
        private FBPivot f_current_pivot = FBPivot.Center;
        #endregion

        #region 属性
        public static FBTips F_Instance
        {
            get
            {
                if (f_instance == null)
                    f_instance = FindObjectOfType<FBTips>();
                return f_instance;
            }
        }
        #endregion

        #region Unity回调
        void Awake()
        {
            f_instance = this;
        }
	
		void FixedUpdate()
		{
            if (!f_isshow_b)
                return;

            if (f_current_pivot.Equals(FBGetPivot()))
            {
                float step = f_speed_f * Time.deltaTime;
                Vector3 currentPos = f_current_tip.transform.localPosition;
                f_current_tip.transform.localPosition = new Vector3(Mathf.Lerp(currentPos.x, FBGetItemLocalPos().x, step),
                    Mathf.Lerp(currentPos.y, FBGetItemLocalPos().y, step),
                    Mathf.Lerp(currentPos.z, FBGetItemLocalPos().z, step));
            }
            else
            {
                f_current_tip.FBOnHide();
                FBOnShow(f_type_enum, f_cachedes_str, f_cachedspname_str, f_cached_tex2D);
            }
        }
        #endregion

        #region 方法
        public void FBOnShow(FBToolType type,string des, string spriteName=null, Texture2D tex=null)
        {
            f_type_enum = type;
            f_cachedes_str = des;
            f_cachedspname_str = spriteName;
            f_cached_tex2D = tex;

            f_current_pivot = FBGetPivot();
            Vector3 localPos = FBGetItemLocalPos();

            switch (f_current_pivot)
            {
                case FBPivot.LeftTop:
                    f_current_tip = f_tips[0];
                    break;
                case FBPivot.RightTop:
                    f_current_tip = f_tips[1];
                    break;
                case FBPivot.LeftBottom:
                    f_current_tip = f_tips[2];
                    break;
                case FBPivot.RightBottom:
                    f_current_tip = f_tips[3];
                    break;
            }

            f_current_tip.FBOnShow(type,localPos,des,spriteName,tex);
            f_isshow_b = true;
        }

        private Vector3 FBGetItemLocalPos()
        {
            Vector3 mouseWorldPos = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 localPos = transform.InverseTransformPoint(mouseWorldPos);
            return localPos;
        }

        private FBPivot FBGetPivot()
        {
            FBPivot pivot = FBPivot.Center;
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x < (Screen.width / 2) && mousePos.y > (Screen.height / 2))
                pivot = FBPivot.LeftTop;
            else if (mousePos.x > (Screen.width / 2) && mousePos.y > (Screen.height / 2))
                pivot = FBPivot.RightTop;
            else if (mousePos.x < (Screen.width / 2) && mousePos.y < (Screen.height / 2))
                pivot = FBPivot.LeftBottom;
            else if (mousePos.x > (Screen.width / 2) && mousePos.y < (Screen.height / 2))
                pivot = FBPivot.RightBottom;
            else
                pivot = FBPivot.LeftTop;

            return pivot;
        }

        public void FBOnHide()
        {
            f_current_tip.FBOnHide();
            f_current_tip = null;
            f_isshow_b = false;
        }
        #endregion
    }
}
