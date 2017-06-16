using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>分类信息</summary>
    [Serializable]
    [DataObject]
    [Description("分类信息")]
    [BindIndex("PK_Category", true, "ID")]
    [BindTable("Sky_Category", Description = "分类信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class Category : ICategory
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _CategoryName;
        /// <summary>分类名称</summary>
        [DisplayName("分类名称")]
        [Description("分类名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "CategoryName", "分类名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryName
        {
            get { return _CategoryName; }
            set { if (OnPropertyChanging(__.CategoryName, value)) { _CategoryName = value; OnPropertyChanged(__.CategoryName); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private Boolean _IsTop;
        /// <summary>是否置顶</summary>
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(4, "IsTop", "是否置顶", null, "bit", 0, 0, false)]
        public virtual Boolean IsTop
        {
            get { return _IsTop; }
            set { if (OnPropertyChanging(__.IsTop, value)) { _IsTop = value; OnPropertyChanged(__.IsTop); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "CreateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.ID : return _ID;
                    case __.CategoryName : return _CategoryName;
                    case __.Sort : return _Sort;
                    case __.IsTop : return _IsTop;
                    case __.CreateTime : return _CreateTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.CategoryName : _CategoryName = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.IsTop : _IsTop = Convert.ToBoolean(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得分类信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>分类名称</summary>
            public static readonly Field CategoryName = FindByName(__.CategoryName);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>是否置顶</summary>
            public static readonly Field IsTop = FindByName(__.IsTop);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得分类信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>分类名称</summary>
            public const String CategoryName = "CategoryName";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>是否置顶</summary>
            public const String IsTop = "IsTop";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

        }
        #endregion
    }

    /// <summary>分类信息接口</summary>
    public partial interface ICategory
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>分类名称</summary>
        String CategoryName { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>是否置顶</summary>
        Boolean IsTop { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}