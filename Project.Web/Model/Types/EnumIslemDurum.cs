using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Model.Types
{
    public enum EnumIslemDurum
    {
        IslemBasarili = 1,
        LoginHata = 2,
        ValidationHata = 3,
        EmailHata = 4,
        HataliIslem = 5
    }
}