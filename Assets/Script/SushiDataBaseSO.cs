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
}
public enum SushiID
{
    Maguro,
    Samon,
    Ikura,
    Cyuutoro,
    Uni,
    Amaebi,
    Hamachi,
    Negitoro,
    Tamago,
    Hotate,
    Corn,
    Nattou,
    Maguroyukke,
    Sujiko,
    Shirasu,
    Ebimayo,
    Tunamayo,
    Onsentamago,
    Mentaiko,
    Tako,
    Tekkamaki,
    Simesaba,
    Kappa,
    Anago,
    Aji,
    Ika,
    Kazunoko,
    Katuo,
    Kani,
    Ootoko,
}
