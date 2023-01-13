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
    public Sprite sushiSprite;
    public string name;
    public SushiRank sushiRank;
    public Sprite saraSprite;
}
public enum SushiID
{
    Maguro_1,
    Tamagoyaki_2,
    Sichikin_3,
    Tekkamaki_4,
    Kappamaki_5,
    Tobikko_6,
    Nattoumaki_7,
    Inarizushi_8,
    Kanpyoumaki_9,
    Hanbagu_10,
    Okuranattou_11,
    Mushiebi_12,
    Hokkigai_13,
    Iwashi_14,
    Sanma_15,
    Samon_16,
    Amaebi_17,
    Hamachi_18,
    Ika_19,
    Tako_20,
    Negitoro_21,
    Maguroyukke_22,
    Aji_23,
    Katuo_24,
    Engawa_25,
    Aburisamon_26,
    Tubu_27,
    Bincyoumaguro_28,
    Buri_29,
    Tai_30,
    Kanpachi_31,
    Kanimiso_32,
    Sujiko_33,
    Torosamon_34,
    Ikura_35,
    Chutoro_36,
    Hirame_37,
    Saba_38,
    Kazunoko_39,
    Unagi_40,
    Zuwaigani_41,
    Anago_42,
    Maguroakami_43,
    Ootoro_44,
    Uni_45,
    Hotate_46,
    Botanebi_47,
    Tarabagani_48,
    Nodoguro_49,
    Awabi_50,
}

public enum TapCoinID
{
    Day_1,
    Day_2,
    Day_3,
    Day_4,
    Day_5,
    Day_6,
    Day_7,
    Day_8,
    Day_9,
    Day_10,
}

public enum SushiRank
{
    Rank_1,
    Rank_2,
    Rank_3,
    Rank_4,
    Rank_5,
    Rank_6,
    Rank_7,
}
