using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Tools.Helpers
{
    public enum FilterType
    {
        None = 0,
        TokType,
        Text,
        Category,
        Country,
        User,
        Group,
        Featured,
        Set,
        All
    }

    public enum Result
    {
        Success = 1,
        Failed,
        Error,
        Forbidden
    }

    public enum CookieFilter
    {
        Id = 1,
        Token,
        StreamToken
    }

    public enum GameMode
    {
        Normal = 1,
        Education
    }

    public enum Reaction
    {
        Like = 1,
        Dislike,
        Accurate,
        Inaccurate,
        Comment
    }

    public enum PackageType
    {
        Basic = 1,
        Mid,
        Premier
    }

    public enum ValueType
    {
        Coins = 1,
        USD
    }

    public enum EmojiType
    {
        Smileys = 1,
        People,
        Celebrations,
        Food,
        Transportation,
        Symbols
    }

    public enum LoadType
    {
        Database = 1,
        Screen
    }
}
