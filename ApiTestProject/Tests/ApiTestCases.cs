using System.Net;
using RestSharp;
using Xunit;
using ApiTestProject.Methods;  // Import the methods

namespace ApiTestProject.Tests
{
    public class ApiTestCases
    {
        private readonly ApiMethods _apiMethods;

        public ApiTestCases()
        {
            _apiMethods = new ApiMethods();
        }

        // 1. GET /posts
        [Fact]
        public void GetAllPosts_ShouldReturn200OK()
        {
            var request = new RestRequest("posts", Method.Get);
            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.OK, "GetAllPosts_ShouldReturn200OK");
        }

        // 2. POST /posts
        [Fact]
        public void CreatePost_ShouldReturn201Created()
        {
            var request = new RestRequest("posts", Method.Post);
            request.AddJsonBody(new
            {
                title = "foo",
                body = "bar",
                userId = 1
            });

            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.Created, "CreatePost_ShouldReturn201Created");
        }

        // 3. PUT /posts/{postId}
        [Fact]
        public void UpdatePost_ShouldReturn200OK()
        {
            var request = new RestRequest("posts/1", Method.Put);
            request.AddJsonBody(new
            {
                id = 1,
                title = "updated title",
                body = "updated body",
                userId = 1
            });

            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.OK, "UpdatePost_ShouldReturn200OK");
        }

        // 4. DELETE /posts/{postId}
        [Fact]
        public void DeletePost_ShouldReturn200OK()
        {
            var request = new RestRequest("posts/1", Method.Delete);
            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.OK, "DeletePost_ShouldReturn200OK");
        }

        // 5. POST /posts/{postId}/comments
        [Fact]
        public void CreateComment_ShouldReturn201Created()
        {
            var request = new RestRequest("posts/1/comments", Method.Post);
            request.AddJsonBody(new
            {
                name = "Test Comment",
                email = "test@example.com",
                body = "This is a test comment"
            });

            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.Created, "CreateComment_ShouldReturn201Created");
        }

        // 6. GET /comments?postId={postId}
        [Fact]
        public void GetCommentsForPost_ShouldReturn200OK()
        {
            var request = new RestRequest("comments", Method.Get);
            request.AddParameter("postId", 1);

            _apiMethods.SendRequestAndAssertStatusCode(request, HttpStatusCode.OK, "GetCommentsForPost_ShouldReturn200OK");
        }
    }
}
