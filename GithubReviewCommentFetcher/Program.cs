HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://api.github.com");
client.DefaultRequestHeaders.Add("Accept", "application/json");

List<string> comments = new List<string>();

comments.ForEach(comment => Console.WriteLine(comment));
