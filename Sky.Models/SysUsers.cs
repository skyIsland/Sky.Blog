using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>系统管理员信息</summary>
    [Serializable]
    [DataObject]
    [Description("系统管理员信息")]
    [BindIndex("PK__Gxu_SysU__3214EC2733D4B598", true, "ID")]
    [BindTable("Gxu_SysUsers", Description = "系统管理员信息", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class SysUsers : ISysUsers
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

        private String _LoginName;
        /// <summary>登录账号</summary>
        [DisplayName("登录账号")]
        [Description("登录账号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "LoginName", "登录账号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LoginName
        {
            get { return _LoginName; }
            set { if (OnPropertyChanging(__.LoginName, value)) { _LoginName = value; OnPropertyChanged(__.LoginName); } }
        }

        private String _PassWord;
        /// <summary>登录密码</summary>
        [DisplayName("登录密码")]
        [Description("登录密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "PassWord", "登录密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String PassWord
        {
            get { return _PassWord; }
            set { if (OnPropertyChanging(__.PassWord, value)) { _PassWord = value; OnPropertyChanged(__.PassWord); } }
        }

        private String _RealName;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "RealName", "姓名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String RealName
        {
            get { return _RealName; }
            set { if (OnPropertyChanging(__.RealName, value)) { _RealName = value; OnPropertyChanged(__.RealName); } }
        }

        private Int32 _LoginCount;
        /// <summary>登陆次数</summary>
        [DisplayName("登陆次数")]
        [Description("登陆次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "LoginCount", "登陆次数", null, "int", 10, 0, false)]
        public virtual Int32 LoginCount
        {
            get { return _LoginCount; }
            set { if (OnPropertyChanging(__.LoginCount, value)) { _LoginCount = value; OnPropertyChanged(__.LoginCount); } }
        }

        private DateTime _LastLoginTime;
        /// <summary>最后登录时间</summary>
        [DisplayName("最后登录时间")]
        [Description("最后登录时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "LastLoginTime", "最后登录时间", null, "datetime", 3, 0, false)]
        public virtual DateTime LastLoginTime
        {
            get { return _LastLoginTime; }
            set { if (OnPropertyChanging(__.LastLoginTime, value)) { _LastLoginTime = value; OnPropertyChanged(__.LastLoginTime); } }
        }

        private String _LastLoginIP;
        /// <summary>最后登录IP</summary>
        [DisplayName("最后登录IP")]
        [Description("最后登录IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "LastLoginIP", "最后登录IP", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LastLoginIP
        {
            get { return _LastLoginIP; }
            set { if (OnPropertyChanging(__.LastLoginIP, value)) { _LastLoginIP = value; OnPropertyChanged(__.LastLoginIP); } }
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
                    case __.LoginName : return _LoginName;
                    case __.PassWord : return _PassWord;
                    case __.RealName : return _RealName;
                    case __.LoginCount : return _LoginCount;
                    case __.LastLoginTime : return _LastLoginTime;
                    case __.LastLoginIP : return _LastLoginIP;                  
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.LoginName : _LoginName = Convert.ToString(value); break;
                    case __.PassWord : _PassWord = Convert.ToString(value); break;
                    case __.RealName : _RealName = Convert.ToString(value); break;
                    case __.LoginCount : _LoginCount = Convert.ToInt32(value); break;
                    case __.LastLoginTime : _LastLoginTime = Convert.ToDateTime(value); break;
                    case __.LastLoginIP : _LastLoginIP = Convert.ToString(value); break;                  
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得系统管理员信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>登录账号</summary>
            public static readonly Field LoginName = FindByName(__.LoginName);

            ///<summary>登录密码</summary>
            public static readonly Field PassWord = FindByName(__.PassWord);

            ///<summary>姓名</summary>
            public static readonly Field RealName = FindByName(__.RealName);

            ///<summary>登陆次数</summary>
            public static readonly Field LoginCount = FindByName(__.LoginCount);

            ///<summary>最后登录时间</summary>
            public static readonly Field LastLoginTime = FindByName(__.LastLoginTime);

            ///<summary>最后登录IP</summary>
            public static readonly Field LastLoginIP = FindByName(__.LastLoginIP);
       

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得系统管理员信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>登录账号</summary>
            public const String LoginName = "LoginName";

            ///<summary>登录密码</summary>
            public const String PassWord = "PassWord";

            ///<summary>姓名</summary>
            public const String RealName = "RealName";

            ///<summary>登陆次数</summary>
            public const String LoginCount = "LoginCount";

            ///<summary>最后登录时间</summary>
            public const String LastLoginTime = "LastLoginTime";

            ///<summary>最后登录IP</summary>
            public const String LastLoginIP = "LastLoginIP";

          
        }
        #endregion
    }

    /// <summary>系统管理员信息接口</summary>
    public partial interface ISysUsers
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>登录账号</summary>
        String LoginName { get; set; }

        /// <summary>登录密码</summary>
        String PassWord { get; set; }

        /// <summary>姓名</summary>
        String RealName { get; set; }

        /// <summary>登陆次数</summary>
        Int32 LoginCount { get; set; }

        /// <summary>最后登录时间</summary>
        DateTime LastLoginTime { get; set; }

        /// <summary>最后登录IP</summary>
        String LastLoginIP { get; set; }         
           
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}