using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Beginner.Blog.Core;
using Beginner.Blog.Models;
using Beginner.Blog.Service.Messaging.Request;
using Beginner.Blog.Core.Messaging;

namespace Beginner.Blog.Service.Interfaces
{
    /// <summary>
    /// 文章服务接口
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetPagesResponse<Article> GetPageArticles(GetPageArticlesRequest request);

        ResponseBase Insert(Article entity);
    }
}
