using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文章信息</summary>
    [Serializable]
    [DataObject]
    [Description("文章信息")]
    [BindIndex("PK_Sky.Article", true, "ID")]
    [BindTable("Sky_Article", Description = "文章信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class Article : IArticle
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

        private String _Title;
        /// <summary>标题</summary>
        [DisplayName("标题")]
        [Description("标题")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Title", "标题", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging(__.Title, value)) { _Title = value; OnPropertyChanged(__.Title); } }
        }

        private String _Content;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(3, "Content", "内容", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging(__.Content, value)) { _Content = value; OnPropertyChanged(__.Content); } }
        }

        private String _Author;
        /// <summary>作者</summary>
        [DisplayName("作者")]
        [Description("作者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Author", "作者", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Author
        {
            get { return _Author; }
            set { if (OnPropertyChanging(__.Author, value)) { _Author = value; OnPropertyChanged(__.Author); } }
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

        private Boolean _IsTop;
        /// <summary>是否置顶</summary>
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(6, "IsTop", "是否置顶", null, "bit", 0, 0, false)]
        public virtual Boolean IsTop
        {
            get { return _IsTop; }
            set { if (OnPropertyChanging(__.IsTop, value)) { _IsTop = value; OnPropertyChanged(__.IsTop); } }
        }

        private Int32 _Sort;
        /// <summary>排序值</summary>
        [DisplayName("排序值")]
        [Description("排序值")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "Sort", "排序值", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private Int32 _State;
        /// <summary>发布状态</summary>
        [DisplayName("发布状态")]
        [Description("发布状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "State", "发布状态", null, "int", 10, 0, false)]
        public virtual Int32 State
        {
            get { return _State; }
            set { if (OnPropertyChanging(__.State, value)) { _State = value; OnPropertyChanged(__.State); } }
        }

        private Int32 _Hits;
        /// <summary>点击量</summary>
        [DisplayName("点击量")]
        [Description("点击量")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "Hits", "点击量", null, "int", 10, 0, false)]
        public virtual Int32 Hits
        {
            get { return _Hits; }
            set { if (OnPropertyChanging(__.Hits, value)) { _Hits = value; OnPropertyChanged(__.Hits); } }
        }

        private Int32 _IsDel;
        /// <summary>是否删除</summary>
        [DisplayName("是否删除")]
        [Description("是否删除")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "IsDel", "是否删除", null, "int", 10, 0, false)]
        public virtual Int32 IsDel
        {
            get { return _IsDel; }
            set { if (OnPropertyChanging(__.IsDel, value)) { _IsDel = value; OnPropertyChanged(__.IsDel); } }
        }

        private String _Tags;
        /// <summary>标签</summary>
        [DisplayName("标签")]
        [Description("标签")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Tags", "标签", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Tags
        {
            get { return _Tags; }
            set { if (OnPropertyChanging(__.Tags, value)) { _Tags = value; OnPropertyChanged(__.Tags); } }
        }

        private String _MetaTitle;
        /// <summary>SEO标题</summary>
        [DisplayName("SEO标题")]
        [Description("SEO标题")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "MetaTitle", "SEO标题", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MetaTitle
        {
            get { return _MetaTitle; }
            set { if (OnPropertyChanging(__.MetaTitle, value)) { _MetaTitle = value; OnPropertyChanged(__.MetaTitle); } }
        }

        private String _MetaKeywords;
        /// <summary>SEO关键字</summary>
        [DisplayName("SEO关键字")]
        [Description("SEO关键字")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "MetaKeywords", "SEO关键字", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MetaKeywords
        {
            get { return _MetaKeywords; }
            set { if (OnPropertyChanging(__.MetaKeywords, value)) { _MetaKeywords = value; OnPropertyChanged(__.MetaKeywords); } }
        }

        private String _MetaDescription;
        /// <summary>SEO描述</summary>
        [DisplayName("SEO描述")]
        [Description("SEO描述")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(14, "MetaDescription", "SEO描述", null, "nvarchar(200)", 0, 0, true)]
        public virtual String MetaDescription
        {
            get { return _MetaDescription; }
            set { if (OnPropertyChanging(__.MetaDescription, value)) { _MetaDescription = value; OnPropertyChanged(__.MetaDescription); } }
        }

        private Int32 _CategoryId;
        /// <summary>分类表ID</summary>
        [DisplayName("分类表ID")]
        [Description("分类表ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "CategoryId", "分类表ID", null, "int", 10, 0, false)]
        public virtual Int32 CategoryId
        {
            get { return _CategoryId; }
            set { if (OnPropertyChanging(__.CategoryId, value)) { _CategoryId = value; OnPropertyChanged(__.CategoryId); } }
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
                    case __.Title : return _Title;
                    case __.Content : return _Content;
                    case __.Author : return _Author;
                    case __.CreateTime : return _CreateTime;
                    case __.IsTop : return _IsTop;
                    case __.Sort : return _Sort;
                    case __.State : return _State;
                    case __.Hits : return _Hits;
                    case __.IsDel : return _IsDel;
                    case __.Tags : return _Tags;
                    case __.MetaTitle : return _MetaTitle;
                    case __.MetaKeywords : return _MetaKeywords;
                    case __.MetaDescription : return _MetaDescription;
                    case __.CategoryId : return _CategoryId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Title : _Title = Convert.ToString(value); break;
                    case __.Content : _Content = Convert.ToString(value); break;
                    case __.Author : _Author = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.IsTop : _IsTop = Convert.ToBoolean(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.State : _State = Convert.ToInt32(value); break;
                    case __.Hits : _Hits = Convert.ToInt32(value); break;
                    case __.IsDel : _IsDel = Convert.ToInt32(value); break;
                    case __.Tags : _Tags = Convert.ToString(value); break;
                    case __.MetaTitle : _MetaTitle = Convert.ToString(value); break;
                    case __.MetaKeywords : _MetaKeywords = Convert.ToString(value); break;
                    case __.MetaDescription : _MetaDescription = Convert.ToString(value); break;
                    case __.CategoryId : _CategoryId = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文章信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>标题</summary>
            public static readonly Field Title = FindByName(__.Title);

            ///<summary>内容</summary>
            public static readonly Field Content = FindByName(__.Content);

            ///<summary>作者</summary>
            public static readonly Field Author = FindByName(__.Author);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>是否置顶</summary>
            public static readonly Field IsTop = FindByName(__.IsTop);

            ///<summary>排序值</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>发布状态</summary>
            public static readonly Field State = FindByName(__.State);

            ///<summary>点击量</summary>
            public static readonly Field Hits = FindByName(__.Hits);

            ///<summary>是否删除</summary>
            public static readonly Field IsDel = FindByName(__.IsDel);

            ///<summary>标签</summary>
            public static readonly Field Tags = FindByName(__.Tags);

            ///<summary>SEO标题</summary>
            public static readonly Field MetaTitle = FindByName(__.MetaTitle);

            ///<summary>SEO关键字</summary>
            public static readonly Field MetaKeywords = FindByName(__.MetaKeywords);

            ///<summary>SEO描述</summary>
            public static readonly Field MetaDescription = FindByName(__.MetaDescription);

            ///<summary>分类表ID</summary>
            public static readonly Field CategoryId = FindByName(__.CategoryId);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文章信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>标题</summary>
            public const String Title = "Title";

            ///<summary>内容</summary>
            public const String Content = "Content";

            ///<summary>作者</summary>
            public const String Author = "Author";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>是否置顶</summary>
            public const String IsTop = "IsTop";

            ///<summary>排序值</summary>
            public const String Sort = "Sort";

            ///<summary>发布状态</summary>
            public const String State = "State";

            ///<summary>点击量</summary>
            public const String Hits = "Hits";

            ///<summary>是否删除</summary>
            public const String IsDel = "IsDel";

            ///<summary>标签</summary>
            public const String Tags = "Tags";

            ///<summary>SEO标题</summary>
            public const String MetaTitle = "MetaTitle";

            ///<summary>SEO关键字</summary>
            public const String MetaKeywords = "MetaKeywords";

            ///<summary>SEO描述</summary>
            public const String MetaDescription = "MetaDescription";

            ///<summary>分类表ID</summary>
            public const String CategoryId = "CategoryId";

        }
        #endregion
    }

    /// <summary>文章信息接口</summary>
    public partial interface IArticle
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>标题</summary>
        String Title { get; set; }

        /// <summary>内容</summary>
        String Content { get; set; }

        /// <summary>作者</summary>
        String Author { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>是否置顶</summary>
        Boolean IsTop { get; set; }

        /// <summary>排序值</summary>
        Int32 Sort { get; set; }

        /// <summary>发布状态</summary>
        Int32 State { get; set; }

        /// <summary>点击量</summary>
        Int32 Hits { get; set; }

        /// <summary>是否删除</summary>
        Int32 IsDel { get; set; }

        /// <summary>标签</summary>
        String Tags { get; set; }

        /// <summary>SEO标题</summary>
        String MetaTitle { get; set; }

        /// <summary>SEO关键字</summary>
        String MetaKeywords { get; set; }

        /// <summary>SEO描述</summary>
        String MetaDescription { get; set; }

        /// <summary>分类表ID</summary>
        Int32 CategoryId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}