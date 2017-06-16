using Sky.Blog.Core;

namespace Sky.Blog.Core.Messaging
{
    public class GetPagesResponse<T> : ResponseBase where T : BaseEntity
    {
        public PagedList<T> Pages { get; set; }
    }
}