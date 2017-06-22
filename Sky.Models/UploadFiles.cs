using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>文件上传关联对象信息</summary>
    [Serializable]
    [DataObject]
    [Description("文件上传关联对象信息")]
    [BindIndex("IX_Gxu_UploadFiles", false, "InfoID")]
    [BindIndex("PK__Gxu_Uplo__3214EC07662B2B3B", true, "Id")]
    [BindTable("Gxu_UploadFiles", Description = "文件上传关联对象信息", ConnName = "FilesConn", DbType = DatabaseType.SqlServer)]
    public partial class UploadFiles : IUploadFiles
    {
        #region 属性
        private Guid _Id;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, false, false, 16)]
        [BindColumn(1, "Id", "", null, "uniqueidentifier", 0, 0, false)]
        public virtual Guid Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private String _FileName;
        /// <summary>文件名称</summary>
        [DisplayName("文件名称")]
        [Description("文件名称")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(2, "FileName", "文件名称", null, "nvarchar(255)", 0, 0, true)]
        public virtual String FileName
        {
            get { return _FileName; }
            set { if (OnPropertyChanging(__.FileName, value)) { _FileName = value; OnPropertyChanged(__.FileName); } }
        }

        private String _FileSize;
        /// <summary>文件大小</summary>
        [DisplayName("文件大小")]
        [Description("文件大小")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(3, "FileSize", "文件大小", null, "nvarchar(255)", 0, 0, true)]
        public virtual String FileSize
        {
            get { return _FileSize; }
            set { if (OnPropertyChanging(__.FileSize, value)) { _FileSize = value; OnPropertyChanged(__.FileSize); } }
        }

        private String _FileType;
        /// <summary>文件类型</summary>
        [DisplayName("文件类型")]
        [Description("文件类型")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(4, "FileType", "文件类型", null, "nvarchar(255)", 0, 0, true)]
        public virtual String FileType
        {
            get { return _FileType; }
            set { if (OnPropertyChanging(__.FileType, value)) { _FileType = value; OnPropertyChanged(__.FileType); } }
        }

        private String _FileExt;
        /// <summary>文件后缀</summary>
        [DisplayName("文件后缀")]
        [Description("文件后缀")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(5, "FileExt", "文件后缀", null, "nvarchar(255)", 0, 0, true)]
        public virtual String FileExt
        {
            get { return _FileExt; }
            set { if (OnPropertyChanging(__.FileExt, value)) { _FileExt = value; OnPropertyChanged(__.FileExt); } }
        }

        private String _FilePath;
        /// <summary>存储路径</summary>
        [DisplayName("存储路径")]
        [Description("存储路径")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(6, "FilePath", "存储路径", null, "nvarchar(255)", 0, 0, true)]
        public virtual String FilePath
        {
            get { return _FilePath; }
            set { if (OnPropertyChanging(__.FilePath, value)) { _FilePath = value; OnPropertyChanged(__.FilePath); } }
        }

        private Boolean _IsImg;
        /// <summary>是否图片</summary>
        [DisplayName("是否图片")]
        [Description("是否图片")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(7, "IsImg", "是否图片", "0", "bit", 0, 0, false)]
        public virtual Boolean IsImg
        {
            get { return _IsImg; }
            set { if (OnPropertyChanging(__.IsImg, value)) { _IsImg = value; OnPropertyChanged(__.IsImg); } }
        }

        private String _bytHash;
        /// <summary>文件MD5值</summary>
        [DisplayName("文件MD5值")]
        [Description("文件MD5值")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(8, "bytHash", "文件MD5值", null, "nvarchar(255)", 0, 0, true)]
        public virtual String bytHash
        {
            get { return _bytHash; }
            set { if (OnPropertyChanging(__.bytHash, value)) { _bytHash = value; OnPropertyChanged(__.bytHash); } }
        }

        private String _CreatBy;
        /// <summary>添加人</summary>
        [DisplayName("添加人")]
        [Description("添加人")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(9, "CreatBy", "添加人", null, "nvarchar(255)", 0, 0, true)]
        public virtual String CreatBy
        {
            get { return _CreatBy; }
            set { if (OnPropertyChanging(__.CreatBy, value)) { _CreatBy = value; OnPropertyChanged(__.CreatBy); } }
        }

        private DateTime _CreateDate;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "CreateDate", "添加时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } }
        }
        private String _FileSizeString;
        /// <summary>文件大小文本</summary>
        [DisplayName("文件大小文本")]
        [Description("文件大小文本")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "FileSizeString", "文件大小文本", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FileSizeString
        {
            get { return _FileSizeString; }
            set { if (OnPropertyChanging(__.FileSizeString, value)) { _FileSizeString = value; OnPropertyChanged(__.FileSizeString); } }
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
                    case __.Id : return _Id;
                    case __.FileName : return _FileName;
                    case __.FileSize : return _FileSize;
                    case __.FileType : return _FileType;
                    case __.FileExt : return _FileExt;
                    case __.FilePath : return _FilePath;
                    case __.IsImg : return _IsImg;
                    case __.bytHash : return _bytHash;
                    case __.CreatBy : return _CreatBy;
                    case __.CreateDate : return _CreateDate;                
                    case __.FileSizeString : return _FileSizeString;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = (Guid)value; break;
                    case __.FileName : _FileName = Convert.ToString(value); break;
                    case __.FileSize : _FileSize = Convert.ToString(value); break;
                    case __.FileType : _FileType = Convert.ToString(value); break;
                    case __.FileExt : _FileExt = Convert.ToString(value); break;
                    case __.FilePath : _FilePath = Convert.ToString(value); break;
                    case __.IsImg : _IsImg = Convert.ToBoolean(value); break;
                    case __.bytHash : _bytHash = Convert.ToString(value); break;
                    case __.CreatBy : _CreatBy = Convert.ToString(value); break;
                    case __.CreateDate : _CreateDate = Convert.ToDateTime(value); break;                  
                    case __.FileSizeString : _FileSizeString = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文件上传关联对象信息字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>文件名称</summary>
            public static readonly Field FileName = FindByName(__.FileName);

            ///<summary>文件大小</summary>
            public static readonly Field FileSize = FindByName(__.FileSize);

            ///<summary>文件类型</summary>
            public static readonly Field FileType = FindByName(__.FileType);

            ///<summary>文件后缀</summary>
            public static readonly Field FileExt = FindByName(__.FileExt);

            ///<summary>存储路径</summary>
            public static readonly Field FilePath = FindByName(__.FilePath);

            ///<summary>是否图片</summary>
            public static readonly Field IsImg = FindByName(__.IsImg);

            ///<summary>文件MD5值</summary>
            public static readonly Field bytHash = FindByName(__.bytHash);

            ///<summary>添加人</summary>
            public static readonly Field CreatBy = FindByName(__.CreatBy);

            ///<summary>添加时间</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);        
            ///<summary>文件大小文本</summary>
            public static readonly Field FileSizeString = FindByName(__.FileSizeString);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文件上传关联对象信息字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary>文件名称</summary>
            public const String FileName = "FileName";

            ///<summary>文件大小</summary>
            public const String FileSize = "FileSize";

            ///<summary>文件类型</summary>
            public const String FileType = "FileType";

            ///<summary>文件后缀</summary>
            public const String FileExt = "FileExt";

            ///<summary>存储路径</summary>
            public const String FilePath = "FilePath";

            ///<summary>是否图片</summary>
            public const String IsImg = "IsImg";

            ///<summary>文件MD5值</summary>
            public const String bytHash = "bytHash";

            ///<summary>添加人</summary>
            public const String CreatBy = "CreatBy";

            ///<summary>添加时间</summary>
            public const String CreateDate = "CreateDate";
            ///<summary>文件大小文本</summary>
            public const String FileSizeString = "FileSizeString";

        }
        #endregion
    }

    /// <summary>文件上传关联对象信息接口</summary>
    public partial interface IUploadFiles
    {
        #region 属性
        /// <summary></summary>
        Guid Id { get; set; }

        /// <summary>文件名称</summary>
        String FileName { get; set; }

        /// <summary>文件大小</summary>
        String FileSize { get; set; }

        /// <summary>文件类型</summary>
        String FileType { get; set; }

        /// <summary>文件后缀</summary>
        String FileExt { get; set; }

        /// <summary>存储路径</summary>
        String FilePath { get; set; }

        /// <summary>是否图片</summary>
        Boolean IsImg { get; set; }

        /// <summary>文件MD5值</summary>
        String bytHash { get; set; }

        /// <summary>添加人</summary>
        String CreatBy { get; set; }

        /// <summary>添加时间</summary>
        DateTime CreateDate { get; set; }       
        /// <summary>文件大小文本</summary>
        String FileSizeString { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}