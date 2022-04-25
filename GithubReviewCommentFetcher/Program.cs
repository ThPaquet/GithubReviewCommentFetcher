using GithubReviewCommentFetcher;
using Newtonsoft.Json;
using System.Net.Http.Headers;

GithubPRCommentFetcher fetcher = new GithubPRCommentFetcher();

//List<Comment> comments = await fetcher.GetPullRequestCommentsAsync("ThPaquet", "GithubReviewCommentFetcher");
//comments.ForEach(comment => Console.WriteLine(comment));

//List<Review> reviews = await fetcher.GetPullRequestReviewCommentsAsync("ThPaquet", "GithubReviewCommentFetcher", 1);
//reviews.ForEach(review => Console.WriteLine(review));

List<Issue> issues = await fetcher.GetPullRequestIssueAsync("ThPaquet", "GithubReviewCommentFetcher");
issues.ForEach(issue => Console.WriteLine(issue));
