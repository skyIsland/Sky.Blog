﻿namespace Sky.Blog.Core.Messaging
{
    public class PageRequest
    {
        public PageRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; private set; }
    }
}