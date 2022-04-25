using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GithubReviewCommentFetcher
{
    public class GithubPRCommentFetcher
    {
        private HttpClient _client;
        public GithubPRCommentFetcher()
        {
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri("https://api.github.com");
            this._client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this._client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("RPLP", "1"));
        }
        
        public async Task<List<Comment>> GetPullRequestCommentsAsync(string p_owner, string p_repository)
        {
            List<Comment> comments = new List<Comment>();

            string content = GetPullRequestCommentsJSONStringAsync(p_owner, p_repository).Result;

            var jsonComments = JArray.Parse(
                GetPullRequestCommentsJSONStringAsync(p_owner, p_repository).Result);

            foreach (var comment in jsonComments)
            {
                comments.Add(new Comment
                {
                    Username = comment["user"]["login"].ToString(),
                    Diff_Hunk = comment["diff_hunk"].ToString(),
                    Position = Convert.ToInt32(comment["position"].ToString()),
                    Body = comment["body"].ToString(),
                    Path = comment["path"].ToString(),
                    PullRequestURL = comment["url"].ToString()
                });
            }

            return comments;
        }

        public async Task<string> GetRepositoryIssueCommentsJSONStringAsync(string p_owner, string p_repository)
        {
            return await this._client.GetAsync($"/repos/{p_owner}/{p_repository}/issues/comments")
                .Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPullRequestReviewsJSONStringAsync(string p_owner, string p_repository, int p_pullNumber)
        {
            return await this._client.GetAsync($"/repos/{p_owner}/{p_repository}/pulls/{p_pullNumber}/reviews")
                .Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPullRequestCommentsJSONStringAsync(string p_owner, string p_repository)
        {
            return await this._client.GetAsync($"/repos/{p_owner}/{p_repository}/pulls/comments")
                .Result.Content.ReadAsStringAsync();
        }
    }
}
