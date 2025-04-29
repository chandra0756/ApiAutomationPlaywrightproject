using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;





namespace ApiAutomationPlaywrightproject
{
    public class Tests : PlaywrightTest
    {
        private IAPIRequestContext Request = null;

        [Test]
        public async Task Getusers()
        {
            Request = await Playwright.APIRequest.NewContextAsync();
            var response = await Request.GetAsync(@"http://localhost:3000/users");
            var responseData = await response.JsonAsync();

            Assert.That(response.Ok);
            Assert.That(response.StatusText.ToString(), Is.EqualTo("OK"));
            Assert.That(response.Status.ToString(), Is.EqualTo("200"));

            Console.WriteLine($"Status code: {response.Status}");
            Console.WriteLine($"Status Text :{response.StatusText}");
            Console.WriteLine($"Status text :{responseData}");

        }
        [Test]
        public async Task Postmethod()
        {

            var data = new Dictionary<string, string>();
            data.Add("id", "5");
            data.Add("Firstname", "laptop");
            data.Add("Lastname", "Dell");
            data.Add("subjetId", "5");

            Request = await Playwright.APIRequest.NewContextAsync();
            var response = await Request.PostAsync(@"http://localhost:3000/users", new() { DataObject = data });//this is additional parameter for post method
            var responseData = await response.JsonAsync();


            Assert.That(response.Ok);
            Assert.That(response.StatusText.ToString(), Is.EqualTo("Created"));
            Assert.That(response.Status.ToString(), Is.EqualTo("201"));

            Console.WriteLine($"Status code: {response.Status}");
            Console.WriteLine($"Status Text :{response.StatusText}");
            Console.WriteLine($"Status text :{responseData}");

        }
        [Test]
        public async Task Putmethod()
        {

            var data = new Dictionary<string, string>();
            data.Add("id", "5");
            data.Add("Firstname", "laptop is updated");
            data.Add("Lastname", "Dell");
            data.Add("subjetId", "1");

            Request = await Playwright.APIRequest.NewContextAsync();
            var response = await Request.PutAsync(@"http://localhost:3000/users/5", new() { DataObject = data });//this is additional parameter for post method
            var responseData = await response.JsonAsync();

            Assert.That(response.Ok);
            Assert.That(response.StatusText.ToString(), Is.EqualTo("OK"));
            Assert.That(response.Status.ToString(), Is.EqualTo("200"));

            Console.WriteLine($"Status code: {response.Status}");
            Console.WriteLine($"Status Text :{response.StatusText}");
            Console.WriteLine($"Status text :{responseData}");


        }
        [Test]
        public async Task Patchmathod()
        {
            var data = new Dictionary<string, string>();
           
            data.Add("Firstname", "Chandu");
           
            Request = await Playwright.APIRequest.NewContextAsync();
            var response = await Request.PatchAsync(@"http://localhost:3000/users/4", new() { DataObject = data });//this is additional parameter for post method
            var responseData = await response.JsonAsync();

            Assert.That(response.Ok);
            Assert.That(response.StatusText.ToString(), Is.EqualTo("OK"));
            Assert.That(response.Status.ToString(), Is.EqualTo("200"));

            Console.WriteLine($"Status code: {response.Status}");
            Console.WriteLine($"Status Text :{response.StatusText}");
            Console.WriteLine($"Status text :{responseData}");


        }
        [Test]
        public async Task Deletemethod()
        {
            Request = await Playwright.APIRequest.NewContextAsync();
            var response = await Request.DeleteAsync(@"http://localhost:3000/users/5");//this is additional parameter for post method
            var responseData = await response.JsonAsync();

            Assert.That(response.Ok);
            Assert.That(response.StatusText.ToString(), Is.EqualTo("OK"));
            Assert.That(response.Status.ToString(), Is.EqualTo("200"));

            Console.WriteLine($"Status code: {response.Status}");
            Console.WriteLine($"Status Text :{response.StatusText}");
            Console.WriteLine($"Status text :{responseData}");

        }

    }


}