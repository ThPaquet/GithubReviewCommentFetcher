using GithubReviewCommentFetcher;
using Newtonsoft.Json;
using System.Net.Http.Headers;

GithubPRCommentFetcher fetcher = new GithubPRCommentFetcher();

List<Comment> comments = await fetcher.GetPullRequestCommentsAsync("ThPaquet", "GithubReviewCommentFetcher");
comments.ForEach(comment => Console.WriteLine(comment));

//string commentsJson = fetcher.GetRepositoryIssueCommentsJSONStringAsync("ThPaquet", "GithubReviewCommentFetcher").Result;
