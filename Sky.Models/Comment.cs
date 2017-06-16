using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>评论</summary>
    [Serializable]
    [DataObject]
    [Description("评论")]
    [BindIndex("PK_SKy.Comment", true, "ID")]
    [BindTable("SKy_Comment", Description = "评论", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class Comment : IComment
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

        private String _Nickname;
        /// <summary>昵称</summary>
        [DisplayName("昵称")]
        [Description("昵称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Nickname", "昵称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Nickname
        {
            get { return _Nickname; }
            set { if (OnPropertyChanging(__.Nickname, value)) { _Nickname = value; OnPropertyChanged(__.Nickname); } }
        }

        private String _Email;
        /// <summary>电子邮箱</summary>
        [DisplayName("电子邮箱")]
        [Description("电子邮箱")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Email", "电子邮箱", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging(__.Email, value)) { _Email = value; OnPropertyChanged(__.Email); } }
        }

        private String _CommentText;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 300)]
        [BindColumn(4, "CommentText", "内容", null, "nvarchar(300)", 0, 0, true)]
        public virtual String CommentText
        {
            get { return _CommentText; }
            set { if (OnPropertyChanging(__.CommentText, value)) { _CommentText = value; OnPropertyChanged(__.CommentText); } }
        }

        private Int32 _ArticleId;
        /// <summary>文章ID</summary>
        [DisplayName("文章ID")]
        [Description("文章ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "ArticleId", "文章ID", null, "int", 10, 0, false)]
        public virtual Int32 ArticleId
        {
            get { return _ArticleId; }
            set { if (OnPropertyChanging(__.ArticleId, value)) { _ArticleId = value; OnPropertyChanged(__.ArticleId); } }
        }

        private DateTime _CreateTime;
        /// <summary>评论时间</summary>
        [DisplayName("评论时间")]
        [Description("评论时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "CreateTime", "评论时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _CommentIp;
        /// <summary>评论者IP</summary>
        [DisplayName("评论者IP")]
        [Description("评论者IP")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(7, "CommentIp", "评论者IP", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CommentIp
        {
            get { return _CommentIp; }
            set { if (OnPropertyChanging(__.CommentIp, value)) { _CommentIp = value; OnPropertyChanged(__.CommentIp); } }
        }

        private Int32 _State;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "State", "状态", null, "int", 10, 0, false)]
        public virtual Int32 State
        {
            get { return _State; }
            set { if (OnPropertyChanging(__.State, value)) { _State = value; OnPropertyChanged(__.State); } }
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
                    case __.Nickname : return _Nickname;
                    case __.Email : return _Email;
                    case __.CommentText : return _CommentText;
                    case __.ArticleId : return _ArticleId;
                    case __.CreateTime : return _CreateTime;
                    case __.CommentIp : return _CommentIp;
                    case __.State : return _State;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Nickname : _Nickname = Convert.ToString(value); break;
                    case __.Email : _Email = Convert.ToString(value); break;
                    case __.CommentText : _CommentText = Convert.ToString(value); break;
                    case __.ArticleId : _ArticleId = Convert.ToInt32(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.CommentIp : _CommentIp = Convert.ToString(value); break;
                    case __.State : _State = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得评论字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>昵称</summary>
            public static readonly Field Nickname = FindByName(__.Nickname);

            ///<summary>电子邮箱</summary>
            public static readonly Field Email = FindByName(__.Email);

            ///<summary>内容</summary>
            public static readonly Field CommentText = FindByName(__.CommentText);

            ///<summary>文章ID</summary>
            public static readonly Field ArticleId = FindByName(__.ArticleId);

            ///<summary>评论时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>评论者IP</summary>
            public static readonly Field CommentIp = FindByName(__.CommentIp);

            ///<summary>状态</summary>
            public static readonly Field State = FindByName(__.State);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得评论字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>昵称</summary>
            public const String Nickname = "Nickname";

            ///<summary>电子邮箱</summary>
            public const String Email = "Email";

            ///<summary>内容</summary>
            public const String CommentText = "CommentText";

            ///<summary>文章ID</summary>
            public const String ArticleId = "ArticleId";

            ///<summary>评论时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>评论者IP</summary>
            public const String CommentIp = "CommentIp";

            ///<summary>状态</summary>
            public const String State = "State";

        }
        #endregion
    }

    /// <summary>评论接口</summary>
    public partial interface IComment
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>昵称</summary>
        String Nickname { get; set; }

        /// <summary>电子邮箱</summary>
        String Email { get; set; }

        /// <summary>内容</summary>
        String CommentText { get; set; }

        /// <summary>文章ID</summary>
        Int32 ArticleId { get; set; }

        /// <summary>评论时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>评论者IP</summary>
        String CommentIp { get; set; }

        /// <summary>状态</summary>
        Int32 State { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}