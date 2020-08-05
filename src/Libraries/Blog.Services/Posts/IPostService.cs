using Blog.Core;
using Blog.Core.Domain.Posts;

namespace Blog.Services.Posts
{
    /// <summary>
    /// Post service
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Get post by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        Post GetPostById(int id);

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post">post entity</param>
        void AddPost(Post post);

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="post">post entity</param>
        void UpdatePost(Post post);

        /// <summary>
        /// Delete post by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        void DeletePost(int id);

        /// <summary>
        /// Search posts by criteria
        /// </summary>
        /// <param name="title">post title</param>
        /// <param name="body">post content</param>
        /// <param name="tags"> post tags</param>
        /// <param name="pageIndex">page index</param>
        /// <param name="pageSize"> page size</param>
        /// <returns></returns>
        PagingResult<Post> SearchPosts(string title = "", string body = "", string tags = "", int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
