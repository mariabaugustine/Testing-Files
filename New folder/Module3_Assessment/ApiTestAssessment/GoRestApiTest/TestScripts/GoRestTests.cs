using GoRestApiTest.HelperClass;
using GoRestApiTest.Utilities;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoRestApiTest.TestScripts
{
    public class GoRestTests:CoreCodes
    {
        private readonly object response;

        public RestRequest request { get; private set; }

        [Test]
        [Category("Get")]//Grouping the test based on the type of request
        [Order(1)]
        public void GetAllUserDetails()
        {
            test = extent.CreateTest("Get All User Test");
            Log.Information("Get all user test");
            var GetAllUserRequest = new RestRequest("", Method.Get);//Get method added
            var GetAllUserResponse = client.Execute(GetAllUserRequest);

            try
            {
                Assert.That(GetAllUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));//verify the status code
                Log.Information($"API Response: {GetAllUserResponse.Content}");

                List<ResponseDetails> allUsers = JsonConvert.DeserializeObject<List<ResponseDetails>>(GetAllUserResponse.Content);
                Log.Information("All user details returned");
                Assert.NotNull(allUsers);//verify the response

                Log.Information("Get All User test passed");

                test.Pass("Get All User test passed");
            }
            catch (AssertionException)
            {
                test.Fail("Get All User test failed");
            }

        }
        [Test]
        [Category("POST")]//Grouping the test based on the type of request
        [Order(2)]
        public void PostUserDetails() 
        {
            test = extent.CreateTest("Create User Test");
            Log.Information("Create User Test");
            string bearerToken = "85fb693e38b58132cff15199acb29649e76c6e9f7b8671d4cedc611853bb9537";
            var CreateUserRequest = new RestRequest("", Method.Post);//Http method added
            CreateUserRequest.AddHeader("Content-Type", "application/json");//request header added
            CreateUserRequest.AddHeader("Authorization", $"Bearer {bearerToken}");
            CreateUserRequest.AddJsonBody(new
            {
                name = "Reshma",
                email = "reshma@gmail.com",
                gender = "female",
                status = "active"
            });
            var CreateUserResponse = client.Execute(CreateUserRequest);

            try
            {
                Assert.That(CreateUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
                Log.Information($"API Response: {CreateUserResponse.Content}");
                var userDetails = JsonConvert.DeserializeObject<ResponseDetails>(CreateUserResponse.Content);
                Assert.NotNull(userDetails);
                Log.Information("User created and details returned");
                Assert.That(userDetails.Name, Is.EqualTo("reshma"));//verify the response
                Log.Information($"User Name matches ");
                Assert.That(userDetails.Email, Is.EqualTo("reshma@gmail.com"));
                Log.Information($"User Email matches");
                Assert.That(userDetails.Gender, Is.EqualTo("female"));
                Log.Information($"User Gender matches");
                Assert.That(userDetails.Status, Is.EqualTo("active"));
                Log.Information($"User Status matches");

                Log.Information("Create User test passed");

                test.Pass("Create User Test passed");
            }
            catch (AssertionException)
            {
                test.Fail("Create User test failed");
            }
        }
        [Test]
        [Category("PUT")]
        [Order(3)]
        [TestCase(5838973)]//Parameeterization
        public void UpdateUserDetails(int userId)
        {
            test = extent.CreateTest("Update User Test");
            Log.Information($"Updated user details: {userId}");
            string bearerToken = "85fb693e38b58132cff15199acb29649e76c6e9f7b8671d4cedc611853bb9537";
            var updateUserRequest = new RestRequest("/"+userId, Method.Put);
            updateUserRequest.AddHeader("Content-Type", "application/json");//Request header
            updateUserRequest.AddHeader("Authorization",$"Bearer { bearerToken}");
            updateUserRequest.AddJsonBody(new
            {
                name = "adithya",
                email = "adithya@gmail.com",
                gender = "female",
                status = "active"
            });
            var updateUserResponse = client.Execute(updateUserRequest);
            try
            {
                Assert.That(updateUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));//Assertion
                Log.Information($"Api Response:{updateUserResponse.Content}");
                var details = JsonConvert.DeserializeObject<ResponseDetails>(updateUserResponse.Content);//Deserialization
                Assert.NotNull(details);
                Log.Information("User Details Updated");
                Assert.That(details.Name, Is.EqualTo("adithya"));//Response validation
                Log.Information("User name matches");
                Assert.That(details.Email, Is.EqualTo("adithya@gmail.com"));
                Log.Information("User email matches");
                Log.Information("Update User Test Passed");
                test.Pass("Update User Test Passed");


            }
            catch (AssertionException)
            {
                test.Fail("Update User Test Failed");
            }
        }
        [Test]
        [Order(4)]
        [Category("Delete")]
        [TestCase(5838972)]
        public void DeleteUser(int userId)
        {
            test = extent.CreateTest("Delete User Test");
            Log.Information("Delete User Test");
            string bearerToken = "85fb693e38b58132cff15199acb29649e76c6e9f7b8671d4cedc611853bb9537";
            var request = new RestRequest("/"+userId, Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));
                var data = JsonConvert.DeserializeObject<ResponseDetails>(response.Content);
                Assert.IsNull(data);//Response validation
                Log.Information("Delet Test Passed");
                test.Pass("Delete User Test Passed");

            }
            catch (AssertionException)
            {
                test.Fail("Delete user Test");
            }
        }

        [Test]
        [Order(5)]
        [Category("Get")]
        [TestCase(5838978)]
        public void GetSingleUser(int userId)
        {
            test = extent.CreateTest("Get Single User Test");
            Log.Information("Get single user test");
            var GetSingleUserRequest = new RestRequest("/"+userId, Method.Get);
            var GetSingleUserResponse = client.Execute(GetSingleUserRequest);
            try
            {
                Assert.That(GetSingleUserResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response: {GetSingleUserResponse.Content}");

                var users = JsonConvert.DeserializeObject<ResponseDetails>(GetSingleUserResponse.Content);
                Log.Information($"Api Response:{GetSingleUserResponse.Content}");
                Log.Information("Single user details returned");
                Assert.NotNull(users);

                Log.Information("Get single User test passed");

                test.Pass("Get single User test passed");
            }
            catch (AssertionException)
            {
                test.Fail("Get single User test failed");
            }
        }
    }
}
