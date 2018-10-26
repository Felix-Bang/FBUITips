//  Felix-Bang：FBTipTarget
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
// Describe：需要显示提示的目标
// Createtime：2018/10/25

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
    public class FBTipTarget : MonoBehaviour
    {
        #region 字段
        [SerializeField]
        private FBToolType f_type;
        [SerializeField, TextArea(3, 10)]
        private string f_des_str = string.Empty;
        [SerializeField]
        private Texture2D f_icon_tex;
        [SerializeField]
        private UISprite f_icon_sprite;
        #endregion

        #region 方法
        public void OnHover(bool isHover)
        {
            if (isHover)
                FBOnGetTips();
            else
                FBTips.F_Instance.FBOnHide();
        }

        private void FBOnGetTips()
        {
            switch (f_type)
            {
                case FBToolType.Des:
                    FBTips.F_Instance.FBOnShow(f_type,f_des_str);
                    break;
                case FBToolType.Des_Sprite:
                    FBTips.F_Instance.FBOnShow(f_type, f_des_str, f_icon_sprite.spriteName);
                    break;
                case FBToolType.Des_Texture:
                    FBTips.F_Instance.FBOnShow(f_type, f_des_str, null,f_icon_tex);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

    public enum FBToolType
    {
        Des,
        Des_Texture,
        Des_Sprite
    }
}
