﻿using Sky.Blog.Core;

namespace Sky.Blog.Core
{
    public class Sort
    {
        public Sort(string propertyName, SortMode sortMode)
        {
            PropertyName = propertyName;
            SortMode = sortMode;
        }
        /// <summary>
        /// 排序属性名
        /// </summary>
        public string PropertyName { get; private set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public SortMode SortMode { get; private set; }
    }
}