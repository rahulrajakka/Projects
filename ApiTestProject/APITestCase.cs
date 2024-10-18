using System;
using System.Net;
using RestSharp;
using Xunit;

public class ApiTests
{
    private readonly RestClient _client;

    public ApiTests()
    {
        _client = new RestClient("https://jsonplaceholder.typicode.com");
    }

    // GET /posts
    [Fact]
    public void GetAllPosts_ShouldReturn200OK()
    {
        var request = new RestRequest("posts", Method.Get);
        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    // POST /posts
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

        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    // PUT /posts/{postId}
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

        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    // DELETE /posts/{postId}
    [Fact]
    public void DeletePost_ShouldReturn200OK()
    {
        var request = new RestRequest("posts/1", Method.Delete);
        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    // POST /posts/{postId}/comments
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

        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    // GET /comments?postId={postId}
    [Fact]
    public void GetCommentsForPost_ShouldReturn200OK()
    {
        var request = new RestRequest("comments", Method.Get);
        request.AddParameter("postId", 1);

        var response = _client.Execute(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
