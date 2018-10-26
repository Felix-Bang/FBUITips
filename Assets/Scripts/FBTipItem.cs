//  Felix-Bang：FBTipItem
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
// Describe：提示框
// Createtime：2018/10/25

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Felix
{
	public class FBTipItem : MonoBehaviour
	{
        #region 字段
        [SerializeField]
        public FBPivot F_Pivot;
        [SerializeField]
        private UITexture f_icon_tex;
        [SerializeField]
        private UISprite f_icon_sprite;
        [SerializeField]
        private UILabel f_des_lab;

        private string f_des_str;
        #endregion

        #region 方法
        public void FBOnShow(FBToolType type, Vector3 pos,string des, string spriteName=null, Texture2D tex=null)
        {
            transform.localPosition = pos;
            f_des_str = des;
            switch (type)
            {
                case FBToolType.Des:
                    FBOnSetLabel(false);
                    break;
                case FBToolType.Des_Sprite:
                    FBOnSetDesSprite(spriteName);
                    break;
                case FBToolType.Des_Texture:
                    FBOnSetDesTexture(tex);
                    break;
                default:
                    break;
            }

            gameObject.SetActive(true);
        }

        void FBOnSetLabel(bool isShowIcon)
        {
            float x;
            float y;
            switch (F_Pivot)
            {
                case FBPivot.LeftTop:
                    x = 38;
                    if (isShowIcon)
                        y = -168;
                    else
                        y = -42;
                    break;
                case FBPivot.LeftBottom:
                    x = 38;
                    if (isShowIcon)
                        y = 168;
                    else
                        y = 284;
                    break;
                case FBPivot.RightTop:
                    x = -338;
                    if (isShowIcon)
                        y = -168;
                    else
                        y = -42;
                    break;
                case FBPivot.RightBottom:
                    x = -338;
                    if (isShowIcon)
                        y = 168;
                    else
                        y = 284;
                    break;
                default:
                    x = 0;
                    y = 0;
                    break;
            }

            if (isShowIcon)
                f_des_lab.height = 127;
            else
                f_des_lab.height = 250;

            f_des_lab.transform.localPosition = new Vector3(x, y, 0);
            f_des_lab.text = f_des_str;
            f_des_lab.gameObject.SetActive(true);
        }

        void FBOnSetDesSprite(string spriteName)
        {
            f_icon_sprite.spriteName = spriteName;
            f_icon_sprite.gameObject.SetActive(true);
            FBOnSetLabel(true);
        }

        void FBOnSetDesTexture(Texture2D tex)
        {
            f_icon_tex.mainTexture = tex;
            f_icon_tex.gameObject.SetActive(true);
            FBOnSetLabel(true);
        }

        public void FBOnHide()
        {
            gameObject.SetActive(false);
            FBOnReset();
        }

        private void FBOnReset()
        {
            f_des_str = string.Empty;
            f_des_lab.text = null;
            f_icon_sprite.spriteName = null;
            f_icon_tex.mainTexture = null;
            f_des_lab.gameObject.SetActive(false);
            f_icon_tex.gameObject.SetActive(false);
            f_icon_sprite.gameObject.SetActive(false);
        }

        #endregion
    }

    public enum FBPivot
    {
        Center,
        LeftTop,
        LeftBottom,
        RightTop,
        RightBottom
    }
}
