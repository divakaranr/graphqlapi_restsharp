using RestSharp;

namespace GraphQLusingRestSharp
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}
        private RestClient client;
        private RestRequest request;
        private string restUrl = "https://spacex-production.up.railway.app/";

        [Test]
        public void Test1()
        {
            var query1= @"query{
  launchesPast(limit: 10) {
    mission_name
    launch_date_local
    launch_site {
      site_name_long
    }
    links {
      article_link
      video_link
    }
    rocket {
      rocket_name
    }
  }
}";
            client = new RestClient();
            request = new RestRequest()
            {
                Method = Method.Post,
                Resource=restUrl,

            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new  { query= query1 });
            var response= client.Post(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
           // Console.WriteLine(response.ResponseStatus.ToString().Contains("200"));


            //Assert.Pass();
        }
    }
}