using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SushiDataBaseSO : ScriptableObject
{
    public List<SushiData> sushiDatas = new List<SushiData>();

    public SushiData GetSushiData(SushiID sushiID)
    {
        return sushiDatas.Find(data => data.sushiID == sushiID);
    }

    //MyScriptableObjectが保存してある場所のパス
    public const string PATH = "SushiDataBaseSO";

    //MyScriptableObjectの実体
    private static SushiDataBaseSO _entity;
    public static SushiDataBaseSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<SushiDataBaseSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}

[System.Serializable]
public class SushiData
{
    //ID
    //画像
    //名前のセットデータ

    public SushiID sushiID;
    public Sprite sprite;
    public string name;
    public bool bought;
}
public enum SushiID
{
    Maguro_1,
    Samon_2,
    Ikura_3,
    Cyuutoro_4,
    Uni_5,
    Amaebi_6,
    Hamachi_7,
    Negitoro_8,
    Tamago_9,
    Hotate_10,
    Corn_11,
    Nattou_12,
    Maguroyukke_13,
    Sujiko_14,
    Shirasu_15,
    Ebimayo_16,
    Tunamayo_17,
    Onsentamago_18,
    Mentaiko_19,
    Tako_20,
    Tekkamaki_21,
    Simesaba_22,
    Kappa_23,
    Anago_24,
    Aji_25,
    Ika_26,
    Kazunoko_27,
    Katuo_28,
    Kani_29,
    Ootoko_30,
}
