
using UnityEngine;

public abstract class Item 
{
  // 아이템에 공통적으로 들어갈 내용 정리 필요.
  // 우선 아이템에 대한 이름 및 Sprite 정보 그리고 3D Prefab 연결 까지 해주면 될 듯

  #region GetProperty

  protected string _name;
  public virtual string GetName
  {
    get { return _name; }
    set { return; }
  }
  
  public Sprite GetSprite { get; private set; }
  
  public int GetSlot { get; private set; }
  
  public GameObject GetPrefab { get; private set; }

  #endregion




}

