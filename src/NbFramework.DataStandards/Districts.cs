using System;
using System.ComponentModel;
using NbFramework.Common.Extensions;

namespace NbFramework.DataStandards
{
    #region 中华人民共和国行政区划分

    /// <summary>
    /// 中国行政区（5级） + 根（中国）
    /// </summary>
    public class District
    {
        /// <summary>
        /// 行政区代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 行政区名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 行政区类型
        /// </summary>
        public DistrictType DistrictType
        {
            get
            {
                bool isOk = Code.NbEquals("root") || Code.Length == 6 || Code.Length == 12;
                if (!isOk)
                {
                    throw new ArgumentException("非法的行政区代码:" + Code + ";行政区代码必须是合法的国家注册的6位（3级行政区）或12位（六级行政区）编码");
                }

                if (Code.NbEquals("root"))
                {
                    return DistrictType.Level0;
                }

                //6位
                if (Code.Length == 6)
                {
                    if (Code.EndsWith("0000"))
                    {
                        return DistrictType.Level1;
                    }
                    if (Code.EndsWith("00"))
                    {
                        return DistrictType.Level2;
                    }
                    return DistrictType.Level3;
                }
                //12位
                if (Code.EndsWith("000"))
                {
                    return DistrictType.Level4;
                }
                return DistrictType.Level5;
            }
        }

        /// <summary>
        /// 父代码
        /// </summary>
        public string ParentCode
        {
            get
            {
                switch (this.DistrictType)
                {
                    case DistrictType.Level0:
                        return null;
                        break;
                    case DistrictType.Level1:
                        return "root";
                        break;
                    case DistrictType.Level2:
                        return string.Format("{0}0000", this.Code.Substring(0, 2));
                        break;
                    case DistrictType.Level3:
                        return string.Format("{0}00", this.Code.Substring(0, 4));
                        break;
                    case DistrictType.Level4:
                        return string.Format("{0}", this.Code.Substring(0, 6));
                        break;
                    case DistrictType.Level5:
                        return string.Format("{0}000", this.Code.Substring(0, 9));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 获取码的前缀，用于自己和子孙节点的查询
        /// 例如root->""
        /// 例如420000->42， 420500-> 4205，420526106000 -> 420526106
        /// 例如420000->42， 420500-> 4205，420526106000 -> 420526106，420526106001 -> 420526106001
        /// {"Code":"420000","Name":"湖北省"}
        /// {"Code":"420500","Name":"宜昌市"},
        /// {"Code":"420526","Name":"兴山县"}
        /// {"Code":"420526106000","Name":"水月寺镇"}
        /// </summary>
        public string ParentCodePrefix
        {
            get
            {
                if (Code.NbEquals("root"))
                {
                    return "";
                }

                //6位
                if (Code.Length == 6)
                {
                    if (Code.EndsWith("0000"))
                    {
                        return Code.Substring(0, 2);
                    }
                    if (Code.EndsWith("00"))
                    {
                        return Code.Substring(0, 4);
                    }
                    return Code.TrimEnd('0');
                }
                //12位
                if (Code.EndsWith("000"))
                {
                    return Code.Substring(0, 9);
                }
                return Code.TrimEnd('0');
            }
        }
    }

    /// <summary>
    /// 行政区级别
    /// </summary>
    public enum DistrictType
    {
        /// <summary>
        /// 行政区根（中国）
        /// </summary>
        [Description("行政区根（中国）")]
        Level0 = 0,
        /// <summary>
        /// 一级行政区（省直辖市等）
        /// </summary>
        [Description("一级行政区（省直辖市等）")]
        Level1 = 1,
        /// <summary>
        /// 二级行政区（地级市等） 
        /// </summary>
        [Description("二级行政区（地级市等）")]
        Level2 = 2,
        /// <summary>
        /// 三级行政区（区县等）
        /// </summary>
        [Description("三级行政区（区县等）")]
        Level3 = 3,
        /// <summary>
        /// 四级行政区（乡级行政区名称）
        /// </summary>
        [Description("四级行政区（乡级行政区名称）")]
        Level4 = 4,
        /// <summary>
        /// 五级行政区（村级行政区名称）
        /// </summary>
        [Description("五级行政区（村级行政区名称）")]
        Level5 = 5
        //,[Description("六级行政区（组级行政区名称：村民小组、社区居民小组等）")]
        //Level6 = 6
    }
    
    #endregion
}
