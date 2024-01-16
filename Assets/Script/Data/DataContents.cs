using System;
using System.Collections.Generic;
using System.Linq;
using Script.Manager.Core;

namespace Script.Data
{
    #region TextData

    [Serializable]
    public class TextData
    {
        public int id;
        public string text;
    }

    [Serializable]
    public class TextDataLoader : ILoader<int, TextData>
    {
        public List<TextData> TextDatas = new List<TextData>();
        public Dictionary<int, TextData> MakeDict()
        {
            return TextDatas.GroupBy(data => data.id).ToDictionary(group => group.Key, group => group.First());
        }
    }
    #endregion
}