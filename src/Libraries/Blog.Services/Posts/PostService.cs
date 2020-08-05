using System;
using System.Linq;
using Blog.Core;
using Blog.Core.Domain.Posts;
using Blog.Data;

namespace Blog.Services.Posts
{
    /// <summary>
    /// Post service
    /// </summary>
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repositoryPost;
        public PostService(IRepository<Post> repositoryPost)
        {
            _repositoryPost = repositoryPost;
        }

        /// <summary>
        /// Get post by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        public Post GetPostById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("id");

            return _repositoryPost.GetById(id);
        }

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post">post entity</param>
        public void AddPost(Post post)
        {
            if (post == null)
                throw new ArgumentNullException("post");

            _repositoryPost.Insert(post);
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="post">post entity</param>
        public void UpdatePost(Post post)
        {
            if (post == null)
                throw new ArgumentNullException($"{nameof(post)}");

            _repositoryPost.Update(post);
        }

        /// <summary>
        /// Delete post by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        public void DeletePost(int id)
        {
            if (id == 0)
                throw new ArgumentNullException($"{nameof(id)}");

            var post = _repositoryPost.GetById(id);
            if (post == null)
                throw new ArgumentNullException($"not found post id:{id}");

            post.Deleted = true;
            _repositoryPost.Update(post);
        }

        /// <summary>
        /// Search posts by criteria
        /// </summary>
        /// <param name="title">post title</param>
        /// <param name="body">post content</param>
        /// <param name="tags"> post tags</param>
        /// <param name="pageIndex">page index</param>
        /// <param name="pageSize"> page size</param>
        /// <returns></returns>
        public PagingResult<Post> SearchPosts(string title = "", string body = "", string tags = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _repositoryPost.Table;

            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.Title.Contains(title));

            if (!string.IsNullOrEmpty(body))
                query = query.Where(x => x.Body.Contains(body));

            if (!string.IsNullOrEmpty(tags))
                query = query.Where(x => x.Tags.Contains(tags));

            return new PagingResult<Post>(query, pageIndex, pageSize);
        }
    }
}